using System.Threading.Tasks;
using Anthropic.Models.Organization.ExternalKeys;

namespace Anthropic.Tests.Services.Organization;

public class ExternalKeyServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var externalKey = await this.client.Organization.ExternalKeys.Create(
            new()
            {
                ProviderConfig = new AwsExternalKeyConfig()
                {
                    KmsArn =
                        "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                    Region = "us-east-1",
                },
            },
            TestContext.Current.CancellationToken
        );
        externalKey.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var externalKey = await this.client.Organization.ExternalKeys.Retrieve(
            "external_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        externalKey.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var externalKey = await this.client.Organization.ExternalKeys.Update(
            "external_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        externalKey.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.ExternalKeys.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var externalKey = await this.client.Organization.ExternalKeys.Delete(
            "external_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        externalKey.Validate();
    }

    [Fact]
    public async Task Validate_Works()
    {
        var response = await this.client.Organization.ExternalKeys.Validate(
            "external_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
