using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Issuers;

public class IssuerCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IssuerCreateParams
        {
            IssuerUrl = "x",
            Name = "x",
            CheckJti = true,
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            MaxJwtLifetimeSeconds = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedIssuerUrl = "x";
        string expectedName = "x";
        bool expectedCheckJti = true;
        Jwks expectedJwks = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        long expectedMaxJwtLifetimeSeconds = 1;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedIssuerUrl, parameters.IssuerUrl);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedCheckJti, parameters.CheckJti);
        Assert.Equal(expectedJwks, parameters.Jwks);
        Assert.Equal(expectedMaxJwtLifetimeSeconds, parameters.MaxJwtLifetimeSeconds);
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
        var parameters = new IssuerCreateParams
        {
            IssuerUrl = "x",
            Name = "x",
            CheckJti = true,
            MaxJwtLifetimeSeconds = 1,
        };

        Assert.Null(parameters.Jwks);
        Assert.False(parameters.RawBodyData.ContainsKey("jwks"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IssuerCreateParams
        {
            IssuerUrl = "x",
            Name = "x",
            CheckJti = true,
            MaxJwtLifetimeSeconds = 1,

            // Null should be interpreted as omitted for these properties
            Jwks = null,
            Betas = null,
        };

        Assert.Null(parameters.Jwks);
        Assert.False(parameters.RawBodyData.ContainsKey("jwks"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IssuerCreateParams
        {
            IssuerUrl = "x",
            Name = "x",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.CheckJti);
        Assert.False(parameters.RawBodyData.ContainsKey("check_jti"));
        Assert.Null(parameters.MaxJwtLifetimeSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("max_jwt_lifetime_seconds"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new IssuerCreateParams
        {
            IssuerUrl = "x",
            Name = "x",
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            CheckJti = null,
            MaxJwtLifetimeSeconds = null,
        };

        Assert.Null(parameters.CheckJti);
        Assert.True(parameters.RawBodyData.ContainsKey("check_jti"));
        Assert.Null(parameters.MaxJwtLifetimeSeconds);
        Assert.True(parameters.RawBodyData.ContainsKey("max_jwt_lifetime_seconds"));
    }

    [Fact]
    public void Url_Works()
    {
        IssuerCreateParams parameters = new() { IssuerUrl = "x", Name = "x" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/federation_issuers?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        IssuerCreateParams parameters = new()
        {
            IssuerUrl = "x",
            Name = "x",
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
        var parameters = new IssuerCreateParams
        {
            IssuerUrl = "x",
            Name = "x",
            CheckJti = true,
            Jwks = new BetaJwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            MaxJwtLifetimeSeconds = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        IssuerCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class JwksTest : TestBase
{
    [Fact]
    public void BetaJwksDiscoveryValidationWorks()
    {
        Jwks value = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        value.Validate();
    }

    [Fact]
    public void BetaJwksExplicitUrlValidationWorks()
    {
        Jwks value = new BetaJwksExplicitUrl() { Url = "x", CACertPem = "ca_cert_pem" };
        value.Validate();
    }

    [Fact]
    public void BetaJwksInlineValidationWorks()
    {
        Jwks value = new BetaJwksInline(
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
        Jwks value = new BetaJwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Jwks>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaJwksExplicitUrlSerializationRoundtripWorks()
    {
        Jwks value = new BetaJwksExplicitUrl() { Url = "x", CACertPem = "ca_cert_pem" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Jwks>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaJwksInlineSerializationRoundtripWorks()
    {
        Jwks value = new BetaJwksInline(
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Jwks>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
