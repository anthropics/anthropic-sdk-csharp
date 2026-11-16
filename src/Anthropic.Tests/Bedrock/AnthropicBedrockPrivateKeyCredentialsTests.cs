using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Anthropic.Bedrock;

namespace Anthropic.Tests.Bedrock;

public class AnthropicBedrockPrivateKeyCredentialsTests
{
    const string SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";

    [Theory]
    [InlineData("anthropic-beta", "beta-a", "beta-b")]
    [InlineData("Accept-Encoding", "br", "gzip")]
    public async Task Apply_HeaderWithTwoValues_SignatureVerifies(
        string name,
        string first,
        string second
    )
    {
        using var request = await SignedRequest(name, first, second);

        Assert.Contains(name.ToLowerInvariant(), Authorization(request));
        Assert.Equal(HttpStatusCode.OK, await GatewayStatus(request));
    }

    [Fact]
    public async Task Apply_UserAgentWithTwoValues_IsSentUnsigned()
    {
        using var request = await SignedRequest("User-Agent", "AnthropicClient/C#", "1.2.3");

        Assert.Equal("AnthropicClient/C# 1.2.3", request.Headers.UserAgent.ToString());
        Assert.DoesNotContain("user-agent", Authorization(request));
        Assert.Equal(HttpStatusCode.OK, await GatewayStatus(request));
    }

    static async Task<HttpRequestMessage> SignedRequest(string name, string first, string second)
    {
        var credentials = new AnthropicBedrockPrivateKeyCredentials
        {
            Region = "us-east-1",
            ApiAccessKey = "AKIAIOSFODNN7EXAMPLE",
            ApiSecret = SecretKey,
        };
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://bedrock-runtime.us-east-1.amazonaws.com/model/anthropic.claude-3/invoke"
        )
        {
            Content = new StringContent("{}", Encoding.UTF8, "application/json"),
        };
        request.Headers.Add(name, [first, second]);

        await credentials.Apply(request);
        return request;
    }

    static string Authorization(HttpRequestMessage request) =>
        Assert.Single(request.Headers.GetValues("Authorization"));

    static async Task<HttpStatusCode> GatewayStatus(HttpRequestMessage request)
    {
        using var gateway = new HttpMessageInvoker(new SigV4VerifyingHandler(SecretKey, "{}"));
        using var response = await gateway.SendAsync(
            request,
            TestContext.Current.CancellationToken
        );
        return response.StatusCode;
    }
}
