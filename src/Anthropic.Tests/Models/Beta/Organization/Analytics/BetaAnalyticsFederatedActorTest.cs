using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsFederatedActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActor
        {
            Provider = new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            },
            Subject = "subject",
        };

        BetaAnalyticsFederatedActorProvider expectedProvider =
            new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            };
        string expectedSubject = "subject";
        JsonElement expectedType = JsonSerializer.SerializeToElement("federated_actor");

        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedSubject, model.Subject);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActor
        {
            Provider = new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            },
            Subject = "subject",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsFederatedActor
        {
            Provider = new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            },
            Subject = "subject",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsFederatedActorProvider expectedProvider =
            new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            };
        string expectedSubject = "subject";
        JsonElement expectedType = JsonSerializer.SerializeToElement("federated_actor");

        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedSubject, deserialized.Subject);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsFederatedActor
        {
            Provider = new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            },
            Subject = "subject",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsFederatedActor
        {
            Provider = new BetaAnalyticsFederatedActorAwsProvider()
            {
                AccountID = "account_id",
                SignedPrincipal = "signed_principal",
            },
            Subject = "subject",
        };

        BetaAnalyticsFederatedActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
