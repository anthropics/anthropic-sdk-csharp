using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedCmekRegionFailedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedCmekRegionFailed
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };

        string expectedEffectiveExternalKeyID = "effective_external_key_id";
        string expectedError = "error";
        JsonElement expectedType = JsonSerializer.SerializeToElement("failed");

        Assert.Equal(expectedEffectiveExternalKeyID, model.EffectiveExternalKeyID);
        Assert.Equal(expectedError, model.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedCmekRegionFailed
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionFailed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedCmekRegionFailed
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionFailed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEffectiveExternalKeyID = "effective_external_key_id";
        string expectedError = "error";
        JsonElement expectedType = JsonSerializer.SerializeToElement("failed");

        Assert.Equal(expectedEffectiveExternalKeyID, deserialized.EffectiveExternalKeyID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedCmekRegionFailed
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedCmekRegionFailed
        {
            EffectiveExternalKeyID = "effective_external_key_id",
            Error = "error",
        };

        BetaGoogleManagedCmekRegionFailed copied = new(model);

        Assert.Equal(model, copied);
    }
}
