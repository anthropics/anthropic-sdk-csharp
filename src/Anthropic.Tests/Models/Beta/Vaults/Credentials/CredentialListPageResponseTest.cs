using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Credentials = Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class CredentialListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
                    ArchivedAt = null,
                    Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
                    {
                        McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                        Type =
                            Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>() { { "environment", "production" } },
                    Type = Credentials::Type.VaultCredential,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
                    DisplayName = "Example credential",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<Credentials::BetaManagedAgentsCredential> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
                    ArchivedAt = null,
                    Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
                    {
                        McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                        Type =
                            Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>() { { "environment", "production" } },
                    Type = Credentials::Type.VaultCredential,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
                    DisplayName = "Example credential",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials::CredentialListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
                    ArchivedAt = null,
                    Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
                    {
                        McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                        Type =
                            Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>() { { "environment", "production" } },
                    Type = Credentials::Type.VaultCredential,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
                    DisplayName = "Example credential",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credentials::CredentialListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Credentials::BetaManagedAgentsCredential> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
                    ArchivedAt = null,
                    Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
                    {
                        McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                        Type =
                            Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>() { { "environment", "production" } },
                    Type = Credentials::Type.VaultCredential,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
                    DisplayName = "Example credential",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
                    ArchivedAt = null,
                    Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
                    {
                        McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                        Type =
                            Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>() { { "environment", "production" } },
                    Type = Credentials::Type.VaultCredential,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
                    DisplayName = "Example credential",
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
                    ArchivedAt = null,
                    Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
                    {
                        McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                        Type =
                            Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>() { { "environment", "production" } },
                    Type = Credentials::Type.VaultCredential,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
                    DisplayName = "Example credential",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
                    ArchivedAt = null,
                    Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
                    {
                        McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                        Type =
                            Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>() { { "environment", "production" } },
                    Type = Credentials::Type.VaultCredential,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
                    DisplayName = "Example credential",
                },
            ],

            NextPage = null,
        };

        Assert.Null(model.NextPage);
        Assert.True(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
                    ArchivedAt = null,
                    Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
                    {
                        McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                        Type =
                            Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>() { { "environment", "production" } },
                    Type = Credentials::Type.VaultCredential,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
                    DisplayName = "Example credential",
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Credentials::CredentialListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
                    ArchivedAt = null,
                    Auth = new Credentials::BetaManagedAgentsStaticBearerAuthResponse()
                    {
                        McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
                        Type =
                            Credentials::BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
                    },
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Metadata = new Dictionary<string, string>() { { "environment", "production" } },
                    Type = Credentials::Type.VaultCredential,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
                    DisplayName = "Example credential",
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        Credentials::CredentialListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
