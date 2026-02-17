using System.Text.Json;
using Anthropic.Core;
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
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        BetaWebSearchToolResultBlockParamContent expectedContent = new(
            [
                new BetaWebSearchResultBlockParam()
                {
                    EncryptedContent = "encrypted_content",
                    Title = "title",
                    Url = "url",
                    PageAge = "page_age",
                },
            ]
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaWebSearchToolResultBlockParamCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCaller, model.Caller);
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
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

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
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaWebSearchToolResultBlockParamContent expectedContent = new(
            [
                new BetaWebSearchResultBlockParam()
                {
                    EncryptedContent = "encrypted_content",
                    Title = "title",
                    Url = "url",
                    PageAge = "page_age",
                },
            ]
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaWebSearchToolResultBlockParamCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCaller, deserialized.Caller);
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
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Caller = null,
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
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
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
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
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
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),

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
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new BetaWebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        BetaWebSearchToolResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaWebSearchToolResultBlockParamCallerTest : TestBase
{
    [Fact]
    public void BetaDirectValidationWorks()
    {
        BetaWebSearchToolResultBlockParamCaller value = new BetaDirectCaller();
        value.Validate();
    }

    [Fact]
    public void BetaServerToolValidationWorks()
    {
        BetaWebSearchToolResultBlockParamCaller value = new BetaServerToolCaller(
            "srvtoolu_SQfNkl1n_JR_"
        );
        value.Validate();
    }

    [Fact]
    public void BetaServerToolCaller20260120ValidationWorks()
    {
        BetaWebSearchToolResultBlockParamCaller value = new BetaServerToolCaller20260120(
            "srvtoolu_SQfNkl1n_JR_"
        );
        value.Validate();
    }

    [Fact]
    public void BetaDirectSerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockParamCaller value = new BetaDirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolSerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockParamCaller value = new BetaServerToolCaller(
            "srvtoolu_SQfNkl1n_JR_"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolCaller20260120SerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockParamCaller value = new BetaServerToolCaller20260120(
            "srvtoolu_SQfNkl1n_JR_"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
