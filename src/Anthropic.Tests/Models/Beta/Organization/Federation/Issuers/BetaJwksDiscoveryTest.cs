using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Issuers;

public class BetaJwksDiscoveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaJwksDiscovery
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("discovery");
        string expectedCACertPem = "ca_cert_pem";
        string expectedDiscoveryBase = "discovery_base";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCACertPem, model.CACertPem);
        Assert.Equal(expectedDiscoveryBase, model.DiscoveryBase);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaJwksDiscovery
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaJwksDiscovery>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaJwksDiscovery
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaJwksDiscovery>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("discovery");
        string expectedCACertPem = "ca_cert_pem";
        string expectedDiscoveryBase = "discovery_base";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCACertPem, deserialized.CACertPem);
        Assert.Equal(expectedDiscoveryBase, deserialized.DiscoveryBase);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaJwksDiscovery
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaJwksDiscovery { };

        Assert.Null(model.CACertPem);
        Assert.False(model.RawData.ContainsKey("ca_cert_pem"));
        Assert.Null(model.DiscoveryBase);
        Assert.False(model.RawData.ContainsKey("discovery_base"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaJwksDiscovery { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaJwksDiscovery { CACertPem = null, DiscoveryBase = null };

        Assert.Null(model.CACertPem);
        Assert.True(model.RawData.ContainsKey("ca_cert_pem"));
        Assert.Null(model.DiscoveryBase);
        Assert.True(model.RawData.ContainsKey("discovery_base"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaJwksDiscovery { CACertPem = null, DiscoveryBase = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaJwksDiscovery
        {
            CACertPem = "ca_cert_pem",
            DiscoveryBase = "discovery_base",
        };

        BetaJwksDiscovery copied = new(model);

        Assert.Equal(model, copied);
    }
}
