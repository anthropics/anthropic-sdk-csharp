using System;
using Anthropic.Models.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Organization.Federation.Rules;

public class RuleArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RuleArchiveParams { FederationRuleID = "federation_rule_id" };

        string expectedFederationRuleID = "federation_rule_id";

        Assert.Equal(expectedFederationRuleID, parameters.FederationRuleID);
    }

    [Fact]
    public void Url_Works()
    {
        RuleArchiveParams parameters = new() { FederationRuleID = "federation_rule_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/federation_rules/federation_rule_id/archive"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RuleArchiveParams { FederationRuleID = "federation_rule_id" };

        RuleArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
