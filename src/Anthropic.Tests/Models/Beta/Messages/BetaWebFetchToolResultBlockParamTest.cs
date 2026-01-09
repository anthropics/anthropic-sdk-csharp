using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        BetaWebFetchToolResultBlockParamContent expectedContent =
            new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_fetch_tool_result\""
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
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParam>(element);
        Assert.NotNull(deserialized);

        BetaWebFetchToolResultBlockParamContent expectedContent =
            new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_fetch_tool_result\""
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
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
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
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            CacheControl = null,
        };

        model.Validate();
    }
}

public class BetaWebFetchToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void BetaWebFetchToolResultErrorBlockParamValidationWorks()
    {
        BetaWebFetchToolResultBlockParamContent value = new(
            new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            )
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchBlockParamValidationWorks()
    {
        BetaWebFetchToolResultBlockParamContent value = new(
            new BetaWebFetchBlockParam()
            {
                Content = new()
                {
                    Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                    CacheControl = new() { TTL = TTL.TTL5m },
                    Citations = new() { Enabled = true },
                    Context = "x",
                    Title = "x",
                },
                URL = "url",
                RetrievedAt = "retrieved_at",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchToolResultErrorBlockParamSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockParamContent value = new(
            new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            )
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParamContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchBlockParamSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockParamContent value = new(
            new BetaWebFetchBlockParam()
            {
                Content = new()
                {
                    Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                    CacheControl = new() { TTL = TTL.TTL5m },
                    Citations = new() { Enabled = true },
                    Context = "x",
                    Title = "x",
                },
                URL = "url",
                RetrievedAt = "retrieved_at",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParamContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }
}
