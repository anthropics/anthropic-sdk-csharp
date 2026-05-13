using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCacheMissMessagesChangedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCacheMissMessagesChanged { CacheMissedInputTokens = 0 };

        long expectedCacheMissedInputTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("messages_changed");

        Assert.Equal(expectedCacheMissedInputTokens, model.CacheMissedInputTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCacheMissMessagesChanged { CacheMissedInputTokens = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCacheMissMessagesChanged>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCacheMissMessagesChanged { CacheMissedInputTokens = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCacheMissMessagesChanged>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCacheMissedInputTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("messages_changed");

        Assert.Equal(expectedCacheMissedInputTokens, deserialized.CacheMissedInputTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCacheMissMessagesChanged { CacheMissedInputTokens = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCacheMissMessagesChanged { CacheMissedInputTokens = 0 };

        BetaCacheMissMessagesChanged copied = new(model);

        Assert.Equal(model, copied);
    }
}
