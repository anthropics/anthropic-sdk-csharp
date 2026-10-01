using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Organization.Federation.Issuers;

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
            Jwks = new JwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            MaxJwtLifetimeSeconds = 1,
        };

        string expectedIssuerUrl = "x";
        string expectedName = "x";
        bool expectedCheckJti = true;
        Jwks expectedJwks = new JwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        long expectedMaxJwtLifetimeSeconds = 1;

        Assert.Equal(expectedIssuerUrl, parameters.IssuerUrl);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedCheckJti, parameters.CheckJti);
        Assert.Equal(expectedJwks, parameters.Jwks);
        Assert.Equal(expectedMaxJwtLifetimeSeconds, parameters.MaxJwtLifetimeSeconds);
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
        };

        Assert.Null(parameters.Jwks);
        Assert.False(parameters.RawBodyData.ContainsKey("jwks"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IssuerCreateParams
        {
            IssuerUrl = "x",
            Name = "x",
            Jwks = new JwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
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
            Jwks = new JwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },

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
                new Uri("https://api.anthropic.com/v1/organizations/federation_issuers"),
                url
            )
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
            Jwks = new JwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            MaxJwtLifetimeSeconds = 1,
        };

        IssuerCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class JwksTest : TestBase
{
    [Fact]
    public void DiscoveryValidationWorks()
    {
        Jwks value = new JwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        value.Validate();
    }

    [Fact]
    public void ExplicitUrlValidationWorks()
    {
        Jwks value = new JwksExplicitUrl() { Url = "x", CACertPem = "ca_cert_pem" };
        value.Validate();
    }

    [Fact]
    public void InlineValidationWorks()
    {
        Jwks value = new JwksInline(
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
    public void DiscoverySerializationRoundtripWorks()
    {
        Jwks value = new JwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Jwks>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExplicitUrlSerializationRoundtripWorks()
    {
        Jwks value = new JwksExplicitUrl() { Url = "x", CACertPem = "ca_cert_pem" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Jwks>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InlineSerializationRoundtripWorks()
    {
        Jwks value = new JwksInline(
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

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Jwks value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "discovery",
                  "ca_cert_pem": "ca_cert_pem"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("discovery");
        string expectedCACertPem = "ca_cert_pem";

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.Equal(expectedCACertPem, value.CACertPem);

        Jwks emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.CACertPem);

        Jwks mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "ca_cert_pem": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.CACertPem);
    }
}
