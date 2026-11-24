using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectCmekRegionActiveTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectCmekRegionActive
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
            LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedEffectiveExternalKeyID = "effective_external_key_id";
        string expectedError = "error";
        DateTimeOffset expectedLastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("active");
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEffectiveExternalKeyID, model.EffectiveExternalKeyID);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedLastCheckedAt, model.LastCheckedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValidatedAt, model.ValidatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectCmekRegionActive
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
            LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionActive>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectCmekRegionActive
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
            LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionActive>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEffectiveExternalKeyID = "effective_external_key_id";
        string expectedError = "error";
        DateTimeOffset expectedLastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("active");
        DateTimeOffset expectedValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEffectiveExternalKeyID, deserialized.EffectiveExternalKeyID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedLastCheckedAt, deserialized.LastCheckedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedValidatedAt, deserialized.ValidatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectCmekRegionActive
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
            LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectCmekRegionActive
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
            LastCheckedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaGoogleManagedProjectCmekRegionActive copied = new(model);

        Assert.Equal(model, copied);
    }
}
