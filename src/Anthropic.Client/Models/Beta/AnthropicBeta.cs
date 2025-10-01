using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta;

[JsonConverter(typeof(AnthropicBetaConverter))]
public enum AnthropicBeta
{
    MessageBatches2024_09_24,
    PromptCaching2024_07_31,
    ComputerUse2024_10_22,
    ComputerUse2025_01_24,
    PDFs2024_09_25,
    TokenCounting2024_11_01,
    TokenEfficientTools2025_02_19,
    Output128k2025_02_19,
    FilesAPI2025_04_14,
    MCPClient2025_04_04,
    DevFullThinking2025_05_14,
    InterleavedThinking2025_05_14,
    CodeExecution2025_05_22,
    ExtendedCacheTTL2025_04_11,
    Context1m2025_08_07,
    ContextManagement2025_06_27,
    ModelContextWindowExceeded2025_08_26,
}

sealed class AnthropicBetaConverter : JsonConverter<AnthropicBeta>
{
    public override AnthropicBeta Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message-batches-2024-09-24" => AnthropicBeta.MessageBatches2024_09_24,
            "prompt-caching-2024-07-31" => AnthropicBeta.PromptCaching2024_07_31,
            "computer-use-2024-10-22" => AnthropicBeta.ComputerUse2024_10_22,
            "computer-use-2025-01-24" => AnthropicBeta.ComputerUse2025_01_24,
            "pdfs-2024-09-25" => AnthropicBeta.PDFs2024_09_25,
            "token-counting-2024-11-01" => AnthropicBeta.TokenCounting2024_11_01,
            "token-efficient-tools-2025-02-19" => AnthropicBeta.TokenEfficientTools2025_02_19,
            "output-128k-2025-02-19" => AnthropicBeta.Output128k2025_02_19,
            "files-api-2025-04-14" => AnthropicBeta.FilesAPI2025_04_14,
            "mcp-client-2025-04-04" => AnthropicBeta.MCPClient2025_04_04,
            "dev-full-thinking-2025-05-14" => AnthropicBeta.DevFullThinking2025_05_14,
            "interleaved-thinking-2025-05-14" => AnthropicBeta.InterleavedThinking2025_05_14,
            "code-execution-2025-05-22" => AnthropicBeta.CodeExecution2025_05_22,
            "extended-cache-ttl-2025-04-11" => AnthropicBeta.ExtendedCacheTTL2025_04_11,
            "context-1m-2025-08-07" => AnthropicBeta.Context1m2025_08_07,
            "context-management-2025-06-27" => AnthropicBeta.ContextManagement2025_06_27,
            "model-context-window-exceeded-2025-08-26" =>
                AnthropicBeta.ModelContextWindowExceeded2025_08_26,
            _ => (AnthropicBeta)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnthropicBeta value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnthropicBeta.MessageBatches2024_09_24 => "message-batches-2024-09-24",
                AnthropicBeta.PromptCaching2024_07_31 => "prompt-caching-2024-07-31",
                AnthropicBeta.ComputerUse2024_10_22 => "computer-use-2024-10-22",
                AnthropicBeta.ComputerUse2025_01_24 => "computer-use-2025-01-24",
                AnthropicBeta.PDFs2024_09_25 => "pdfs-2024-09-25",
                AnthropicBeta.TokenCounting2024_11_01 => "token-counting-2024-11-01",
                AnthropicBeta.TokenEfficientTools2025_02_19 => "token-efficient-tools-2025-02-19",
                AnthropicBeta.Output128k2025_02_19 => "output-128k-2025-02-19",
                AnthropicBeta.FilesAPI2025_04_14 => "files-api-2025-04-14",
                AnthropicBeta.MCPClient2025_04_04 => "mcp-client-2025-04-04",
                AnthropicBeta.DevFullThinking2025_05_14 => "dev-full-thinking-2025-05-14",
                AnthropicBeta.InterleavedThinking2025_05_14 => "interleaved-thinking-2025-05-14",
                AnthropicBeta.CodeExecution2025_05_22 => "code-execution-2025-05-22",
                AnthropicBeta.ExtendedCacheTTL2025_04_11 => "extended-cache-ttl-2025-04-11",
                AnthropicBeta.Context1m2025_08_07 => "context-1m-2025-08-07",
                AnthropicBeta.ContextManagement2025_06_27 => "context-management-2025-06-27",
                AnthropicBeta.ModelContextWindowExceeded2025_08_26 =>
                    "model-context-window-exceeded-2025-08-26",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
