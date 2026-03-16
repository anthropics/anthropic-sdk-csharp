using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingConfigEnabled
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };

        long expectedBudgetTokens = 1024;
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        ApiEnum<string, ThinkingConfigEnabledDisplay> expectedDisplay =
            ThinkingConfigEnabledDisplay.Summarized;

        Assert.Equal(expectedBudgetTokens, model.BudgetTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisplay, model.Display);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThinkingConfigEnabled
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigEnabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThinkingConfigEnabled
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigEnabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBudgetTokens = 1024;
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        ApiEnum<string, ThinkingConfigEnabledDisplay> expectedDisplay =
            ThinkingConfigEnabledDisplay.Summarized;

        Assert.Equal(expectedBudgetTokens, deserialized.BudgetTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisplay, deserialized.Display);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThinkingConfigEnabled
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThinkingConfigEnabled { BudgetTokens = 1024 };

        Assert.Null(model.Display);
        Assert.False(model.RawData.ContainsKey("display"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThinkingConfigEnabled { BudgetTokens = 1024 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ThinkingConfigEnabled
        {
            BudgetTokens = 1024,

            Display = null,
        };

        Assert.Null(model.Display);
        Assert.True(model.RawData.ContainsKey("display"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThinkingConfigEnabled
        {
            BudgetTokens = 1024,

            Display = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThinkingConfigEnabled
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };

        ThinkingConfigEnabled copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThinkingConfigEnabledDisplayTest : TestBase
{
    [Theory]
    [InlineData(ThinkingConfigEnabledDisplay.Summarized)]
    [InlineData(ThinkingConfigEnabledDisplay.Omitted)]
    public void Validation_Works(ThinkingConfigEnabledDisplay rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingConfigEnabledDisplay> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingConfigEnabledDisplay>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ThinkingConfigEnabledDisplay.Summarized)]
    [InlineData(ThinkingConfigEnabledDisplay.Omitted)]
    public void SerializationRoundtrip_Works(ThinkingConfigEnabledDisplay rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingConfigEnabledDisplay> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ThinkingConfigEnabledDisplay>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingConfigEnabledDisplay>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ThinkingConfigEnabledDisplay>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
