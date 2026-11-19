using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ModelTest : TestBase
{
    [Theory]
    [InlineData(Model.ClaudeFable5_2)]
    [InlineData(Model.ClaudeMythos5_2)]
    [InlineData(Model.ClaudeHaiku5_5)]
    [InlineData(Model.ClaudeSonnet5_5)]
    [InlineData(Model.ClaudeFable5_1)]
    [InlineData(Model.ClaudeOpus5_5)]
    [InlineData(Model.ClaudeMythos5_1)]
    [InlineData(Model.ClaudeSonnet5)]
    [InlineData(Model.ClaudeFable5)]
    [InlineData(Model.ClaudeMythos5)]
    [InlineData(Model.ClaudeOpus5)]
    [InlineData(Model.ClaudeOpus4_8)]
    [InlineData(Model.ClaudeOpus4_7)]
    [InlineData(Model.ClaudeMythosPreview)]
    [InlineData(Model.ClaudeOpus4_6)]
    [InlineData(Model.ClaudeSonnet4_6)]
    [InlineData(Model.ClaudeHaiku4_5)]
    [InlineData(Model.ClaudeHaiku4_5_20251001)]
    [InlineData(Model.ClaudeOpus4_5)]
    [InlineData(Model.ClaudeOpus4_5_20251101)]
    [InlineData(Model.ClaudeSonnet4_5)]
    [InlineData(Model.ClaudeSonnet4_5_20250929)]
    public void Validation_Works(Model rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Model> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Model.ClaudeFable5_2, 0, "claude-fable-5-2")]
    [InlineData(Model.ClaudeMythos5_2, 1, "claude-mythos-5-2")]
    [InlineData(Model.ClaudeHaiku5_5, 2, "claude-haiku-5-5")]
    [InlineData(Model.ClaudeSonnet5_5, 3, "claude-sonnet-5-5")]
    [InlineData(Model.ClaudeFable5_1, 4, "claude-fable-5-1")]
    [InlineData(Model.ClaudeOpus5_5, 5, "claude-opus-5-5")]
    [InlineData(Model.ClaudeMythos5_1, 6, "claude-mythos-5-1")]
    [InlineData(Model.ClaudeSonnet5, 7, "claude-sonnet-5")]
    [InlineData(Model.ClaudeFable5, 8, "claude-fable-5")]
    [InlineData(Model.ClaudeMythos5, 9, "claude-mythos-5")]
    [InlineData(Model.ClaudeOpus5, 10, "claude-opus-5")]
    [InlineData(Model.ClaudeOpus4_8, 11, "claude-opus-4-8")]
    [InlineData(Model.ClaudeOpus4_7, 12, "claude-opus-4-7")]
    [InlineData(Model.ClaudeMythosPreview, 13, "claude-mythos-preview")]
    [InlineData(Model.ClaudeOpus4_6, 14, "claude-opus-4-6")]
    [InlineData(Model.ClaudeSonnet4_6, 15, "claude-sonnet-4-6")]
    [InlineData(Model.ClaudeHaiku4_5, 16, "claude-haiku-4-5")]
    [InlineData(Model.ClaudeHaiku4_5_20251001, 17, "claude-haiku-4-5-20251001")]
    [InlineData(Model.ClaudeOpus4_5, 18, "claude-opus-4-5")]
    [InlineData(Model.ClaudeOpus4_5_20251101, 19, "claude-opus-4-5-20251101")]
    [InlineData(Model.ClaudeSonnet4_5, 20, "claude-sonnet-4-5")]
    [InlineData(Model.ClaudeSonnet4_5_20250929, 21, "claude-sonnet-4-5-20250929")]
    public void EnumMemberSerializationRoundtrip_Works(Model rawValue, int number, string apiValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Model> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
