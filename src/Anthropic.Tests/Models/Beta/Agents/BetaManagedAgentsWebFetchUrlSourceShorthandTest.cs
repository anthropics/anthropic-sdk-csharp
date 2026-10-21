using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebFetchUrlSourceShorthandTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsWebFetchUrlSourceShorthand.All)]
    [InlineData(BetaManagedAgentsWebFetchUrlSourceShorthand.None)]
    public void Validation_Works(BetaManagedAgentsWebFetchUrlSourceShorthand rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsWebFetchUrlSourceShorthand.All)]
    [InlineData(BetaManagedAgentsWebFetchUrlSourceShorthand.None)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsWebFetchUrlSourceShorthand rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
