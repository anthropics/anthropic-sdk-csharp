using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class BetaSpendLimitIncreaseRequestStatusTest : TestBase
{
    [Theory]
    [InlineData(BetaSpendLimitIncreaseRequestStatus.Approved)]
    [InlineData(BetaSpendLimitIncreaseRequestStatus.Denied)]
    [InlineData(BetaSpendLimitIncreaseRequestStatus.Pending)]
    public void Validation_Works(BetaSpendLimitIncreaseRequestStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendLimitIncreaseRequestStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaSpendLimitIncreaseRequestStatus.Approved)]
    [InlineData(BetaSpendLimitIncreaseRequestStatus.Denied)]
    [InlineData(BetaSpendLimitIncreaseRequestStatus.Pending)]
    public void SerializationRoundtrip_Works(BetaSpendLimitIncreaseRequestStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSpendLimitIncreaseRequestStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSpendLimitIncreaseRequestStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
