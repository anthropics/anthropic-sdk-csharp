using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingConfigAdaptiveTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingConfigAdaptive { Display = Display.Summarized };

        JsonElement expectedType = JsonSerializer.SerializeToElement("adaptive");
        ApiEnum<string, Display> expectedDisplay = Display.Summarized;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplay, model.Display);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaThinkingConfigAdaptive { Display = Display.Summarized };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigAdaptive>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaThinkingConfigAdaptive { Display = Display.Summarized };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigAdaptive>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("adaptive");
        ApiEnum<string, Display> expectedDisplay = Display.Summarized;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplay, deserialized.Display);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaThinkingConfigAdaptive { Display = Display.Summarized };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaThinkingConfigAdaptive { };

        Assert.Null(model.Display);
        Assert.False(model.RawData.ContainsKey("display"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaThinkingConfigAdaptive { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaThinkingConfigAdaptive { Display = null };

        Assert.Null(model.Display);
        Assert.True(model.RawData.ContainsKey("display"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaThinkingConfigAdaptive { Display = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaThinkingConfigAdaptive { Display = Display.Summarized };

        BetaThinkingConfigAdaptive copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DisplayTest : TestBase
{
    [Theory]
    [InlineData(Display.Summarized)]
    [InlineData(Display.Omitted)]
    public void Validation_Works(Display rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Display> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Display>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Display.Summarized)]
    [InlineData(Display.Omitted)]
    public void SerializationRoundtrip_Works(Display rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Display> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Display>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Display>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Display>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
