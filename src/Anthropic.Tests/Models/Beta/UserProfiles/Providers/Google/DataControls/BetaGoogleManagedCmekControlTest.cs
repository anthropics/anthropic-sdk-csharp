using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedCmekControlTest : TestBase
{
    [Fact]
    public void DisabledValidationWorks()
    {
        BetaGoogleManagedCmekControl value = new BetaGoogleManagedCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void EnabledValidationWorks()
    {
        BetaGoogleManagedCmekControl value = new BetaGoogleManagedCmekEnabled()
        {
            ExternalKeyIds = new Dictionary<string, string>() { { "foo", "string" } },
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedCmekRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedCmekRegionNotConfigured("effective_external_key_id")
                },
            },
        };
        value.Validate();
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedCmekControl value = new BetaGoogleManagedCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekControl>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedCmekControl value = new BetaGoogleManagedCmekEnabled()
        {
            ExternalKeyIds = new Dictionary<string, string>() { { "foo", "string" } },
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedCmekRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedCmekRegionNotConfigured("effective_external_key_id")
                },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekControl>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaGoogleManagedCmekControl value = new BetaGoogleManagedCmekDisabled(
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ]
        );
        Assert.Equal(BetaGoogleManagedCmekControlType.Disabled, value.Type.Value());
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaGoogleManagedCmekControl value = new BetaGoogleManagedCmekEnabled()
        {
            ExternalKeyIds = new Dictionary<string, string>() { { "foo", "string" } },
            RetiredKeys =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalKeyID = "external_key_id",
                    Region = "region",
                },
            ],
            Status = new Dictionary<string, BetaGoogleManagedCmekRegionStatus>()
            {
                {
                    "foo",
                    new BetaGoogleManagedCmekRegionNotConfigured("effective_external_key_id")
                },
            },
        };
        Assert.Equal(BetaGoogleManagedCmekControlType.Enabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedCmekControl value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "retired_keys": [
                    {
                      "expires_at": "2019-12-27T18:11:19.117+00:00",
                      "external_key_id": "external_key_id",
                      "region": "region"
                    }
                  ],
                  "type": "disabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        List<BetaGoogleManagedRetiredKey> expectedRetiredKeys =
        [
            new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                ExternalKeyID = "external_key_id",
                Region = "region",
            },
        ];
        ApiEnum<string, BetaGoogleManagedCmekControlType> expectedType =
            BetaGoogleManagedCmekControlType.Disabled;

        Assert.Equal(expectedRetiredKeys.Count, value.RetiredKeys.Count);
        for (int i = 0; i < expectedRetiredKeys.Count; i++)
        {
            Assert.Equal(expectedRetiredKeys[i], value.RetiredKeys[i]);
        }
        Assert.Equal(expectedType, value.Type);

        BetaGoogleManagedCmekControl emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.RetiredKeys);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaGoogleManagedCmekControlTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedCmekControlType.Disabled)]
    [InlineData(BetaGoogleManagedCmekControlType.Enabled)]
    public void Validation_Works(BetaGoogleManagedCmekControlType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedCmekControlType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaGoogleManagedCmekControlType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaGoogleManagedCmekControlType.Disabled, 2068438255, "disabled")]
    [InlineData(BetaGoogleManagedCmekControlType.Enabled, 924343854, "enabled")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedCmekControlType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedCmekControlType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedCmekControlType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaGoogleManagedCmekControlType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedCmekControlType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
