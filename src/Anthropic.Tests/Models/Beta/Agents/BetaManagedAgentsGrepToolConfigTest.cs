using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsGrepToolConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsGrepToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("grep");
        BetaManagedAgentsGrepToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        JsonElement expectedType = JsonSerializer.SerializeToElement("grep");

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsGrepToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsGrepToolConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsGrepToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsGrepToolConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("grep");
        BetaManagedAgentsGrepToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        JsonElement expectedType = JsonSerializer.SerializeToElement("grep");

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsGrepToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsGrepToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        BetaManagedAgentsGrepToolConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsGrepToolConfigPermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAutoValidationWorks()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value = new BetaManagedAgentsAutoPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsGrepToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsGrepToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAutoSerializationRoundtripWorks()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value = new BetaManagedAgentsAutoPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsGrepToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowTypeWorks()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        Assert.Equal(
            BetaManagedAgentsGrepToolConfigPermissionPolicyType.AlwaysAllow,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskTypeWorks()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        Assert.Equal(
            BetaManagedAgentsGrepToolConfigPermissionPolicyType.AlwaysAsk,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAutoTypeWorks()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value = new BetaManagedAgentsAutoPolicy();
        Assert.Equal(BetaManagedAgentsGrepToolConfigPermissionPolicyType.Auto, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsGrepToolConfigPermissionPolicy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "always_allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsGrepToolConfigPermissionPolicyType> expectedType =
            BetaManagedAgentsGrepToolConfigPermissionPolicyType.AlwaysAllow;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsGrepToolConfigPermissionPolicy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsGrepToolConfigPermissionPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsGrepToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsGrepToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsGrepToolConfigPermissionPolicyType.Auto)]
    public void Validation_Works(BetaManagedAgentsGrepToolConfigPermissionPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsGrepToolConfigPermissionPolicyType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGrepToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsGrepToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsGrepToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsGrepToolConfigPermissionPolicyType.Auto)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsGrepToolConfigPermissionPolicyType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsGrepToolConfigPermissionPolicyType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGrepToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGrepToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGrepToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
