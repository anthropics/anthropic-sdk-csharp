using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Tests.Models.Beta.MemoryStores.MemoryVersions;

public class BetaManagedAgentsMemoryVersionOperationTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryVersionOperation.Created)]
    [InlineData(BetaManagedAgentsMemoryVersionOperation.Modified)]
    [InlineData(BetaManagedAgentsMemoryVersionOperation.Deleted)]
    public void Validation_Works(BetaManagedAgentsMemoryVersionOperation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryVersionOperation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryVersionOperation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryVersionOperation.Created)]
    [InlineData(BetaManagedAgentsMemoryVersionOperation.Modified)]
    [InlineData(BetaManagedAgentsMemoryVersionOperation.Deleted)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMemoryVersionOperation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryVersionOperation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryVersionOperation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryVersionOperation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryVersionOperation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
