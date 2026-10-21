using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Anthropic.Core.Telemetry;

namespace Anthropic.Tests.Core.Telemetry;

public class ContentTest
{
    /// <summary>
    /// The <c>messages</c> of a request: <paramref name="count"/> of them whose content is their
    /// number and then <paramref name="text"/>, then one for each of <paramref name="more"/>, with
    /// alternating roles.
    /// </summary>
    static JsonElement Conversation(int count, string text, params string[] more)
    {
        var messages = new JsonArray();
        foreach (
            var content in Enumerable.Range(1, count).Select(index => index + text).Concat(more)
        )
        {
            messages.Add(
                new JsonObject
                {
                    ["role"] = messages.Count % 2 == 0 ? "user" : "assistant",
                    ["content"] = content,
                }
            );
        }
        return Parse(messages.ToJsonString());
    }

    /// <summary>
    /// The parts of an output message, one text part for each of <paramref name="texts"/>.
    /// </summary>
    static JsonArray Output(params string[] texts)
    {
        var parts = new JsonArray();
        foreach (var text in texts)
        {
            parts.Add(new JsonObject { ["type"] = "text", ["content"] = text });
        }
        return parts;
    }

    static JsonElement Parse(string json) => JsonDocument.Parse(json).RootElement.Clone();

    static JsonElement Instructions(string text) => Parse(JsonSerializer.Serialize(text));

    /// <summary>
    /// The span with the content of a request, as a Messages create method writes it when it
    /// starts, and then of its response, when there is an <paramref name="output"/>.
    /// </summary>
    static Activity Record(
        JsonElement? system,
        JsonElement messages,
        JsonArray? output,
        int limit = Content.ContentLimit,
        JsonElement? stopSequences = null
    )
    {
        var activity = new Activity("test");
        var request = Content.SetRequestContent(activity, system, messages, stopSequences, limit);
        if (output != null)
        {
            Content.SetResponseContent(activity, request, output);
        }
        return activity;
    }

    static string Tag(Activity activity, string name) =>
        Assert.IsType<string>(activity.GetTagItem(name));

    static JsonElement Input(Activity activity) => Parse(Tag(activity, "gen_ai.input.messages"));

    static JsonElement OutputParts(Activity activity) =>
        Parse(Tag(activity, "gen_ai.output.messages"))[0].GetProperty("parts");

    static readonly string[] ContentAttributes =
    [
        "gen_ai.system_instructions",
        "gen_ai.input.messages",
        "gen_ai.output.messages",
    ];

    /// <summary>
    /// The bytes of UTF-8 of the content attributes of <paramref name="activity"/>, which is what
    /// an exporter writes of them.
    /// </summary>
    static int Size(Activity activity) =>
        ContentAttributes
            .Select(name =>
                activity.GetTagItem(name) is string json ? Encoding.UTF8.GetByteCount(json) : 0
            )
            .Sum();

    static string Text(JsonElement message) =>
        message.GetProperty("parts")[0].GetProperty("content").GetString()!;

    [Fact]
    public void Content_UnderTheLimit_IsTheWholeContent()
    {
        var text = new string('x', 1000);
        var activity = Record(Instructions("be brief"), Conversation(4, text), Output("a", "b"));

        Assert.Equal(
            """[{"type":"text","content":"be brief"}]""",
            Tag(activity, "gen_ai.system_instructions")
        );
        var input = Input(activity);
        Assert.Equal(4, input.GetArrayLength());
        Assert.Equal("user", input[0].GetProperty("role").GetString());
        Assert.Equal("1" + text, Text(input[0]));
        Assert.Equal("assistant", input[3].GetProperty("role").GetString());
        Assert.Equal(
            """[{"role":"assistant","parts":[{"type":"text","content":"a"},{"type":"text","content":"b"}]}]""",
            Tag(activity, "gen_ai.output.messages")
        );
        Assert.Null(activity.GetTagItem("anthropic.content.truncated"));

        // A limit of exactly the size keeps everything.
        var exact = Record(
            Instructions("be brief"),
            Conversation(4, text),
            Output("a", "b"),
            limit: Size(activity)
        );
        Assert.Equal(Size(activity), Size(exact));
        Assert.Null(exact.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_ToolResultOverTheLimit_IsRemovedWholeAndItsMessageStays()
    {
        var big = new string('x', 2000);
        // The size of a tool result counts the fields that its blocks keep: a text block's
        // citations, and a search result block's content.
        var messages = Parse(
            $$"""
            [
              {"role":"user","content":[{"type":"tool_result","tool_use_id":"toolu_0","content":[
                {"type":"text","text":"sunny","citations":[{"type":"char_location","cited_text":"{{big}}","document_index":0,"document_title":null,"start_char_index":0,"end_char_index":2000}]},
                {"type":"search_result","source":"https://example.com","title":"Weather","content":[{"type":"text","text":"{{big}}"}]}
              ]}]},
              {"role":"assistant","content":"ok"}
            ]
            """
        );

        var whole = Record(system: null, messages, output: null);
        Assert.Equal(2, Input(whole).GetArrayLength());
        Assert.True(Size(whole) > 4000);
        Assert.Null(whole.GetTagItem("anthropic.content.truncated"));

        // The response of a tool call is never reduced block by block: the part goes whole, and
        // its message stays, without parts.
        var activity = Record(system: null, messages, output: null, limit: 3000);
        Assert.Equal(
            """[{"role":"user","parts":[]},{"role":"assistant","parts":[{"type":"text","content":"ok"}]}]""",
            Tag(activity, "gen_ai.input.messages")
        );
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Theory]
    [InlineData("tool_use", "", "null")]
    [InlineData("tool_use", ",\"input\":null", "null")]
    [InlineData("tool_use", ",\"input\":\"not an object\"", "\"not an object\"")]
    [InlineData("server_tool_use", ",\"input\":[1,2]", "[1,2]")]
    [InlineData("mcp_tool_use", ",\"input\":7", "7")]
    public void Content_ToolUseWithoutAnObjectForItsInput_KeepsTheOtherContent(
        string type,
        string input,
        string arguments
    )
    {
        var messages = Parse(
            $$"""
            [
              {"role":"user","content":"Weather?"},
              {"role":"assistant","content":[{"type":"{{type}}","id":"toolu_1","name":"lookup"{{input}}}]}
            ]
            """
        );

        var activity = Record(system: null, messages, Output("done"));

        var call = Input(activity)[1].GetProperty("parts")[0];
        Assert.Equal("tool_call", call.GetProperty("type").GetString());
        Assert.Equal("lookup", call.GetProperty("name").GetString());
        Assert.Equal(arguments, call.GetProperty("arguments").GetRawText());
        Assert.Equal("Weather?", Text(Input(activity)[0]));
        Assert.Equal("done", OutputParts(activity)[0].GetProperty("content").GetString());
    }

    [Fact]
    public void Content_OverTheLimit_RemovesTheOldestPartsAndHoldsNoMarker()
    {
        var big = new string('x', 225_000);
        var activity = Record(system: null, Conversation(4, big, "5"), output: null);

        // Four messages of 225 k characters exceed the limit; removing the part of the oldest is
        // enough. Its message stays, without parts.
        var json = Tag(activity, "gen_ai.input.messages");
        var input = Parse(json);
        Assert.Equal(5, input.GetArrayLength());
        Assert.Equal("user", input[0].GetProperty("role").GetString());
        Assert.Equal(0, input[0].GetProperty("parts").GetArrayLength());
        Assert.Equal("2" + big, Text(input[1]));
        Assert.Equal("5", Text(input[4]));
        Assert.All(
            input.EnumerateArray().Skip(1),
            message => Assert.Equal(1, message.GetProperty("parts").GetArrayLength())
        );
        Assert.DoesNotContain("truncated", json);
        Assert.DoesNotContain("omitted_messages", json);
        Assert.True(json.Length <= Content.ContentLimit);
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
        Assert.Null(activity.GetTagItem("gen_ai.output.messages"));
    }

    [Fact]
    public void Content_RemovesPartsAndNotWholeMessages()
    {
        var messages = Parse(
            """
            [
              {"role":"user","content":[
                {"type":"text","text":"first"},
                {"type":"image","source":{"type":"base64","media_type":"image/png","data":"AAAA"}},
                {"type":"text","text":"third"}
              ]},
              {"role":"assistant","content":"newest"}
            ]
            """
        );
        var whole = Size(Record(system: null, messages, output: null));

        // One character over the limit takes the first part of the first message, and the other
        // two stay in it.
        var activity = Record(system: null, messages, output: null, limit: whole - 1);

        Assert.Equal(
            """[{"role":"user","parts":[{"type":"anthropic_image"},{"type":"text","content":"third"}]},{"role":"assistant","parts":[{"type":"text","content":"newest"}]}]""",
            Tag(activity, "gen_ai.input.messages")
        );
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_WritesTextAsItIsTypedApartFromWhatJsonAndDotNetEscape()
    {
        // Quotes, a backslash, control characters, markup, non-ASCII letters, a space that is not
        // U+0020, and a character outside the basic plane, in a message that is a string, in a
        // text block, and in the system instructions.
        var text =
            "say \"hi\" \\ back\n\ttab <b>&amp;</b> 'x' + ` caf\u00e9 \u6f22\u5b57\u3000\ud83d\ude00 \u0001";
        var messages = Parse(
            new JsonArray(
                new JsonObject { ["role"] = "user", ["content"] = text },
                new JsonObject
                {
                    ["role"] = "assistant",
                    ["content"] = new JsonArray(
                        new JsonObject { ["type"] = "text", ["text"] = text }
                    ),
                }
            ).ToJsonString()
        );

        var activity = Record(Instructions(text), messages, output: null);

        var part =
            "{\"type\":\"text\",\"content\":\"say \\\"hi\\\" \\\\ back\\n\\ttab <b>&amp;</b> 'x' + ` "
            + "caf\u00e9 \u6f22\u5b57\\u3000\\uD83D\\uDE00 \\u0001\"}";
        Assert.Equal("[" + part + "]", Tag(activity, "gen_ai.system_instructions"));
        Assert.Equal(
            "[{\"role\":\"user\",\"parts\":["
                + part
                + "]},{\"role\":\"assistant\",\"parts\":["
                + part
                + "]}]",
            Tag(activity, "gen_ai.input.messages")
        );
        Assert.Equal(text, Text(Input(activity)[1]));
    }

    [Fact]
    public void Content_EveryStringOfTheJson_HasNonAsciiCharactersAsThemselves()
    {
        // In a role, an ID, a name, a key and a value, and not only in the text of a text part.
        var text = "caf\u00e9 5\u20ac \u65e5\u672c \ud83d\ude00";
        var system = Parse(
            new JsonArray(new JsonObject { ["type"] = "text", ["text"] = text }).ToJsonString()
        );
        var blocks = Parse(
            new JsonArray(
                new JsonObject { ["type"] = "text", ["text"] = text },
                new JsonObject
                {
                    ["type"] = "tool_use",
                    ["id"] = text,
                    ["name"] = text,
                    ["input"] = new JsonObject { [text] = text },
                },
                new JsonObject
                {
                    ["type"] = "tool_result",
                    ["tool_use_id"] = text,
                    ["content"] = text,
                }
            ).ToJsonString()
        );
        var messages = Parse(
            new JsonArray(
                new JsonObject { ["role"] = text, ["content"] = text },
                new JsonObject
                {
                    ["role"] = "user",
                    ["content"] = JsonNode.Parse(blocks.GetRawText()),
                }
            ).ToJsonString()
        );
        // The text as the API sends it, not escaped, and as a response that was read whole or
        // streamed holds it, a string.
        var raw = Parse("[{\"type\":\"text\",\"text\":\"" + text + "\"}]");
        var output = Content.Parts(raw);
        output.Add(new JsonObject { ["type"] = "text", ["content"] = text });

        var activity = Record(system, messages, output);
        var tool = new Activity("test");
        Content.SetToolResultContent(tool, Content.ToolResultContent(blocks));

        foreach (
            var json in ContentAttributes
                .Select(name => Tag(activity, name))
                .Append(Tag(tool, "anthropic.tool_result.content"))
        )
        {
            Assert.Contains("caf\u00e9 5\u20ac \u65e5\u672c \\uD83D\\uDE00", json);
            Assert.DoesNotContain("\\u00E9", json);
            Assert.DoesNotContain("\\u20AC", json);
            Assert.DoesNotContain("\\u65E5", json);
        }
    }

    [Fact]
    public void Content_MeasuresTheSerializedString()
    {
        var messages = Conversation(3, new string('\u20ac', 1000));
        var whole = Size(Record(system: null, messages, output: null));

        // One byte under the whole size removes the part of the oldest message, and no more.
        var activity = Record(system: null, messages, output: null, limit: whole - 1);

        var input = Input(activity);
        Assert.Equal(3, input.GetArrayLength());
        Assert.Equal(0, input[0].GetProperty("parts").GetArrayLength());
        Assert.Equal(1, input[1].GetProperty("parts").GetArrayLength());
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_MeasuresTheRoleOfAMessageInBytesOfUtf8()
    {
        var messages = Parse(
            """[{"role":"é","content":"first"},{"role":"é","content":"second"}]"""
        );
        var whole = Size(Record(system: null, messages, output: null));

        var activity = Record(system: null, messages, output: null, limit: whole - 1);

        Assert.True(Size(activity) < whole);
        Assert.Equal(0, Input(activity)[0].GetProperty("parts").GetArrayLength());
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_TheOtherAttributesCountTowardTheLimit()
    {
        var text = new string('x', 100);
        var messages = Conversation(3, text);
        var inputOnly = Size(Record(system: null, messages, output: null));

        // The input fits in this limit alone, but not with the system instructions and the
        // output: the system instructions go first, then the part of the oldest input message,
        // and the output stays whole.
        var activity = Record(
            Instructions(new string('s', 50)),
            messages,
            Output(new string('y', 50)),
            limit: inputOnly + 10
        );

        Assert.Equal("[]", Tag(activity, "gen_ai.system_instructions"));
        var input = Input(activity);
        Assert.Equal(3, input.GetArrayLength());
        Assert.Equal(0, input[0].GetProperty("parts").GetArrayLength());
        Assert.Equal("2" + text, Text(input[1]));
        Assert.Equal("3" + text, Text(input[2]));
        Assert.Equal(
            new string('y', 50),
            OutputParts(activity)[0].GetProperty("content").GetString()
        );
        Assert.True(Size(activity) <= inputOnly + 10);
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_StillOverWithNoRequestPartLeft_RemovesOutputPartsFromTheStart()
    {
        var big = new string('y', 225_000);
        var activity = Record(
            Instructions("be brief"),
            Conversation(2, "small", new string('x', 150_000)),
            Output("1" + big, "2" + big, "3" + big, "4" + big)
        );

        // The output alone is over the limit: every part of the system instructions and of the
        // input goes, the emptied list and messages stay in their attributes, and then the first
        // output part goes, whole. The newest parts stay whole.
        Assert.Equal("[]", Tag(activity, "gen_ai.system_instructions"));
        Assert.Equal(
            """[{"role":"user","parts":[]},{"role":"assistant","parts":[]},{"role":"user","parts":[]}]""",
            Tag(activity, "gen_ai.input.messages")
        );
        var parts = OutputParts(activity);
        Assert.Equal(3, parts.GetArrayLength());
        Assert.Equal("2" + big, parts[0].GetProperty("content").GetString());
        Assert.Equal("3" + big, parts[1].GetProperty("content").GetString());
        Assert.Equal("4" + big, parts[2].GetProperty("content").GetString());
        Assert.DoesNotContain("truncated", Tag(activity, "gen_ai.output.messages"));
        Assert.True(Size(activity) <= Content.ContentLimit);
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_RemovesAReasoningPartWholeAlsoWhenItIsTheLastPart()
    {
        var thinking = new string('t', Content.ContentLimit + 10);
        var first = new JsonArray(
            new JsonObject { ["type"] = "reasoning", ["content"] = thinking },
            new JsonObject { ["type"] = "text", ["content"] = "Hi" }
        );
        var activity = Record(system: null, Parse("[]"), first);
        Assert.Equal(
            """[{"role":"assistant","parts":[{"type":"text","content":"Hi"}]}]""",
            Tag(activity, "gen_ai.output.messages")
        );
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));

        // Only the text of a text part is cut: a reasoning part that is the one part left goes
        // whole, and its message stays, without parts.
        var last = new JsonArray(
            new JsonObject { ["type"] = "text", ["content"] = "Hi" },
            new JsonObject { ["type"] = "reasoning", ["content"] = thinking }
        );
        activity = Record(system: null, Parse("[]"), last);
        Assert.Equal(
            """[{"role":"assistant","parts":[]}]""",
            Tag(activity, "gen_ai.output.messages")
        );
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_CutsTheTextOfTheLastPartOnceEveryPartBeforeItIsRemoved()
    {
        var call = new JsonObject
        {
            ["type"] = "tool_call",
            ["id"] = "toolu_1",
            ["name"] = "get_weather",
            ["arguments"] = new JsonObject { ["city"] = "Paris" },
        };
        var output = new JsonArray(call);
        output.Add(new JsonObject { ["type"] = "text", ["content"] = new string('a', 100) });
        output.Add(new JsonObject { ["type"] = "text", ["content"] = new string('b', 100) });
        var whole = Size(Record(system: null, Parse("[]"), output));
        var text = new JsonObject { ["type"] = "text", ["content"] = new string('a', 100) }
            .ToJsonString()
            .Length;

        // One character over the limit takes the whole tool call, the first part, and nothing of
        // the texts after it.
        var one = OutputParts(Record(system: null, Parse("[]"), output, limit: whole - 1));
        Assert.Equal(2, one.GetArrayLength());
        Assert.Equal(new string('a', 100), one[0].GetProperty("content").GetString());
        Assert.Equal(new string('b', 100), one[1].GetProperty("content").GetString());

        // Ten more than the tool call, the first text and their commas take that text whole too,
        // and then the end of the last text, which is the one part left.
        var limit = whole - call.ToJsonString().Length - 1 - text - 1 - 10;
        var activity = Record(system: null, Parse("[]"), output, limit);
        var parts = OutputParts(activity);
        Assert.Equal(1, parts.GetArrayLength());
        Assert.Equal(new string('b', 90), parts[0].GetProperty("content").GetString());
        Assert.Equal(limit, Size(activity));
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_RemovesTheLastPartWholeWhenItIsNotText()
    {
        var call = new JsonObject
        {
            ["type"] = "tool_call",
            ["id"] = "toolu_1",
            ["name"] = "write_file",
            ["arguments"] = new JsonObject { ["text"] = new string('w', 200) },
        };
        var output = Output("before");
        output.Add(call);

        var activity = Record(system: null, Conversation(1, "hi"), output, limit: 150);

        Assert.Equal("""[{"role":"user","parts":[]}]""", Tag(activity, "gen_ai.input.messages"));
        Assert.Equal(
            """[{"role":"assistant","parts":[]}]""",
            Tag(activity, "gen_ai.output.messages")
        );
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_CutsATextBetweenTwoCharactersToTheLongestStartThatFits()
    {
        // Characters that the JSON escapes, in two characters or in six, characters that it holds
        // as themselves in two bytes and in three, a character outside the basic plane, which is
        // two in the text and twelve in the JSON, and backslashes before a `u`, which are not the
        // escape of a control character. Every limit is tried, so the last byte that fits falls
        // at each place inside each of them.
        var text = string.Concat(
            Enumerable.Repeat("a\n\"\\\u0001\u00e9\u65e5\u3000\ud83d\ude42\\\\u00e9<", 8)
        );
        // The text arrives escaped, and is written as the encoder writes it.
        var blocks = Parse(
            new JsonArray(new JsonObject { ["type"] = "text", ["text"] = text }).ToJsonString()
        );
        var whole = Size(Record(system: null, Parse("[]"), Content.Parts(blocks)));
        var empty = Size(Record(system: null, Parse("[]"), Output("")));

        for (var limit = empty; limit < whole; limit++)
        {
            var activity = Record(system: null, Parse("[]"), Content.Parts(blocks), limit);

            Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
            Assert.True(Size(activity) <= limit);
            var parts = OutputParts(activity);
            Assert.Equal(1, parts.GetArrayLength());
            var cut = parts[0].GetProperty("content").GetString()!;
            Assert.StartsWith(cut, text, StringComparison.Ordinal);
            Assert.False(cut.Length > 0 && char.IsHighSurrogate(cut[^1]));
            // One more character does not fit.
            var next = cut.Length + (char.IsHighSurrogate(text[cut.Length]) ? 2 : 1);
            Assert.True(
                Size(Record(system: null, Parse("[]"), Output(text.Substring(0, next)))) > limit
            );
        }
    }

    [Fact]
    public void Content_LastTextPartWithNoRoomForAnyOfItsText_StaysWithEmptyContent()
    {
        var empty = Size(Record(system: null, Parse("[]"), Output()));
        var activity = Record(
            system: null,
            Parse("[]"),
            Output("first", "second"),
            limit: empty + 5
        );

        // Not even an empty text part fits. The one part left is a text part, which is cut and
        // never removed: it stays, with no text, and the span is over the limit.
        Assert.Equal(
            """[{"role":"assistant","parts":[{"type":"text","content":""}]}]""",
            Tag(activity, "gen_ai.output.messages")
        );
        Assert.True(Size(activity) > empty + 5);
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));

        // The same for the last part of a request, when the call starts.
        var started = Record(system: null, Conversation(2, "text"), output: null, limit: 10);
        Assert.Equal(
            """[{"role":"user","parts":[]},{"role":"assistant","parts":[{"type":"text","content":""}]}]""",
            Tag(started, "gen_ai.input.messages")
        );
        Assert.Equal(true, started.GetTagItem("anthropic.content.truncated"));

        // A text part that had no text, with no other part, is not reduced.
        var nothing = Record(system: null, Parse("[]"), Output(""), limit: 10);
        Assert.Equal(
            """[{"role":"assistant","parts":[{"type":"text","content":""}]}]""",
            Tag(nothing, "gen_ai.output.messages")
        );
        Assert.Null(nothing.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_OutputPartsStayWhileRemovingInputPartsIsEnough()
    {
        var messages = Conversation(3, new string('x', 100));
        var whole = Size(Record(system: null, messages, Output("a", "b", "c")));

        // Removing the part of the oldest input message is enough, so every output part stays.
        var activity = Record(system: null, messages, Output("a", "b", "c"), limit: whole - 1);

        var input = Input(activity);
        Assert.Equal(3, input.GetArrayLength());
        Assert.Equal(0, input[0].GetProperty("parts").GetArrayLength());
        Assert.Equal(1, input[1].GetProperty("parts").GetArrayLength());
        Assert.Equal(3, OutputParts(activity).GetArrayLength());
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_AnOutputPartThatAloneExceedsTheLimit_IsRemovedUnlessItIsTheLast()
    {
        var huge = new string('y', Content.ContentLimit + 10);
        var activity = Record(system: null, Conversation(1, "hi"), Output(huge, "second", "third"));

        // The first output part alone is over the limit, so the input part and it go, and the
        // parts after it stay whole.
        Assert.Equal("""[{"role":"user","parts":[]}]""", Tag(activity, "gen_ai.input.messages"));
        Assert.Equal(
            """[{"role":"assistant","parts":[{"type":"text","content":"second"},{"type":"text","content":"third"}]}]""",
            Tag(activity, "gen_ai.output.messages")
        );
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));

        // As the last part, it keeps the start that fits.
        var last = Record(system: null, Conversation(1, "hi"), Output("first", huge));
        Assert.Equal("""[{"role":"user","parts":[]}]""", Tag(last, "gen_ai.input.messages"));
        var parts = OutputParts(last);
        Assert.Equal(1, parts.GetArrayLength());
        var kept = parts[0].GetProperty("content").GetString()!;
        Assert.NotEmpty(kept);
        Assert.StartsWith(kept, huge);
        Assert.Equal(Content.ContentLimit, Size(last));
        Assert.Equal(true, last.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_ASingleInputPartOverTheLimit_IsRemovedBeforeAnyOutputPart()
    {
        var huge = new string('x', Content.ContentLimit + 10);
        var activity = Record(system: null, Conversation(0, "", huge), Output("kept"));

        // The message stays in its attribute, without parts, and the output, which now fits,
        // stays whole.
        Assert.Equal("""[{"role":"user","parts":[]}]""", Tag(activity, "gen_ai.input.messages"));
        var parts = OutputParts(activity);
        Assert.Equal(1, parts.GetArrayLength());
        Assert.Equal("kept", parts[0].GetProperty("content").GetString());
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));

        // Without an output it is the last part, after the older messages have lost theirs, and
        // keeps the start that fits.
        var older = Record(system: null, Conversation(2, "small", huge), output: null);
        var input = Input(older);
        Assert.Equal(3, input.GetArrayLength());
        Assert.Equal(0, input[0].GetProperty("parts").GetArrayLength());
        Assert.Equal(0, input[1].GetProperty("parts").GetArrayLength());
        Assert.StartsWith(Text(input[2]), huge);
        Assert.Equal(Content.ContentLimit, Size(older));
        Assert.Null(older.GetTagItem("gen_ai.output.messages"));
        Assert.Equal(true, older.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_SystemInstructionsOverTheLimit_LoseTheirFirstPartsBeforeAnyMessageDoes()
    {
        var huge = new string('s', Content.ContentLimit + 10);
        var system = Parse(
            new JsonArray(
                new JsonObject { ["type"] = "text", ["text"] = huge },
                new JsonObject { ["type"] = "text", ["text"] = "last" }
            ).ToJsonString()
        );
        var activity = Record(system, Conversation(2, "older", "newest"), Output("a", "b"));

        // The first part of the system instructions goes, whole, and then everything fits.
        Assert.Equal(
            """[{"type":"text","content":"last"}]""",
            Tag(activity, "gen_ai.system_instructions")
        );
        Assert.Equal(3, Input(activity).GetArrayLength());
        Assert.All(
            Input(activity).EnumerateArray(),
            message => Assert.Equal(1, message.GetProperty("parts").GetArrayLength())
        );
        Assert.Equal(2, OutputParts(activity).GetArrayLength());
        Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));

        // The same when the call starts, before there is a response.
        var started = Record(system, Conversation(2, "older", "newest"), output: null);
        Assert.Equal(
            """[{"type":"text","content":"last"}]""",
            Tag(started, "gen_ai.system_instructions")
        );
        Assert.Equal("newest", Text(Input(started)[2]));
        Assert.Equal(true, started.GetTagItem("anthropic.content.truncated"));

        // Emptied system instructions stay in their attribute.
        var emptied = Record(Instructions(huge), Conversation(1, "hi"), output: null);
        Assert.Equal("[]", Tag(emptied, "gen_ai.system_instructions"));
        Assert.Equal("1hi", Text(Input(emptied)[0]));
        Assert.Equal(true, emptied.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_Response_IsFitWithAllThePartsOfTheRequestAndNotWithWhatWasLeftOfThem()
    {
        var text = new string('x', 100);
        var messages = Conversation(2, text);
        var whole = Size(Record(system: null, messages, output: null));

        // When the call starts, the last input part is the one part left, and loses the end of
        // its text.
        var started = new Activity("test");
        var request = Content.SetRequestContent(started, null, messages, null, whole - 140);
        var input = Input(started);
        Assert.Equal(0, input[0].GetProperty("parts").GetArrayLength());
        var cut = Text(input[1]);
        Assert.NotEqual("2" + text, cut);
        Assert.StartsWith(cut, "2" + text);
        Assert.Equal(whole - 140, Size(started));

        // With the response it is not the last part any more, and goes whole, as it would had the
        // request and the response been fit together.
        Content.SetResponseContent(started, request, Output("answer"));
        Assert.Equal(
            """[{"role":"user","parts":[]},{"role":"assistant","parts":[]}]""",
            Tag(started, "gen_ai.input.messages")
        );
        Assert.Equal(
            """[{"role":"assistant","parts":[{"type":"text","content":"answer"}]}]""",
            Tag(started, "gen_ai.output.messages")
        );
        Assert.Equal(true, started.GetTagItem("anthropic.content.truncated"));

        // A response without parts leaves it the last part, with the start of its whole text that
        // fits beside the output message.
        var again = new Activity("test");
        request = Content.SetRequestContent(again, null, messages, null, whole - 140);
        Content.SetResponseContent(again, request, Output());
        Assert.StartsWith(Text(Input(again)[1]), cut);
        Assert.Equal(whole - 140, Size(again));
    }

    [Fact]
    public void Content_StopSequences_AreWholeAndCountTowardTheLimit()
    {
        var sequences = Parse("""["END","\n\nHuman:"]""");
        var activity = Record(
            system: null,
            Conversation(2, "text"),
            output: null,
            stopSequences: sequences
        );
        Assert.Equal(
            ["END", "\n\nHuman:"],
            Assert.IsType<string[]>(activity.GetTagItem("gen_ai.request.stop_sequences"))
        );
        Assert.Null(activity.GetTagItem("anthropic.content.truncated"));

        // An empty list, and no list, set nothing.
        var empty = Record(
            system: null,
            Conversation(1, "text"),
            output: null,
            stopSequences: Parse("[]")
        );
        Assert.Null(empty.GetTagItem("gen_ai.request.stop_sequences"));
        Assert.Null(
            Record(system: null, Conversation(1, "text"), output: null)
                .GetTagItem("gen_ai.request.stop_sequences")
        );

        // Strings that fit take room from the rest of the content, and are not reduced themselves.
        var text = new string('x', 100);
        var whole = Size(Record(system: null, Conversation(2, text), output: null));
        var counted = Record(
            system: null,
            Conversation(2, text),
            output: null,
            limit: whole + 5,
            stopSequences: Parse("""["123456"]""")
        );
        Assert.Equal(0, Input(counted)[0].GetProperty("parts").GetArrayLength());
        Assert.Equal("2" + text, Text(Input(counted)[1]));
        Assert.Equal(true, counted.GetTagItem("anthropic.content.truncated"));
    }

    [Fact]
    public void Content_StopSequencesAtTheLimitByThemselves_StayAndLeaveNoRoom()
    {
        // The strings are the limit exactly, which is not over it. They leave no room for any
        // part, and the last part is a tool call, which goes whole.
        string[] sequences = [new string('q', Content.ContentLimit - 1), "r"];
        var output = Output("a");
        output.Add(
            new JsonObject
            {
                ["type"] = "tool_call",
                ["id"] = "toolu_1",
                ["name"] = "f",
                ["arguments"] = new JsonObject(),
            }
        );
        var atTheLimit = Record(
            Instructions("be brief"),
            Conversation(2, "older", "newest"),
            output,
            stopSequences: Parse(JsonSerializer.Serialize(sequences))
        );
        Assert.Equal(
            sequences,
            Assert.IsType<string[]>(atTheLimit.GetTagItem("gen_ai.request.stop_sequences"))
        );
        Assert.Equal(
            """[{"role":"user","parts":[]},{"role":"assistant","parts":[]},{"role":"user","parts":[]}]""",
            Tag(atTheLimit, "gen_ai.input.messages")
        );
        Assert.Equal(
            """[{"role":"assistant","parts":[]}]""",
            Tag(atTheLimit, "gen_ai.output.messages")
        );
        Assert.Equal("[]", Tag(atTheLimit, "gen_ai.system_instructions"));
        Assert.Equal(true, atTheLimit.GetTagItem("anthropic.content.truncated"));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void Content_StopSequencesOverTheLimitByThemselves_AreLeftOutWhole(bool hasResponse)
    {
        // One character over the limit, counted over all the strings.
        string[] sequences = [new string('q', Content.ContentLimit), "r"];
        var messages = Conversation(2, "older", "newest");
        var over = Record(
            Instructions("be brief"),
            messages,
            hasResponse ? Output("a") : null,
            stopSequences: Parse(JsonSerializer.Serialize(sequences))
        );
        Assert.Null(over.GetTagItem("gen_ai.request.stop_sequences"));
        Assert.Equal(true, over.GetTagItem("anthropic.content.truncated"));

        // They count for nothing then: the rest of the content is whole, as it is without them.
        var without = Record(Instructions("be brief"), messages, hasResponse ? Output("a") : null);
        Assert.Null(without.GetTagItem("anthropic.content.truncated"));
        foreach (var name in ContentAttributes)
        {
            Assert.Equal(without.GetTagItem(name), over.GetTagItem(name));
        }
        Assert.Equal(
            """[{"type":"text","content":"be brief"}]""",
            Tag(over, "gen_ai.system_instructions")
        );
        Assert.Equal("newest", Text(Input(over)[2]));

        // And so with a limit that the rest of the content is at exactly.
        var exact = Record(
            Instructions("be brief"),
            messages,
            hasResponse ? Output("a") : null,
            limit: Size(without),
            stopSequences: Parse(
                JsonSerializer.Serialize(new[] { new string('q', Size(without)), "r" })
            )
        );
        Assert.Null(exact.GetTagItem("gen_ai.request.stop_sequences"));
        Assert.Equal(true, exact.GetTagItem("anthropic.content.truncated"));
        Assert.Equal(Size(without), Size(exact));
    }

    [Fact]
    public void Content_StopSequences_AreMeasuredInBytesOfUtf8()
    {
        // Four characters, and nine bytes: three of two and one of three.
        var sequences = Parse("""["\u00e9\u00e9\u00e9","\u20ac"]""");

        // The strings are the limit exactly, in bytes, which is not over it.
        var atTheLimit = Record(system: null, Parse("[]"), output: null, 9, sequences);
        Assert.Equal(
            ["\u00e9\u00e9\u00e9", "\u20ac"],
            Assert.IsType<string[]>(atTheLimit.GetTagItem("gen_ai.request.stop_sequences"))
        );
        Assert.Null(atTheLimit.GetTagItem("anthropic.content.truncated"));

        // One byte over the limit, and four characters under it.
        var over = Record(system: null, Parse("[]"), output: null, 8, sequences);
        Assert.Null(over.GetTagItem("gen_ai.request.stop_sequences"));
        Assert.Equal(true, over.GetTagItem("anthropic.content.truncated"));

        // Strings that fit take their bytes from the rest of the content: with room for five
        // more, two characters of three bytes each are one byte too many, and the oldest part goes.
        var euros = Parse("""["\u20ac\u20ac"]""");
        var text = new string('x', 100);
        var whole = Size(Record(system: null, Conversation(2, text), output: null));
        var fits = Record(
            system: null,
            Conversation(2, text),
            output: null,
            limit: whole + 6,
            stopSequences: euros
        );
        Assert.Equal("1" + text, Text(Input(fits)[0]));
        Assert.Null(fits.GetTagItem("anthropic.content.truncated"));
        var counted = Record(
            system: null,
            Conversation(2, text),
            output: null,
            limit: whole + 5,
            stopSequences: euros
        );
        Assert.Equal(
            ["\u20ac\u20ac"],
            Assert.IsType<string[]>(counted.GetTagItem("gen_ai.request.stop_sequences"))
        );
        Assert.Equal(0, Input(counted)[0].GetProperty("parts").GetArrayLength());
        Assert.Equal("2" + text, Text(Input(counted)[1]));
        Assert.Equal(true, counted.GetTagItem("anthropic.content.truncated"));
        Assert.True(CountedSize(counted) <= whole + 5);

        // The response is fit with the same bytes for them as the request was.
        var answer = Size(Record(system: null, Parse("[]"), Output("a"))) - "[]".Length;
        var answered = Record(
            system: null,
            Conversation(2, text),
            Output("a"),
            limit: whole + answer + 5,
            stopSequences: euros
        );
        Assert.Equal(0, Input(answered)[0].GetProperty("parts").GetArrayLength());
        Assert.Equal("2" + text, Text(Input(answered)[1]));
        Assert.Equal("a", OutputParts(answered)[0].GetProperty("content").GetString());
    }

    [Fact]
    public void Content_WithNothingToRemove_IsNotTruncated()
    {
        var none = Record(system: null, Parse("[]"), output: null);
        Assert.Equal("[]", Tag(none, "gen_ai.input.messages"));
        Assert.Null(none.GetTagItem("anthropic.content.truncated"));

        // With no room at all there is still nothing to remove.
        var noRoom = Record(Parse("[]"), Parse("[]"), Output(), limit: -100);
        Assert.Equal("[]", Tag(noRoom, "gen_ai.input.messages"));
        Assert.Equal(
            """[{"role":"assistant","parts":[]}]""",
            Tag(noRoom, "gen_ai.output.messages")
        );
        Assert.Equal("[]", Tag(noRoom, "gen_ai.system_instructions"));
        Assert.Null(noRoom.GetTagItem("anthropic.content.truncated"));
    }

    /// <summary>
    /// The cases of the size limit that every SDK has, as JSON. The parts of a case's
    /// <c>input</c> and <c>expected</c> are in the form that the content attributes hold, null is
    /// an absent attribute, and its sizes count the bytes of UTF-8 of the JSON and of the stop
    /// sequences.
    /// </summary>
    const string SizeLimitCases = """
        [
          {"name":"under_the_bound_is_unchanged",
           "note":"Nothing is over, so nothing is removed and anthropic.content.truncated is absent.",
           "bound":1000,"size_before":163,"size_after":163,"expected_truncated":false,
           "input":{"system_instructions":[{"type":"text","content":"Be brief."}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"hi"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"hello"}]}]},
           "expected":{"system_instructions":[{"type":"text","content":"Be brief."}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"hi"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"hello"}]}]}},
          {"name":"exactly_at_the_bound_is_unchanged",
           "note":"The bound is inclusive: a total equal to the bound is not over it.",
           "bound":163,"size_before":163,"size_after":163,"expected_truncated":false,
           "input":{"system_instructions":[{"type":"text","content":"Be brief."}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"hi"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"hello"}]}]},
           "expected":{"system_instructions":[{"type":"text","content":"Be brief."}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"hi"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"hello"}]}]}},
          {"name":"system_parts_go_first",
           "note":"One character over: the first system part is removed whole; the second system part, the input and the output stay.",
           "bound":260,"size_before":261,"size_after":169,"expected_truncated":true,
           "input":{"system_instructions":[{"type":"text","content":"S1-ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss"},{"type":"text","content":"S2 stays"}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"question"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"answer"}]}]},
           "expected":{"system_instructions":[{"type":"text","content":"S2 stays"}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"question"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"answer"}]}]}},
          {"name":"input_parts_follow_and_a_message_is_left_without_parts",
           "note":"The system list is emptied to [] and stays. Both parts of the oldest input message go, so it stays as a message with parts []. Later messages are whole.",
           "bound":222,"size_before":380,"size_after":219,"expected_truncated":true,
           "input":{"system_instructions":[{"type":"text","content":"sys-ssssssssssssssssssssssssssssss"}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"old-oooooooooooooooooooooooooooooooooooooooo"},{"type":"anthropic_image"}]},{"role":"assistant","parts":[{"type":"text","content":"mid"}]},{"role":"user","parts":[{"type":"text","content":"last"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"answer"}]}]},
           "expected":{"system_instructions":[],"input_messages":[{"role":"user","parts":[]},{"role":"assistant","parts":[{"type":"text","content":"mid"}]},{"role":"user","parts":[{"type":"text","content":"last"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"answer"}]}]}},
          {"name":"parts_not_whole_messages_are_removed_and_absent_attributes_stay_absent",
           "note":"No system and no output attribute (a request-only span). Two of three parts of the first message go; the third stays in the same message. An absent attribute is not created.",
           "bound":180,"size_before":246,"size_after":124,"expected_truncated":true,
           "input":{"system_instructions":null,"input_messages":[{"role":"user","parts":[{"type":"text","content":"a-aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"},{"type":"text","content":"b-bbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"},{"type":"text","content":"c stays"}]},{"role":"user","parts":[{"type":"text","content":"newest"}]}],"output_messages":null},
           "expected":{"system_instructions":null,"input_messages":[{"role":"user","parts":[{"type":"text","content":"c stays"}]},{"role":"user","parts":[{"type":"text","content":"newest"}]}],"output_messages":null}},
          {"name":"output_parts_go_from_the_start_and_reasoning_goes_whole",
           "note":"System and input are emptied, then the first output part, a reasoning part, is removed whole (never cut). The last text part stays whole.",
           "bound":183,"size_before":281,"size_after":103,"expected_truncated":true,
           "input":{"system_instructions":[{"type":"text","content":"sys"}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"question qqqqqqqqqqqqqqqqqqqq"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"reasoning","content":"think-tttttttttttttttttttttttttttttttttttttttttttttttttt"},{"type":"text","content":"final answer"}]}]},
           "expected":{"system_instructions":[],"input_messages":[{"role":"user","parts":[]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"final answer"}]}]}},
          {"name":"last_remaining_text_part_is_cut_from_its_end",
           "note":"Everything before the last part is removed (the tool_call whole). One part is left and it is text, so its content keeps the longest start that fits: the total is exactly the bound.",
           "bound":126,"size_before":304,"size_after":126,"expected_truncated":true,
           "input":{"system_instructions":[{"type":"text","content":"sys"}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"question"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"tool_call","id":"toolu_1","name":"get_weather","arguments":{"city":"Paris"}},{"type":"text","content":"012345678901234567890123456789012345678901234567890123456789"}]}]},
           "expected":{"system_instructions":[],"input_messages":[{"role":"user","parts":[]}],"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"01234567890123456789012345678901234"}]}]}},
          {"name":"cut_counts_the_serialized_escapes",
           "note":"A quote or a newline takes more than one character of JSON. The kept start is the longest whose serialized form fits, and it does not end inside an escape.",
           "bound":133,"size_before":152,"size_after":132,"expected_truncated":true,
           "input":{"system_instructions":null,"input_messages":[{"role":"user","parts":[{"type":"text","content":"say \"hi\"\nsay \"hi\"\nsay \"hi\"\nsay \"hi\"\nsay \"hi\"\nsay \"hi\"\nsay \"hi\"\nsay \"hi\"\n"}]}],"output_messages":null},
           "expected":{"system_instructions":null,"input_messages":[{"role":"user","parts":[{"type":"text","content":"say \"hi\"\nsay \"hi\"\nsay \"hi\"\nsay \"hi\"\nsay \"hi\"\nsay \"hi\"\nsay "}]}],"output_messages":null}},
          {"name":"cut_is_at_a_character_boundary",
           "note":"The kept text ends at a code point boundary: no half of a surrogate pair is left.",
           "bound":117,"size_before":121,"size_after":115,"expected_truncated":true,
           "input":{"system_instructions":null,"input_messages":null,"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"a\u20ac\ud83d\ude00\u00e9a\u20ac\ud83d\ude00\u00e9a\u20ac\ud83d\ude00\u00e9a\u20ac\ud83d\ude00\u00e9a\u20ac\ud83d\ude00\u00e9a\u20ac\ud83d\ude00\u00e9"}]}]},
           "expected":{"system_instructions":null,"input_messages":null,"output_messages":[{"role":"assistant","parts":[{"type":"text","content":"a\u20ac\ud83d\ude00\u00e9a\u20ac\ud83d\ude00\u00e9a\u20ac\ud83d\ude00\u00e9a\u20ac\ud83d\ude00\u00e9a\u20ac\ud83d\ude00\u00e9a\u20ac"}]}]}},
          {"name":"last_remaining_part_that_is_not_text_is_removed_whole",
           "note":"The one part left is a tool_call, which is never cut, so it is removed whole. The assistant message stays with parts [].",
           "bound":120,"size_before":304,"size_after":63,"expected_truncated":true,
           "input":{"system_instructions":[{"type":"text","content":"sys"}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"question"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"tool_call","id":"toolu_1","name":"write_file","arguments":{"path":"a.txt","text":"wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww"}}]}]},
           "expected":{"system_instructions":[],"input_messages":[{"role":"user","parts":[]}],"output_messages":[{"role":"assistant","parts":[]}]}},
          {"name":"last_remaining_reasoning_part_is_removed_whole",
           "note":"Only a text part's content is cut. A reasoning part that is the one part left is removed whole.",
           "bound":110,"size_before":223,"size_after":61,"expected_truncated":true,
           "input":{"system_instructions":null,"input_messages":[{"role":"user","parts":[{"type":"text","content":"q"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"reasoning","content":"rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr"}]}]},
           "expected":{"system_instructions":null,"input_messages":[{"role":"user","parts":[]}],"output_messages":[{"role":"assistant","parts":[]}]}},
          {"name":"stop_sequences_alone_over_the_bound_are_removed_whole_then_parts",
           "note":"The stop sequences alone exceed the bound, so the attribute is removed whole and counts for nothing. The rest is still over the bound: every part goes (the last one is not text), the emptied lists and messages stay, and truncated is true.",
           "bound":100,"size_before":296,"size_after":63,"expected_truncated":true,
           "input":{"stop_sequences":["STOP-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"],"system_instructions":[{"type":"text","content":"sys"}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"question"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"tool_call","id":"toolu_1","name":"f","arguments":{}}]}]},
           "expected":{"stop_sequences":null,"system_instructions":[],"input_messages":[{"role":"user","parts":[]}],"output_messages":[{"role":"assistant","parts":[]}]}},
          {"name":"stop_sequences_alone_over_the_bound_are_removed_whole",
           "note":"The stop sequences alone exceed the bound, so the attribute is removed whole and truncated is true. There is no message part, and what is left is under the bound.",
           "bound":100,"size_before":133,"size_after":28,"expected_truncated":true,
           "input":{"stop_sequences":["STOP-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"],"input_messages":[{"role":"user","parts":[]}],"system_instructions":null,"output_messages":null},
           "expected":{"stop_sequences":null,"input_messages":[{"role":"user","parts":[]}],"system_instructions":null,"output_messages":null}},
          {"name":"kept_structure_alone_over_a_tiny_bound_is_exported_as_it_is",
           "note":"No attribute of the first step is present. Every part goes (the last one is not text). The emptied lists and the messages without parts stay, they alone exceed the bound, and the span is exported as it is, with truncated true.",
           "bound":10,"size_before":191,"size_after":63,"expected_truncated":true,
           "input":{"system_instructions":[{"type":"text","content":"sys"}],"input_messages":[{"role":"user","parts":[{"type":"text","content":"question"}]}],"output_messages":[{"role":"assistant","parts":[{"type":"tool_call","id":"toolu_1","name":"f","arguments":{}}]}]},
           "expected":{"system_instructions":[],"input_messages":[{"role":"user","parts":[]}],"output_messages":[{"role":"assistant","parts":[]}]}},
          {"name":"multibyte_text_is_measured_in_utf8_bytes",
           "note":"Each é is one character and one UTF-16 unit but two bytes of UTF-8. The values have 86 characters, under the bound, and 116 bytes, over it. The bound is in bytes, so the text is cut: 22 of the 30 é fit, and the total is exactly the bound.",
           "bound":100,"size_before":116,"size_after":100,"expected_truncated":true,
           "input":{"system_instructions":null,"input_messages":[{"role":"user","parts":[{"type":"text","content":"éééééééééééééééééééééééééééééé"}]}],"output_messages":null},
           "expected":{"system_instructions":null,"input_messages":[{"role":"user","parts":[{"type":"text","content":"éééééééééééééééééééééé"}]}],"output_messages":null}},
          {"name":"cut_lands_on_a_whole_character_in_multibyte_text",
           "note":"44 bytes of content fit. The first 42 end after the third €, and the next character, 😀, takes four bytes (two UTF-16 units), so the 44th byte falls inside it. The kept content ends before that character: no part of it stays, and the total is 2 bytes under the bound.",
           "bound":100,"size_before":148,"size_after":98,"expected_truncated":true,
           "input":{"system_instructions":null,"input_messages":[{"role":"user","parts":[{"type":"text","content":"cost 5€ 😀 cost 5€ 😀 total: 10€😀 thanks, see you again next week! Bye for now."}]}],"output_messages":null},
           "expected":{"system_instructions":null,"input_messages":[{"role":"user","parts":[{"type":"text","content":"cost 5€ 😀 cost 5€ 😀 total: 10€"}]}],"output_messages":null}}
        ]
        """;

    /// <summary>
    /// The cases whose sizes this SDK measures otherwise, because its JSON writes a character
    /// outside the basic plane as <c>\u</c> and four digits, twice: they are run with a limit that
    /// is as far under their whole size as the case's is, and their text is compared with what
    /// the case says of it and not with the text that it lists.
    /// </summary>
    static readonly string[] CasesMeasuredOtherwise =
    [
        "cut_is_at_a_character_boundary",
        "cut_lands_on_a_whole_character_in_multibyte_text",
    ];

    public static TheoryData<string> SizeLimitCaseNames()
    {
        var names = new TheoryData<string>();
        foreach (var item in Parse(SizeLimitCases).EnumerateArray())
        {
            names.Add(item.GetProperty("name").GetString()!);
        }
        return names;
    }

    /// <summary>
    /// The content block of a request that <paramref name="part"/> is the part of.
    /// </summary>
    static JsonObject Block(JsonElement part)
    {
        var type = part.GetProperty("type").GetString()!;
        return type switch
        {
            "text" => new JsonObject
            {
                ["type"] = "text",
                ["text"] = part.GetProperty("content").GetString(),
            },
            _ when type.StartsWith("anthropic_", StringComparison.Ordinal) => new JsonObject
            {
                ["type"] = type.Substring("anthropic_".Length),
            },
            _ => throw new ArgumentException($"A request of the cases has no {type} part."),
        };
    }

    static JsonArray Blocks(JsonElement parts) =>
        new([.. parts.EnumerateArray().Select(part => (JsonNode)Block(part))]);

    /// <summary>
    /// The span of a call with the <c>input</c> of a case: its request, and its response when it
    /// has one, which is one message.
    /// </summary>
    static Activity RecordCase(JsonElement input, int limit)
    {
        JsonElement? system = null;
        if (Property(input, "system_instructions") is { } instructions)
        {
            system = Parse(Blocks(instructions).ToJsonString());
        }
        JsonElement? messages = null;
        if (Property(input, "input_messages") is { } inputMessages)
        {
            var list = new JsonArray();
            foreach (var message in inputMessages.EnumerateArray())
            {
                list.Add(
                    new JsonObject
                    {
                        ["role"] = message.GetProperty("role").GetString(),
                        ["content"] = Blocks(message.GetProperty("parts")),
                    }
                );
            }
            messages = Parse(list.ToJsonString());
        }
        JsonArray? output = null;
        if (Property(input, "output_messages") is { } outputMessages)
        {
            var message = Assert.Single(outputMessages.EnumerateArray());
            Assert.Equal("assistant", message.GetProperty("role").GetString());
            output = Assert.IsType<JsonArray>(
                JsonNode.Parse(message.GetProperty("parts").GetRawText())
            );
        }

        var activity = new Activity("test");
        var request = Content.SetRequestContent(
            activity,
            system,
            messages,
            Property(input, "stop_sequences"),
            limit
        );
        if (output != null)
        {
            Content.SetResponseContent(activity, request, output);
        }
        return activity;
    }

    static JsonElement? Property(JsonElement value, string name) =>
        value.TryGetProperty(name, out var property) && property.ValueKind != JsonValueKind.Null
            ? property
            : null;

    /// <summary>
    /// The bytes of UTF-8 of the content attributes of <paramref name="activity"/> and of its
    /// stop sequences, which is what the size limit counts.
    /// </summary>
    static int CountedSize(Activity activity) =>
        Size(activity)
        + (
            (activity.GetTagItem("gen_ai.request.stop_sequences") as string[])?.Sum(
                Encoding.UTF8.GetByteCount
            ) ?? 0
        );

    static readonly (string Attribute, string Name)[] CaseAttributes =
    [
        ("gen_ai.system_instructions", "system_instructions"),
        ("gen_ai.input.messages", "input_messages"),
        ("gen_ai.output.messages", "output_messages"),
    ];

    /// <summary>
    /// The parts of the system instructions and of every message of <paramref name="content"/>,
    /// the <c>input</c> or the <c>expected</c> of a case.
    /// </summary>
    static IEnumerable<JsonElement> AllParts(JsonElement content) =>
        CaseAttributes.SelectMany(attribute =>
            Property(content, attribute.Name) switch
            {
                null => [],
                { } parts when attribute.Name == "system_instructions" => parts.EnumerateArray(),
                { } messages => messages
                    .EnumerateArray()
                    .SelectMany(message => message.GetProperty("parts").EnumerateArray()),
            }
        );

    /// <summary>
    /// A copy of <paramref name="content"/>, the <c>input</c> or the <c>expected</c> of a case,
    /// in which the content of every part is <paramref name="text"/>.
    /// </summary>
    static JsonNode WithText(JsonElement content, string text)
    {
        var copy = JsonNode.Parse(content.GetRawText())!;
        Set(copy);
        return copy;

        void Set(JsonNode? node)
        {
            switch (node)
            {
                case JsonObject fields when fields["content"] is JsonValue:
                    fields["content"] = text;
                    break;
                case JsonObject fields:
                    foreach (var field in fields.ToList())
                    {
                        Set(field.Value);
                    }
                    break;
                case JsonArray items:
                    foreach (var item in items)
                    {
                        Set(item);
                    }
                    break;
            }
        }
    }

    [Theory]
    [MemberData(nameof(SizeLimitCaseNames))]
    public void Content_SizeLimitCase_IsWhatEverySdkGives(string name)
    {
        var item = Parse(SizeLimitCases)
            .EnumerateArray()
            .Single(item => item.GetProperty("name").GetString() == name);
        var input = item.GetProperty("input");
        var expected = item.GetProperty("expected");
        var bound = item.GetProperty("bound").GetInt32();
        var sizeBefore = item.GetProperty("size_before").GetInt32();

        // This SDK writes `gen_ai.input.messages` for a request without messages too, as an empty
        // list, which the sizes of the case do not count.
        var always = Property(input, "input_messages") == null ? "[]".Length : 0;
        var whole = CountedSize(RecordCase(input, int.MaxValue)) - always;
        var isMeasuredOtherwise = CasesMeasuredOtherwise.Contains(name);
        if (isMeasuredOtherwise)
        {
            bound = whole - (sizeBefore - bound);
        }
        else
        {
            Assert.Equal(sizeBefore, whole);
        }

        var activity = RecordCase(input, bound + always);

        if (item.GetProperty("expected_truncated").GetBoolean())
        {
            Assert.Equal(true, activity.GetTagItem("anthropic.content.truncated"));
        }
        else
        {
            Assert.Null(activity.GetTagItem("anthropic.content.truncated"));
        }
        var listed = JsonNode.Parse(expected.GetRawText())!;
        if (isMeasuredOtherwise)
        {
            // The case has one part, a text part. It is left with a start of its text that ends
            // between two characters, fits, and would not with one character more.
            var original = Assert.Single(AllParts(input)).GetProperty("content").GetString()!;
            var held = new JsonObject();
            foreach (var (attribute, property) in CaseAttributes)
            {
                held[property] = activity.GetTagItem(attribute) is string json
                    ? JsonNode.Parse(json)
                    : null;
            }
            var kept = Assert
                .Single(AllParts(Parse(held.ToJsonString())))
                .GetProperty("content")
                .GetString()!;
            Assert.StartsWith(kept, original, StringComparison.Ordinal);
            Assert.NotEqual(original, kept);
            Assert.False(kept.Length > 0 && char.IsHighSurrogate(kept[^1]));
            Assert.True(CountedSize(activity) - always <= bound);
            var next = kept.Length + (char.IsHighSurrogate(original[kept.Length]) ? 2 : 1);
            var longer = Parse(WithText(input, original.Substring(0, next)).ToJsonString());
            Assert.True(CountedSize(RecordCase(longer, int.MaxValue)) - always > bound);
            listed = WithText(expected, kept);
        }
        else
        {
            Assert.Equal(item.GetProperty("size_after").GetInt32(), CountedSize(activity) - always);
        }

        foreach (var (attribute, property) in CaseAttributes)
        {
            Assert.Equal(
                listed[property]?.ToJsonString(Content.JsonOptions)
                    ?? (property == "input_messages" ? "[]" : null),
                activity.GetTagItem(attribute)
            );
        }
        if (Property(expected, "stop_sequences") is { } sequences)
        {
            Assert.Equal(
                sequences.EnumerateArray().Select(sequence => sequence.GetString()),
                Assert.IsType<string[]>(activity.GetTagItem("gen_ai.request.stop_sequences"))
            );
        }
        else
        {
            Assert.Null(activity.GetTagItem("gen_ai.request.stop_sequences"));
        }
    }
}
