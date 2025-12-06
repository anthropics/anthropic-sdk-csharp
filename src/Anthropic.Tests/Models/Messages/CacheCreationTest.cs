using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CacheCreationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CacheCreation { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 };

        long expectedEphemeral1hInputTokens = 0;
        long expectedEphemeral5mInputTokens = 0;

        Assert.Equal(expectedEphemeral1hInputTokens, model.Ephemeral1hInputTokens);
        Assert.Equal(expectedEphemeral5mInputTokens, model.Ephemeral5mInputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CacheCreation { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CacheCreation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CacheCreation { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CacheCreation>(json);
        Assert.NotNull(deserialized);

        long expectedEphemeral1hInputTokens = 0;
        long expectedEphemeral5mInputTokens = 0;

        Assert.Equal(expectedEphemeral1hInputTokens, deserialized.Ephemeral1hInputTokens);
        Assert.Equal(expectedEphemeral5mInputTokens, deserialized.Ephemeral5mInputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CacheCreation { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 };

        model.Validate();
    }
}
