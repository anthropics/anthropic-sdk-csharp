using System.Threading.Tasks;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Services;

public class MessageServiceTest : TestBase
{
    public async Task Create_Works()
    {
        var message = await this.client.Messages.Create(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = Model.ClaudeOpus4_6,
            },
            TestContext.Current.CancellationToken
        );
        message.Validate();
    }

    public async Task CreateStreaming_Works()
    {
        var stream = this.client.Messages.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = Model.ClaudeOpus4_6,
            },
            TestContext.Current.CancellationToken
        );

        await foreach (var message in stream)
        {
            message.Validate();
        }
    }

    public async Task CountTokens_Works()
    {
        var messageTokensCount = await this.client.Messages.CountTokens(
            new()
            {
                Messages =
                [
                    new()
                    {
                        Content = new(
                            [
                                new ContentBlockParam(
                                    new TextBlockParam()
                                    {
                                        Text = "What is a quaternion?",
                                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                                        Citations =
                                        [
                                            new CitationCharLocationParam()
                                            {
                                                CitedText = "cited_text",
                                                DocumentIndex = 0,
                                                DocumentTitle = "x",
                                                EndCharIndex = 0,
                                                StartCharIndex = 0,
                                            },
                                        ],
                                    }
                                ),
                            ]
                        ),
                        Role = Role.User,
                    },
                ],
                Model = Model.ClaudeMythosPreview,
            },
            TestContext.Current.CancellationToken
        );
        messageTokensCount.Validate();
    }
}
