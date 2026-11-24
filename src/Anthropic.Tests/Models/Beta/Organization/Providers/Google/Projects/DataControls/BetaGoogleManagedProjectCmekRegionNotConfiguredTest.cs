using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectCmekRegionNotConfiguredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectCmekRegionNotConfigured
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
        var model = new BetaGoogleManagedProjectCmekRegionNotConfigured
        {
            EffectiveExternalKeyID = "effective_external_key_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionNotConfigured>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectCmekRegionNotConfigured
        {
            EffectiveExternalKeyID = "effective_external_key_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionNotConfigured>(
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
        var model = new BetaGoogleManagedProjectCmekRegionNotConfigured
        {
            EffectiveExternalKeyID = "effective_external_key_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectCmekRegionNotConfigured
        {
            EffectiveExternalKeyID = "effective_external_key_id",
        };

        BetaGoogleManagedProjectCmekRegionNotConfigured copied = new(model);

        Assert.Equal(model, copied);
    }
}
