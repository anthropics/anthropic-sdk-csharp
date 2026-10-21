using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Aws;
using Anthropic.Bedrock;
using Anthropic.Core;
using Anthropic.Foundry;
using Anthropic.Models.Messages;
using Anthropic.Vertex;

namespace Anthropic.Tests;

/// <summary>
/// Pins, on the wire, what each client does with user profiles. How the Bedrock Mantle client
/// sends the profile ID is in <see cref="Bedrock.AnthropicBedrockMantleClientTests"/>.
/// </summary>
public class PlatformUserProfilesTest
{
    const string FirstParty = "first-party";
    const string PlainBedrock = "bedrock";
    const string Mantle = "mantle";
    const string Vertex = "vertex";
    const string AwsApiKey = "aws-api-key";
    const string AwsSigV4 = "aws-sigv4";
    const string Foundry = "foundry";

    const string ProfileID = "uprof_test";
    const string ProfileHeader = "anthropic-user-profile-id";
    const string SigV4SecretKey = "test-secret-key";

    static CancellationToken Ct => TestContext.Current.CancellationToken;

    sealed class OkGateway : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        ) =>
            Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json"),
                }
            );
    }

    sealed class FakeBedrockCredentials : IAnthropicBedrockCredentials
    {
        public string Region => "us-east-1";

        public Task Apply(HttpRequestMessage requestMessage) => Task.CompletedTask;
    }

    sealed class FakeVertexCredentials : IAnthropicVertexCredentials
    {
        public string Region => "us-east5";
        public string Project => "test-project";

        public ValueTask ApplyAsync(HttpRequestMessage requestMessage) => default;
    }

    sealed class FakeFoundryCredentials : IAnthropicFoundryCredentials
    {
        public string ResourceName => "test-resource";

        public void Apply(HttpRequestMessage requestMessage) =>
            requestMessage.Headers.TryAddWithoutValidation("api-key", "test-api-key");
    }

    /// <summary>
    /// In SigV4 mode the gateway answers 403 unless the signature covers the request as sent.
    /// </summary>
    static WireRecordingHandler CreateWire(string backend) =>
        new(
            backend == AwsSigV4 ? new SigV4VerifyingHandler(SigV4SecretKey, "{}") : new OkGateway()
        );

    static AnthropicClient CreateClient(string backend, HttpMessageHandler wire)
    {
        var httpClient = new HttpClient(wire);
        return backend switch
        {
            FirstParty => new AnthropicClient
            {
                ApiKey = "sk-test-key",
                BaseUrl = "http://localhost",
                HttpClient = httpClient,
            },
            PlainBedrock => new AnthropicBedrockClient(new FakeBedrockCredentials())
            {
                HttpClient = httpClient,
            },
            Mantle => new AnthropicBedrockMantleClient(
                new()
                {
                    ApiKey = "sk-test-key",
                    BaseUrl = "http://localhost/anthropic",
                    ClientOptions = new() { HttpClient = httpClient },
                }
            ),
            Vertex => new AnthropicVertexClient(new FakeVertexCredentials())
            {
                HttpClient = httpClient,
            },
            AwsApiKey => new AnthropicAwsClient(
                new()
                {
                    ApiKey = "sk-test-key",
                    WorkspaceId = "ws-test",
                    BaseUrl = "http://localhost",
                    ClientOptions = new() { HttpClient = httpClient },
                }
            ),
            AwsSigV4 => new AnthropicAwsClient(
                new()
                {
                    AwsAccessKey = "AKIDEXAMPLE",
                    AwsSecretAccessKey = SigV4SecretKey,
                    AwsRegion = "us-east-1",
                    WorkspaceId = "ws-test",
                    BaseUrl = "http://localhost",
                    ClientOptions = new() { HttpClient = httpClient },
                }
            ),
            Foundry => new AnthropicFoundryClient(new FakeFoundryCredentials())
            {
                HttpClient = httpClient,
            },
            _ => throw new ArgumentOutOfRangeException(nameof(backend), backend, null),
        };
    }

    [Theory]
    [InlineData(FirstParty, "")]
    [InlineData(AwsApiKey, "")]
    [InlineData(AwsSigV4, "")]
    [InlineData(Foundry, "/anthropic")]
    public async Task UserProfiles_Crud_ReachesTheGeneralAvailabilityEndpoints(
        string backend,
        string basePath
    )
    {
        var wire = CreateWire(backend);
        var profiles = CreateClient(backend, wire).WithRawResponse.UserProfiles;

        await profiles.Create(cancellationToken: Ct);
        await profiles.Retrieve(ProfileID, cancellationToken: Ct);
        await profiles.Update(ProfileID, cancellationToken: Ct);
        await profiles.List(cancellationToken: Ct);
        await profiles.Delete(ProfileID, cancellationToken: Ct);

        Assert.Equal(
            [
                $"POST {basePath}/v1/user_profiles",
                $"GET {basePath}/v1/user_profiles/{ProfileID}",
                $"POST {basePath}/v1/user_profiles/{ProfileID}",
                $"GET {basePath}/v1/user_profiles",
                $"DELETE {basePath}/v1/user_profiles/{ProfileID}",
            ],
            wire.Requests.Select(request => $"{request.Method} {request.Uri.PathAndQuery}")
        );
        Assert.All(
            wire.Requests,
            request => Assert.False(request.Headers.ContainsKey("anthropic-beta"))
        );
    }

    [Theory]
    [InlineData(FirstParty)]
    [InlineData(Vertex)]
    [InlineData(AwsApiKey)]
    [InlineData(AwsSigV4)]
    [InlineData(Foundry)]
    public async Task UserProfileID_MessagesCreate_SentAsHeader(string backend)
    {
        var wire = CreateWire(backend);

        await CreateClient(backend, wire)
            .WithRawResponse.Messages.Create(
                new MessageCreateParams
                {
                    MaxTokens = 16,
                    Messages = [new UserMessageParam { Content = "hello" }],
                    Model = "claude-sonnet-4-5",
                    UserProfileID = ProfileID,
                },
                Ct
            );

        var request = Assert.Single(wire.Requests);
        Assert.Equal(ProfileID, request.Headers[ProfileHeader]);
        Assert.False(request.JsonBody.ContainsKey("user_profile_id"));
    }

    [Theory]
    [InlineData(PlainBedrock)]
    [InlineData(Mantle)]
    [InlineData(Vertex)]
    public async Task UserProfiles_NotServed_ThrowsBeforeSending(string backend)
    {
        var wire = CreateWire(backend);
        var client = CreateClient(backend, wire);

        var exception = await Assert.ThrowsAsync<NotSupportedException>(() =>
            client.UserProfiles.Create(cancellationToken: Ct)
        );
        Assert.Contains("UserProfiles", exception.Message);

        await Assert.ThrowsAsync<NotSupportedException>(() =>
            client.UserProfiles.Retrieve(ProfileID, cancellationToken: Ct)
        );
        await Assert.ThrowsAsync<NotSupportedException>(() =>
            client.UserProfiles.List(cancellationToken: Ct)
        );
        await Assert.ThrowsAsync<NotSupportedException>(() =>
            client.UserProfiles.Delete(ProfileID, cancellationToken: Ct)
        );
        await Assert.ThrowsAsync<NotSupportedException>(() =>
            client.UserProfiles.ActionUrls.Create(ProfileID, new() { Action = new() }, Ct)
        );
        await Assert.ThrowsAsync<NotSupportedException>(() =>
            client.Beta.UserProfiles.List(cancellationToken: Ct)
        );
        await Assert.ThrowsAsync<NotSupportedException>(() =>
            client.WithRawResponse.UserProfiles.List(cancellationToken: Ct)
        );
        Assert.Empty(wire.Requests);
    }

    [Theory]
    [InlineData(AwsApiKey)]
    [InlineData(AwsSigV4)]
    public async Task ActionUrls_OnAws_ThrowsBeforeSending(string backend)
    {
        var wire = CreateWire(backend);
        var client = CreateClient(backend, wire);

        var exception = await Assert.ThrowsAsync<NotSupportedException>(() =>
            client.UserProfiles.ActionUrls.Create(ProfileID, new() { Action = new() }, Ct)
        );
        Assert.Contains("ActionUrls", exception.Message);

        await Assert.ThrowsAsync<NotSupportedException>(() =>
            client.Beta.UserProfiles.ActionUrls.Create(ProfileID, new() { Action = new() }, Ct)
        );
        Assert.Empty(wire.Requests);

        // A profile whose ID happens to spell the last path segment is still served.
        await client.WithRawResponse.UserProfiles.Retrieve("action_urls", cancellationToken: Ct);
        Assert.Equal(
            "/v1/user_profiles/action_urls",
            Assert.Single(wire.Requests).Uri.AbsolutePath
        );
    }

    [Fact]
    public async Task ActionUrls_FirstParty_ReachesTheEndpoint()
    {
        var wire = CreateWire(FirstParty);

        await CreateClient(FirstParty, wire)
            .WithRawResponse.UserProfiles.ActionUrls.Create(
                ProfileID,
                new() { Action = new() },
                Ct
            );

        var request = Assert.Single(wire.Requests);
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal($"/v1/user_profiles/{ProfileID}/action_urls", request.Uri.PathAndQuery);
    }
}
