using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFallbackCreditNotAppliedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFallbackCreditNotApplied
        {
            Reason = Reason.BodyMismatch,
            RemoveToRedeem = ["string"],
        };

        ApiEnum<string, Reason> expectedReason = Reason.BodyMismatch;
        JsonElement expectedType = JsonSerializer.SerializeToElement("not_applied");
        List<string> expectedRemoveToRedeem = ["string"];

        Assert.Equal(expectedReason, model.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.RemoveToRedeem);
        Assert.Equal(expectedRemoveToRedeem.Count, model.RemoveToRedeem.Count);
        for (int i = 0; i < expectedRemoveToRedeem.Count; i++)
        {
            Assert.Equal(expectedRemoveToRedeem[i], model.RemoveToRedeem[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFallbackCreditNotApplied
        {
            Reason = Reason.BodyMismatch,
            RemoveToRedeem = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackCreditNotApplied>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFallbackCreditNotApplied
        {
            Reason = Reason.BodyMismatch,
            RemoveToRedeem = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackCreditNotApplied>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Reason> expectedReason = Reason.BodyMismatch;
        JsonElement expectedType = JsonSerializer.SerializeToElement("not_applied");
        List<string> expectedRemoveToRedeem = ["string"];

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.RemoveToRedeem);
        Assert.Equal(expectedRemoveToRedeem.Count, deserialized.RemoveToRedeem.Count);
        for (int i = 0; i < expectedRemoveToRedeem.Count; i++)
        {
            Assert.Equal(expectedRemoveToRedeem[i], deserialized.RemoveToRedeem[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFallbackCreditNotApplied
        {
            Reason = Reason.BodyMismatch,
            RemoveToRedeem = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaFallbackCreditNotApplied { Reason = Reason.BodyMismatch };

        Assert.Null(model.RemoveToRedeem);
        Assert.False(model.RawData.ContainsKey("remove_to_redeem"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaFallbackCreditNotApplied { Reason = Reason.BodyMismatch };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaFallbackCreditNotApplied
        {
            Reason = Reason.BodyMismatch,

            RemoveToRedeem = null,
        };

        Assert.Null(model.RemoveToRedeem);
        Assert.True(model.RawData.ContainsKey("remove_to_redeem"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaFallbackCreditNotApplied
        {
            Reason = Reason.BodyMismatch,

            RemoveToRedeem = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFallbackCreditNotApplied
        {
            Reason = Reason.BodyMismatch,
            RemoveToRedeem = ["string"],
        };

        BetaFallbackCreditNotApplied copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.BodyMismatch)]
    [InlineData(Reason.ContinuationExcluded)]
    [InlineData(Reason.ContinuationOnly)]
    [InlineData(Reason.Expired)]
    [InlineData(Reason.InvalidTargetModel)]
    [InlineData(Reason.NotEnabled)]
    [InlineData(Reason.RepriceUnavailable)]
    [InlineData(Reason.TemporarilyUnavailable)]
    [InlineData(Reason.VariantFieldsPresent)]
    [InlineData(Reason.WrongOrganization)]
    [InlineData(Reason.WrongPlatform)]
    [InlineData(Reason.WrongWorkspace)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.BodyMismatch)]
    [InlineData(Reason.ContinuationExcluded)]
    [InlineData(Reason.ContinuationOnly)]
    [InlineData(Reason.Expired)]
    [InlineData(Reason.InvalidTargetModel)]
    [InlineData(Reason.NotEnabled)]
    [InlineData(Reason.RepriceUnavailable)]
    [InlineData(Reason.TemporarilyUnavailable)]
    [InlineData(Reason.VariantFieldsPresent)]
    [InlineData(Reason.WrongOrganization)]
    [InlineData(Reason.WrongPlatform)]
    [InlineData(Reason.WrongWorkspace)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
