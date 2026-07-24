using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFallbacksParamTest : TestBase
{
    [Fact]
    public void BetaFallbackParamsValidationWorks()
    {
        BetaFallbacksParam value = new(
            [
                new BetaFallbackParam()
                {
                    Model = Messages::Model.ClaudeSonnet5,
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
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void DefaultValidationWorks()
    {
        BetaFallbacksParam value = new Default();
        value.Validate();
    }

    [Fact]
    public void BetaFallbackParamsSerializationRoundtripWorks()
    {
        BetaFallbacksParam value = new(
            [
                new BetaFallbackParam()
                {
                    Model = Messages::Model.ClaudeSonnet5,
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
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbacksParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DefaultSerializationRoundtripWorks()
    {
        BetaFallbacksParam value = new Default();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbacksParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DefaultTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Default();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Default>(
            JsonSerializer.SerializeToElement("default"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<Default>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<AnthropicInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Default();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Default>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Default>(
            JsonSerializer.SerializeToElement("default"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Default>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Default>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Default>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}
