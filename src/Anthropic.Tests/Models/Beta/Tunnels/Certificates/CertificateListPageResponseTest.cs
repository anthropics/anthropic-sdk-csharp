using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Tunnels.Certificates;

namespace Anthropic.Tests.Models.Beta.Tunnels.Certificates;

public class CertificateListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CertificateListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fingerprint = "fingerprint",
                    TunnelID = "tunnel_id",
                },
            ],
            NextPage = "next_page",
        };

        List<BetaTunnelCertificate> expectedData =
        [
            new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fingerprint = "fingerprint",
                TunnelID = "tunnel_id",
            },
        ];
        string expectedNextPage = "next_page";

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
        var model = new CertificateListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fingerprint = "fingerprint",
                    TunnelID = "tunnel_id",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CertificateListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CertificateListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fingerprint = "fingerprint",
                    TunnelID = "tunnel_id",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CertificateListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaTunnelCertificate> expectedData =
        [
            new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fingerprint = "fingerprint",
                TunnelID = "tunnel_id",
            },
        ];
        string expectedNextPage = "next_page";

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
        var model = new CertificateListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fingerprint = "fingerprint",
                    TunnelID = "tunnel_id",
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CertificateListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fingerprint = "fingerprint",
                    TunnelID = "tunnel_id",
                },
            ],
            NextPage = "next_page",
        };

        CertificateListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
