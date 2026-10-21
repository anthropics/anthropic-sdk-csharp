using System;
using Anthropic.Models.Organization.ServiceAccounts;

namespace Anthropic.Tests.Models.Organization.ServiceAccounts;

public class ServiceAccountArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ServiceAccountArchiveParams
        {
            ServiceAccountID = "service_account_id",
        };

        string expectedServiceAccountID = "service_account_id";

        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
    }

    [Fact]
    public void Url_Works()
    {
        ServiceAccountArchiveParams parameters = new() { ServiceAccountID = "service_account_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/service_accounts/service_account_id/archive"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ServiceAccountArchiveParams
        {
            ServiceAccountID = "service_account_id",
        };

        ServiceAccountArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
