using System.Text.Json;
using Anthropic.Core;
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        BetaWebFetchToolResultBlockParamContent expectedContent =
            new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaWebFetchToolResultBlockParamCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCaller, model.Caller);
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaWebFetchToolResultBlockParamContent expectedContent =
            new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaWebFetchToolResultBlockParamCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCaller, deserialized.Caller);
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
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
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
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
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
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
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
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
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
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
            Caller = new BetaDirectCaller(),

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
            Caller = new BetaDirectCaller(),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        BetaWebFetchToolResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaWebFetchToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void BetaWebFetchToolResultErrorBlockParamValidationWorks()
    {
        BetaWebFetchToolResultBlockParamContent value = new BetaWebFetchToolResultErrorBlockParam(
            BetaWebFetchToolResultErrorCode.InvalidToolInput
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchBlockParamValidationWorks()
    {
        BetaWebFetchToolResultBlockParamContent value = new BetaWebFetchBlockParam()
        {
            Content = new()
            {
                Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
            RetrievedAt = "retrieved_at",
        };
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchToolResultErrorBlockParamSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockParamContent value = new BetaWebFetchToolResultErrorBlockParam(
            BetaWebFetchToolResultErrorCode.InvalidToolInput
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchBlockParamSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockParamContent value = new BetaWebFetchBlockParam()
        {
            Content = new()
            {
                Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
            RetrievedAt = "retrieved_at",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaWebFetchToolResultBlockParamCallerTest : TestBase
{
    [Fact]
    public void BetaDirectValidationWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaDirectCaller();
        value.Validate();
    }

    [Fact]
    public void BetaServerToolValidationWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaServerToolCaller(
            "srvtoolu_SQfNkl1n_JR_"
        );
        value.Validate();
    }

    [Fact]
    public void BetaServerToolCaller20260120ValidationWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaServerToolCaller20260120(
            "srvtoolu_SQfNkl1n_JR_"
        );
        value.Validate();
    }

    [Fact]
    public void BetaDirectSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaDirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaServerToolCaller(
            "srvtoolu_SQfNkl1n_JR_"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolCaller20260120SerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaServerToolCaller20260120(
            "srvtoolu_SQfNkl1n_JR_"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
