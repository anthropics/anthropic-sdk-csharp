using System.Text.Json;
using Anthropic.Core;
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
}
