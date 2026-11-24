using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewCaseOrderByTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewCaseOrderBy.CreatedAt)]
    [InlineData(BetaComplianceReviewCaseOrderBy.UpdatedAt)]
    public void Validation_Works(BetaComplianceReviewCaseOrderBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewCaseOrderBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewCaseOrderBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceReviewCaseOrderBy.CreatedAt, 1607052486, "created_at")]
    [InlineData(BetaComplianceReviewCaseOrderBy.UpdatedAt, 1777428345, "updated_at")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewCaseOrderBy rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewCaseOrderBy> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewCaseOrderBy>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewCaseOrderBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewCaseOrderBy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
