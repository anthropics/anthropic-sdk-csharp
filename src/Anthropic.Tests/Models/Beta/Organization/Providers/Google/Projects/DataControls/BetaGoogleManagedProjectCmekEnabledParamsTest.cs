using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectCmekEnabledParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        Dictionary<string, string?> expectedExternalKeyIds = new()
        {
            { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
        };

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
        var model = new BetaGoogleManagedProjectCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekEnabledParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekEnabledParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");
        Dictionary<string, string?> expectedExternalKeyIds = new()
        {
            { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
        };

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
        var model = new BetaGoogleManagedProjectCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabledParams { };

        Assert.Null(model.ExternalKeyIds);
        Assert.False(model.RawData.ContainsKey("external_key_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabledParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabledParams
        {
            // Null should be interpreted as omitted for these properties
            ExternalKeyIds = null,
        };

        Assert.Null(model.ExternalKeyIds);
        Assert.False(model.RawData.ContainsKey("external_key_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
        } with
        {
            // Null should be interpreted as omitted for these properties
            ExternalKeyIds = null,
        };

        Assert.Null(model.ExternalKeyIds);
        Assert.False(model.RawData.ContainsKey("external_key_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabledParams
        {
            // Null should be interpreted as omitted for these properties
            ExternalKeyIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabledParams
        {
            ExternalKeyIds = new Dictionary<string, string?>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
        };

        BetaGoogleManagedProjectCmekEnabledParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
