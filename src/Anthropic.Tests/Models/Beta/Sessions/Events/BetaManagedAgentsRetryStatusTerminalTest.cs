using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsRetryStatusTerminalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRetryStatusTerminal
        {
            Type = BetaManagedAgentsRetryStatusTerminalType.Terminal,
        };

        ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType> expectedType =
            BetaManagedAgentsRetryStatusTerminalType.Terminal;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRetryStatusTerminal
        {
            Type = BetaManagedAgentsRetryStatusTerminalType.Terminal,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRetryStatusTerminal>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsRetryStatusTerminal
        {
            Type = BetaManagedAgentsRetryStatusTerminalType.Terminal,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRetryStatusTerminal>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType> expectedType =
            BetaManagedAgentsRetryStatusTerminalType.Terminal;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsRetryStatusTerminal
        {
            Type = BetaManagedAgentsRetryStatusTerminalType.Terminal,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsRetryStatusTerminal
        {
            Type = BetaManagedAgentsRetryStatusTerminalType.Terminal,
        };

        BetaManagedAgentsRetryStatusTerminal copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsRetryStatusTerminalTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsRetryStatusTerminalType.Terminal)]
    public void Validation_Works(BetaManagedAgentsRetryStatusTerminalType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsRetryStatusTerminalType.Terminal)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsRetryStatusTerminalType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
