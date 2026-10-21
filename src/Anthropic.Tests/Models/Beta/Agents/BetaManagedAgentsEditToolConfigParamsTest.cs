using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsEditToolConfigParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("edit");
        bool expectedEnabled = true;
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        ApiEnum<string, BetaManagedAgentsEditToolConfigParamsType> expectedType =
            BetaManagedAgentsEditToolConfigParamsType.Edit;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEditToolConfigParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEditToolConfigParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("edit");
        bool expectedEnabled = true;
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        ApiEnum<string, BetaManagedAgentsEditToolConfigParamsType> expectedType =
            BetaManagedAgentsEditToolConfigParamsType.Edit;

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        } with
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.PermissionPolicy);
        Assert.False(model.RawData.ContainsKey("permission_policy"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,

            Enabled = null,
            PermissionPolicy = null,
        };

        Assert.Null(model.Enabled);
        Assert.True(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.PermissionPolicy);
        Assert.True(model.RawData.ContainsKey("permission_policy"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,

            Enabled = null,
            PermissionPolicy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsEditToolConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
            Type = BetaManagedAgentsEditToolConfigParamsType.Edit,
        };

        BetaManagedAgentsEditToolConfigParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsEditToolConfigParamsPermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAutoValidationWorks()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEditToolConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEditToolConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAutoSerializationRoundtripWorks()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEditToolConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowTypeWorks()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        Assert.Equal(
            BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.AlwaysAllow,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskTypeWorks()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        Assert.Equal(
            BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.AlwaysAsk,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAutoTypeWorks()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        Assert.Equal(
            BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.Auto,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsEditToolConfigParamsPermissionPolicy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "always_allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsEditToolConfigParamsPermissionPolicyType> expectedType =
            BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.AlwaysAllow;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsEditToolConfigParamsPermissionPolicy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsEditToolConfigParamsPermissionPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.Auto)]
    public void Validation_Works(BetaManagedAgentsEditToolConfigParamsPermissionPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEditToolConfigParamsPermissionPolicyType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEditToolConfigParamsPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsEditToolConfigParamsPermissionPolicyType.Auto)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsEditToolConfigParamsPermissionPolicyType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEditToolConfigParamsPermissionPolicyType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEditToolConfigParamsPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEditToolConfigParamsPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEditToolConfigParamsPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsEditToolConfigParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsEditToolConfigParamsType.Edit)]
    public void Validation_Works(BetaManagedAgentsEditToolConfigParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEditToolConfigParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEditToolConfigParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsEditToolConfigParamsType.Edit)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsEditToolConfigParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEditToolConfigParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEditToolConfigParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEditToolConfigParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEditToolConfigParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
