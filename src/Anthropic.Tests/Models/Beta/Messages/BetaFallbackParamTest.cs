using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFallbackParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFallbackParam
        {
            Model = Messages::Model.ClaudeFable5,
            MaxTokens = 0,
            OutputConfig = new()
            {
                Effort = Effort.Low,
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                TaskBudget = new() { Total = 1024, Remaining = 0 },
            },
            Speed = BetaFallbackParamSpeed.Standard,
            Thinking = new BetaThinkingConfigEnabled()
            {
                BudgetTokens = 1024,
                Display = BetaThinkingConfigEnabledDisplay.Summarized,
            },
        };

        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeFable5;
        long expectedMaxTokens = 0;
        BetaOutputConfig expectedOutputConfig = new()
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TaskBudget = new() { Total = 1024, Remaining = 0 },
        };
        ApiEnum<string, BetaFallbackParamSpeed> expectedSpeed = BetaFallbackParamSpeed.Standard;
        Thinking expectedThinking = new BetaThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = BetaThinkingConfigEnabledDisplay.Summarized,
        };

        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.Equal(expectedOutputConfig, model.OutputConfig);
        Assert.Equal(expectedSpeed, model.Speed);
        Assert.Equal(expectedThinking, model.Thinking);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFallbackParam
        {
            Model = Messages::Model.ClaudeFable5,
            MaxTokens = 0,
            OutputConfig = new()
            {
                Effort = Effort.Low,
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                TaskBudget = new() { Total = 1024, Remaining = 0 },
            },
            Speed = BetaFallbackParamSpeed.Standard,
            Thinking = new BetaThinkingConfigEnabled()
            {
                BudgetTokens = 1024,
                Display = BetaThinkingConfigEnabledDisplay.Summarized,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFallbackParam
        {
            Model = Messages::Model.ClaudeFable5,
            MaxTokens = 0,
            OutputConfig = new()
            {
                Effort = Effort.Low,
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                TaskBudget = new() { Total = 1024, Remaining = 0 },
            },
            Speed = BetaFallbackParamSpeed.Standard,
            Thinking = new BetaThinkingConfigEnabled()
            {
                BudgetTokens = 1024,
                Display = BetaThinkingConfigEnabledDisplay.Summarized,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeFable5;
        long expectedMaxTokens = 0;
        BetaOutputConfig expectedOutputConfig = new()
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TaskBudget = new() { Total = 1024, Remaining = 0 },
        };
        ApiEnum<string, BetaFallbackParamSpeed> expectedSpeed = BetaFallbackParamSpeed.Standard;
        Thinking expectedThinking = new BetaThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = BetaThinkingConfigEnabledDisplay.Summarized,
        };

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.Equal(expectedOutputConfig, deserialized.OutputConfig);
        Assert.Equal(expectedSpeed, deserialized.Speed);
        Assert.Equal(expectedThinking, deserialized.Thinking);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFallbackParam
        {
            Model = Messages::Model.ClaudeFable5,
            MaxTokens = 0,
            OutputConfig = new()
            {
                Effort = Effort.Low,
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                TaskBudget = new() { Total = 1024, Remaining = 0 },
            },
            Speed = BetaFallbackParamSpeed.Standard,
            Thinking = new BetaThinkingConfigEnabled()
            {
                BudgetTokens = 1024,
                Display = BetaThinkingConfigEnabledDisplay.Summarized,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaFallbackParam { Model = Messages::Model.ClaudeFable5 };

        Assert.Null(model.MaxTokens);
        Assert.False(model.RawData.ContainsKey("max_tokens"));
        Assert.Null(model.OutputConfig);
        Assert.False(model.RawData.ContainsKey("output_config"));
        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaFallbackParam { Model = Messages::Model.ClaudeFable5 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaFallbackParam
        {
            Model = Messages::Model.ClaudeFable5,

            MaxTokens = null,
            OutputConfig = null,
            Speed = null,
            Thinking = null,
        };

        Assert.Null(model.MaxTokens);
        Assert.True(model.RawData.ContainsKey("max_tokens"));
        Assert.Null(model.OutputConfig);
        Assert.True(model.RawData.ContainsKey("output_config"));
        Assert.Null(model.Speed);
        Assert.True(model.RawData.ContainsKey("speed"));
        Assert.Null(model.Thinking);
        Assert.True(model.RawData.ContainsKey("thinking"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaFallbackParam
        {
            Model = Messages::Model.ClaudeFable5,

            MaxTokens = null,
            OutputConfig = null,
            Speed = null,
            Thinking = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFallbackParam
        {
            Model = Messages::Model.ClaudeFable5,
            MaxTokens = 0,
            OutputConfig = new()
            {
                Effort = Effort.Low,
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                TaskBudget = new() { Total = 1024, Remaining = 0 },
            },
            Speed = BetaFallbackParamSpeed.Standard,
            Thinking = new BetaThinkingConfigEnabled()
            {
                BudgetTokens = 1024,
                Display = BetaThinkingConfigEnabledDisplay.Summarized,
            },
        };

        BetaFallbackParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaFallbackParamSpeedTest : TestBase
{
    [Theory]
    [InlineData(BetaFallbackParamSpeed.Standard)]
    [InlineData(BetaFallbackParamSpeed.Fast)]
    public void Validation_Works(BetaFallbackParamSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaFallbackParamSpeed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaFallbackParamSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaFallbackParamSpeed.Standard)]
    [InlineData(BetaFallbackParamSpeed.Fast)]
    public void SerializationRoundtrip_Works(BetaFallbackParamSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaFallbackParamSpeed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaFallbackParamSpeed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaFallbackParamSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaFallbackParamSpeed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThinkingTest : TestBase
{
    [Fact]
    public void BetaThinkingConfigEnabledValidationWorks()
    {
        Thinking value = new BetaThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = BetaThinkingConfigEnabledDisplay.Summarized,
        };
        value.Validate();
    }

    [Fact]
    public void BetaThinkingConfigDisabledValidationWorks()
    {
        Thinking value = new BetaThinkingConfigDisabled();
        value.Validate();
    }

    [Fact]
    public void BetaThinkingConfigAdaptiveValidationWorks()
    {
        Thinking value = new BetaThinkingConfigAdaptive() { Display = Display.Summarized };
        value.Validate();
    }

    [Fact]
    public void BetaThinkingConfigEnabledSerializationRoundtripWorks()
    {
        Thinking value = new BetaThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = BetaThinkingConfigEnabledDisplay.Summarized,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Thinking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaThinkingConfigDisabledSerializationRoundtripWorks()
    {
        Thinking value = new BetaThinkingConfigDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Thinking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaThinkingConfigAdaptiveSerializationRoundtripWorks()
    {
        Thinking value = new BetaThinkingConfigAdaptive() { Display = Display.Summarized };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Thinking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
