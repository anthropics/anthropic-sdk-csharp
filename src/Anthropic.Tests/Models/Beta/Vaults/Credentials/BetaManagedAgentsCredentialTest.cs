using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Credentials = Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsCredentialTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Credentials::BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            ArchivedAt = null,
            Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            },
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Type = Credentials::Type.VaultCredential,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        string expectedID = "vcrd_011CZkZEMt8gZan2iYOQfSkw";
        Credentials::BetaManagedAgentsCredentialAuth expectedAuth =
            new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Dictionary<string, string> expectedMetadata = new() { { "environment", "production" } };
        ApiEnum<string, Credentials::Type> expectedType = Credentials::Type.VaultCredential;
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
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVaultID, model.VaultID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Credentials::BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            ArchivedAt = null,
            Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            },
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Type = Credentials::Type.VaultCredential,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials::BetaManagedAgentsCredential>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Credentials::BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            ArchivedAt = null,
            Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            },
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Type = Credentials::Type.VaultCredential,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials::BetaManagedAgentsCredential>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "vcrd_011CZkZEMt8gZan2iYOQfSkw";
        Credentials::BetaManagedAgentsCredentialAuth expectedAuth =
            new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        Dictionary<string, string> expectedMetadata = new() { { "environment", "production" } };
        ApiEnum<string, Credentials::Type> expectedType = Credentials::Type.VaultCredential;
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
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Credentials::BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            ArchivedAt = null,
            Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            },
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Type = Credentials::Type.VaultCredential,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Credentials::BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            ArchivedAt = null,
            Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            },
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Type = Credentials::Type.VaultCredential,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Credentials::BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            ArchivedAt = null,
            Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            },
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Type = Credentials::Type.VaultCredential,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Credentials::BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            ArchivedAt = null,
            Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            },
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Type = Credentials::Type.VaultCredential,
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
        var model = new Credentials::BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            ArchivedAt = null,
            Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            },
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Type = Credentials::Type.VaultCredential,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",

            DisplayName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Credentials::BetaManagedAgentsCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            ArchivedAt = null,
            Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            },
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Metadata = new Dictionary<string, string>() { { "environment", "production" } },
            Type = Credentials::Type.VaultCredential,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example credential",
        };

        Credentials::BetaManagedAgentsCredential copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsCredentialAuthTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsMcpOAuthAuthResponseValidationWorks()
    {
        Credentials::BetaManagedAgentsCredentialAuth value =
            new Credentials::BetaManagedAgentsMcpOAuthAuthResponse()
            {
                McpServerUrl = "mcp_server_url",
                Type = Credentials::BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Refresh = new()
                {
                    ClientID = "client_id",
                    TokenEndpoint = "token_endpoint",
                    TokenEndpointAuth =
                        new Credentials::BetaManagedAgentsTokenEndpointAuthNoneResponse(
                            Credentials::BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
                        ),
                    Resource = "resource",
                    Scope = "scope",
                },
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerAuthResponseValidationWorks()
    {
        Credentials::BetaManagedAgentsCredentialAuth value =
            new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpOAuthAuthResponseSerializationRoundtripWorks()
    {
        Credentials::BetaManagedAgentsCredentialAuth value =
            new Credentials::BetaManagedAgentsMcpOAuthAuthResponse()
            {
                McpServerUrl = "mcp_server_url",
                Type = Credentials::BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Refresh = new()
                {
                    ClientID = "client_id",
                    TokenEndpoint = "token_endpoint",
                    TokenEndpointAuth =
                        new Credentials::BetaManagedAgentsTokenEndpointAuthNoneResponse(
                            Credentials::BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
                        ),
                    Resource = "resource",
                    Scope = "scope",
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials::BetaManagedAgentsCredentialAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsStaticBearerAuthResponseSerializationRoundtripWorks()
    {
        Credentials::BetaManagedAgentsCredentialAuth value =
            new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
            {
                McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                Type = Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials::BetaManagedAgentsCredentialAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Credentials::Type.VaultCredential)]
    public void Validation_Works(Credentials::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Credentials::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Credentials::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Credentials::Type.VaultCredential)]
    public void SerializationRoundtrip_Works(Credentials::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Credentials::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Credentials::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Credentials::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Credentials::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
