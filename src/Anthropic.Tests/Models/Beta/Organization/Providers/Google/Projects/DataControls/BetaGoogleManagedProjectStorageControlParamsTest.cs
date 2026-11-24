using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectStorageControlParamsTest : TestBase
{
    [Fact]
    public void DisabledValidationWorks()
    {
        BetaGoogleManagedProjectStorageControlParams value =
            new BetaGoogleManagedProjectStorageDisabledParams();
        value.Validate();
    }

    [Fact]
    public void EnabledValidationWorks()
    {
        BetaGoogleManagedProjectStorageControlParams value =
            new BetaGoogleManagedProjectStorageEnabledParams()
            {
                Buckets = new Dictionary<string, BetaGoogleManagedProjectBucketReference?>()
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
        BetaGoogleManagedProjectStorageControlParams value =
            new BetaGoogleManagedProjectStorageDisabledParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageControlParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectStorageControlParams value =
            new BetaGoogleManagedProjectStorageEnabledParams()
            {
                Buckets = new Dictionary<string, BetaGoogleManagedProjectBucketReference?>()
                {
                    {
                        "foo",
                        new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                    },
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageControlParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaGoogleManagedProjectStorageControlParams value =
            new BetaGoogleManagedProjectStorageDisabledParams();
        Assert.Equal(BetaGoogleManagedProjectStorageControlParamsType.Disabled, value.Type.Value());
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaGoogleManagedProjectStorageControlParams value =
            new BetaGoogleManagedProjectStorageEnabledParams()
            {
                Buckets = new Dictionary<string, BetaGoogleManagedProjectBucketReference?>()
                {
                    {
                        "foo",
                        new() { BucketName = "bucket_name", ProjectNumber = "project_number" }
                    },
                },
            };
        Assert.Equal(BetaGoogleManagedProjectStorageControlParamsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedProjectStorageControlParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "disabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaGoogleManagedProjectStorageControlParamsType> expectedType =
            BetaGoogleManagedProjectStorageControlParamsType.Disabled;

        Assert.Equal(expectedType, value.Type);

        BetaGoogleManagedProjectStorageControlParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaGoogleManagedProjectStorageControlParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedProjectStorageControlParamsType.Disabled)]
    [InlineData(BetaGoogleManagedProjectStorageControlParamsType.Enabled)]
    public void Validation_Works(BetaGoogleManagedProjectStorageControlParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectStorageControlParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectStorageControlParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaGoogleManagedProjectStorageControlParamsType.Disabled, 2068438255, "disabled")]
    [InlineData(BetaGoogleManagedProjectStorageControlParamsType.Enabled, 924343854, "enabled")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedProjectStorageControlParamsType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectStorageControlParamsType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectStorageControlParamsType>
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
            ApiEnum<string, BetaGoogleManagedProjectStorageControlParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectStorageControlParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
