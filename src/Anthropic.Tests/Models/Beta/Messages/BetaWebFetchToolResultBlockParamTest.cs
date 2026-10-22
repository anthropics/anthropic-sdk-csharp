using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        BetaWebFetchToolResultBlockParamContent expectedContent =
            new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_c";
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
        string expectedToolUseID = "srvtoolu_c";
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaWebFetchToolResultBlockParam
        {
            Content = new BetaWebFetchToolResultErrorBlockParam(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        } with
        {
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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
            ToolUseID = "srvtoolu_c",
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

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaWebFetchToolResultBlockParamContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "web_fetch_tool_result_error"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaWebFetchToolResultBlockParamContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
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
        BetaWebFetchToolResultBlockParamCaller value = new BetaServerToolCaller("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void BetaServerToolCaller20260120ValidationWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaServerToolCaller20260120(
            "srvtoolu_c"
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
        BetaWebFetchToolResultBlockParamCaller value = new BetaServerToolCaller("srvtoolu_c");
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
            "srvtoolu_c"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaDirectTypeWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaDirectCaller();
        Assert.Equal(BetaWebFetchToolResultBlockParamCallerType.Direct, value.Type.Value());
    }

    [Fact]
    public void BetaServerToolTypeWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaServerToolCaller("srvtoolu_c");
        Assert.Equal(
            BetaWebFetchToolResultBlockParamCallerType.CodeExecution20250825,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaServerToolCaller20260120TypeWorks()
    {
        BetaWebFetchToolResultBlockParamCaller value = new BetaServerToolCaller20260120(
            "srvtoolu_c"
        );
        Assert.Equal(
            BetaWebFetchToolResultBlockParamCallerType.CodeExecution20260120,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaWebFetchToolResultBlockParamCaller value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "direct",
                  "tool_id": "srvtoolu_c"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaWebFetchToolResultBlockParamCallerType> expectedType =
            BetaWebFetchToolResultBlockParamCallerType.Direct;
        string expectedToolID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedToolID, value.ToolID);

        BetaWebFetchToolResultBlockParamCaller emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ToolID);

        BetaWebFetchToolResultBlockParamCaller mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "tool_id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ToolID);
    }
}

public class BetaWebFetchToolResultBlockParamCallerTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaWebFetchToolResultBlockParamCallerType.Direct)]
    [InlineData(BetaWebFetchToolResultBlockParamCallerType.CodeExecution20250825)]
    [InlineData(BetaWebFetchToolResultBlockParamCallerType.CodeExecution20260120)]
    public void Validation_Works(BetaWebFetchToolResultBlockParamCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebFetchToolResultBlockParamCallerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchToolResultBlockParamCallerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWebFetchToolResultBlockParamCallerType.Direct)]
    [InlineData(BetaWebFetchToolResultBlockParamCallerType.CodeExecution20250825)]
    [InlineData(BetaWebFetchToolResultBlockParamCallerType.CodeExecution20260120)]
    public void SerializationRoundtrip_Works(BetaWebFetchToolResultBlockParamCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebFetchToolResultBlockParamCallerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchToolResultBlockParamCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchToolResultBlockParamCallerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchToolResultBlockParamCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
