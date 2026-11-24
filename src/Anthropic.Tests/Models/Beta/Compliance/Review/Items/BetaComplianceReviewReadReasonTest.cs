using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Items;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Items;

public class BetaComplianceReviewReadReasonTest : TestBase
{
    [Fact]
    public void SafeguardsValidationWorks()
    {
        BetaComplianceReviewReadReason value = new BetaComplianceReviewSafeguardsReason();
        value.Validate();
    }

    [Fact]
    public void SafeguardsSerializationRoundtripWorks()
    {
        BetaComplianceReviewReadReason value = new BetaComplianceReviewSafeguardsReason();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewReadReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SafeguardsTypeWorks()
    {
        BetaComplianceReviewReadReason value = new BetaComplianceReviewSafeguardsReason();
        Assert.Equal(BetaComplianceReviewReadReasonType.SafeguardsReview, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaComplianceReviewReadReason value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "safeguards_review"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaComplianceReviewReadReasonType> expectedType =
            BetaComplianceReviewReadReasonType.SafeguardsReview;

        Assert.Equal(expectedType, value.Type);

        BetaComplianceReviewReadReason emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaComplianceReviewReadReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewReadReasonType.SafeguardsReview)]
    public void Validation_Works(BetaComplianceReviewReadReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewReadReasonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewReadReasonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaComplianceReviewReadReasonType.SafeguardsReview,
        748035249,
        "safeguards_review"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewReadReasonType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewReadReasonType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewReadReasonType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewReadReasonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewReadReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
