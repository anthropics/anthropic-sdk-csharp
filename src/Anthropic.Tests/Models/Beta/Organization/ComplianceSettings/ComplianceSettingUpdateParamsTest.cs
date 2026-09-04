using System;
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

        BetaComplianceSettingsStateParam expectedState =
            new BetaComplianceSettingsStateEnabledParam();

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
