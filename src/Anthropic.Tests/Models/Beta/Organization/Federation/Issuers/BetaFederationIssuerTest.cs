using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Issuers;

public class BetaFederationIssuerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFederationIssuer
        {
            ID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CheckJti = true,
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            IssuerUrl = "https://token.actions.githubusercontent.com",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MaxJwtLifetimeSeconds = 0,
            Name = "github-actions",
            PollStatus = new()
            {
                ConsecutiveFailures = 0,
                LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        string expectedID = "fdis_01SDCCSbTxrXDpWc1phhtcfK";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedArchivedByActorID = "archived_by_actor_id";
        bool expectedCheckJti = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedCreatedByActorID = "created_by_actor_id";
        string expectedIssuerUrl = "https://token.actions.githubusercontent.com";
        BetaFederationIssuerJwks expectedJwks = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        DateTimeOffset expectedJwksPollingDisabledAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedMaxJwtLifetimeSeconds = 0;
        string expectedName = "github-actions";
        BetaFederationIssuerPollStatus expectedPollStatus = new()
        {
            ConsecutiveFailures = 0,
            LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("federation_issuer");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedUpdatedByActorID = "updated_by_actor_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedArchivedByActorID, model.ArchivedByActorID);
        Assert.Equal(expectedCheckJti, model.CheckJti);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedByActorID, model.CreatedByActorID);
        Assert.Equal(expectedIssuerUrl, model.IssuerUrl);
        Assert.Equal(expectedJwks, model.Jwks);
        Assert.Equal(expectedJwksPollingDisabledAt, model.JwksPollingDisabledAt);
        Assert.Equal(expectedMaxJwtLifetimeSeconds, model.MaxJwtLifetimeSeconds);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPollStatus, model.PollStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUpdatedByActorID, model.UpdatedByActorID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFederationIssuer
        {
            ID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CheckJti = true,
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            IssuerUrl = "https://token.actions.githubusercontent.com",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MaxJwtLifetimeSeconds = 0,
            Name = "github-actions",
            PollStatus = new()
            {
                ConsecutiveFailures = 0,
                LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationIssuer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFederationIssuer
        {
            ID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CheckJti = true,
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            IssuerUrl = "https://token.actions.githubusercontent.com",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MaxJwtLifetimeSeconds = 0,
            Name = "github-actions",
            PollStatus = new()
            {
                ConsecutiveFailures = 0,
                LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationIssuer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "fdis_01SDCCSbTxrXDpWc1phhtcfK";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedArchivedByActorID = "archived_by_actor_id";
        bool expectedCheckJti = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedCreatedByActorID = "created_by_actor_id";
        string expectedIssuerUrl = "https://token.actions.githubusercontent.com";
        BetaFederationIssuerJwks expectedJwks = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        DateTimeOffset expectedJwksPollingDisabledAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedMaxJwtLifetimeSeconds = 0;
        string expectedName = "github-actions";
        BetaFederationIssuerPollStatus expectedPollStatus = new()
        {
            ConsecutiveFailures = 0,
            LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("federation_issuer");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedUpdatedByActorID = "updated_by_actor_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedArchivedByActorID, deserialized.ArchivedByActorID);
        Assert.Equal(expectedCheckJti, deserialized.CheckJti);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedByActorID, deserialized.CreatedByActorID);
        Assert.Equal(expectedIssuerUrl, deserialized.IssuerUrl);
        Assert.Equal(expectedJwks, deserialized.Jwks);
        Assert.Equal(expectedJwksPollingDisabledAt, deserialized.JwksPollingDisabledAt);
        Assert.Equal(expectedMaxJwtLifetimeSeconds, deserialized.MaxJwtLifetimeSeconds);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPollStatus, deserialized.PollStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUpdatedByActorID, deserialized.UpdatedByActorID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFederationIssuer
        {
            ID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CheckJti = true,
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            IssuerUrl = "https://token.actions.githubusercontent.com",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MaxJwtLifetimeSeconds = 0,
            Name = "github-actions",
            PollStatus = new()
            {
                ConsecutiveFailures = 0,
                LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFederationIssuer
        {
            ID = "fdis_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CheckJti = true,
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            IssuerUrl = "https://token.actions.githubusercontent.com",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MaxJwtLifetimeSeconds = 0,
            Name = "github-actions",
            PollStatus = new()
            {
                ConsecutiveFailures = 0,
                LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        BetaFederationIssuer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaFederationIssuerJwksTest : TestBase
{
    [Fact]
    public void BetaJwksDiscoveryValidationWorks()
    {
        BetaFederationIssuerJwks value = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        value.Validate();
    }

    [Fact]
    public void BetaJwksExplicitUrlValidationWorks()
    {
        BetaFederationIssuerJwks value = new BetaJwksExplicitUrl()
        {
            Url = "x",
            CACertPem = "ca_cert_pem",
        };
        value.Validate();
    }

    [Fact]
    public void BetaJwksInlineValidationWorks()
    {
        BetaFederationIssuerJwks value = new BetaJwksInline(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void BetaJwksDiscoverySerializationRoundtripWorks()
    {
        BetaFederationIssuerJwks value = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationIssuerJwks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaJwksExplicitUrlSerializationRoundtripWorks()
    {
        BetaFederationIssuerJwks value = new BetaJwksExplicitUrl()
        {
            Url = "x",
            CACertPem = "ca_cert_pem",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationIssuerJwks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaJwksInlineSerializationRoundtripWorks()
    {
        BetaFederationIssuerJwks value = new BetaJwksInline(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationIssuerJwks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
