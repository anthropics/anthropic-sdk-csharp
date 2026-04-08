using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class CredentialCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CredentialCreateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Auth = new BetaManagedAgentsStaticBearerCreateParams()
            {
                Token = "bearer_exampletoken",
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            },
            DisplayName = "Example credential",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        Auth expectedAuth = new BetaManagedAgentsStaticBearerCreateParams()
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
        };
        string expectedDisplayName = "Example credential";
        Dictionary<string, string> expectedMetadata = new() { { "environment", "production" } };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedVaultID, parameters.VaultID);
        Assert.Equal(expectedAuth, parameters.Auth);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CredentialCreateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Auth = new BetaManagedAgentsStaticBearerCreateParams()
            {
                Token = "bearer_exampletoken",
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            },
            DisplayName = "Example credential",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CredentialCreateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Auth = new BetaManagedAgentsStaticBearerCreateParams()
            {
                Token = "bearer_exampletoken",
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            },
            DisplayName = "Example credential",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Betas = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CredentialCreateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Auth = new BetaManagedAgentsStaticBearerCreateParams()
            {
                Token = "bearer_exampletoken",
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            },
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CredentialCreateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Auth = new BetaManagedAgentsStaticBearerCreateParams()
            {
                Token = "bearer_exampletoken",
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            },
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DisplayName = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void Url_Works()
    {
        CredentialCreateParams parameters = new()
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Auth = new BetaManagedAgentsStaticBearerCreateParams()
            {
                Token = "bearer_exampletoken",
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            },
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri(
                "https://api.anthropic.com/v1/vaults/vlt_011CZkZDLs7fYzm1hXNPeRjv/credentials?beta=true"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CredentialCreateParams parameters = new()
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Auth = new BetaManagedAgentsStaticBearerCreateParams()
            {
                Token = "bearer_exampletoken",
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CredentialCreateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Auth = new BetaManagedAgentsStaticBearerCreateParams()
            {
                Token = "bearer_exampletoken",
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            },
            DisplayName = "Example credential",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        CredentialCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AuthTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsMcpOAuthCreateParamsValidationWorks()
    {
        Auth value = new BetaManagedAgentsMcpOAuthCreateParams()
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                    BetaManagedAgentsTokenEndpointAuthNoneParamType.None
                ),
                Resource = "x",
                Scope = "x",
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerCreateParamsValidationWorks()
    {
        Auth value = new BetaManagedAgentsStaticBearerCreateParams()
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpOAuthCreateParamsSerializationRoundtripWorks()
    {
        Auth value = new BetaManagedAgentsMcpOAuthCreateParams()
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                    BetaManagedAgentsTokenEndpointAuthNoneParamType.None
                ),
                Resource = "x",
                Scope = "x",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Auth>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerCreateParamsSerializationRoundtripWorks()
    {
        Auth value = new BetaManagedAgentsStaticBearerCreateParams()
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Auth>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
