using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagReplyModeTest : TestBase
{
    [Fact]
    public void AutomaticValidationWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeAutomatic();
        value.Validate();
    }

    [Fact]
    public void MentionOnlyValidationWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeMentionOnly();
        value.Validate();
    }

    [Fact]
    public void AlwaysAwakeValidationWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeAlwaysAwake();
        value.Validate();
    }

    [Fact]
    public void ThreadValidationWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeThread();
        value.Validate();
    }

    [Fact]
    public void AutomaticSerializationRoundtripWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeAutomatic();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagReplyMode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MentionOnlySerializationRoundtripWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeMentionOnly();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagReplyMode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AlwaysAwakeSerializationRoundtripWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeAlwaysAwake();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagReplyMode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadSerializationRoundtripWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeThread();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagReplyMode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutomaticTypeWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeAutomatic();
        Assert.Equal(BetaClaudeTagReplyModeType.Automatic, value.Type.Value());
    }

    [Fact]
    public void MentionOnlyTypeWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeMentionOnly();
        Assert.Equal(BetaClaudeTagReplyModeType.MentionOnly, value.Type.Value());
    }

    [Fact]
    public void AlwaysAwakeTypeWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeAlwaysAwake();
        Assert.Equal(BetaClaudeTagReplyModeType.AlwaysAwake, value.Type.Value());
    }

    [Fact]
    public void ThreadTypeWorks()
    {
        BetaClaudeTagReplyMode value = new BetaClaudeTagReplyModeThread();
        Assert.Equal(BetaClaudeTagReplyModeType.Thread, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaClaudeTagReplyMode value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "automatic"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaClaudeTagReplyModeType> expectedType =
            BetaClaudeTagReplyModeType.Automatic;

        Assert.Equal(expectedType, value.Type);

        BetaClaudeTagReplyMode emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaClaudeTagReplyModeTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaClaudeTagReplyModeType.Automatic)]
    [InlineData(BetaClaudeTagReplyModeType.MentionOnly)]
    [InlineData(BetaClaudeTagReplyModeType.AlwaysAwake)]
    [InlineData(BetaClaudeTagReplyModeType.Thread)]
    public void Validation_Works(BetaClaudeTagReplyModeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagReplyModeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagReplyModeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaClaudeTagReplyModeType.Automatic, 0, "automatic")]
    [InlineData(BetaClaudeTagReplyModeType.MentionOnly, 1, "mention_only")]
    [InlineData(BetaClaudeTagReplyModeType.AlwaysAwake, 2, "always_awake")]
    [InlineData(BetaClaudeTagReplyModeType.Thread, 3, "thread")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaClaudeTagReplyModeType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagReplyModeType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagReplyModeType>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagReplyModeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagReplyModeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
