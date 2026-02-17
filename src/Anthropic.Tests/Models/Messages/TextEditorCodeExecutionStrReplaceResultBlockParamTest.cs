using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextEditorCodeExecutionStrReplaceResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextEditorCodeExecutionStrReplaceResultBlockParam
        {
            Lines = ["string"],
            NewLines = 0,
            NewStart = 0,
            OldLines = 0,
            OldStart = 0,
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_str_replace_result"
        );
        List<string> expectedLines = ["string"];
        long expectedNewLines = 0;
        long expectedNewStart = 0;
        long expectedOldLines = 0;
        long expectedOldStart = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Lines);
        Assert.Equal(expectedLines.Count, model.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], model.Lines[i]);
        }
        Assert.Equal(expectedNewLines, model.NewLines);
        Assert.Equal(expectedNewStart, model.NewStart);
        Assert.Equal(expectedOldLines, model.OldLines);
        Assert.Equal(expectedOldStart, model.OldStart);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TextEditorCodeExecutionStrReplaceResultBlockParam
        {
            Lines = ["string"],
            NewLines = 0,
            NewStart = 0,
            OldLines = 0,
            OldStart = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionStrReplaceResultBlockParam>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextEditorCodeExecutionStrReplaceResultBlockParam
        {
            Lines = ["string"],
            NewLines = 0,
            NewStart = 0,
            OldLines = 0,
            OldStart = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionStrReplaceResultBlockParam>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_str_replace_result"
        );
        List<string> expectedLines = ["string"];
        long expectedNewLines = 0;
        long expectedNewStart = 0;
        long expectedOldLines = 0;
        long expectedOldStart = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Lines);
        Assert.Equal(expectedLines.Count, deserialized.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], deserialized.Lines[i]);
        }
        Assert.Equal(expectedNewLines, deserialized.NewLines);
        Assert.Equal(expectedNewStart, deserialized.NewStart);
        Assert.Equal(expectedOldLines, deserialized.OldLines);
        Assert.Equal(expectedOldStart, deserialized.OldStart);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TextEditorCodeExecutionStrReplaceResultBlockParam
        {
            Lines = ["string"],
            NewLines = 0,
            NewStart = 0,
            OldLines = 0,
            OldStart = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextEditorCodeExecutionStrReplaceResultBlockParam { };

        Assert.Null(model.Lines);
        Assert.False(model.RawData.ContainsKey("lines"));
        Assert.Null(model.NewLines);
        Assert.False(model.RawData.ContainsKey("new_lines"));
        Assert.Null(model.NewStart);
        Assert.False(model.RawData.ContainsKey("new_start"));
        Assert.Null(model.OldLines);
        Assert.False(model.RawData.ContainsKey("old_lines"));
        Assert.Null(model.OldStart);
        Assert.False(model.RawData.ContainsKey("old_start"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextEditorCodeExecutionStrReplaceResultBlockParam { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TextEditorCodeExecutionStrReplaceResultBlockParam
        {
            Lines = null,
            NewLines = null,
            NewStart = null,
            OldLines = null,
            OldStart = null,
        };

        Assert.Null(model.Lines);
        Assert.True(model.RawData.ContainsKey("lines"));
        Assert.Null(model.NewLines);
        Assert.True(model.RawData.ContainsKey("new_lines"));
        Assert.Null(model.NewStart);
        Assert.True(model.RawData.ContainsKey("new_start"));
        Assert.Null(model.OldLines);
        Assert.True(model.RawData.ContainsKey("old_lines"));
        Assert.Null(model.OldStart);
        Assert.True(model.RawData.ContainsKey("old_start"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TextEditorCodeExecutionStrReplaceResultBlockParam
        {
            Lines = null,
            NewLines = null,
            NewStart = null,
            OldLines = null,
            OldStart = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextEditorCodeExecutionStrReplaceResultBlockParam
        {
            Lines = ["string"],
            NewLines = 0,
            NewStart = 0,
            OldLines = 0,
            OldStart = 0,
        };

        TextEditorCodeExecutionStrReplaceResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
