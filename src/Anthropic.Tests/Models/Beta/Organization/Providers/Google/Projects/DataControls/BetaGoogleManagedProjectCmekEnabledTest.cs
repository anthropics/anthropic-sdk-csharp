using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectCmekEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabled
        {
            ExternalKeyIds = new Dictionary<string, string>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectCmekRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id")
                },
            },
        };

        Dictionary<string, string> expectedExternalKeyIds = new()
        {
            { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
        };
        List<BetaGoogleManagedProjectRetiredKey> expectedRetiredKeys =
        [
            new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                Region = "us",
            },
        ];
        Dictionary<string, BetaGoogleManagedProjectCmekRegionStatus> expectedStatus = new()
        {
            {
                "foo",
                new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id")
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedExternalKeyIds.Count, model.ExternalKeyIds.Count);
        foreach (var item in expectedExternalKeyIds)
        {
            Assert.True(model.ExternalKeyIds.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ExternalKeyIds[item.Key]);
        }
        Assert.Equal(expectedRetiredKeys.Count, model.RetiredKeys.Count);
        for (int i = 0; i < expectedRetiredKeys.Count; i++)
        {
            Assert.Equal(expectedRetiredKeys[i], model.RetiredKeys[i]);
        }
        Assert.Equal(expectedStatus.Count, model.Status.Count);
        foreach (var item in expectedStatus)
        {
            Assert.True(model.Status.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Status[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabled
        {
            ExternalKeyIds = new Dictionary<string, string>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectCmekRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id")
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekEnabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabled
        {
            ExternalKeyIds = new Dictionary<string, string>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectCmekRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id")
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekEnabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, string> expectedExternalKeyIds = new()
        {
            { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
        };
        List<BetaGoogleManagedProjectRetiredKey> expectedRetiredKeys =
        [
            new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                Region = "us",
            },
        ];
        Dictionary<string, BetaGoogleManagedProjectCmekRegionStatus> expectedStatus = new()
        {
            {
                "foo",
                new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id")
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.Equal(expectedExternalKeyIds.Count, deserialized.ExternalKeyIds.Count);
        foreach (var item in expectedExternalKeyIds)
        {
            Assert.True(deserialized.ExternalKeyIds.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ExternalKeyIds[item.Key]);
        }
        Assert.Equal(expectedRetiredKeys.Count, deserialized.RetiredKeys.Count);
        for (int i = 0; i < expectedRetiredKeys.Count; i++)
        {
            Assert.Equal(expectedRetiredKeys[i], deserialized.RetiredKeys[i]);
        }
        Assert.Equal(expectedStatus.Count, deserialized.Status.Count);
        foreach (var item in expectedStatus)
        {
            Assert.True(deserialized.Status.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Status[item.Key]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabled
        {
            ExternalKeyIds = new Dictionary<string, string>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectCmekRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id")
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectCmekEnabled
        {
            ExternalKeyIds = new Dictionary<string, string>()
            {
                { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
            },
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedProjectCmekRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedProjectCmekRegionNotConfigured("effective_external_key_id")
                },
            },
        };

        BetaGoogleManagedProjectCmekEnabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
