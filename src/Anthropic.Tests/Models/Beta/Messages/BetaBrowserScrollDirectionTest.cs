using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserScrollDirectionTest : TestBase
{
    [Theory]
    [InlineData(BetaBrowserScrollDirection.Up)]
    [InlineData(BetaBrowserScrollDirection.Down)]
    [InlineData(BetaBrowserScrollDirection.Left)]
    [InlineData(BetaBrowserScrollDirection.Right)]
    public void Validation_Works(BetaBrowserScrollDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserScrollDirection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserScrollDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaBrowserScrollDirection.Up)]
    [InlineData(BetaBrowserScrollDirection.Down)]
    [InlineData(BetaBrowserScrollDirection.Left)]
    [InlineData(BetaBrowserScrollDirection.Right)]
    public void SerializationRoundtrip_Works(BetaBrowserScrollDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserScrollDirection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserScrollDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserScrollDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserScrollDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
