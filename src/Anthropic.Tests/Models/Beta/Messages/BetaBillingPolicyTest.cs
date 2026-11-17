using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBillingPolicyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBillingPolicy { BillTo = BetaBillTo.Self };

        JsonElement expectedType = JsonSerializer.SerializeToElement("billing_policy");
        ApiEnum<string, BetaBillTo> expectedBillTo = BetaBillTo.Self;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBillTo, model.BillTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBillingPolicy { BillTo = BetaBillTo.Self };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBillingPolicy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBillingPolicy { BillTo = BetaBillTo.Self };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBillingPolicy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("billing_policy");
        ApiEnum<string, BetaBillTo> expectedBillTo = BetaBillTo.Self;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBillTo, deserialized.BillTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBillingPolicy { BillTo = BetaBillTo.Self };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBillingPolicy { };

        Assert.Null(model.BillTo);
        Assert.False(model.RawData.ContainsKey("bill_to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBillingPolicy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaBillingPolicy
        {
            // Null should be interpreted as omitted for these properties
            BillTo = null,
        };

        Assert.Null(model.BillTo);
        Assert.False(model.RawData.ContainsKey("bill_to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaBillingPolicy { BillTo = BetaBillTo.Self } with
        {
            // Null should be interpreted as omitted for these properties
            BillTo = null,
        };

        Assert.Null(model.BillTo);
        Assert.False(model.RawData.ContainsKey("bill_to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBillingPolicy
        {
            // Null should be interpreted as omitted for these properties
            BillTo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBillingPolicy { BillTo = BetaBillTo.Self };

        BetaBillingPolicy copied = new(model);

        Assert.Equal(model, copied);
    }
}
