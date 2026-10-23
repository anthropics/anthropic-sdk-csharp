using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Tests.Services.Beta.Organization;

public class WebhookServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaNewOrganizationWebhookEndpoint = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Webhooks.Create(
                new()
                {
                    EnabledEvents = [EnabledEvent.UserProfileEnforcementActionOpened],
                    UrlValue = "x",
                },
                TestContext.Current.CancellationToken
            );
        betaNewOrganizationWebhookEndpoint.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaOrganizationWebhookEndpoint = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Webhooks.Retrieve(
                "webhook_endpoint_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaOrganizationWebhookEndpoint.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaOrganizationWebhookEndpoint = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Webhooks.Update(
                "webhook_endpoint_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaOrganizationWebhookEndpoint.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Webhooks.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaDeletedOrganizationWebhookEndpoint = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Webhooks.Delete(
                "webhook_endpoint_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaDeletedOrganizationWebhookEndpoint.Validate();
    }

    [Fact]
    public async Task RegenerateSigningSecret_Works()
    {
        var betaOrganizationWebhookEndpointSigningSecret = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Webhooks.RegenerateSigningSecret(
                "webhook_endpoint_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaOrganizationWebhookEndpointSigningSecret.Validate();
    }
}
