using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFallbackCreditUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFallbackCreditUsage { Status = new BetaFallbackCreditRedeemed() };

        Status expectedStatus = new BetaFallbackCreditRedeemed();

        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFallbackCreditUsage { Status = new BetaFallbackCreditRedeemed() };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackCreditUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFallbackCreditUsage { Status = new BetaFallbackCreditRedeemed() };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackCreditUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Status expectedStatus = new BetaFallbackCreditRedeemed();

        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFallbackCreditUsage { Status = new BetaFallbackCreditRedeemed() };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFallbackCreditUsage { Status = new BetaFallbackCreditRedeemed() };

        BetaFallbackCreditUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Fact]
    public void BetaFallbackCreditRedeemedValidationWorks()
    {
        Status value = new BetaFallbackCreditRedeemed();
        value.Validate();
    }

    [Fact]
    public void BetaFallbackCreditNotAppliedValidationWorks()
    {
        Status value = new BetaFallbackCreditNotApplied()
        {
            Reason = Reason.BodyMismatch,
            RemoveToRedeem = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void BetaFallbackCreditRedeemedSerializationRoundtripWorks()
    {
        Status value = new BetaFallbackCreditRedeemed();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaFallbackCreditNotAppliedSerializationRoundtripWorks()
    {
        Status value = new BetaFallbackCreditNotApplied()
        {
            Reason = Reason.BodyMismatch,
            RemoveToRedeem = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaFallbackCreditRedeemedTypeWorks()
    {
        Status value = new BetaFallbackCreditRedeemed();
        Assert.Equal(StatusType.Redeemed, value.Type.Value());
    }

    [Fact]
    public void BetaFallbackCreditNotAppliedTypeWorks()
    {
        Status value = new BetaFallbackCreditNotApplied()
        {
            Reason = Reason.BodyMismatch,
            RemoveToRedeem = ["string"],
        };
        Assert.Equal(StatusType.NotApplied, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Status value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "redeemed"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, StatusType> expectedType = StatusType.Redeemed;

        Assert.Equal(expectedType, value.Type);

        Status emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class StatusTypeTest : TestBase
{
    [Theory]
    [InlineData(StatusType.Redeemed)]
    [InlineData(StatusType.NotApplied)]
    public void Validation_Works(StatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StatusType.Redeemed)]
    [InlineData(StatusType.NotApplied)]
    public void SerializationRoundtrip_Works(StatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatusType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatusType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatusType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
