using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Organization.ComplianceSettings;

public class OrganizationComplianceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OrganizationComplianceSettings
        {
            State = new ComplianceSettingsStateEnabled(),
        };

        ComplianceSettingsState expectedState = new ComplianceSettingsStateEnabled();
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_settings");

        Assert.Equal(expectedState, model.State);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OrganizationComplianceSettings
        {
            State = new ComplianceSettingsStateEnabled(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrganizationComplianceSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OrganizationComplianceSettings
        {
            State = new ComplianceSettingsStateEnabled(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrganizationComplianceSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ComplianceSettingsState expectedState = new ComplianceSettingsStateEnabled();
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_settings");

        Assert.Equal(expectedState, deserialized.State);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OrganizationComplianceSettings
        {
            State = new ComplianceSettingsStateEnabled(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OrganizationComplianceSettings
        {
            State = new ComplianceSettingsStateEnabled(),
        };

        OrganizationComplianceSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}
