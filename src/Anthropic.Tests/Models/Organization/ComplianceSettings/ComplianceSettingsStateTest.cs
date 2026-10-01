using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Organization.ComplianceSettings;

public class ComplianceSettingsStateTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateEnabled();
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateDisabled();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateEnabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        ComplianceSettingsState value = new ComplianceSettingsStateDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ComplianceSettingsState value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        ComplianceSettingsState emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
