using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.ClaudeCode.ManagedSettings;

public class RbacGroupServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaClaudeCodeRbacGroupManagedSettings = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups.Retrieve(
                "rbac_group_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaClaudeCodeRbacGroupManagedSettings.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups.List(
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaDeletedClaudeCodeRbacGroupManagedSettings = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups.Delete(
                "rbac_group_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaDeletedClaudeCodeRbacGroupManagedSettings.Validate();
    }

    [Fact]
    public async Task Set_Works()
    {
        var betaClaudeCodeRbacGroupManagedSettings = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups.Set(
                "rbac_group_id",
                new()
                {
                    Settings = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
                TestContext.Current.CancellationToken
            );
        betaClaudeCodeRbacGroupManagedSettings.Validate();
    }
}
