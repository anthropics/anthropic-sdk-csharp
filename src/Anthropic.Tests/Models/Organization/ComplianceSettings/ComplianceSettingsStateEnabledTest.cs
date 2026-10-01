using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Organization.ComplianceSettings;

public class ComplianceSettingsStateEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComplianceSettingsStateEnabled { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComplianceSettingsStateEnabled { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsStateEnabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComplianceSettingsStateEnabled { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsStateEnabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComplianceSettingsStateEnabled { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComplianceSettingsStateEnabled { };

        ComplianceSettingsStateEnabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
