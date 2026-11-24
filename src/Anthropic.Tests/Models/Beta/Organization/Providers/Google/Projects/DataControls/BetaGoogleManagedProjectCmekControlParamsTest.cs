using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectCmekControlParamsTest : TestBase
{
    [Fact]
    public void DisabledValidationWorks()
    {
        BetaGoogleManagedProjectCmekControlParams value =
            new BetaGoogleManagedProjectCmekDisabledParams();
        value.Validate();
    }

    [Fact]
    public void EnabledValidationWorks()
    {
        BetaGoogleManagedProjectCmekControlParams value =
            new BetaGoogleManagedProjectCmekEnabledParams()
            {
                ExternalKeyIds = new Dictionary<string, string?>()
                {
                    { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
                },
            };
        value.Validate();
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectCmekControlParams value =
            new BetaGoogleManagedProjectCmekDisabledParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekControlParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaGoogleManagedProjectCmekControlParams value =
            new BetaGoogleManagedProjectCmekEnabledParams()
            {
                ExternalKeyIds = new Dictionary<string, string?>()
                {
                    { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekControlParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaGoogleManagedProjectCmekControlParams value =
            new BetaGoogleManagedProjectCmekDisabledParams();
        Assert.Equal(BetaGoogleManagedProjectCmekControlParamsType.Disabled, value.Type.Value());
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaGoogleManagedProjectCmekControlParams value =
            new BetaGoogleManagedProjectCmekEnabledParams()
            {
                ExternalKeyIds = new Dictionary<string, string?>()
                {
                    { "us", "ekey_01SDCCSbTxrXDpWc1phhtcfK" },
                },
            };
        Assert.Equal(BetaGoogleManagedProjectCmekControlParamsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaGoogleManagedProjectCmekControlParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "disabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaGoogleManagedProjectCmekControlParamsType> expectedType =
            BetaGoogleManagedProjectCmekControlParamsType.Disabled;

        Assert.Equal(expectedType, value.Type);

        BetaGoogleManagedProjectCmekControlParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaGoogleManagedProjectCmekControlParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaGoogleManagedProjectCmekControlParamsType.Disabled)]
    [InlineData(BetaGoogleManagedProjectCmekControlParamsType.Enabled)]
    public void Validation_Works(BetaGoogleManagedProjectCmekControlParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectCmekControlParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekControlParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaGoogleManagedProjectCmekControlParamsType.Disabled, 2068438255, "disabled")]
    [InlineData(BetaGoogleManagedProjectCmekControlParamsType.Enabled, 924343854, "enabled")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaGoogleManagedProjectCmekControlParamsType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaGoogleManagedProjectCmekControlParamsType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekControlParamsType>
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
            ApiEnum<string, BetaGoogleManagedProjectCmekControlParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaGoogleManagedProjectCmekControlParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
