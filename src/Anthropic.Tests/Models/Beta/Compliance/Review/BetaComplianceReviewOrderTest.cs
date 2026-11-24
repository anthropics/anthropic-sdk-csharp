using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review;

namespace Anthropic.Tests.Models.Beta.Compliance.Review;

public class BetaComplianceReviewOrderTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewOrder.Asc)]
    [InlineData(BetaComplianceReviewOrder.Desc)]
    public void Validation_Works(BetaComplianceReviewOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewOrder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceReviewOrder.Asc, 755640198, "asc")]
    [InlineData(BetaComplianceReviewOrder.Desc, 1005339449, "desc")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewOrder rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewOrder> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewOrder>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
