using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using static Anthropic.Core.Telemetry.SemanticConventions;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// Builds the content attributes of a span: the messages of a request and a response as the parts
/// that the span schema defines, bounded in size.
/// </summary>
static class Content
{
    /// <summary>
    /// The most bytes of UTF-8, which is what an exporter writes of a string, that the content
    /// attributes of one span hold, when removing message parts can bring them under it, unless
    /// the client's options set another (<see cref="OpenTelemetryTraces.MaxContentBytes"/>).
    ///
    /// <para>The JSON that the attributes hold has most characters as themselves
    /// (<see cref="JsonOptions"/>), so bytes are counted, not characters.</para>
    /// </summary>
    internal const int ContentLimit = 750_000;

    /// <summary>
    /// Writes the JSON of the content attributes with text as it was typed, as the other SDKs do.
    /// The default encoder escapes every non-ASCII character, and <c>&lt;</c>, <c>&gt;</c>,
    /// <c>&amp;</c>, <c>'</c>, <c>+</c>, <c>`</c> and <c>"</c>, as <c>\uXXXX</c>, which protects JSON
    /// that is pasted into HTML. A span attribute is not. This encoder still escapes spaces other
    /// than U+0020, U+2028, U+2029, and characters outside the basic plane such as emoji (two
    /// escapes, 12 bytes): no built-in encoder writes those unescaped.
    /// </summary>
    internal static readonly JsonSerializerOptions JsonOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    /// <summary>
    /// Whether the spans of a client hold the content of the requests and responses.
    /// <paramref name="options"/> are the client's options with nothing left unset
    /// (<see cref="ClientOptions.ResolvedOpenTelemetry"/>). The environment is not read here, so
    /// that a variable set after a client was made cannot put content on its spans, and options
    /// that leave the mode unset record none.
    /// </summary>
    internal static bool IsRecorded(OpenTelemetryOptions options) =>
        options.Traces?.ContentMode == OpenTelemetryContentMode.Content;

    /// <summary>
    /// The size limit of the content attributes of one span of a client.
    /// <paramref name="options"/> are the client's options with nothing left unset
    /// (<see cref="ClientOptions.ResolvedOpenTelemetry"/>), in bytes of UTF-8. A string holds no
    /// more characters than an <c>int</c> counts, and none takes less than a byte, so a larger
    /// limit is that many.
    /// </summary>
    internal static int Limit(OpenTelemetryOptions options) =>
        (int)Math.Min(options.Traces?.MaxContentBytes ?? ContentLimit, int.MaxValue);

    /// <summary>
    /// The part for a content block of the API. A tool use, a server tool use, and an MCP tool use
    /// are tool calls, and only a tool use whose <c>toolset_name</c> is a string has an
    /// <c>anthropic_toolset_name</c>. A block whose type ends in <c>_tool_result</c> is a tool call
    /// response: a <c>tool_result</c> block's response is what <see cref="ToolResultContent"/>
    /// gives, and any other result block's is what <see cref="ResultBlockContent"/> gives. A
    /// thinking block is a reasoning part with the block's thinking, which is empty for a hidden
    /// block, and without its signature. Any other block is a part with only a type, the block's
    /// type after <c>anthropic_</c>: redacted thinking because its data is encrypted, and an image
    /// or a document because its data is large and binary.
    /// </summary>
    internal static JsonObject BlockPart(JsonElement block)
    {
        var type = block.Text("type");
        return type switch
        {
            "text" => new JsonObject
            {
                ["type"] = "text",
                ["content"] = Text(block.Property("text")),
            },
            "tool_use" when block.Text("toolset_name") is { } toolsetName => new JsonObject
            {
                ["type"] = "tool_call",
                ["id"] = block.Text("id") ?? "",
                ["name"] = block.Text("name") ?? "",
                ["arguments"] = Arguments(block.Property("input")),
                ["anthropic_toolset_name"] = toolsetName,
            },
            "tool_use" or "server_tool_use" => new JsonObject
            {
                ["type"] = "tool_call",
                ["id"] = block.Text("id") ?? "",
                ["name"] = block.Text("name") ?? "",
                ["arguments"] = Arguments(block.Property("input")),
            },
            "mcp_tool_use" => new JsonObject
            {
                ["type"] = "tool_call",
                ["id"] = block.Text("id") ?? "",
                ["name"] = block.Text("name") ?? "",
                ["arguments"] = Arguments(block.Property("input")),
                ["anthropic_mcp_server_name"] = block.Text("server_name") ?? "",
            },
            "tool_result" => new JsonObject
            {
                ["type"] = "tool_call_response",
                ["id"] = block.Text("tool_use_id") ?? "",
                ["response"] = ToolResultContent(block.Property("content")),
            },
            _ when type?.EndsWith("_tool_result", StringComparison.Ordinal) == true =>
                new JsonObject
                {
                    ["type"] = "tool_call_response",
                    ["id"] = block.Text("tool_use_id") ?? "",
                    ["response"] = ResultBlockContent(block.Property("content")),
                },
            "thinking" => new JsonObject
            {
                ["type"] = "reasoning",
                ["content"] = Text(block.Property("thinking")),
            },
            _ => new JsonObject { ["type"] = "anthropic_" + (type ?? "unknown") },
        };
    }

    /// <summary>
    /// The node for <paramref name="input"/>, the input of a tool use block, as it was sent: an
    /// object, or whatever else a block has there. Null when the block has none.
    /// </summary>
    static JsonNode? Arguments(JsonElement? input) =>
        input switch
        {
            null or { ValueKind: JsonValueKind.Null } => null,
            { ValueKind: JsonValueKind.Object } fields => JsonObject.Create(fields.Clone()),
            { ValueKind: JsonValueKind.Array } items => JsonArray.Create(items.Clone()),
            { } value => JsonValue.Create(value.Clone()),
        };

    /// <summary>
    /// The node for <paramref name="text"/>, a JSON string, and an empty string when it is
    /// absent. The node keeps the element, which is written from its UTF-8 form, rather than a
    /// string decoded from it only to be encoded again.
    /// </summary>
    static JsonNode Text(JsonElement? text) =>
        text is { ValueKind: JsonValueKind.String } element && JsonValue.Create(element) is { } node
            ? node
            : "";

    /// <summary>
    /// The parts of <paramref name="content"/>, a string or a list of content blocks. A string
    /// is one text part.
    /// </summary>
    internal static JsonArray Parts(JsonElement? content)
    {
        var parts = new JsonArray();
        switch (content)
        {
            case { ValueKind: JsonValueKind.String } text:
                parts.Add(new JsonObject { ["type"] = "text", ["content"] = Text(text) });
                break;
            case { ValueKind: JsonValueKind.Array } blocks:
                foreach (var block in blocks.EnumerateArray())
                {
                    parts.Add(BlockPart(block));
                }
                break;
        }
        return parts;
    }

    /// <summary>
    /// The content blocks of <paramref name="content"/>, the <c>content</c> of a
    /// <c>tool_result</c> block, as they are sent to the API: a string, a list of content blocks,
    /// or nothing, which is an empty list. A string is one text block. A text block and a search
    /// result block keep all their fields, such as a text block's citations and cache control,
    /// except those whose name starts with <c>encrypted_</c>, at any depth. Any other block has
    /// only its type: image and document data is left out because it is large and binary.
    /// </summary>
    internal static JsonArray ToolResultContent(JsonElement? content)
    {
        var blocks = new JsonArray();
        switch (content)
        {
            case { ValueKind: JsonValueKind.String } text:
                blocks.Add(new JsonObject { ["type"] = "text", ["text"] = Text(text) });
                break;
            case { ValueKind: JsonValueKind.Array } list:
                foreach (var block in list.EnumerateArray())
                {
                    blocks.Add(
                        block.Text("type") switch
                        {
                            "text" or "search_result" => Kept(block),
                            var type => new JsonObject { ["type"] = type ?? "unknown" },
                        }
                    );
                }
                break;
        }
        return blocks;
    }

    /// <summary>
    /// What a tool call response holds of <paramref name="content"/>, the <c>content</c> of a
    /// result block other than <c>tool_result</c>, such as <c>mcp_tool_result</c> or
    /// <c>web_search_tool_result</c>. A string, or nothing, is what
    /// <see cref="ToolResultContent"/> gives. In a list, a text block, a search result block, and
    /// a web search result have the fields that <see cref="Kept"/> keeps, and any other element
    /// has only its type. One object, such as a code execution result or an error, has the fields
    /// that <see cref="Kept"/> keeps.
    /// </summary>
    internal static JsonNode? ResultBlockContent(JsonElement? content)
    {
        switch (content)
        {
            case { ValueKind: JsonValueKind.Object } result:
                return Kept(result);
            case { ValueKind: JsonValueKind.Array } list:
                var blocks = new JsonArray();
                foreach (var block in list.EnumerateArray())
                {
                    blocks.Add(
                        block.Text("type") switch
                        {
                            "text" or "search_result" or "web_search_result" => Kept(block),
                            var type => new JsonObject { ["type"] = type ?? "unknown" },
                        }
                    );
                }
                return blocks;
            default:
                return ToolResultContent(content);
        }
    }

    /// <summary>
    /// A copy of <paramref name="value"/>, a value inside a result's content, without what is
    /// left out at any depth. A field whose name starts with <c>encrypted_</c> is left out: the
    /// API returns it only as an opaque string. An image or a document block has only its type,
    /// and a text editor view result of an image or a PDF file has no content, because image and
    /// document data is large and binary.
    /// </summary>
    static JsonNode? Kept(JsonElement value)
    {
        switch (value.ValueKind)
        {
            case JsonValueKind.Object:
                var type = value.Text("type");
                if (type is "image" or "document")
                {
                    return new JsonObject { ["type"] = type };
                }
                var holdsFileData =
                    type == "text_editor_code_execution_view_result"
                    && value.Text("file_type") is "image" or "pdf";
                var fields = new JsonObject();
                foreach (var field in value.EnumerateObject())
                {
                    if (
                        field.Name.StartsWith("encrypted_", StringComparison.Ordinal)
                        || (holdsFileData && field.Name == "content")
                    )
                    {
                        continue;
                    }
                    fields[field.Name] = Kept(field.Value);
                }
                return fields;
            case JsonValueKind.Array:
                var items = new JsonArray();
                foreach (var item in value.EnumerateArray())
                {
                    items.Add(Kept(item));
                }
                return items;
            default:
                return JsonValue.Create(value);
        }
    }

    /// <summary>
    /// Sets the content attributes of the request of a Messages create call, when the call
    /// starts: the request's <paramref name="system"/> prompt, <paramref name="messages"/> and
    /// <paramref name="stopSequences"/>. A call that fails, or whose response is never read, keeps
    /// them. Returns the request's content, for <see cref="SetResponseContent"/> to write the
    /// response's content beside it without serializing the request again.
    ///
    /// <para>Stop sequences whose bytes of UTF-8 are over <paramref name="limit"/> by themselves
    /// are left out, whole, and then count for nothing. Stop sequences that fit are never reduced,
    /// and count for their bytes. When the content is then over <paramref name="limit"/>,
    /// message parts are removed as <see cref="Fit"/> says. When anything was left out or
    /// removed, the span has <c>anthropic.content.truncated</c>, which is true or absent, and no
    /// attribute holds a marker.</para>
    /// </summary>
    internal static RequestContent SetRequestContent(
        Activity span,
        JsonElement? system,
        JsonElement? messages,
        JsonElement? stopSequences = null,
        int limit = ContentLimit
    )
    {
        var completeSize = 0;
        if (StopSequences(stopSequences) is { Length: > 0 } sequences)
        {
            long size = 0;
            foreach (var sequence in sequences)
            {
                size += Encoding.UTF8.GetByteCount(sequence);
            }
            if (size > limit)
            {
                span.SetTag(AttributeAnthropicContentTruncated, true);
            }
            else
            {
                completeSize = (int)size;
                span.SetTag(AttributeGenAiRequestStopSequences, sequences);
            }
        }
        var instructions = system is { ValueKind: not JsonValueKind.Null } prompt
            ? new PartList(open: "[", close: "]", Parts(prompt))
            : null;
        var input = new List<PartList>();
        if (messages is { ValueKind: JsonValueKind.Array } list)
        {
            foreach (var message in list.EnumerateArray())
            {
                input.Add(
                    MessageParts(message.Text("role") ?? "user", Parts(message.Property("content")))
                );
            }
        }
        var request = new RequestContent(completeSize, instructions, input, limit);

        var truncated = Fit(request, null, limit);
        span.SetTag(AttributeGenAiInputMessages, Json(open: "[", input, close: "]"));
        if (instructions != null)
        {
            span.SetTag(
                AttributeGenAiSystemInstructions,
                Json(open: "", [instructions], close: "")
            );
        }
        if (truncated)
        {
            span.SetTag(AttributeAnthropicContentTruncated, true);
        }
        return request;
    }

    /// <summary>
    /// The strings of <paramref name="stopSequences"/>, the request's <c>stop_sequences</c>, or
    /// null when it is not a list.
    /// </summary>
    static string[]? StopSequences(JsonElement? stopSequences)
    {
        if (stopSequences is not { ValueKind: JsonValueKind.Array } list)
        {
            return null;
        }
        var sequences = new List<string>();
        foreach (var item in list.EnumerateArray())
        {
            if (item.ValueKind == JsonValueKind.String)
            {
                sequences.Add(item.GetString() ?? "");
            }
        }
        return [.. sequences];
    }

    /// <summary>
    /// Sets the content attributes of the response of a Messages create call whose request's
    /// content is <paramref name="request"/>, when the response is complete or its stream has
    /// ended: its one <c>assistant</c> message with the parts <paramref name="output"/>.
    ///
    /// <para>The size limit counts the request's content and the response's together. When they
    /// are over the limit of <paramref name="request"/>, message parts are removed as
    /// <see cref="Fit"/> says, from all the parts of the request and not from what was left of
    /// them when the call started. The system instructions and the input messages are set again
    /// only when they hold less than they did. When anything was removed, the span has
    /// <c>anthropic.content.truncated</c>.</para>
    /// </summary>
    internal static void SetResponseContent(Activity span, RequestContent request, JsonArray output)
    {
        List<PartList> messages = [MessageParts("assistant", output)];

        var truncated = Fit(request, messages, request.Limit);
        if (request.SystemInstructions is { Changed: true } instructions)
        {
            span.SetTag(
                AttributeGenAiSystemInstructions,
                Json(open: "", [instructions], close: "")
            );
        }
        if (request.InputMessages.Exists(message => message.Changed))
        {
            span.SetTag(
                AttributeGenAiInputMessages,
                Json(open: "[", request.InputMessages, close: "]")
            );
        }
        span.SetTag(AttributeGenAiOutputMessages, Json(open: "[", messages, close: "]"));
        if (truncated)
        {
            span.SetTag(AttributeAnthropicContentTruncated, true);
        }
    }

    /// <summary>
    /// Sets <c>gen_ai.tool.call.arguments</c> on <paramref name="span"/>, a tool span, to
    /// <paramref name="arguments"/>, the JSON of the tool's input, when the span starts.
    /// Arguments whose bytes of UTF-8 are over <paramref name="limit"/> by themselves are left
    /// out, whole: the span then has <c>anthropic.content.truncated</c>, and the tool's result has
    /// all of the limit (<see cref="SetToolResultContent"/>). Arguments that fit are never
    /// reduced. No string has fewer bytes than characters, so arguments that are over the limit
    /// by their characters are not read.
    /// </summary>
    internal static void SetToolCallArguments(
        Activity span,
        string arguments,
        int limit = ContentLimit
    )
    {
        if (arguments.Length > limit || Encoding.UTF8.GetByteCount(arguments) > limit)
        {
            span.SetTag(AttributeAnthropicContentTruncated, true);
            return;
        }
        span.SetTag(AttributeGenAiToolCallArguments, arguments);
    }

    /// <summary>
    /// Sets <c>anthropic.tool_result.content</c> on <paramref name="span"/>, a tool span, to
    /// <paramref name="blocks"/>, the content blocks of the tool's result, each serialized once.
    ///
    /// <para>The size limit counts them together with the bytes of UTF-8 of the span's
    /// <c>gen_ai.tool.call.arguments</c>, which <see cref="SetToolCallArguments"/> set when it is
    /// within the limit, and which is not reduced here. When they would exceed
    /// <paramref name="limit"/>, content blocks are removed, the last one first, until they
    /// don't, or until none remains. The emptied list stays in its attribute. When a block was
    /// removed, the span has <c>anthropic.content.truncated</c>.</para>
    /// </summary>
    internal static void SetToolResultContent(
        Activity span,
        JsonArray blocks,
        int limit = ContentLimit
    )
    {
        var items = new List<string>();
        foreach (var block in blocks)
        {
            items.Add(block == null ? "null" : block.ToJsonString(JsonOptions));
        }
        long size = span.GetTagItem(AttributeGenAiToolCallArguments) is string arguments
            ? Encoding.UTF8.GetByteCount(arguments)
            : 0;
        size += 2 + Math.Max(items.Count - 1, 0);
        var sizes = items.ConvertAll(Encoding.UTF8.GetByteCount);
        foreach (var bytes in sizes)
        {
            size += bytes;
        }

        var end = items.Count;
        while (size > limit && end > 0)
        {
            end--;
            size -= sizes[end] + (end > 0 ? 1 : 0);
        }

        span.SetTag(
            AttributeAnthropicToolResultContent,
            List(open: "[", items, start: 0, end, close: "]")
        );
        if (end < items.Count)
        {
            span.SetTag(AttributeAnthropicContentTruncated, true);
        }
    }

    /// <summary>
    /// Says which parts of <paramref name="request"/> and of <paramref name="output"/>, the
    /// messages of <c>gen_ai.output.messages</c>, or null before there is a response, a span
    /// holds for its content attributes to be at most <paramref name="limit"/> bytes of UTF-8
    /// together, and whether it is fewer than all of them.
    ///
    /// <para>The parts of the system instructions, then of each input message, then of each
    /// output message are one list. While the content is over the limit and the list has more
    /// than one part, its first part is removed, whole. A message that lost its parts stays, with
    /// no parts, and so do emptied system instructions. When one part is left and the content is
    /// still over the limit, a text part loses the end of its text, as <see cref="CutText"/>
    /// says, and any other part, such as a tool call or a reasoning part, is removed. What is
    /// still over the limit then stays so.</para>
    ///
    /// <para>The parts are serialized from the last one back, each once, and only as long as they
    /// fit with all that is never removed: the ones before them are removed, which is what
    /// removing the first part until the rest fits comes to.</para>
    /// </summary>
    static bool Fit(RequestContent request, List<PartList>? output, int limit)
    {
        var lists = new List<PartList>();
        var size = request.CompleteContentSize;
        if (request.SystemInstructions is { } instructions)
        {
            lists.Add(instructions);
            size += instructions.Open.Length + instructions.Close.Length;
        }
        lists.AddRange(request.InputMessages);
        size += EmptySize(request.InputMessages);
        if (output != null)
        {
            lists.AddRange(output);
            size += EmptySize(output);
        }

        var truncated = false;
        var fits = true;
        var isLast = true;
        for (var at = lists.Count - 1; at >= 0; at--)
        {
            var list = lists[at];
            var (start, cut) = (list.Start, list.Cut);
            var count = list.Parts.Count;
            list.Start = count;
            list.Cut = null;
            while (fits && list.Start > 0)
            {
                var index = list.Start - 1;
                var json = list.Json(index);
                var bytes = Encoding.UTF8.GetByteCount(json);
                // A part that is not the last of its list has a comma after it.
                var added = bytes + (list.Start < count ? 1 : 0);
                if (size + added <= limit)
                {
                    size += added;
                    list.Start = index;
                    isLast = false;
                    continue;
                }
                fits = false;
                if (isLast && CutText(list.Parts[index], bytes - (limit - size)) is { } kept)
                {
                    list.Start = index;
                    list.Cut = kept == json ? null : kept;
                }
            }
            list.Changed = list.Start != start || list.Cut != cut;
            truncated |= list.Start > 0 || list.Cut != null;
        }
        return truncated;
    }

    /// <summary>
    /// The JSON of <paramref name="part"/>, a text part, with the longest start of its
    /// <c>content</c> that makes it at least <paramref name="excess"/> bytes shorter, or with an
    /// empty content when no start does. Null for any other part. <paramref name="part"/> keeps
    /// its whole content. The cut is made in the JSON of the content: there the bytes are
    /// counted, and one character of the text can take several, up to twelve for one outside the
    /// basic plane, which stays whole or goes whole (<see cref="TextEnd"/>). The text is read back
    /// from what is kept.
    /// </summary>
    static string? CutText(JsonNode? part, int excess)
    {
        if (
            part is not JsonObject fields
            || fields["type"] is not JsonValue type
            || !type.TryGetValue<string>(out var name)
            || name != "text"
            || fields["content"] is not JsonValue content
            || content.GetValueKind() != JsonValueKind.String
        )
        {
            return null;
        }
        var json = content.ToJsonString(JsonOptions);
        var bytes = Encoding.UTF8.GetByteCount(json) - 1 - excess;
        var end = Math.Max(TextEnd(json, LengthWithin(json, bytes)), 1);
        var cut = new JsonObject();
        foreach (var field in fields)
        {
            cut[field.Key] =
                field.Key == "content"
                    ? JsonNode.Parse(json.Remove(end, json.Length - 1 - end))
                    : field.Value?.DeepClone();
        }
        return cut.ToJsonString(JsonOptions);
    }

    /// <summary>
    /// How many characters from the start of <paramref name="text"/> are at most
    /// <paramref name="bytes"/> bytes of UTF-8.
    /// </summary>
    static int LengthWithin(string text, int bytes)
    {
        var length = 0;
        for (; length < text.Length; length++)
        {
            var character = text[length];
            bytes -=
                character < '\u0080' ? 1
                : character < '\u0800' ? 2
                : 3;
            if (bytes < 0)
            {
                break;
            }
        }
        return length;
    }

    /// <summary>
    /// The last index up to <paramref name="end"/> at which the text of <paramref name="json"/>,
    /// a JSON string with its quotes, can end: not inside an escape, and not between the two
    /// halves of a surrogate pair, escaped or not.
    /// </summary>
    static int TextEnd(string json, int end)
    {
        if (end <= 1)
        {
            return end;
        }
        if (char.IsHighSurrogate(json[end - 1]))
        {
            return end - 1;
        }
        var slash = json.LastIndexOf('\\', end - 1, Math.Min(6, end - 1));
        if (slash < 0)
        {
            return end;
        }
        var first = slash;
        while (json[first - 1] == '\\')
        {
            first--;
        }
        // The last of an odd number of backslashes starts an escape: `\u` and four digits, or one
        // character.
        if ((slash - first) % 2 != 0)
        {
            return end;
        }
        var length = slash + 1 < end && json[slash + 1] == 'u' ? 6 : 2;
        if (slash + length > end)
        {
            return TextEnd(json, slash);
        }
        var isHighSurrogate =
            length == 6
            && slash + length == end
            && char.IsHighSurrogate((char)Convert.ToInt32(json.Substring(slash + 2, 4), 16));
        return isHighSurrogate ? slash : end;
    }

    /// <summary>
    /// The bytes of the JSON of the list of <paramref name="messages"/> without their parts: its
    /// brackets, what each message has around its parts, and a comma between each two.
    /// </summary>
    static int EmptySize(List<PartList> messages)
    {
        var size = 2 + Math.Max(messages.Count - 1, 0);
        foreach (var message in messages)
        {
            size += Encoding.UTF8.GetByteCount(message.Open) + message.Close.Length;
        }
        return size;
    }

    /// <summary>
    /// The JSON of <paramref name="lists"/>, each with the parts that the span holds and a comma
    /// between each two, between <paramref name="open"/> and <paramref name="close"/>. The pieces
    /// are concatenated once, so that a large value is not copied a second time to put the
    /// brackets around it.
    /// </summary>
    static string Json(string open, List<PartList> lists, string close)
    {
        var pieces = new List<string> { open };
        foreach (var list in lists)
        {
            if (pieces.Count > 1)
            {
                pieces.Add(",");
            }
            pieces.Add(list.Open);
            for (var index = list.Start; index < list.Parts.Count; index++)
            {
                if (index > list.Start)
                {
                    pieces.Add(",");
                }
                pieces.Add(list.Cut ?? list.Json(index));
            }
            pieces.Add(list.Close);
        }
        pieces.Add(close);
        string[] all = [.. pieces];
        return string.Concat(all);
    }

    /// <summary>
    /// The JSON of a list: <paramref name="open"/>, the <paramref name="items"/> from
    /// <paramref name="start"/> up to <paramref name="end"/> with a comma between each two, and
    /// <paramref name="close"/>. The pieces are concatenated once, so that a large value is not
    /// copied a second time to put the brackets around it.
    /// </summary>
    static string List(string open, List<string> items, int start, int end, string close)
    {
        var count = Math.Max(end - start, 0);
        var pieces = new string[2 + count + Math.Max(count - 1, 0)];
        var next = 0;
        pieces[next++] = open;
        for (var index = start; index < end; index++)
        {
            if (index > start)
            {
                pieces[next++] = ",";
            }
            pieces[next++] = items[index];
        }
        pieces[next] = close;
        return string.Concat(pieces);
    }

    const string MessageClose = "]}";

    /// <summary>
    /// The <paramref name="parts"/> of a message with the <paramref name="role"/>, between the
    /// JSON that a message of the conventions' content format has around its parts.
    /// </summary>
    static PartList MessageParts(string role, JsonArray parts)
    {
        var empty = new JsonObject { ["role"] = role, ["parts"] = new JsonArray() }.ToJsonString(
            JsonOptions
        );
        return new(empty.Substring(0, empty.Length - MessageClose.Length), MessageClose, parts);
    }
}

/// <summary>
/// The content of the request of a Messages create call, which
/// <see cref="Content.SetRequestContent"/> wrote on a span: all the parts of its system
/// instructions and of its input messages, the size of the content that is never reduced, and
/// the size limit that it was written within.
/// </summary>
sealed class RequestContent(
    int completeContentSize,
    PartList? systemInstructions,
    List<PartList> inputMessages,
    int limit
)
{
    /// <summary>
    /// The bytes of UTF-8 of the strings of <c>gen_ai.request.stop_sequences</c>, which the size
    /// limit counts and <see cref="Content.Fit"/> never removes. It is 0 when the span has no
    /// stop sequences, which is also when they were over the limit by themselves and left out.
    /// </summary>
    internal int CompleteContentSize { get; } = completeContentSize;

    /// <summary>
    /// The parts of <c>gen_ai.system_instructions</c>, between its brackets, or null for a
    /// request without a system prompt.
    /// </summary>
    internal PartList? SystemInstructions { get; } = systemInstructions;

    /// <summary>
    /// The parts of each message of <c>gen_ai.input.messages</c>.
    /// </summary>
    internal List<PartList> InputMessages { get; } = inputMessages;

    /// <summary>
    /// The most bytes of UTF-8 that the content attributes of the span hold, which the content
    /// of the response counts toward too.
    /// </summary>
    internal int Limit { get; } = limit;
}

/// <summary>
/// The parts of one message, or of the system instructions, in a content attribute:
/// <paramref name="parts"/>, between the JSON <paramref name="open"/> and
/// <paramref name="close"/>, and which of them the span holds.
/// </summary>
sealed class PartList(string open, string close, JsonArray parts)
{
    readonly string?[] _jsons = new string?[parts.Count];

    internal string Open { get; } = open;

    internal string Close { get; } = close;

    /// <summary>
    /// All the parts, as they were before any was removed or cut.
    /// </summary>
    internal JsonArray Parts { get; } = parts;

    /// <summary>
    /// The index of the first part that the span holds: the parts before it were removed.
    /// </summary>
    internal int Start { get; set; }

    /// <summary>
    /// The JSON of the one part that the span holds, the last one, without the end of its text,
    /// or null when no part was cut.
    /// </summary>
    internal string? Cut { get; set; }

    /// <summary>
    /// Whether the span holds other parts, or another cut, since <see cref="Content.Fit"/> last
    /// ran than before it did.
    /// </summary>
    internal bool Changed { get; set; }

    /// <summary>
    /// The JSON of the whole part at <paramref name="index"/>, which is serialized once.
    /// </summary>
    internal string Json(int index) =>
        _jsons[index] ??= Parts[index]?.ToJsonString(Content.JsonOptions) ?? "null";
}
