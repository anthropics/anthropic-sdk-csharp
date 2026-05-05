using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Threads;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads;

public class BetaManagedAgentsSessionThreadStatusTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadStatus.Running)]
    [InlineData(BetaManagedAgentsSessionThreadStatus.Idle)]
    [InlineData(BetaManagedAgentsSessionThreadStatus.Rescheduling)]
    [InlineData(BetaManagedAgentsSessionThreadStatus.Terminated)]
    public void Validation_Works(BetaManagedAgentsSessionThreadStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadStatus.Running)]
    [InlineData(BetaManagedAgentsSessionThreadStatus.Idle)]
    [InlineData(BetaManagedAgentsSessionThreadStatus.Rescheduling)]
    [InlineData(BetaManagedAgentsSessionThreadStatus.Terminated)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionThreadStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
