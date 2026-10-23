using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            },
            DisplayName = "Example credential",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        Auth expectedAuth = new BetaManagedAgentsStaticBearerCreateParams()
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
        };
        string expectedDisplayName = "Example credential";
        Dictionary<string, string> expectedMetadata = new() { { "environment", "production" } };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

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
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
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
            },
            DisplayName = "Example credential",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
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
            },
            DisplayName = "Example credential",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new CredentialCreateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Auth = new BetaManagedAgentsStaticBearerCreateParams()
            {
                Token = "bearer_exampletoken",
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            },
            DisplayName = "Example credential",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        } with
        {
            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
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
            },
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
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
            },
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",

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
            },
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/vaults/vlt_011CZkZDLs7fYzm1hXNPeRjv/credentials"
                ),
                url
            )
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
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,managed-agents-2026-04-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
        Assert.Equal(
            ["wrkspc_011CZkZaBF1tNoB5wlCeusgy"],
            requestMessage.Headers.GetValues("anthropic-workspace-id")
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
            },
            DisplayName = "Example credential",
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentVariableCreateParamsValidationWorks()
    {
        Auth value = new BetaManagedAgentsEnvironmentVariableCreateParams()
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
            InjectionLocation = new() { Body = true, Header = true },
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Auth>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentVariableCreateParamsSerializationRoundtripWorks()
    {
        Auth value = new BetaManagedAgentsEnvironmentVariableCreateParams()
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
            InjectionLocation = new() { Body = true, Header = true },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Auth>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpOAuthCreateParamsTypeWorks()
    {
        Auth value = new BetaManagedAgentsMcpOAuthCreateParams()
        {
            AccessToken = "x",
            McpServerUrl = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
                Resource = "x",
                Scope = "x",
            },
        };
        Assert.Equal(AuthType.McpOAuth, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerCreateParamsTypeWorks()
    {
        Auth value = new BetaManagedAgentsStaticBearerCreateParams()
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
        };
        Assert.Equal(AuthType.StaticBearer, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentVariableCreateParamsTypeWorks()
    {
        Auth value = new BetaManagedAgentsEnvironmentVariableCreateParams()
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
            InjectionLocation = new() { Body = true, Header = true },
        };
        Assert.Equal(AuthType.EnvironmentVariable, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Auth value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "mcp_server_url": "x",
                  "type": "static_bearer"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedMcpServerUrl = "x";
        ApiEnum<string, AuthType> expectedType = AuthType.StaticBearer;

        Assert.Equal(expectedMcpServerUrl, value.McpServerUrl);
        Assert.Equal(expectedType, value.Type);

        Auth emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.McpServerUrl);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        Auth mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "mcp_server_url": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.McpServerUrl);
    }
}

public class AuthTypeTest : TestBase
{
    [Theory]
    [InlineData(AuthType.McpOAuth)]
    [InlineData(AuthType.StaticBearer)]
    [InlineData(AuthType.EnvironmentVariable)]
    public void Validation_Works(AuthType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuthType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuthType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuthType.McpOAuth)]
    [InlineData(AuthType.StaticBearer)]
    [InlineData(AuthType.EnvironmentVariable)]
    public void SerializationRoundtrip_Works(AuthType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuthType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuthType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuthType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuthType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
