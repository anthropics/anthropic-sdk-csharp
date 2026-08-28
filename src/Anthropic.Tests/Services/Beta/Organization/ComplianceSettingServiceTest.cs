using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.ComplianceSettings;

namespace Anthropic.Tests.Services.Beta.Organization;

public class ComplianceSettingServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaComplianceSettings =
            await this.client.Beta.Organization.ComplianceSettings.Retrieve(
                new(),
                TestContext.Current.CancellationToken
            );
        betaComplianceSettings.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaComplianceSettings = await this.client.Beta.Organization.ComplianceSettings.Update(
            new() { State = new BetaComplianceSettingsStateEnabledParam() },
            TestContext.Current.CancellationToken
        );
        betaComplianceSettings.Validate();
    }
}
