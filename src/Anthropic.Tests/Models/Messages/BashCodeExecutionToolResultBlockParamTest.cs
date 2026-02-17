using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BashCodeExecutionToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BashCodeExecutionToolResultBlockParam
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BashCodeExecutionToolResultBlockParamContent expectedContent =
            new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "bash_code_execution_tool_result"
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
        var model = new BashCodeExecutionToolResultBlockParam
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BashCodeExecutionToolResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BashCodeExecutionToolResultBlockParam
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BashCodeExecutionToolResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BashCodeExecutionToolResultBlockParamContent expectedContent =
            new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "bash_code_execution_tool_result"
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
        var model = new BashCodeExecutionToolResultBlockParam
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BashCodeExecutionToolResultBlockParam
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BashCodeExecutionToolResultBlockParam
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BashCodeExecutionToolResultBlockParam
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
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
        var model = new BashCodeExecutionToolResultBlockParam
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BashCodeExecutionToolResultBlockParam
        {
            Content = new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BashCodeExecutionToolResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BashCodeExecutionToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void BashCodeExecutionToolResultErrorParamValidationWorks()
    {
        BashCodeExecutionToolResultBlockParamContent value =
            new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        value.Validate();
    }

    [Fact]
    public void BashCodeExecutionResultBlockParamValidationWorks()
    {
        BashCodeExecutionToolResultBlockParamContent value = new BashCodeExecutionResultBlockParam()
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };
        value.Validate();
    }

    [Fact]
    public void BashCodeExecutionToolResultErrorParamSerializationRoundtripWorks()
    {
        BashCodeExecutionToolResultBlockParamContent value =
            new BashCodeExecutionToolResultErrorParam(
                BashCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BashCodeExecutionToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BashCodeExecutionResultBlockParamSerializationRoundtripWorks()
    {
        BashCodeExecutionToolResultBlockParamContent value = new BashCodeExecutionResultBlockParam()
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BashCodeExecutionToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
