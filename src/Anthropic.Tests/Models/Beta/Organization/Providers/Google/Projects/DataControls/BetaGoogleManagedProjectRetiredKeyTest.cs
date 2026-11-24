using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectRetiredKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Region = "us",
        };

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        string expectedRegion = "us";

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedExternalKeyID, model.ExternalKeyID);
        Assert.Equal(expectedRegion, model.Region);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Region = "us",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectRetiredKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Region = "us",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectRetiredKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        string expectedRegion = "us";

        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedExternalKeyID, deserialized.ExternalKeyID);
        Assert.Equal(expectedRegion, deserialized.Region);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Region = "us",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Region = "us",
        };

        BetaGoogleManagedProjectRetiredKey copied = new(model);

        Assert.Equal(model, copied);
    }
}
