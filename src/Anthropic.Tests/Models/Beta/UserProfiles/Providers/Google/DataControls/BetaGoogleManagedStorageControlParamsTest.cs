using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.Providers.Google.DataControls;

public class BetaGoogleManagedStorageControlParamsTest : TestBase
{
    [Fact]
    public void DisabledValidationWorks()
    {
        BetaGoogleManagedStorageControlParams value = new BetaGoogleManagedStorageDisabledParams();
        value.Validate();
    }

    [Fact]
    public void EnabledValidationWorks()
    {
        BetaGoogleManagedStorageControlParams value = new BetaGoogleManagedStorageEnabledParams()
        {
            Buckets = new Dictionary<string, BetaGoogleManagedBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };
        value.Validate();
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedStorageControlParams value = new BetaGoogleManagedStorageDisabledParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageControlParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedStorageControlParams value = new BetaGoogleManagedStorageEnabledParams()
        {
            Buckets = new Dictionary<string, BetaGoogleManagedBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageControlParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaGoogleManagedStorageControlParams value = new BetaGoogleManagedStorageDisabledParams();
        Assert.Equal(BetaGoogleManagedStorageControlParamsType.Disabled, value.Type.Value());
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaGoogleManagedStorageControlParams value = new BetaGoogleManagedStorageEnabledParams()
        {
            Buckets = new Dictionary<string, BetaGoogleManagedBucketReference?>()
            {
                {
                    "foo",
                    new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                },
            },
        };
        Assert.Equal(BetaGoogleManagedStorageControlParamsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedStorageControlParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "disabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaGoogleManagedStorageControlParamsType> expectedType =
            BetaGoogleManagedStorageControlParamsType.Disabled;

        Assert.Equal(expectedType, value.Type);

        BetaGoogleManagedStorageControlParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaGoogleManagedStorageControlParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedStorageControlParamsType.Disabled)]
    [InlineData(BetaGoogleManagedStorageControlParamsType.Enabled)]
    public void Validation_Works(BetaGoogleManagedStorageControlParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedStorageControlParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageControlParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaGoogleManagedStorageControlParamsType.Disabled, 2068438255, "disabled")]
    [InlineData(BetaGoogleManagedStorageControlParamsType.Enabled, 924343854, "enabled")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedStorageControlParamsType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedStorageControlParamsType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageControlParamsType>
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
            ApiEnum<string, BetaGoogleManagedStorageControlParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedStorageControlParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
