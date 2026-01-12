using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        URL = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        BetaWebSearchToolResultBlockParamContent expectedContent = new(
            [
                new BetaWebSearchResultBlockParam()
                {
                    EncryptedContent = "encrypted_content",
                    Title = "title",
                    URL = "url",
                    PageAge = "page_age",
                },
            ]
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result\""
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
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        URL = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        URL = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParam>(element);
        Assert.NotNull(deserialized);

        BetaWebSearchToolResultBlockParamContent expectedContent = new(
            [
                new BetaWebSearchResultBlockParam()
                {
                    EncryptedContent = "encrypted_content",
                    Title = "title",
                    URL = "url",
                    PageAge = "page_age",
                },
            ]
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result\""
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
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        URL = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        URL = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        URL = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        URL = "url",
                        PageAge = "page_age",
                    },
                ]
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
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        URL = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            CacheControl = null,
        };

        model.Validate();
    }
}
