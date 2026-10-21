using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMcpToolConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpToolConfig
        {
            Enabled = true,
            Name = "name",
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        bool expectedEnabled = true;
        string expectedName = "name";
        BetaManagedAgentsMcpToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpToolConfig
        {
            Enabled = true,
            Name = "name",
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpToolConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpToolConfig
        {
            Enabled = true,
            Name = "name",
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpToolConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        string expectedName = "name";
        BetaManagedAgentsMcpToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpToolConfig
        {
            Enabled = true,
            Name = "name",
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpToolConfig
        {
            Enabled = true,
            Name = "name",
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        BetaManagedAgentsMcpToolConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpToolConfigPermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAutoValidationWorks()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value = new BetaManagedAgentsAutoPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAutoSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value = new BetaManagedAgentsAutoPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowTypeWorks()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        Assert.Equal(
            BetaManagedAgentsMcpToolConfigPermissionPolicyType.AlwaysAllow,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskTypeWorks()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        Assert.Equal(
            BetaManagedAgentsMcpToolConfigPermissionPolicyType.AlwaysAsk,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAutoTypeWorks()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value = new BetaManagedAgentsAutoPolicy();
        Assert.Equal(BetaManagedAgentsMcpToolConfigPermissionPolicyType.Auto, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMcpToolConfigPermissionPolicy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "always_allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsMcpToolConfigPermissionPolicyType> expectedType =
            BetaManagedAgentsMcpToolConfigPermissionPolicyType.AlwaysAllow;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMcpToolConfigPermissionPolicy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMcpToolConfigPermissionPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsMcpToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsMcpToolConfigPermissionPolicyType.Auto)]
    public void Validation_Works(BetaManagedAgentsMcpToolConfigPermissionPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpToolConfigPermissionPolicyType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsMcpToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsMcpToolConfigPermissionPolicyType.Auto)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMcpToolConfigPermissionPolicyType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpToolConfigPermissionPolicyType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
