using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Issuers;

public class IssuerUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IssuerUpdateParams
        {
            FederationIssuerID = "federation_issuer_id",
            CheckJti = true,
            IssuerUrl = "x",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabled = true,
            MaxJwtLifetimeSeconds = 1,
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedFederationIssuerID = "federation_issuer_id";
        bool expectedCheckJti = true;
        string expectedIssuerUrl = "x";
        IssuerUpdateParamsJwks expectedJwks = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        bool expectedJwksPollingDisabled = true;
        long expectedMaxJwtLifetimeSeconds = 1;
        string expectedName = "x";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedFederationIssuerID, parameters.FederationIssuerID);
        Assert.Equal(expectedCheckJti, parameters.CheckJti);
        Assert.Equal(expectedIssuerUrl, parameters.IssuerUrl);
        Assert.Equal(expectedJwks, parameters.Jwks);
        Assert.Equal(expectedJwksPollingDisabled, parameters.JwksPollingDisabled);
        Assert.Equal(expectedMaxJwtLifetimeSeconds, parameters.MaxJwtLifetimeSeconds);
        Assert.Equal(expectedName, parameters.Name);
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
        var parameters = new IssuerUpdateParams
        {
            FederationIssuerID = "federation_issuer_id",
            CheckJti = true,
            IssuerUrl = "x",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabled = true,
            MaxJwtLifetimeSeconds = 1,
            Name = "x",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IssuerUpdateParams
        {
            FederationIssuerID = "federation_issuer_id",
            CheckJti = true,
            IssuerUrl = "x",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabled = true,
            MaxJwtLifetimeSeconds = 1,
            Name = "x",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IssuerUpdateParams
        {
            FederationIssuerID = "federation_issuer_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.CheckJti);
        Assert.False(parameters.RawBodyData.ContainsKey("check_jti"));
        Assert.Null(parameters.IssuerUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("issuer_url"));
        Assert.Null(parameters.Jwks);
        Assert.False(parameters.RawBodyData.ContainsKey("jwks"));
        Assert.Null(parameters.JwksPollingDisabled);
        Assert.False(parameters.RawBodyData.ContainsKey("jwks_polling_disabled"));
        Assert.Null(parameters.MaxJwtLifetimeSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("max_jwt_lifetime_seconds"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new IssuerUpdateParams
        {
            FederationIssuerID = "federation_issuer_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            CheckJti = null,
            IssuerUrl = null,
            Jwks = null,
            JwksPollingDisabled = null,
            MaxJwtLifetimeSeconds = null,
            Name = null,
        };

        Assert.Null(parameters.CheckJti);
        Assert.True(parameters.RawBodyData.ContainsKey("check_jti"));
        Assert.Null(parameters.IssuerUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("issuer_url"));
        Assert.Null(parameters.Jwks);
        Assert.True(parameters.RawBodyData.ContainsKey("jwks"));
        Assert.Null(parameters.JwksPollingDisabled);
        Assert.True(parameters.RawBodyData.ContainsKey("jwks_polling_disabled"));
        Assert.Null(parameters.MaxJwtLifetimeSeconds);
        Assert.True(parameters.RawBodyData.ContainsKey("max_jwt_lifetime_seconds"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        IssuerUpdateParams parameters = new() { FederationIssuerID = "federation_issuer_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/federation_issuers/federation_issuer_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        IssuerUpdateParams parameters = new()
        {
            FederationIssuerID = "federation_issuer_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IssuerUpdateParams
        {
            FederationIssuerID = "federation_issuer_id",
            CheckJti = true,
            IssuerUrl = "x",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabled = true,
            MaxJwtLifetimeSeconds = 1,
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        IssuerUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class IssuerUpdateParamsJwksTest : TestBase
{
    [Fact]
    public void BetaJwksDiscoveryValidationWorks()
    {
        IssuerUpdateParamsJwks value = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        value.Validate();
    }

    [Fact]
    public void BetaJwksExplicitUrlValidationWorks()
    {
        IssuerUpdateParamsJwks value = new BetaJwksExplicitUrl()
        {
            Url = "x",
            CACertPem = "ca_cert_pem",
        };
        value.Validate();
    }

    [Fact]
    public void BetaJwksInlineValidationWorks()
    {
        IssuerUpdateParamsJwks value = new BetaJwksInline(
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
        IssuerUpdateParamsJwks value = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IssuerUpdateParamsJwks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaJwksExplicitUrlSerializationRoundtripWorks()
    {
        IssuerUpdateParamsJwks value = new BetaJwksExplicitUrl()
        {
            Url = "x",
            CACertPem = "ca_cert_pem",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IssuerUpdateParamsJwks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaJwksInlineSerializationRoundtripWorks()
    {
        IssuerUpdateParamsJwks value = new BetaJwksInline(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IssuerUpdateParamsJwks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
