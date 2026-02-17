using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
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
            Caller = new DirectCaller(),
        };

        WebSearchToolResultBlockParamContent expectedContent = new(
            [
                new WebSearchResultBlockParam()
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
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        WebSearchToolResultBlockParamCaller expectedCaller = new DirectCaller();

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCaller, model.Caller);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
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
            Caller = new DirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
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
            Caller = new DirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebSearchToolResultBlockParamContent expectedContent = new(
            [
                new WebSearchResultBlockParam()
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
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        WebSearchToolResultBlockParamCaller expectedCaller = new DirectCaller();

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCaller, deserialized.Caller);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
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
            Caller = new DirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
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
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
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
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
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
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
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
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        Url = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new WebSearchResultBlockParam()
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
            Caller = new DirectCaller(),
        };

        WebSearchToolResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebSearchToolResultBlockParamCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        WebSearchToolResultBlockParamCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        WebSearchToolResultBlockParamCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void CodeExecution20260120ValidationWorks()
    {
        WebSearchToolResultBlockParamCaller value =
            new WebSearchToolResultBlockParamCallerCodeExecution20260120("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockParamCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockParamCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecution20260120SerializationRoundtripWorks()
    {
        WebSearchToolResultBlockParamCaller value =
            new WebSearchToolResultBlockParamCallerCodeExecution20260120("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WebSearchToolResultBlockParamCallerCodeExecution20260120Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string expectedToolID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20260120");

        Assert.Equal(expectedToolID, model.ToolID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WebSearchToolResultBlockParamCallerCodeExecution20260120>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchToolResultBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WebSearchToolResultBlockParamCallerCodeExecution20260120>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedToolID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20260120");

        Assert.Equal(expectedToolID, deserialized.ToolID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchToolResultBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebSearchToolResultBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        WebSearchToolResultBlockParamCallerCodeExecution20260120 copied = new(model);

        Assert.Equal(model, copied);
    }
}
