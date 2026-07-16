using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Tunnels.Certificates;

namespace Anthropic.Tests.Models.Beta.Tunnels.Certificates;

public class BetaTunnelCertificateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTunnelCertificate
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Fingerprint = "fingerprint",
            TunnelID = "tunnel_id",
        };

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFingerprint = "fingerprint";
        string expectedTunnelID = "tunnel_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tunnel_certificate");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedFingerprint, model.Fingerprint);
        Assert.Equal(expectedTunnelID, model.TunnelID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTunnelCertificate
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Fingerprint = "fingerprint",
            TunnelID = "tunnel_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTunnelCertificate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTunnelCertificate
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Fingerprint = "fingerprint",
            TunnelID = "tunnel_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTunnelCertificate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFingerprint = "fingerprint";
        string expectedTunnelID = "tunnel_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tunnel_certificate");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedFingerprint, deserialized.Fingerprint);
        Assert.Equal(expectedTunnelID, deserialized.TunnelID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTunnelCertificate
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Fingerprint = "fingerprint",
            TunnelID = "tunnel_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTunnelCertificate
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Fingerprint = "fingerprint",
            TunnelID = "tunnel_id",
        };

        BetaTunnelCertificate copied = new(model);

        Assert.Equal(model, copied);
    }
}
