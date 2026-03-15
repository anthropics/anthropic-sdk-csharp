// xUnit1024: same-name overloads are intentional — base method is parameterless with no test attribute.
#pragma warning disable xUnit1024

using System.Threading.Tasks;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Services;

/// <summary>
/// Runs the <see cref="MessageServiceTest"/> suite against each client implementation supported by this service.
/// Each wrapper method sets <c>client</c> to the injected implementation then delegates to the base method.
///
/// When codegen adds a new method to <see cref="MessageServiceTest"/>, add a corresponding wrapper here
/// and remove the [Fact] attribute from the base method. The <see cref="GeneratedTestConformanceTest"/>
/// will fail loudly if any [Fact] is left on a <see cref="TestBase"/> subclass.
///
/// Note: these methods inline the test body rather than delegating to base because they need per-provider
/// model names that cannot be injected into the base method's hardcoded parameters.
/// </summary>
public class MessageServiceMultiClientTest : MessageServiceTest
{
    [Theory]
    [AnthropicTestClients]
    [AnthropicTestData(TestSupportTypes.Anthropic, "ClaudeSonnet4_5")]
    [AnthropicTestData(TestSupportTypes.Foundry, "claude-sonnet-4-5")]
    [AnthropicTestData(TestSupportTypes.Bedrock, "global.anthropic.claude-haiku-4-5-20251001-v1:0")]
    [AnthropicTestData(TestSupportTypes.Vertex, "claude-3-7-sonnet@20250219")]
    public async Task Create_Works(IAnthropicClient c, string modelName)
    {
        client = c;
        var message = await client.Messages.Create(
            new MessageCreateParams()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = modelName,
            },
            TestContext.Current.CancellationToken
        );
        message.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    [AnthropicTestData(TestSupportTypes.Anthropic, "ClaudeSonnet4_5")]
    [AnthropicTestData(TestSupportTypes.Foundry, "claude-sonnet-4-5")]
    [AnthropicTestData(TestSupportTypes.Bedrock, "global.anthropic.claude-haiku-4-5-20251001-v1:0")]
    public async Task CreateStreaming_Works(IAnthropicClient c, string modelName)
    {
        client = c;
        var stream = client.Messages.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = modelName,
            },
            TestContext.Current.CancellationToken
        );

        await foreach (var message in stream)
        {
            message.Validate();
        }
    }

    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    [AnthropicTestData(TestSupportTypes.Anthropic, "ClaudeSonnet4_5")]
    [AnthropicTestData(TestSupportTypes.Foundry, "claude-sonnet-4-5")]
    public async Task CountTokens_Works(IAnthropicClient c, string modelName)
    {
        client = c;
        var messageTokensCount = await client.Messages.CountTokens(
            new()
            {
                Messages = [new() { Content = "string", Role = Role.User }],
                Model = modelName,
            },
            TestContext.Current.CancellationToken
        );
        messageTokensCount.Validate();
    }
}
