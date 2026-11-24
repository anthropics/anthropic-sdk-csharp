using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedCmekRegionNotConfiguredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedCmekRegionNotConfigured
        {
            EffectiveExternalKeyID = "effective_external_key_id",
        };

        string expectedEffectiveExternalKeyID = "effective_external_key_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("not_configured");

        Assert.Equal(expectedEffectiveExternalKeyID, model.EffectiveExternalKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedCmekRegionNotConfigured
        {
            EffectiveExternalKeyID = "effective_external_key_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionNotConfigured>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedCmekRegionNotConfigured
        {
            EffectiveExternalKeyID = "effective_external_key_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionNotConfigured>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEffectiveExternalKeyID = "effective_external_key_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("not_configured");

        Assert.Equal(expectedEffectiveExternalKeyID, deserialized.EffectiveExternalKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedCmekRegionNotConfigured
        {
            EffectiveExternalKeyID = "effective_external_key_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedCmekRegionNotConfigured
        {
            EffectiveExternalKeyID = "effective_external_key_id",
        };

        BetaGoogleManagedCmekRegionNotConfigured copied = new(model);

        Assert.Equal(model, copied);
    }
}
