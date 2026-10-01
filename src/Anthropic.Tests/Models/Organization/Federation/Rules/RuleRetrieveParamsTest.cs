using System;
using Anthropic.Models.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Organization.Federation.Rules;

public class RuleRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RuleRetrieveParams { FederationRuleID = "federation_rule_id" };

        string expectedFederationRuleID = "federation_rule_id";

        Assert.Equal(expectedFederationRuleID, parameters.FederationRuleID);
    }

    [Fact]
    public void Url_Works()
    {
        RuleRetrieveParams parameters = new() { FederationRuleID = "federation_rule_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/federation_rules/federation_rule_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RuleRetrieveParams { FederationRuleID = "federation_rule_id" };

        RuleRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
