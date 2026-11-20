using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

public class BetaClaudeCodeRbacGroupStatusTest : TestBase
{
    [Fact]
    public void ActiveValidationWorks()
    {
        BetaClaudeCodeRbacGroupStatus value = new BetaClaudeCodeRbacGroupStatusActive();
        value.Validate();
    }

    [Fact]
    public void DeletedValidationWorks()
    {
        BetaClaudeCodeRbacGroupStatus value = new BetaClaudeCodeRbacGroupStatusDeleted();
        value.Validate();
    }

    [Fact]
    public void UnknownValidationWorks()
    {
        BetaClaudeCodeRbacGroupStatus value = new BetaClaudeCodeRbacGroupStatusUnknown();
        value.Validate();
    }

    [Fact]
    public void ActiveSerializationRoundtripWorks()
    {
        BetaClaudeCodeRbacGroupStatus value = new BetaClaudeCodeRbacGroupStatusActive();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DeletedSerializationRoundtripWorks()
    {
        BetaClaudeCodeRbacGroupStatus value = new BetaClaudeCodeRbacGroupStatusDeleted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownSerializationRoundtripWorks()
    {
        BetaClaudeCodeRbacGroupStatus value = new BetaClaudeCodeRbacGroupStatusUnknown();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActiveTypeWorks()
    {
        BetaClaudeCodeRbacGroupStatus value = new BetaClaudeCodeRbacGroupStatusActive();
        Assert.Equal(BetaClaudeCodeRbacGroupStatusType.Active, value.Type.Value());
    }

    [Fact]
    public void DeletedTypeWorks()
    {
        BetaClaudeCodeRbacGroupStatus value = new BetaClaudeCodeRbacGroupStatusDeleted();
        Assert.Equal(BetaClaudeCodeRbacGroupStatusType.Deleted, value.Type.Value());
    }

    [Fact]
    public void UnknownTypeWorks()
    {
        BetaClaudeCodeRbacGroupStatus value = new BetaClaudeCodeRbacGroupStatusUnknown();
        Assert.Equal(BetaClaudeCodeRbacGroupStatusType.Unknown, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaClaudeCodeRbacGroupStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "active"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaClaudeCodeRbacGroupStatusType> expectedType =
            BetaClaudeCodeRbacGroupStatusType.Active;

        Assert.Equal(expectedType, value.Type);

        BetaClaudeCodeRbacGroupStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaClaudeCodeRbacGroupStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaClaudeCodeRbacGroupStatusType.Active)]
    [InlineData(BetaClaudeCodeRbacGroupStatusType.Deleted)]
    [InlineData(BetaClaudeCodeRbacGroupStatusType.Unknown)]
    public void Validation_Works(BetaClaudeCodeRbacGroupStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeCodeRbacGroupStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeCodeRbacGroupStatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaClaudeCodeRbacGroupStatusType.Active, 0, "active")]
    [InlineData(BetaClaudeCodeRbacGroupStatusType.Deleted, 1, "deleted")]
    [InlineData(BetaClaudeCodeRbacGroupStatusType.Unknown, 2, "unknown")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaClaudeCodeRbacGroupStatusType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeCodeRbacGroupStatusType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeRbacGroupStatusType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeCodeRbacGroupStatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeCodeRbacGroupStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
