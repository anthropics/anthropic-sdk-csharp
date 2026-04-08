using System.Threading.Tasks;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Services.Beta.Sessions;

public class EventServiceTest : TestBase
{
    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Sessions.Events.List(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Send_Works()
    {
        var betaManagedAgentsSendSessionEvents = await this.client.Beta.Sessions.Events.Send(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new()
            {
                Events =
                [
                    new BetaManagedAgentsUserMessageEventParams()
                    {
                        Content =
                        [
                            new BetaManagedAgentsTextBlock()
                            {
                                Text = "Where is my order #1234?",
                                Type = BetaManagedAgentsTextBlockType.Text,
                            },
                        ],
                        Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsSendSessionEvents.Validate();
    }

    [Fact]
    public async Task StreamStreaming_Works()
    {
        var stream = this.client.Beta.Sessions.Events.StreamStreaming(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var betaManagedAgentsStreamSessionEvents in stream)
        {
            betaManagedAgentsStreamSessionEvents.Validate();
        }
    }
}
