using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization.Federation;

public class RuleServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var federationRule = await this.client.Organization.Federation.Rules.Create(
            new()
            {
                IssuerID = "issuer_id",
                Match = new()
                {
                    Audience = "audience",
                    Claims = new Dictionary<string, string>() { { "foo", "string" } },
                    Condition = "condition",
                    SubjectPrefix = "subject_prefix",
                },
                Name = "x",
                OAuthScope = "x",
                Target = new()
                {
                    ServiceAccountID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
                    ServiceAccountName = "service_account_name",
                },
            },
            TestContext.Current.CancellationToken
        );
        federationRule.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var federationRule = await this.client.Organization.Federation.Rules.Retrieve(
            "federation_rule_id",
            new(),
            TestContext.Current.CancellationToken
        );
        federationRule.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var federationRule = await this.client.Organization.Federation.Rules.Update(
            "federation_rule_id",
            new(),
            TestContext.Current.CancellationToken
        );
        federationRule.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.Federation.Rules.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var federationRule = await this.client.Organization.Federation.Rules.Archive(
            "federation_rule_id",
            new(),
            TestContext.Current.CancellationToken
        );
        federationRule.Validate();
    }
}
