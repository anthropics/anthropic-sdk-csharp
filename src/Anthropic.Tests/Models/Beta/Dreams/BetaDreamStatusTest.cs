using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamStatusTest : TestBase
{
    [Theory]
    [InlineData(BetaDreamStatus.Pending)]
    [InlineData(BetaDreamStatus.Running)]
    [InlineData(BetaDreamStatus.Completed)]
    [InlineData(BetaDreamStatus.Failed)]
    [InlineData(BetaDreamStatus.Canceled)]
    public void Validation_Works(BetaDreamStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDreamStatus.Pending)]
    [InlineData(BetaDreamStatus.Running)]
    [InlineData(BetaDreamStatus.Completed)]
    [InlineData(BetaDreamStatus.Failed)]
    [InlineData(BetaDreamStatus.Canceled)]
    public void SerializationRoundtrip_Works(BetaDreamStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
