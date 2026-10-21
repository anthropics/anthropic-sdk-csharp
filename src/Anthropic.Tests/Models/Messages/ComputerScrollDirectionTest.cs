using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerScrollDirectionTest : TestBase
{
    [Theory]
    [InlineData(ComputerScrollDirection.Up)]
    [InlineData(ComputerScrollDirection.Down)]
    [InlineData(ComputerScrollDirection.Left)]
    [InlineData(ComputerScrollDirection.Right)]
    public void Validation_Works(ComputerScrollDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComputerScrollDirection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComputerScrollDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ComputerScrollDirection.Up)]
    [InlineData(ComputerScrollDirection.Down)]
    [InlineData(ComputerScrollDirection.Left)]
    [InlineData(ComputerScrollDirection.Right)]
    public void SerializationRoundtrip_Works(ComputerScrollDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComputerScrollDirection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComputerScrollDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComputerScrollDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComputerScrollDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
