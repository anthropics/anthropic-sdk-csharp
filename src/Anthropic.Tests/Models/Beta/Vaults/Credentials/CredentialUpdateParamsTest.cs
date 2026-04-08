using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class CredentialUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CredentialUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            CredentialID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            Auth = new BetaManagedAgentsMcpOAuthUpdateParams()
            {
                Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
                AccessToken = "x",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Refresh = new()
                {
                    RefreshToken = "x",
                    Scope = "scope",
                    TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                    {
                        Type =
                            BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                        ClientSecret = "x",
                    },
                },
            },
            DisplayName = "Example credential",
            Metadata = new Dictionary<string, string?>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        string expectedCredentialID = "vcrd_011CZkZEMt8gZan2iYOQfSkw";
        CredentialUpdateParamsAuth expectedAuth = new BetaManagedAgentsMcpOAuthUpdateParams()
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                    ClientSecret = "x",
                },
            },
        };
        string expectedDisplayName = "Example credential";
        Dictionary<string, string?> expectedMetadata = new() { { "environment", "production" } };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedVaultID, parameters.VaultID);
        Assert.Equal(expectedCredentialID, parameters.CredentialID);
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
        var parameters = new CredentialUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            CredentialID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            DisplayName = "Example credential",
            Metadata = new Dictionary<string, string?>() { { "environment", "production" } },
        };

        Assert.Null(parameters.Auth);
        Assert.False(parameters.RawBodyData.ContainsKey("auth"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CredentialUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            CredentialID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            DisplayName = "Example credential",
            Metadata = new Dictionary<string, string?>() { { "environment", "production" } },

            // Null should be interpreted as omitted for these properties
            Auth = null,
            Betas = null,
        };

        Assert.Null(parameters.Auth);
        Assert.False(parameters.RawBodyData.ContainsKey("auth"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CredentialUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            CredentialID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            Auth = new BetaManagedAgentsMcpOAuthUpdateParams()
            {
                Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
                AccessToken = "x",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Refresh = new()
                {
                    RefreshToken = "x",
                    Scope = "scope",
                    TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                    {
                        Type =
                            BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                        ClientSecret = "x",
                    },
                },
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CredentialUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            CredentialID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            Auth = new BetaManagedAgentsMcpOAuthUpdateParams()
            {
                Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
                AccessToken = "x",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Refresh = new()
                {
                    RefreshToken = "x",
                    Scope = "scope",
                    TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                    {
                        Type =
                            BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                        ClientSecret = "x",
                    },
                },
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DisplayName = null,
            Metadata = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        CredentialUpdateParams parameters = new()
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            CredentialID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri(
                "https://api.anthropic.com/v1/vaults/vlt_011CZkZDLs7fYzm1hXNPeRjv/credentials/vcrd_011CZkZEMt8gZan2iYOQfSkw?beta=true"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CredentialUpdateParams parameters = new()
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            CredentialID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
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
        var parameters = new CredentialUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            CredentialID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            Auth = new BetaManagedAgentsMcpOAuthUpdateParams()
            {
                Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
                AccessToken = "x",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Refresh = new()
                {
                    RefreshToken = "x",
                    Scope = "scope",
                    TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                    {
                        Type =
                            BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                        ClientSecret = "x",
                    },
                },
            },
            DisplayName = "Example credential",
            Metadata = new Dictionary<string, string?>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        CredentialUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CredentialUpdateParamsAuthTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsMcpOAuthUpdateParamsValidationWorks()
    {
        CredentialUpdateParamsAuth value = new BetaManagedAgentsMcpOAuthUpdateParams()
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                    ClientSecret = "x",
                },
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerUpdateParamsValidationWorks()
    {
        CredentialUpdateParamsAuth value = new BetaManagedAgentsStaticBearerUpdateParams()
        {
            Type = BetaManagedAgentsStaticBearerUpdateParamsType.StaticBearer,
            Token = "x",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpOAuthUpdateParamsSerializationRoundtripWorks()
    {
        CredentialUpdateParamsAuth value = new BetaManagedAgentsMcpOAuthUpdateParams()
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                    ClientSecret = "x",
                },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CredentialUpdateParamsAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerUpdateParamsSerializationRoundtripWorks()
    {
        CredentialUpdateParamsAuth value = new BetaManagedAgentsStaticBearerUpdateParams()
        {
            Type = BetaManagedAgentsStaticBearerUpdateParamsType.StaticBearer,
            Token = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CredentialUpdateParamsAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
