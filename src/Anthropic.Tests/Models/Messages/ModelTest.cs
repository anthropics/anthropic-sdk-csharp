using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ModelTest : TestBase
{
    [Theory]
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
    [InlineData(Model.ClaudeOpus4_0)]
    [InlineData(Model.ClaudeOpus4_20250514)]
    [InlineData(Model.ClaudeSonnet4_0)]
    [InlineData(Model.ClaudeSonnet4_20250514)]
    [InlineData(Model.Claude_3_Haiku_20240307)]
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
    [InlineData(Model.ClaudeOpus4_0)]
    [InlineData(Model.ClaudeOpus4_20250514)]
    [InlineData(Model.ClaudeSonnet4_0)]
    [InlineData(Model.ClaudeSonnet4_20250514)]
    [InlineData(Model.Claude_3_Haiku_20240307)]
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
