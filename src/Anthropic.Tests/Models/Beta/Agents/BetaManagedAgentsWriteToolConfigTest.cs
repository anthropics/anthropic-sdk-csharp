using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWriteToolConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWriteToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("write");
        BetaManagedAgentsWriteToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        JsonElement expectedType = JsonSerializer.SerializeToElement("write");

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedPermissionPolicy, model.PermissionPolicy);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWriteToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWriteToolConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWriteToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWriteToolConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        JsonElement expectedName = JsonSerializer.SerializeToElement("write");
        BetaManagedAgentsWriteToolConfigPermissionPolicy expectedPermissionPolicy =
            new BetaManagedAgentsAlwaysAllowPolicy();
        JsonElement expectedType = JsonSerializer.SerializeToElement("write");

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.Equal(expectedPermissionPolicy, deserialized.PermissionPolicy);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWriteToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWriteToolConfig
        {
            Enabled = true,
            PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy(),
        };

        BetaManagedAgentsWriteToolConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsWriteToolConfigPermissionPolicyTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAlwaysAllowValidationWorks()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskValidationWorks()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAutoValidationWorks()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value = new BetaManagedAgentsAutoPolicy();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWriteToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWriteToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAutoSerializationRoundtripWorks()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value = new BetaManagedAgentsAutoPolicy();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWriteToolConfigPermissionPolicy>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAllowTypeWorks()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAllowPolicy();
        Assert.Equal(
            BetaManagedAgentsWriteToolConfigPermissionPolicyType.AlwaysAllow,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAlwaysAskTypeWorks()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value =
            new BetaManagedAgentsAlwaysAskPolicy();
        Assert.Equal(
            BetaManagedAgentsWriteToolConfigPermissionPolicyType.AlwaysAsk,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsAutoTypeWorks()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value = new BetaManagedAgentsAutoPolicy();
        Assert.Equal(BetaManagedAgentsWriteToolConfigPermissionPolicyType.Auto, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsWriteToolConfigPermissionPolicy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "always_allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsWriteToolConfigPermissionPolicyType> expectedType =
            BetaManagedAgentsWriteToolConfigPermissionPolicyType.AlwaysAllow;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsWriteToolConfigPermissionPolicy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsWriteToolConfigPermissionPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsWriteToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsWriteToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsWriteToolConfigPermissionPolicyType.Auto)]
    public void Validation_Works(BetaManagedAgentsWriteToolConfigPermissionPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWriteToolConfigPermissionPolicyType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWriteToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsWriteToolConfigPermissionPolicyType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsWriteToolConfigPermissionPolicyType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsWriteToolConfigPermissionPolicyType.Auto)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsWriteToolConfigPermissionPolicyType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWriteToolConfigPermissionPolicyType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWriteToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWriteToolConfigPermissionPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWriteToolConfigPermissionPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
