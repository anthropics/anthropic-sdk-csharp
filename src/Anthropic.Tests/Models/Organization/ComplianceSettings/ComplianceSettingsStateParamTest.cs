using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Organization.ComplianceSettings;

public class ComplianceSettingsStateParamTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateEnabledParam();
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateDisabledParam();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateEnabledParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsStateParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        ComplianceSettingsStateParam value = new ComplianceSettingsStateDisabledParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComplianceSettingsStateParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ComplianceSettingsStateParam value = new(
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

        ComplianceSettingsStateParam emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
