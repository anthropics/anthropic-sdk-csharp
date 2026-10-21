using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMcpToolsetDefaultConfigParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetDefaultConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        bool expectedEnabled = true;
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetDefaultConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpToolsetDefaultConfigParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetDefaultConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpToolsetDefaultConfigParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetDefaultConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetDefaultConfigParams { };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.PermissionPolicy);
        Assert.False(model.RawData.ContainsKey("permission_policy"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetDefaultConfigParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetDefaultConfigParams
        {
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
        var model = new BetaManagedAgentsMcpToolsetDefaultConfigParams
        {
            Enabled = null,
            PermissionPolicy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpToolsetDefaultConfigParams
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        BetaManagedAgentsMcpToolsetDefaultConfigParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAutoValidationWorks()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAutoSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowTypeWorks()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        Assert.Equal(
            BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.AlwaysAllow,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskTypeWorks()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        Assert.Equal(
            BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.AlwaysAsk,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAutoTypeWorks()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value =
            new BetaManagedAgentsAutoPolicy();
        Assert.Equal(
            BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.Auto,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "always_allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<
            string,
            BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType
        > expectedType =
            BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.AlwaysAllow;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.Auto)]
    public void Validation_Works(
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType.Auto)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolsetDefaultConfigParamsPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
