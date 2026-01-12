using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultBlockParam
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        BetaToolSearchToolResultBlockParamContent expectedContent =
            new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_result\""
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
        var model = new BetaToolSearchToolResultBlockParam
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolSearchToolResultBlockParam
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlockParam>(element);
        Assert.NotNull(deserialized);

        BetaToolSearchToolResultBlockParamContent expectedContent =
            new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_result\""
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
        var model = new BetaToolSearchToolResultBlockParam
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaToolSearchToolResultBlockParam
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaToolSearchToolResultBlockParam
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaToolSearchToolResultBlockParam
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
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
        var model = new BetaToolSearchToolResultBlockParam
        {
            Content = new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            CacheControl = null,
        };

        model.Validate();
    }
}

public class BetaToolSearchToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void BetaToolSearchToolResultErrorParamValidationWorks()
    {
        BetaToolSearchToolResultBlockParamContent value = new(
            new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            )
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolSearchToolSearchResultBlockParamValidationWorks()
    {
        BetaToolSearchToolResultBlockParamContent value = new(
            new BetaToolSearchToolSearchResultBlockParam(
                [
                    new()
                    {
                        ToolName = "tool_name",
                        CacheControl = new() { TTL = TTL.TTL5m },
                    },
                ]
            )
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolSearchToolResultErrorParamSerializationRoundtripWorks()
    {
        BetaToolSearchToolResultBlockParamContent value = new(
            new BetaToolSearchToolResultErrorParam(
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput
            )
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlockParamContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolSearchToolSearchResultBlockParamSerializationRoundtripWorks()
    {
        BetaToolSearchToolResultBlockParamContent value = new(
            new BetaToolSearchToolSearchResultBlockParam(
                [
                    new()
                    {
                        ToolName = "tool_name",
                        CacheControl = new() { TTL = TTL.TTL5m },
                    },
                ]
            )
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlockParamContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }
}
