using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThreadUnsupportedFeatureNameTest : TestBase
{
    [Theory]
    [InlineData(ThreadUnsupportedFeatureName.CacheControl)]
    [InlineData(ThreadUnsupportedFeatureName.ContextManagement)]
    [InlineData(ThreadUnsupportedFeatureName.Fallbacks)]
    [InlineData(ThreadUnsupportedFeatureName.Hipaa)]
    [InlineData(ThreadUnsupportedFeatureName.InferenceHooks)]
    [InlineData(ThreadUnsupportedFeatureName.Thinking)]
    public void Validation_Works(ThreadUnsupportedFeatureName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThreadUnsupportedFeatureName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThreadUnsupportedFeatureName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ThreadUnsupportedFeatureName.CacheControl, 0, "cache_control")]
    [InlineData(ThreadUnsupportedFeatureName.ContextManagement, 1, "context_management")]
    [InlineData(ThreadUnsupportedFeatureName.Fallbacks, 2, "fallbacks")]
    [InlineData(ThreadUnsupportedFeatureName.Hipaa, 3, "hipaa")]
    [InlineData(ThreadUnsupportedFeatureName.InferenceHooks, 4, "inference_hooks")]
    [InlineData(ThreadUnsupportedFeatureName.Thinking, 5, "thinking")]
    public void EnumMemberSerializationRoundtrip_Works(
        ThreadUnsupportedFeatureName rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThreadUnsupportedFeatureName> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ThreadUnsupportedFeatureName>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThreadUnsupportedFeatureName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ThreadUnsupportedFeatureName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
