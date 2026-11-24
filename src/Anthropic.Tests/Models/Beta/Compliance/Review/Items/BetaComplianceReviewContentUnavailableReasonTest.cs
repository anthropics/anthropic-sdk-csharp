using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Items;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Items;

public class BetaComplianceReviewContentUnavailableReasonTest : TestBase
{
    [Fact]
    public void NotCapturedValidationWorks()
    {
        BetaComplianceReviewContentUnavailableReason value =
            new BetaComplianceReviewContentNotCaptured();
        value.Validate();
    }

    [Fact]
    public void StoredCopyUnavailableValidationWorks()
    {
        BetaComplianceReviewContentUnavailableReason value =
            new BetaComplianceReviewStoredCopyUnavailable();
        value.Validate();
    }

    [Fact]
    public void NotCapturedSerializationRoundtripWorks()
    {
        BetaComplianceReviewContentUnavailableReason value =
            new BetaComplianceReviewContentNotCaptured();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewContentUnavailableReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StoredCopyUnavailableSerializationRoundtripWorks()
    {
        BetaComplianceReviewContentUnavailableReason value =
            new BetaComplianceReviewStoredCopyUnavailable();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewContentUnavailableReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotCapturedTypeWorks()
    {
        BetaComplianceReviewContentUnavailableReason value =
            new BetaComplianceReviewContentNotCaptured();
        Assert.Equal(
            BetaComplianceReviewContentUnavailableReasonType.NotCaptured,
            value.Type.Value()
        );
    }

    [Fact]
    public void StoredCopyUnavailableTypeWorks()
    {
        BetaComplianceReviewContentUnavailableReason value =
            new BetaComplianceReviewStoredCopyUnavailable();
        Assert.Equal(
            BetaComplianceReviewContentUnavailableReasonType.StoredCopyUnavailable,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaComplianceReviewContentUnavailableReason value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "not_captured"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaComplianceReviewContentUnavailableReasonType> expectedType =
            BetaComplianceReviewContentUnavailableReasonType.NotCaptured;

        Assert.Equal(expectedType, value.Type);

        BetaComplianceReviewContentUnavailableReason emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaComplianceReviewContentUnavailableReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewContentUnavailableReasonType.NotCaptured)]
    [InlineData(BetaComplianceReviewContentUnavailableReasonType.StoredCopyUnavailable)]
    public void Validation_Works(BetaComplianceReviewContentUnavailableReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewContentUnavailableReasonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewContentUnavailableReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaComplianceReviewContentUnavailableReasonType.NotCaptured,
        656959855,
        "not_captured"
    )]
    [InlineData(
        BetaComplianceReviewContentUnavailableReasonType.StoredCopyUnavailable,
        618452559,
        "stored_copy_unavailable"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewContentUnavailableReasonType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewContentUnavailableReasonType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewContentUnavailableReasonType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewContentUnavailableReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewContentUnavailableReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
