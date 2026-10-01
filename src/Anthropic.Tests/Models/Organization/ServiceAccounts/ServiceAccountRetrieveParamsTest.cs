using System;
using Anthropic.Models.Organization.ServiceAccounts;

namespace Anthropic.Tests.Models.Organization.ServiceAccounts;

public class ServiceAccountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ServiceAccountRetrieveParams
        {
            ServiceAccountID = "service_account_id",
        };

        string expectedServiceAccountID = "service_account_id";

        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
    }

    [Fact]
    public void Url_Works()
    {
        ServiceAccountRetrieveParams parameters = new() { ServiceAccountID = "service_account_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/service_accounts/service_account_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ServiceAccountRetrieveParams
        {
            ServiceAccountID = "service_account_id",
        };

        ServiceAccountRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
