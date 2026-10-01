using System.Threading.Tasks;
using Anthropic.Models.Organization.ComplianceSettings;

namespace Anthropic.Tests.Services.Organization;

public class ComplianceSettingServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var organizationComplianceSettings =
            await this.client.Organization.ComplianceSettings.Retrieve(
                new(),
                TestContext.Current.CancellationToken
            );
        organizationComplianceSettings.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var organizationComplianceSettings =
            await this.client.Organization.ComplianceSettings.Update(
                new() { State = new ComplianceSettingsStateEnabledParam() },
                TestContext.Current.CancellationToken
            );
        organizationComplianceSettings.Validate();
    }
}
