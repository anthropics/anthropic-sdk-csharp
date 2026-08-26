using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Tests.Services.Beta.Organization;

public class ExternalKeyServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaExternalKey = await this.client.Beta.Organization.ExternalKeys.Create(
            new()
            {
                ProviderConfig = new BetaAwsExternalKeyConfig()
                {
                    KmsArn =
                        "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                    Region = "us-east-1",
                    RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
                },
            },
            TestContext.Current.CancellationToken
        );
        betaExternalKey.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaExternalKey = await this.client.Beta.Organization.ExternalKeys.Retrieve(
            "external_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaExternalKey.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaExternalKey = await this.client.Beta.Organization.ExternalKeys.Update(
            "external_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaExternalKey.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.ExternalKeys.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var externalKey = await this.client.Beta.Organization.ExternalKeys.Delete(
            "external_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        externalKey.Validate();
    }

    [Fact]
    public async Task Validate_Works()
    {
        var response = await this.client.Beta.Organization.ExternalKeys.Validate(
            "external_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
