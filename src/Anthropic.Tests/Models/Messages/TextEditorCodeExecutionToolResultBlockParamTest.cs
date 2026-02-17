using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextEditorCodeExecutionToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlockParam
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        TextEditorCodeExecutionToolResultBlockParamContent expectedContent =
            new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result"
        );
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlockParam
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlockParam
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TextEditorCodeExecutionToolResultBlockParamContent expectedContent =
            new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result"
        );
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlockParam
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlockParam
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlockParam
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlockParam
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlockParam
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextEditorCodeExecutionToolResultBlockParam
        {
            Content = new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        TextEditorCodeExecutionToolResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextEditorCodeExecutionToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void TextEditorCodeExecutionToolResultErrorParamValidationWorks()
    {
        TextEditorCodeExecutionToolResultBlockParamContent value =
            new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionViewResultBlockParamValidationWorks()
    {
        TextEditorCodeExecutionToolResultBlockParamContent value =
            new TextEditorCodeExecutionViewResultBlockParam()
            {
                Content = "content",
                FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,
                NumLines = 0,
                StartLine = 0,
                TotalLines = 0,
            };
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionCreateResultBlockParamValidationWorks()
    {
        TextEditorCodeExecutionToolResultBlockParamContent value =
            new TextEditorCodeExecutionCreateResultBlockParam(true);
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionStrReplaceResultBlockParamValidationWorks()
    {
        TextEditorCodeExecutionToolResultBlockParamContent value =
            new TextEditorCodeExecutionStrReplaceResultBlockParam()
            {
                Lines = ["string"],
                NewLines = 0,
                NewStart = 0,
                OldLines = 0,
                OldStart = 0,
            };
        value.Validate();
    }

    [Fact]
    public void TextEditorCodeExecutionToolResultErrorParamSerializationRoundtripWorks()
    {
        TextEditorCodeExecutionToolResultBlockParamContent value =
            new TextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode = TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockParamContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionViewResultBlockParamSerializationRoundtripWorks()
    {
        TextEditorCodeExecutionToolResultBlockParamContent value =
            new TextEditorCodeExecutionViewResultBlockParam()
            {
                Content = "content",
                FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,
                NumLines = 0,
                StartLine = 0,
                TotalLines = 0,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockParamContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionCreateResultBlockParamSerializationRoundtripWorks()
    {
        TextEditorCodeExecutionToolResultBlockParamContent value =
            new TextEditorCodeExecutionCreateResultBlockParam(true);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockParamContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditorCodeExecutionStrReplaceResultBlockParamSerializationRoundtripWorks()
    {
        TextEditorCodeExecutionToolResultBlockParamContent value =
            new TextEditorCodeExecutionStrReplaceResultBlockParam()
            {
                Lines = ["string"],
                NewLines = 0,
                NewStart = 0,
                OldLines = 0,
                OldStart = 0,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlockParamContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
