using System;
using Anthropic.Models.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Organization.ComplianceSettings;

public class ComplianceSettingUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ComplianceSettingUpdateParams
        {
            State = new ComplianceSettingsStateEnabledParam(),
        };

        ComplianceSettingsStateParam expectedState = new ComplianceSettingsStateEnabledParam();

        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void Url_Works()
    {
        ComplianceSettingUpdateParams parameters = new()
        {
            State = new ComplianceSettingsStateEnabledParam(),
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/compliance_settings"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ComplianceSettingUpdateParams
        {
            State = new ComplianceSettingsStateEnabledParam(),
        };

        ComplianceSettingUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
