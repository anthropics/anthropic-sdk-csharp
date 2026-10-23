using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsFederatedActorAwsProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActorAwsProvider
        {
            AccountID = "account_id",
            SignedPrincipal = "signed_principal",
        };

        string expectedAccountID = "account_id";
        string expectedSignedPrincipal = "signed_principal";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws");

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedSignedPrincipal, model.SignedPrincipal);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActorAwsProvider
        {
            AccountID = "account_id",
            SignedPrincipal = "signed_principal",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorAwsProvider>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsFederatedActorAwsProvider
        {
            AccountID = "account_id",
            SignedPrincipal = "signed_principal",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorAwsProvider>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        string expectedSignedPrincipal = "signed_principal";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws");

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedSignedPrincipal, deserialized.SignedPrincipal);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsFederatedActorAwsProvider
        {
            AccountID = "account_id",
            SignedPrincipal = "signed_principal",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsFederatedActorAwsProvider
        {
            AccountID = "account_id",
            SignedPrincipal = "signed_principal",
        };

        BetaAnalyticsFederatedActorAwsProvider copied = new(model);

        Assert.Equal(model, copied);
    }
}
