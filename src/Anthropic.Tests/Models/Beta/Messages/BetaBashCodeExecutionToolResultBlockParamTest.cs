using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBashCodeExecutionToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlockParam
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        BetaBashCodeExecutionToolResultBlockParamContent expectedContent =
            new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result\""
        );
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlockParam
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlockParam>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlockParam
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlockParam>(
            json
        );
        Assert.NotNull(deserialized);

        BetaBashCodeExecutionToolResultBlockParamContent expectedContent =
            new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result\""
        );
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlockParam
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlockParam
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlockParam
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlockParam
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBashCodeExecutionToolResultBlockParam
        {
            Content = new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            CacheControl = null,
        };

        model.Validate();
    }
}

public class BetaBashCodeExecutionToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void beta_bash_code_execution_tool_result_error_paramValidation_Works()
    {
        BetaBashCodeExecutionToolResultBlockParamContent value = new(
            new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            )
        );
        value.Validate();
    }

    [Fact]
    public void beta_bash_code_execution_result_block_paramValidation_Works()
    {
        BetaBashCodeExecutionToolResultBlockParamContent value = new(
            new BetaBashCodeExecutionResultBlockParam()
            {
                Content = [new("file_id")],
                ReturnCode = 0,
                Stderr = "stderr",
                Stdout = "stdout",
            }
        );
        value.Validate();
    }

    [Fact]
    public void beta_bash_code_execution_tool_result_error_paramSerializationRoundtrip_Works()
    {
        BetaBashCodeExecutionToolResultBlockParamContent value = new(
            new BetaBashCodeExecutionToolResultErrorParam(
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlockParamContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_bash_code_execution_result_block_paramSerializationRoundtrip_Works()
    {
        BetaBashCodeExecutionToolResultBlockParamContent value = new(
            new BetaBashCodeExecutionResultBlockParam()
            {
                Content = [new("file_id")],
                ReturnCode = 0,
                Stderr = "stderr",
                Stdout = "stdout",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlockParamContent>(json);

        Assert.Equal(value, deserialized);
    }
}
