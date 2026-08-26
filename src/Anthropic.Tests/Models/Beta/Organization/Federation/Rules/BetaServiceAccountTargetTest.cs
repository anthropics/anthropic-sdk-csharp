using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Rules;

public class BetaServiceAccountTargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServiceAccountTarget
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };

        string expectedServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK";
        JsonElement expectedType = JsonSerializer.SerializeToElement("service_account");
        string expectedServiceAccountName = "service_account_name";

        Assert.Equal(expectedServiceAccountID, model.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedServiceAccountName, model.ServiceAccountName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaServiceAccountTarget
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServiceAccountTarget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaServiceAccountTarget
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServiceAccountTarget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK";
        JsonElement expectedType = JsonSerializer.SerializeToElement("service_account");
        string expectedServiceAccountName = "service_account_name";

        Assert.Equal(expectedServiceAccountID, deserialized.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedServiceAccountName, deserialized.ServiceAccountName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaServiceAccountTarget
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaServiceAccountTarget
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
        };

        Assert.Null(model.ServiceAccountName);
        Assert.False(model.RawData.ContainsKey("service_account_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaServiceAccountTarget
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaServiceAccountTarget
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",

            ServiceAccountName = null,
        };

        Assert.Null(model.ServiceAccountName);
        Assert.True(model.RawData.ContainsKey("service_account_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaServiceAccountTarget
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",

            ServiceAccountName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaServiceAccountTarget
        {
            ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ServiceAccountName = "service_account_name",
        };

        BetaServiceAccountTarget copied = new(model);

        Assert.Equal(model, copied);
    }
}
