using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.RbacRoles;

namespace Anthropic.Tests.Models.Organization.RbacRoles;

public class RbacRoleSourceTest : TestBase
{
    [Fact]
    public void BuiltInValidationWorks()
    {
        RbacRoleSource value = new RbacRoleSourceBuiltIn();
        value.Validate();
    }

    [Fact]
    public void CustomValidationWorks()
    {
        RbacRoleSource value = new RbacRoleSourceCustom();
        value.Validate();
    }

    [Fact]
    public void BuiltInSerializationRoundtripWorks()
    {
        RbacRoleSource value = new RbacRoleSourceBuiltIn();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRoleSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CustomSerializationRoundtripWorks()
    {
        RbacRoleSource value = new RbacRoleSourceCustom();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRoleSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BuiltInTypeWorks()
    {
        RbacRoleSource value = new RbacRoleSourceBuiltIn();
        Assert.Equal(RbacRoleSourceType.BuiltIn, value.Type.Value());
    }

    [Fact]
    public void CustomTypeWorks()
    {
        RbacRoleSource value = new RbacRoleSourceCustom();
        Assert.Equal(RbacRoleSourceType.Custom, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        RbacRoleSource value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "built_in"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, RbacRoleSourceType> expectedType = RbacRoleSourceType.BuiltIn;

        Assert.Equal(expectedType, value.Type);

        RbacRoleSource emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class RbacRoleSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(RbacRoleSourceType.BuiltIn)]
    [InlineData(RbacRoleSourceType.Custom)]
    public void Validation_Works(RbacRoleSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RbacRoleSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RbacRoleSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RbacRoleSourceType.BuiltIn, 0, "built_in")]
    [InlineData(RbacRoleSourceType.Custom, 1, "custom")]
    public void EnumMemberSerializationRoundtrip_Works(
        RbacRoleSourceType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RbacRoleSourceType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RbacRoleSourceType>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, RbacRoleSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RbacRoleSourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
