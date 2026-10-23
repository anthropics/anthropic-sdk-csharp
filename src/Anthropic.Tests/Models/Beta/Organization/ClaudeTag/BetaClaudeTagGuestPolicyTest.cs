using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagGuestPolicyTest : TestBase
{
    [Fact]
    public void AllowValidationWorks()
    {
        BetaClaudeTagGuestPolicy value = new BetaClaudeTagGuestPolicyAllow();
        value.Validate();
    }

    [Fact]
    public void RestrictValidationWorks()
    {
        BetaClaudeTagGuestPolicy value = new BetaClaudeTagGuestPolicyRestrict();
        value.Validate();
    }

    [Fact]
    public void ChannelOnlyValidationWorks()
    {
        BetaClaudeTagGuestPolicy value = new BetaClaudeTagGuestPolicyChannelOnly();
        value.Validate();
    }

    [Fact]
    public void AllowSerializationRoundtripWorks()
    {
        BetaClaudeTagGuestPolicy value = new BetaClaudeTagGuestPolicyAllow();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagGuestPolicy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RestrictSerializationRoundtripWorks()
    {
        BetaClaudeTagGuestPolicy value = new BetaClaudeTagGuestPolicyRestrict();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagGuestPolicy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChannelOnlySerializationRoundtripWorks()
    {
        BetaClaudeTagGuestPolicy value = new BetaClaudeTagGuestPolicyChannelOnly();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagGuestPolicy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AllowTypeWorks()
    {
        BetaClaudeTagGuestPolicy value = new BetaClaudeTagGuestPolicyAllow();
        Assert.Equal(BetaClaudeTagGuestPolicyType.Allow, value.Type.Value());
    }

    [Fact]
    public void RestrictTypeWorks()
    {
        BetaClaudeTagGuestPolicy value = new BetaClaudeTagGuestPolicyRestrict();
        Assert.Equal(BetaClaudeTagGuestPolicyType.Restrict, value.Type.Value());
    }

    [Fact]
    public void ChannelOnlyTypeWorks()
    {
        BetaClaudeTagGuestPolicy value = new BetaClaudeTagGuestPolicyChannelOnly();
        Assert.Equal(BetaClaudeTagGuestPolicyType.ChannelOnly, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaClaudeTagGuestPolicy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaClaudeTagGuestPolicyType> expectedType =
            BetaClaudeTagGuestPolicyType.Allow;

        Assert.Equal(expectedType, value.Type);

        BetaClaudeTagGuestPolicy emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaClaudeTagGuestPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaClaudeTagGuestPolicyType.Allow)]
    [InlineData(BetaClaudeTagGuestPolicyType.Restrict)]
    [InlineData(BetaClaudeTagGuestPolicyType.ChannelOnly)]
    public void Validation_Works(BetaClaudeTagGuestPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagGuestPolicyType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagGuestPolicyType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaClaudeTagGuestPolicyType.Allow)]
    [InlineData(BetaClaudeTagGuestPolicyType.Restrict)]
    [InlineData(BetaClaudeTagGuestPolicyType.ChannelOnly)]
    public void SerializationRoundtrip_Works(BetaClaudeTagGuestPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagGuestPolicyType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagGuestPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagGuestPolicyType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagGuestPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
