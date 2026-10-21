using System;
using Anthropic.Models.Beta.Organization.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups;

public class RbacGroupCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RbacGroupCreateParams { Name = "Engineering" };

        string expectedName = "Engineering";

        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        RbacGroupCreateParams parameters = new() { Name = "Engineering" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/rbac_groups?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RbacGroupCreateParams { Name = "Engineering" };

        RbacGroupCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
