using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedCmekDisabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ],
        };

        List<BetaGoogleManagedRetiredKey> expectedRetiredKeys =
        [
            new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalKeyID = "external_key_id",
                Region = "region",
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
        var model = new BetaGoogleManagedCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekDisabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekDisabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaGoogleManagedRetiredKey> expectedRetiredKeys =
        [
            new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalKeyID = "external_key_id",
                Region = "region",
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
        var model = new BetaGoogleManagedCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedCmekDisabled
        {
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ],
        };

        BetaGoogleManagedCmekDisabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
