using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectCmekDisabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.Equal(expectedRetiredKeys.Count, model.RetiredKeys.Count);
        for (int i = 0; i < expectedRetiredKeys.Count; i++)
        {
            Assert.Equal(expectedRetiredKeys[i], model.RetiredKeys[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekDisabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekDisabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaGoogleManagedProjectRetiredKey> expectedRetiredKeys =
        [
            new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                Region = "us",
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.Equal(expectedRetiredKeys.Count, deserialized.RetiredKeys.Count);
        for (int i = 0; i < expectedRetiredKeys.Count; i++)
        {
            Assert.Equal(expectedRetiredKeys[i], deserialized.RetiredKeys[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ],
        };

        BetaGoogleManagedProjectCmekDisabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
