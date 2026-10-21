using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsCredentialTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            ArchivedAt = null,
            Auth = new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            ),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        string expectedID = "vcrd_011CZkZEMt8gZan2iYPQfSkw";
        BetaManagedAgentsCredentialAuth expectedAuth =
            new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Dictionary<string, string> expectedMetadata = new() { { "environment", "production" } };
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_credential");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        string expectedDisplayName = "Example credential";

        Assert.Equal(expectedID, model.ID);
        Assert.Null(model.ArchivedAt);
        Assert.Equal(expectedAuth, model.Auth);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVaultID, model.VaultID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            ArchivedAt = null,
            Auth = new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            ),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredential>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            ArchivedAt = null,
            Auth = new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            ),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredential>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "vcrd_011CZkZEMt8gZan2iYPQfSkw";
        BetaManagedAgentsCredentialAuth expectedAuth =
            new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Dictionary<string, string> expectedMetadata = new() { { "environment", "production" } };
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_credential");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        string expectedDisplayName = "Example credential";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Null(deserialized.ArchivedAt);
        Assert.Equal(expectedAuth, deserialized.Auth);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            ArchivedAt = null,
            Auth = new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            ),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            ArchivedAt = null,
            Auth = new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            ),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            ArchivedAt = null,
            Auth = new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            ),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            ArchivedAt = null,
            Auth = new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            ),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",

            DisplayName = null,
        };

        Assert.Null(model.DisplayName);
        Assert.True(model.RawData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            ArchivedAt = null,
            Auth = new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            ),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",

            DisplayName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw",
            ArchivedAt = null,
            Auth = new BetaManagedAgentsStaticBearerAuthResponse(
                "https://example-server.modelcontextprotocol.io/sse"
            ),
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        BetaManagedAgentsCredential copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsCredentialAuthTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsMcpOAuthAuthResponseValidationWorks()
    {
        BetaManagedAgentsCredentialAuth value = new BetaManagedAgentsMcpOAuthAuthResponse()
        {
            McpServerUrl = "mcp_server_url",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
                Resource = "resource",
                Scope = "scope",
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerAuthResponseValidationWorks()
    {
        BetaManagedAgentsCredentialAuth value = new BetaManagedAgentsStaticBearerAuthResponse(
            "https://example-server.modelcontextprotocol.io/sse"
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentVariableAuthResponseValidationWorks()
    {
        BetaManagedAgentsCredentialAuth value =
            new BetaManagedAgentsEnvironmentVariableAuthResponse()
            {
                InjectionLocation = new() { Body = true, Header = true },
                Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(),
                SecretName = "secret_name",
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpOAuthAuthResponseSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialAuth value = new BetaManagedAgentsMcpOAuthAuthResponse()
        {
            McpServerUrl = "mcp_server_url",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
                Resource = "resource",
                Scope = "scope",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredentialAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerAuthResponseSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialAuth value = new BetaManagedAgentsStaticBearerAuthResponse(
            "https://example-server.modelcontextprotocol.io/sse"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredentialAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentVariableAuthResponseSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialAuth value =
            new BetaManagedAgentsEnvironmentVariableAuthResponse()
            {
                InjectionLocation = new() { Body = true, Header = true },
                Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(),
                SecretName = "secret_name",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredentialAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpOAuthAuthResponseTypeWorks()
    {
        BetaManagedAgentsCredentialAuth value = new BetaManagedAgentsMcpOAuthAuthResponse()
        {
            McpServerUrl = "mcp_server_url",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
                Resource = "resource",
                Scope = "scope",
            },
        };
        Assert.Equal(BetaManagedAgentsCredentialAuthType.McpOAuth, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerAuthResponseTypeWorks()
    {
        BetaManagedAgentsCredentialAuth value = new BetaManagedAgentsStaticBearerAuthResponse(
            "https://example-server.modelcontextprotocol.io/sse"
        );
        Assert.Equal(BetaManagedAgentsCredentialAuthType.StaticBearer, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentVariableAuthResponseTypeWorks()
    {
        BetaManagedAgentsCredentialAuth value =
            new BetaManagedAgentsEnvironmentVariableAuthResponse()
            {
                InjectionLocation = new() { Body = true, Header = true },
                Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(),
                SecretName = "secret_name",
            };
        Assert.Equal(BetaManagedAgentsCredentialAuthType.EnvironmentVariable, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsCredentialAuth value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "mcp_server_url": "mcp_server_url",
                  "type": "static_bearer"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedMcpServerUrl = "mcp_server_url";
        ApiEnum<string, BetaManagedAgentsCredentialAuthType> expectedType =
            BetaManagedAgentsCredentialAuthType.StaticBearer;

        Assert.Equal(expectedMcpServerUrl, value.McpServerUrl);
        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsCredentialAuth emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.McpServerUrl);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaManagedAgentsCredentialAuth mismatchedValue = new(
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

public class BetaManagedAgentsCredentialAuthTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsCredentialAuthType.McpOAuth)]
    [InlineData(BetaManagedAgentsCredentialAuthType.StaticBearer)]
    [InlineData(BetaManagedAgentsCredentialAuthType.EnvironmentVariable)]
    public void Validation_Works(BetaManagedAgentsCredentialAuthType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCredentialAuthType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialAuthType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsCredentialAuthType.McpOAuth)]
    [InlineData(BetaManagedAgentsCredentialAuthType.StaticBearer)]
    [InlineData(BetaManagedAgentsCredentialAuthType.EnvironmentVariable)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsCredentialAuthType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCredentialAuthType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialAuthType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialAuthType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialAuthType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
