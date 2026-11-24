using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewCaseStatusTest : TestBase
{
    [Fact]
    public void OpenValidationWorks()
    {
        BetaComplianceReviewCaseStatus value = new BetaComplianceReviewCaseOpen();
        value.Validate();
    }

    [Fact]
    public void ClosedValidationWorks()
    {
        BetaComplianceReviewCaseStatus value = new BetaComplianceReviewCaseClosed(
            new BetaComplianceReviewCaseCloseReason(Type.Responded)
        );
        value.Validate();
    }

    [Fact]
    public void OpenSerializationRoundtripWorks()
    {
        BetaComplianceReviewCaseStatus value = new BetaComplianceReviewCaseOpen();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewCaseStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClosedSerializationRoundtripWorks()
    {
        BetaComplianceReviewCaseStatus value = new BetaComplianceReviewCaseClosed(
            new BetaComplianceReviewCaseCloseReason(Type.Responded)
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewCaseStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OpenTypeWorks()
    {
        BetaComplianceReviewCaseStatus value = new BetaComplianceReviewCaseOpen();
        Assert.Equal(BetaComplianceReviewCaseStatusType.Open, value.Type.Value());
    }

    [Fact]
    public void ClosedTypeWorks()
    {
        BetaComplianceReviewCaseStatus value = new BetaComplianceReviewCaseClosed(
            new BetaComplianceReviewCaseCloseReason(Type.Responded)
        );
        Assert.Equal(BetaComplianceReviewCaseStatusType.Closed, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaComplianceReviewCaseStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "open"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaComplianceReviewCaseStatusType> expectedType =
            BetaComplianceReviewCaseStatusType.Open;

        Assert.Equal(expectedType, value.Type);

        BetaComplianceReviewCaseStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaComplianceReviewCaseStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewCaseStatusType.Open)]
    [InlineData(BetaComplianceReviewCaseStatusType.Closed)]
    public void Validation_Works(BetaComplianceReviewCaseStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewCaseStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewCaseStatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceReviewCaseStatusType.Open, 452966999, "open")]
    [InlineData(BetaComplianceReviewCaseStatusType.Closed, 24219560, "closed")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewCaseStatusType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewCaseStatusType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewCaseStatusType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewCaseStatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewCaseStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
