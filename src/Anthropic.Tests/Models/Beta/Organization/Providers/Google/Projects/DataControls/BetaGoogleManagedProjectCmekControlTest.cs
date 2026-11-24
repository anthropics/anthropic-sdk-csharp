using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectCmekControlTest : TestBase
{
    [Fact]
    public void DisabledValidationWorks()
    {
        BetaGoogleManagedProjectCmekControl value = new BetaGoogleManagedProjectCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void EnabledValidationWorks()
    {
        BetaGoogleManagedProjectCmekControl value = new BetaGoogleManagedProjectCmekEnabled()
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
        value.Validate();
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectCmekControl value = new BetaGoogleManagedProjectCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekControl>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectCmekControl value = new BetaGoogleManagedProjectCmekEnabled()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekControl>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaGoogleManagedProjectCmekControl value = new BetaGoogleManagedProjectCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                    Region = "us",
                },
            ]
        );
        Assert.Equal(BetaGoogleManagedProjectCmekControlType.Disabled, value.Type.Value());
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaGoogleManagedProjectCmekControl value = new BetaGoogleManagedProjectCmekEnabled()
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
        Assert.Equal(BetaGoogleManagedProjectCmekControlType.Enabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedProjectCmekControl value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "retired_keys": [
                    {
                      "expires_at": "2019-12-27T18:11:19.117+00:00",
                      "external_key_id": "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                      "region": "us"
                    }
                  ],
                  "type": "disabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        List<BetaGoogleManagedProjectRetiredKey> expectedRetiredKeys =
        [
            new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                ExternalKeyID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
                Region = "us",
            },
        ];
        ApiEnum<string, BetaGoogleManagedProjectCmekControlType> expectedType =
            BetaGoogleManagedProjectCmekControlType.Disabled;

        Assert.Equal(expectedRetiredKeys.Count, value.RetiredKeys.Count);
        for (int i = 0; i < expectedRetiredKeys.Count; i++)
        {
            Assert.Equal(expectedRetiredKeys[i], value.RetiredKeys[i]);
        }
        Assert.Equal(expectedType, value.Type);

        BetaGoogleManagedProjectCmekControl emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.RetiredKeys);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaGoogleManagedProjectCmekControlTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedProjectCmekControlType.Disabled)]
    [InlineData(BetaGoogleManagedProjectCmekControlType.Enabled)]
    public void Validation_Works(BetaGoogleManagedProjectCmekControlType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectCmekControlType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekControlType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaGoogleManagedProjectCmekControlType.Disabled, 2068438255, "disabled")]
    [InlineData(BetaGoogleManagedProjectCmekControlType.Enabled, 924343854, "enabled")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedProjectCmekControlType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectCmekControlType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekControlType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekControlType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekControlType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
