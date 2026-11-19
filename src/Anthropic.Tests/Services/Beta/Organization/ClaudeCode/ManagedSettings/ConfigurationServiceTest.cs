using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.ClaudeCode.ManagedSettings;

public class ConfigurationServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaClaudeCodeManagedSettingsConfiguration = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeCode.ManagedSettings.Configuration.Retrieve(
                new(),
                TestContext.Current.CancellationToken
            );
        betaClaudeCodeManagedSettingsConfiguration.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaClaudeCodeManagedSettingsConfiguration = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeCode.ManagedSettings.Configuration.Update(
                new(),
                TestContext.Current.CancellationToken
            );
        betaClaudeCodeManagedSettingsConfiguration.Validate();
    }
}
