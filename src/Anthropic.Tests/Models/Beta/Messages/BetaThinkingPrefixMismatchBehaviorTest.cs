using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingPrefixMismatchBehaviorTest : TestBase
{
    [Theory]
    [InlineData(BetaThinkingPrefixMismatchBehavior.Error)]
    [InlineData(BetaThinkingPrefixMismatchBehavior.DropBlock)]
    public void Validation_Works(BetaThinkingPrefixMismatchBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaThinkingPrefixMismatchBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaThinkingPrefixMismatchBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaThinkingPrefixMismatchBehavior.Error)]
    [InlineData(BetaThinkingPrefixMismatchBehavior.DropBlock)]
    public void SerializationRoundtrip_Works(BetaThinkingPrefixMismatchBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaThinkingPrefixMismatchBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingPrefixMismatchBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaThinkingPrefixMismatchBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingPrefixMismatchBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
