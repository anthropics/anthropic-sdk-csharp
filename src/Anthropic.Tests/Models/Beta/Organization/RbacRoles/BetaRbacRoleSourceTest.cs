using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.RbacRoles;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles;

public class BetaRbacRoleSourceTest : TestBase
{
    [Fact]
    public void BuiltInValidationWorks()
    {
        BetaRbacRoleSource value = new BetaRbacRoleSourceBuiltIn();
        value.Validate();
    }

    [Fact]
    public void CustomValidationWorks()
    {
        BetaRbacRoleSource value = new BetaRbacRoleSourceCustom();
        value.Validate();
    }

    [Fact]
    public void BuiltInSerializationRoundtripWorks()
    {
        BetaRbacRoleSource value = new BetaRbacRoleSourceBuiltIn();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacRoleSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CustomSerializationRoundtripWorks()
    {
        BetaRbacRoleSource value = new BetaRbacRoleSourceCustom();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacRoleSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BuiltInTypeWorks()
    {
        BetaRbacRoleSource value = new BetaRbacRoleSourceBuiltIn();
        Assert.Equal(BetaRbacRoleSourceType.BuiltIn, value.Type.Value());
    }

    [Fact]
    public void CustomTypeWorks()
    {
        BetaRbacRoleSource value = new BetaRbacRoleSourceCustom();
        Assert.Equal(BetaRbacRoleSourceType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaRbacRoleSource value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "built_in"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaRbacRoleSourceType> expectedType = BetaRbacRoleSourceType.BuiltIn;

        Assert.Equal(expectedType, value.Type);

        BetaRbacRoleSource emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaRbacRoleSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaRbacRoleSourceType.BuiltIn)]
    [InlineData(BetaRbacRoleSourceType.Custom)]
    public void Validation_Works(BetaRbacRoleSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaRbacRoleSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaRbacRoleSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaRbacRoleSourceType.BuiltIn, 0, "built_in")]
    [InlineData(BetaRbacRoleSourceType.Custom, 1, "custom")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaRbacRoleSourceType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaRbacRoleSourceType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaRbacRoleSourceType>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaRbacRoleSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaRbacRoleSourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
