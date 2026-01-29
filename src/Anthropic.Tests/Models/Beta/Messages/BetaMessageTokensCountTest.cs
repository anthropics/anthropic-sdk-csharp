using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMessageTokensCountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageTokensCount { ContextManagement = new(0), InputTokens = 2095 };

        BetaCountTokensContextManagementResponse expectedContextManagement = new(0);
        long expectedInputTokens = 2095;

        Assert.Equal(expectedContextManagement, model.ContextManagement);
        Assert.Equal(expectedInputTokens, model.InputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageTokensCount { ContextManagement = new(0), InputTokens = 2095 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageTokensCount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMessageTokensCount { ContextManagement = new(0), InputTokens = 2095 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageTokensCount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCountTokensContextManagementResponse expectedContextManagement = new(0);
        long expectedInputTokens = 2095;

        Assert.Equal(expectedContextManagement, deserialized.ContextManagement);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageTokensCount { ContextManagement = new(0), InputTokens = 2095 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMessageTokensCount { ContextManagement = new(0), InputTokens = 2095 };

        BetaMessageTokensCount copied = new(model);

        Assert.Equal(model, copied);
    }
}
