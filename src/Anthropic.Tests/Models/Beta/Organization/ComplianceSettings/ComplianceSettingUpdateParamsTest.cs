using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ComplianceSettings;

public class ComplianceSettingUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ComplianceSettingUpdateParams
        {
            State = new BetaComplianceSettingsStateEnabledParam(),
        };

        State expectedState = new BetaComplianceSettingsStateEnabledParam();

        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void Url_Works()
    {
        ComplianceSettingUpdateParams parameters = new()
        {
            State = new BetaComplianceSettingsStateEnabledParam(),
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/compliance_settings?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ComplianceSettingUpdateParams
        {
            State = new BetaComplianceSettingsStateEnabledParam(),
        };

        ComplianceSettingUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StateTest : TestBase
{
    [Fact]
    public void BetaComplianceSettingsStateEnabledParamValidationWorks()
    {
        State value = new BetaComplianceSettingsStateEnabledParam();
        value.Validate();
    }

    [Fact]
    public void BetaComplianceSettingsStateDisabledParamValidationWorks()
    {
        State value = new BetaComplianceSettingsStateDisabledParam();
        value.Validate();
    }

    [Fact]
    public void BetaComplianceSettingsStateEnabledParamSerializationRoundtripWorks()
    {
        State value = new BetaComplianceSettingsStateEnabledParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<State>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaComplianceSettingsStateDisabledParamSerializationRoundtripWorks()
    {
        State value = new BetaComplianceSettingsStateDisabledParam();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<State>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        State value = new(
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

        State emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
