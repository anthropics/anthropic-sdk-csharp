using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCacheCreationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCacheCreation
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        long expectedEphemeral1hInputTokens = 0;
        long expectedEphemeral5mInputTokens = 0;

        Assert.Equal(expectedEphemeral1hInputTokens, model.Ephemeral1hInputTokens);
        Assert.Equal(expectedEphemeral5mInputTokens, model.Ephemeral5mInputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCacheCreation
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCacheCreation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCacheCreation
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCacheCreation>(json);
        Assert.NotNull(deserialized);

        long expectedEphemeral1hInputTokens = 0;
        long expectedEphemeral5mInputTokens = 0;

        Assert.Equal(expectedEphemeral1hInputTokens, deserialized.Ephemeral1hInputTokens);
        Assert.Equal(expectedEphemeral5mInputTokens, deserialized.Ephemeral5mInputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCacheCreation
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        model.Validate();
    }
}
