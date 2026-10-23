using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Anthropic.Bedrock;

namespace Anthropic.Tests.Bedrock;

[Collection("EnvVarMutating")]
public sealed class AnthropicBedrockCredentialsHelperTests : IDisposable
{
    private const string SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
    private const string SessionToken = "FwoGZXIvYXdzEA_SESSION_TOKEN";

    private readonly Dictionary<string, string?> _original = [];
    private readonly string? _originalSdkRegion = AWSConfigs.AWSRegion;

    public AnthropicBedrockCredentialsHelperTests()
    {
        SetEnvironmentVariable("AWS_REGION", "us-east-1");
        SetEnvironmentVariable("AWS_ACCESS_KEY_ID", "AKIAIOSFODNN7EXAMPLE");
        SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", SecretKey);
        SetEnvironmentVariable("AWS_SESSION_TOKEN", null);
        SetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK", null);
    }

    public void Dispose()
    {
        foreach (var variable in _original)
        {
            Environment.SetEnvironmentVariable(variable.Key, variable.Value);
        }
        AWSConfigs.AWSRegion = _originalSdkRegion;
        FallbackRegionFactory.Reset();
    }

    private void SetEnvironmentVariable(string name, string? value)
    {
        if (!_original.ContainsKey(name))
        {
            _original[name] = Environment.GetEnvironmentVariable(name);
        }
        Environment.SetEnvironmentVariable(name, value);
    }

    /// <summary>
    /// A request signed with the credentials of <c>FromEnv</c>, whose signature a stand-in
    /// for the AWS gateway has verified.
    /// </summary>
    private static async Task<HttpRequestMessage> SignWithCredentialsFromEnv()
    {
        var credentials = await AnthropicBedrockCredentialsHelper.FromEnv();
        Assert.NotNull(credentials);
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://bedrock-runtime.us-east-1.amazonaws.com/model/anthropic.claude-3/invoke"
        )
        {
            Content = new StringContent("{}", Encoding.UTF8, "application/json"),
        };

        await credentials.Apply(request);

        using var gateway = new HttpMessageInvoker(new SigV4VerifyingHandler(SecretKey, "{}"));
        using var response = await gateway.SendAsync(
            request,
            TestContext.Current.CancellationToken
        );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        return request;
    }

    [Fact]
    public async Task FromEnv_TemporaryCredentials_SignsAndSendsTheSessionToken()
    {
        SetEnvironmentVariable("AWS_SESSION_TOKEN", SessionToken);

        using var request = await SignWithCredentialsFromEnv();

        Assert.Equal([SessionToken], request.Headers.GetValues("x-amz-security-token"));
        Assert.Contains(
            ";x-amz-security-token,",
            request.Headers.GetValues("Authorization").Single()
        );
    }

    [Fact]
    public async Task FromEnv_LongTermCredentials_SendsNoSessionToken()
    {
        using var request = await SignWithCredentialsFromEnv();

        Assert.False(request.Headers.Contains("x-amz-security-token"));
    }

    [Fact]
    public async Task FromEnv_WithoutAwsRegion_UsesTheNameOfTheAwsSdkRegion()
    {
        SetEnvironmentVariable("AWS_REGION", null);
        SetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK", "token");
        AWSConfigs.AWSRegion = "us-west-2";
        FallbackRegionFactory.Reset();

        var credentials = await AnthropicBedrockCredentialsHelper.FromEnv();

        Assert.Equal("us-west-2", credentials?.Region);
    }
}
