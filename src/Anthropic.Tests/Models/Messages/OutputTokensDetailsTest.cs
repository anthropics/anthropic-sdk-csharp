using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class OutputTokensDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputTokensDetails { ThinkingTokens = 0 };

        long expectedThinkingTokens = 0;

        Assert.Equal(expectedThinkingTokens, model.ThinkingTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputTokensDetails { ThinkingTokens = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputTokensDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputTokensDetails { ThinkingTokens = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputTokensDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedThinkingTokens = 0;

        Assert.Equal(expectedThinkingTokens, deserialized.ThinkingTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputTokensDetails { ThinkingTokens = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputTokensDetails { ThinkingTokens = 0 };

        OutputTokensDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
