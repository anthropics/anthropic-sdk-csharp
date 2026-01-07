using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlockParam
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BetaTextEditorCodeExecutionToolResultBlockParamContent expectedContent =
            new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlockParam
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlockParam
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockParam>(element);
        Assert.NotNull(deserialized);

        BetaTextEditorCodeExecutionToolResultBlockParamContent expectedContent =
            new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlockParam
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
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
        var model = new BetaTextEditorCodeExecutionToolResultBlockParam
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
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
        var model = new BetaTextEditorCodeExecutionToolResultBlockParam
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlockParam
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
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
        var model = new BetaTextEditorCodeExecutionToolResultBlockParam
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            CacheControl = null,
        };

        model.Validate();
    }
}

public class BetaTextEditorCodeExecutionToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void BetaTextEditorCodeExecutionToolResultErrorParamValidationWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockParamContent value = new(
            new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaTextEditorCodeExecutionViewResultBlockParamValidationWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockParamContent value = new(
            new BetaTextEditorCodeExecutionViewResultBlockParam()
            {
                Content = "content",
                FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
                NumLines = 0,
                StartLine = 0,
                TotalLines = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaTextEditorCodeExecutionCreateResultBlockParamValidationWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockParamContent value = new(
            new BetaTextEditorCodeExecutionCreateResultBlockParam(true)
        );
        value.Validate();
    }

    [Fact]
    public void BetaTextEditorCodeExecutionStrReplaceResultBlockParamValidationWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockParamContent value = new(
            new BetaTextEditorCodeExecutionStrReplaceResultBlockParam()
            {
                Lines = ["string"],
                NewLines = 0,
                NewStart = 0,
                OldLines = 0,
                OldStart = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaTextEditorCodeExecutionToolResultErrorParamSerializationRoundtripWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockParamContent value = new(
            new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockParamContent>(
                element
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextEditorCodeExecutionViewResultBlockParamSerializationRoundtripWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockParamContent value = new(
            new BetaTextEditorCodeExecutionViewResultBlockParam()
            {
                Content = "content",
                FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
                NumLines = 0,
                StartLine = 0,
                TotalLines = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockParamContent>(
                element
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextEditorCodeExecutionCreateResultBlockParamSerializationRoundtripWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockParamContent value = new(
            new BetaTextEditorCodeExecutionCreateResultBlockParam(true)
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockParamContent>(
                element
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextEditorCodeExecutionStrReplaceResultBlockParamSerializationRoundtripWorks()
    {
        BetaTextEditorCodeExecutionToolResultBlockParamContent value = new(
            new BetaTextEditorCodeExecutionStrReplaceResultBlockParam()
            {
                Lines = ["string"],
                NewLines = 0,
                NewStart = 0,
                OldLines = 0,
                OldStart = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockParamContent>(
                element
            );

        Assert.Equal(value, deserialized);
    }
}
