using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Organization.ComplianceSettings;

public class ComplianceSettingsStateDisabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComplianceSettingsStateDisabled { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComplianceSettingsStateDisabled { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsStateDisabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComplianceSettingsStateDisabled { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsStateDisabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComplianceSettingsStateDisabled { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComplianceSettingsStateDisabled { };

        ComplianceSettingsStateDisabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
