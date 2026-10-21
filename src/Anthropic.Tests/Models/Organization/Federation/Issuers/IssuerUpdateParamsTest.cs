using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Organization.Federation.Issuers;

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
            Jwks = new JwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabled = true,
            MaxJwtLifetimeSeconds = 1,
            Name = "x",
        };

        string expectedFederationIssuerID = "federation_issuer_id";
        bool expectedCheckJti = true;
        string expectedIssuerUrl = "x";
        IssuerUpdateParamsJwks expectedJwks = new JwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        bool expectedJwksPollingDisabled = true;
        long expectedMaxJwtLifetimeSeconds = 1;
        string expectedName = "x";

        Assert.Equal(expectedFederationIssuerID, parameters.FederationIssuerID);
        Assert.Equal(expectedCheckJti, parameters.CheckJti);
        Assert.Equal(expectedIssuerUrl, parameters.IssuerUrl);
        Assert.Equal(expectedJwks, parameters.Jwks);
        Assert.Equal(expectedJwksPollingDisabled, parameters.JwksPollingDisabled);
        Assert.Equal(expectedMaxJwtLifetimeSeconds, parameters.MaxJwtLifetimeSeconds);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IssuerUpdateParams { FederationIssuerID = "federation_issuer_id" };

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
                    "https://api.anthropic.com/v1/organizations/federation_issuers/federation_issuer_id"
                ),
                url
            )
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
            Jwks = new JwksDiscovery()
            {
                CACertPem = "ca_cert_pem",
                DiscoveryBase = "discovery_base",
            },
            JwksPollingDisabled = true,
            MaxJwtLifetimeSeconds = 1,
            Name = "x",
        };

        IssuerUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class IssuerUpdateParamsJwksTest : TestBase
{
    [Fact]
    public void DiscoveryValidationWorks()
    {
        IssuerUpdateParamsJwks value = new JwksDiscovery()
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };
        value.Validate();
    }

    [Fact]
    public void ExplicitUrlValidationWorks()
    {
        IssuerUpdateParamsJwks value = new JwksExplicitUrl()
        {
            Url = "x",
            CACertPem = "ca_cert_pem",
        };
        value.Validate();
    }

    [Fact]
    public void InlineValidationWorks()
    {
        IssuerUpdateParamsJwks value = new JwksInline(
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
        IssuerUpdateParamsJwks value = new JwksDiscovery()
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
    public void ExplicitUrlSerializationRoundtripWorks()
    {
        IssuerUpdateParamsJwks value = new JwksExplicitUrl()
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
    public void InlineSerializationRoundtripWorks()
    {
        IssuerUpdateParamsJwks value = new JwksInline(
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

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        IssuerUpdateParamsJwks value = new(
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

        IssuerUpdateParamsJwks emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.CACertPem);

        IssuerUpdateParamsJwks mismatchedValue = new(
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
