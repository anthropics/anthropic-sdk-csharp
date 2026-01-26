using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCountTokensContextManagementResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCountTokensContextManagementResponse { OriginalInputTokens = 0 };

        long expectedOriginalInputTokens = 0;

        Assert.Equal(expectedOriginalInputTokens, model.OriginalInputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCountTokensContextManagementResponse { OriginalInputTokens = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCountTokensContextManagementResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCountTokensContextManagementResponse { OriginalInputTokens = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCountTokensContextManagementResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedOriginalInputTokens = 0;

        Assert.Equal(expectedOriginalInputTokens, deserialized.OriginalInputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCountTokensContextManagementResponse { OriginalInputTokens = 0 };

        model.Validate();
    }
}
