using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewDeterminationTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewDetermination.Violation)]
    [InlineData(BetaComplianceReviewDetermination.NoViolation)]
    public void Validation_Works(BetaComplianceReviewDetermination rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewDetermination> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewDetermination>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceReviewDetermination.Violation, 572662914, "violation")]
    [InlineData(BetaComplianceReviewDetermination.NoViolation, 1791738098, "no_violation")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewDetermination rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewDetermination> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewDetermination>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewDetermination>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewDetermination>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
