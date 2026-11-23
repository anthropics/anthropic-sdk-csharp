using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ComplianceSettings;

public class BetaComplianceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceSettings
        {
            State = new BetaComplianceSettingsStateEnabled(),
            AccessTransparency = new(Type.Disabled),
        };

        BetaComplianceSettingsState expectedState = new BetaComplianceSettingsStateEnabled();
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_settings");
        BetaAccessTransparency expectedAccessTransparency = new(Type.Disabled);

        Assert.Equal(expectedState, model.State);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAccessTransparency, model.AccessTransparency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceSettings
        {
            State = new BetaComplianceSettingsStateEnabled(),
            AccessTransparency = new(Type.Disabled),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceSettings
        {
            State = new BetaComplianceSettingsStateEnabled(),
            AccessTransparency = new(Type.Disabled),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaComplianceSettingsState expectedState = new BetaComplianceSettingsStateEnabled();
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_settings");
        BetaAccessTransparency expectedAccessTransparency = new(Type.Disabled);

        Assert.Equal(expectedState, deserialized.State);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedAccessTransparency, deserialized.AccessTransparency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceSettings
        {
            State = new BetaComplianceSettingsStateEnabled(),
            AccessTransparency = new(Type.Disabled),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComplianceSettings { State = new BetaComplianceSettingsStateEnabled() };

        Assert.Null(model.AccessTransparency);
        Assert.False(model.RawData.ContainsKey("access_transparency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComplianceSettings { State = new BetaComplianceSettingsStateEnabled() };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaComplianceSettings
        {
            State = new BetaComplianceSettingsStateEnabled(),

            // Null should be interpreted as omitted for these properties
            AccessTransparency = null,
        };

        Assert.Null(model.AccessTransparency);
        Assert.False(model.RawData.ContainsKey("access_transparency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaComplianceSettings
        {
            State = new BetaComplianceSettingsStateEnabled(),
            AccessTransparency = new(Type.Disabled),
        } with
        {
            // Null should be interpreted as omitted for these properties
            AccessTransparency = null,
        };

        Assert.Null(model.AccessTransparency);
        Assert.False(model.RawData.ContainsKey("access_transparency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaComplianceSettings
        {
            State = new BetaComplianceSettingsStateEnabled(),

            // Null should be interpreted as omitted for these properties
            AccessTransparency = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceSettings
        {
            State = new BetaComplianceSettingsStateEnabled(),
            AccessTransparency = new(Type.Disabled),
        };

        BetaComplianceSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}
