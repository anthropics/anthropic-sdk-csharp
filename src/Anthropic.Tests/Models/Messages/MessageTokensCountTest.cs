using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageTokensCountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageTokensCount { InputTokens = 2095 };

        long expectedInputTokens = 2095;

        Assert.Equal(expectedInputTokens, model.InputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageTokensCount { InputTokens = 2095 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageTokensCount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageTokensCount { InputTokens = 2095 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageTokensCount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedInputTokens = 2095;

        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageTokensCount { InputTokens = 2095 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageTokensCount { InputTokens = 2095 };

        MessageTokensCount copied = new(model);

        Assert.Equal(model, copied);
    }
}
