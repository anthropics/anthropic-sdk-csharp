using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ModelTest : TestBase
{
    [Theory]
    [InlineData(Model.ClaudeSonnet5)]
    [InlineData(Model.ClaudeFable5)]
    [InlineData(Model.ClaudeMythos5)]
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
    [InlineData(Model.ClaudeOpus4_1)]
    [InlineData(Model.ClaudeOpus4_1_20250805)]
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
    [InlineData(Model.ClaudeSonnet5)]
    [InlineData(Model.ClaudeFable5)]
    [InlineData(Model.ClaudeMythos5)]
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
    [InlineData(Model.ClaudeOpus4_1)]
    [InlineData(Model.ClaudeOpus4_1_20250805)]
    public void SerializationRoundtrip_Works(Model rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Model> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
