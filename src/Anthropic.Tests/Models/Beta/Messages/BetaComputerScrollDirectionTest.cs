using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerScrollDirectionTest : TestBase
{
    [Theory]
    [InlineData(BetaComputerScrollDirection.Up)]
    [InlineData(BetaComputerScrollDirection.Down)]
    [InlineData(BetaComputerScrollDirection.Left)]
    [InlineData(BetaComputerScrollDirection.Right)]
    public void Validation_Works(BetaComputerScrollDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComputerScrollDirection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComputerScrollDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComputerScrollDirection.Up)]
    [InlineData(BetaComputerScrollDirection.Down)]
    [InlineData(BetaComputerScrollDirection.Left)]
    [InlineData(BetaComputerScrollDirection.Right)]
    public void SerializationRoundtrip_Works(BetaComputerScrollDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComputerScrollDirection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaComputerScrollDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComputerScrollDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaComputerScrollDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
