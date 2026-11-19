using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.ClaudeCode.ManagedSettings;

public class RbacGroupDefaultServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaClaudeCodeRbacGroupDefaultManagedSettings = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeCode.ManagedSettings.RbacGroupDefault.Retrieve(
                new(),
                TestContext.Current.CancellationToken
            );
        betaClaudeCodeRbacGroupDefaultManagedSettings.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaClaudeCodeRbacGroupDefaultManagedSettings = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeCode.ManagedSettings.RbacGroupDefault.Update(
                new()
                {
                    Settings = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                TestContext.Current.CancellationToken
            );
        betaClaudeCodeRbacGroupDefaultManagedSettings.Validate();
    }
}
