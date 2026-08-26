using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Issuers;

public class BetaJwksExplicitUrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaJwksExplicitUrl { Url = "x", CACertPem = "ca_cert_pem" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("explicit_url");
        string expectedUrl = "x";
        string expectedCACertPem = "ca_cert_pem";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedCACertPem, model.CACertPem);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaJwksExplicitUrl { Url = "x", CACertPem = "ca_cert_pem" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaJwksExplicitUrl>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaJwksExplicitUrl { Url = "x", CACertPem = "ca_cert_pem" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaJwksExplicitUrl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("explicit_url");
        string expectedUrl = "x";
        string expectedCACertPem = "ca_cert_pem";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedCACertPem, deserialized.CACertPem);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaJwksExplicitUrl { Url = "x", CACertPem = "ca_cert_pem" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaJwksExplicitUrl { Url = "x" };

        Assert.Null(model.CACertPem);
        Assert.False(model.RawData.ContainsKey("ca_cert_pem"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaJwksExplicitUrl { Url = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaJwksExplicitUrl
        {
            Url = "x",

            CACertPem = null,
        };

        Assert.Null(model.CACertPem);
        Assert.True(model.RawData.ContainsKey("ca_cert_pem"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaJwksExplicitUrl
        {
            Url = "x",

            CACertPem = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaJwksExplicitUrl { Url = "x", CACertPem = "ca_cert_pem" };

        BetaJwksExplicitUrl copied = new(model);

        Assert.Equal(model, copied);
    }
}
