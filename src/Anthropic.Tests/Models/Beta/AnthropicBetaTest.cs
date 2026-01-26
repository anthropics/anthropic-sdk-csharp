using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class AnthropicBetaTest : TestBase
{
    [Theory]
    [InlineData(AnthropicBeta.MessageBatches2024_09_24)]
    [InlineData(AnthropicBeta.PromptCaching2024_07_31)]
    [InlineData(AnthropicBeta.ComputerUse2024_10_22)]
    [InlineData(AnthropicBeta.ComputerUse2025_01_24)]
    [InlineData(AnthropicBeta.Pdfs2024_09_25)]
    [InlineData(AnthropicBeta.TokenCounting2024_11_01)]
    [InlineData(AnthropicBeta.TokenEfficientTools2025_02_19)]
    [InlineData(AnthropicBeta.Output128k2025_02_19)]
    [InlineData(AnthropicBeta.FilesApi2025_04_14)]
    [InlineData(AnthropicBeta.McpClient2025_04_04)]
    [InlineData(AnthropicBeta.McpClient2025_11_20)]
    [InlineData(AnthropicBeta.DevFullThinking2025_05_14)]
    [InlineData(AnthropicBeta.InterleavedThinking2025_05_14)]
    [InlineData(AnthropicBeta.CodeExecution2025_05_22)]
    [InlineData(AnthropicBeta.ExtendedCacheTtl2025_04_11)]
    [InlineData(AnthropicBeta.Context1m2025_08_07)]
    [InlineData(AnthropicBeta.ContextManagement2025_06_27)]
    [InlineData(AnthropicBeta.ModelContextWindowExceeded2025_08_26)]
    [InlineData(AnthropicBeta.Skills2025_10_02)]
    public void Validation_Works(AnthropicBeta rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnthropicBeta> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnthropicBeta>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AnthropicBeta.MessageBatches2024_09_24)]
    [InlineData(AnthropicBeta.PromptCaching2024_07_31)]
    [InlineData(AnthropicBeta.ComputerUse2024_10_22)]
    [InlineData(AnthropicBeta.ComputerUse2025_01_24)]
    [InlineData(AnthropicBeta.Pdfs2024_09_25)]
    [InlineData(AnthropicBeta.TokenCounting2024_11_01)]
    [InlineData(AnthropicBeta.TokenEfficientTools2025_02_19)]
    [InlineData(AnthropicBeta.Output128k2025_02_19)]
    [InlineData(AnthropicBeta.FilesApi2025_04_14)]
    [InlineData(AnthropicBeta.McpClient2025_04_04)]
    [InlineData(AnthropicBeta.McpClient2025_11_20)]
    [InlineData(AnthropicBeta.DevFullThinking2025_05_14)]
    [InlineData(AnthropicBeta.InterleavedThinking2025_05_14)]
    [InlineData(AnthropicBeta.CodeExecution2025_05_22)]
    [InlineData(AnthropicBeta.ExtendedCacheTtl2025_04_11)]
    [InlineData(AnthropicBeta.Context1m2025_08_07)]
    [InlineData(AnthropicBeta.ContextManagement2025_06_27)]
    [InlineData(AnthropicBeta.ModelContextWindowExceeded2025_08_26)]
    [InlineData(AnthropicBeta.Skills2025_10_02)]
    public void SerializationRoundtrip_Works(AnthropicBeta rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnthropicBeta> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnthropicBeta>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AnthropicBeta>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnthropicBeta>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
