using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedRetiredKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "external_key_id",
            Region = "region",
        };

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalKeyID = "external_key_id";
        string expectedRegion = "region";

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedExternalKeyID, model.ExternalKeyID);
        Assert.Equal(expectedRegion, model.Region);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "external_key_id",
            Region = "region",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedRetiredKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "external_key_id",
            Region = "region",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedRetiredKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalKeyID = "external_key_id";
        string expectedRegion = "region";

        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedExternalKeyID, deserialized.ExternalKeyID);
        Assert.Equal(expectedRegion, deserialized.Region);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "external_key_id",
            Region = "region",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedRetiredKey
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalKeyID = "external_key_id",
            Region = "region",
        };

        BetaGoogleManagedRetiredKey copied = new(model);

        Assert.Equal(model, copied);
    }
}
