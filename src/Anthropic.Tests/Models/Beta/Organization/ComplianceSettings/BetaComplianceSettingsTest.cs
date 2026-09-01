using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ComplianceSettings;

public class BetaComplianceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceSettings { State = new BetaComplianceSettingsStateEnabled() };

        BetaComplianceSettingsState expectedState = new BetaComplianceSettingsStateEnabled();
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_settings");

        Assert.Equal(expectedState, model.State);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceSettings { State = new BetaComplianceSettingsStateEnabled() };

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
        var model = new BetaComplianceSettings { State = new BetaComplianceSettingsStateEnabled() };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaComplianceSettingsState expectedState = new BetaComplianceSettingsStateEnabled();
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_settings");

        Assert.Equal(expectedState, deserialized.State);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceSettings { State = new BetaComplianceSettingsStateEnabled() };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceSettings { State = new BetaComplianceSettingsStateEnabled() };

        BetaComplianceSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaComplianceSettingsStateTest : TestBase
{
    [Fact]
    public void BetaComplianceSettingsStateEnabledValidationWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateEnabled();
        value.Validate();
    }

    [Fact]
    public void BetaComplianceSettingsStateDisabledValidationWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateDisabled();
        value.Validate();
    }

    [Fact]
    public void BetaComplianceSettingsStateEnabledSerializationRoundtripWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateEnabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceSettingsState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaComplianceSettingsStateDisabledSerializationRoundtripWorks()
    {
        BetaComplianceSettingsState value = new BetaComplianceSettingsStateDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceSettingsState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
