using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Organization.SpendLimits.IncreaseRequests;

public class SpendLimitIncreaseRequestStatusTest : TestBase
{
    [Theory]
    [InlineData(SpendLimitIncreaseRequestStatus.Approved)]
    [InlineData(SpendLimitIncreaseRequestStatus.Denied)]
    [InlineData(SpendLimitIncreaseRequestStatus.Pending)]
    public void Validation_Works(SpendLimitIncreaseRequestStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendLimitIncreaseRequestStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpendLimitIncreaseRequestStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SpendLimitIncreaseRequestStatus.Approved, 0, "approved")]
    [InlineData(SpendLimitIncreaseRequestStatus.Denied, 1, "denied")]
    [InlineData(SpendLimitIncreaseRequestStatus.Pending, 2, "pending")]
    public void EnumMemberSerializationRoundtrip_Works(
        SpendLimitIncreaseRequestStatus rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SpendLimitIncreaseRequestStatus> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SpendLimitIncreaseRequestStatus>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SpendLimitIncreaseRequestStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SpendLimitIncreaseRequestStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
