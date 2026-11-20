using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Services.Beta.Organization;

public class ExternalStorageServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaExternalStorage = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ExternalStorage.Create(
                new()
                {
                    ProviderConfig = new BetaAwsExternalStorageConfigParam()
                    {
                        AccountID = "111122223333",
                        BucketName = "acme-safety-retention",
                        Region = "us-east-2",
                    },
                },
                TestContext.Current.CancellationToken
            );
        betaExternalStorage.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaExternalStorage = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ExternalStorage.Retrieve(
                "external_storage_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaExternalStorage.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaExternalStorage = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ExternalStorage.Update(
                "external_storage_id",
                new() { DisplayName = "x" },
                TestContext.Current.CancellationToken
            );
        betaExternalStorage.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ExternalStorage.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaDeletedExternalStorage = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ExternalStorage.Delete(
                "external_storage_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaDeletedExternalStorage.Validate();
    }

    [Fact]
    public async Task Activate_Works()
    {
        var betaExternalStorage = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ExternalStorage.Activate(
                "external_storage_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaExternalStorage.Validate();
    }
}
