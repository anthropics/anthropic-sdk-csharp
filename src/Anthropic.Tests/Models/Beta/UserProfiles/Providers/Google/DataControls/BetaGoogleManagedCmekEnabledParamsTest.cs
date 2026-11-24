using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedCmekEnabledParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        Dictionary<string, string?> expectedExternalKeyIds = new() { { "foo", "string" } };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.ExternalKeyIds);
        Assert.Equal(expectedExternalKeyIds.Count, model.ExternalKeyIds.Count);
        foreach (var item in expectedExternalKeyIds)
        {
            Assert.True(model.ExternalKeyIds.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ExternalKeyIds[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekEnabledParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekEnabledParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        Dictionary<string, string?> expectedExternalKeyIds = new() { { "foo", "string" } };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.ExternalKeyIds);
        Assert.Equal(expectedExternalKeyIds.Count, deserialized.ExternalKeyIds.Count);
        foreach (var item in expectedExternalKeyIds)
        {
            Assert.True(deserialized.ExternalKeyIds.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ExternalKeyIds[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaGoogleManagedCmekEnabledParams { };

        Assert.Null(model.ExternalKeyIds);
        Assert.False(model.RawData.ContainsKey("external_key_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaGoogleManagedCmekEnabledParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaGoogleManagedCmekEnabledParams { ExternalKeyIds = null };

        Assert.Null(model.ExternalKeyIds);
        Assert.True(model.RawData.ContainsKey("external_key_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaGoogleManagedCmekEnabledParams { ExternalKeyIds = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        BetaGoogleManagedCmekEnabledParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
