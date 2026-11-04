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
    [InlineData(ThreadUnsupportedFeatureName.Zdr)]
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
    [InlineData(ThreadUnsupportedFeatureName.CacheControl)]
    [InlineData(ThreadUnsupportedFeatureName.ContextManagement)]
    [InlineData(ThreadUnsupportedFeatureName.Fallbacks)]
    [InlineData(ThreadUnsupportedFeatureName.Hipaa)]
    [InlineData(ThreadUnsupportedFeatureName.InferenceHooks)]
    [InlineData(ThreadUnsupportedFeatureName.Thinking)]
    [InlineData(ThreadUnsupportedFeatureName.Zdr)]
    public void SerializationRoundtrip_Works(ThreadUnsupportedFeatureName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThreadUnsupportedFeatureName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ThreadUnsupportedFeatureName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
