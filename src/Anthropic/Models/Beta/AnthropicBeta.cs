using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(EnumConverter<AnthropicBeta, string>))]
public sealed record class AnthropicBeta(string value) : IEnum<AnthropicBeta, string>
{
    public static readonly AnthropicBeta MessageBatches2024_09_24 = new(
        "message-batches-2024-09-24"
    );

    public static readonly AnthropicBeta PromptCaching2024_07_31 = new("prompt-caching-2024-07-31");

    public static readonly AnthropicBeta ComputerUse2024_10_22 = new("computer-use-2024-10-22");

    public static readonly AnthropicBeta ComputerUse2025_01_24 = new("computer-use-2025-01-24");

    public static readonly AnthropicBeta PDFs2024_09_25 = new("pdfs-2024-09-25");

    public static readonly AnthropicBeta TokenCounting2024_11_01 = new("token-counting-2024-11-01");

    public static readonly AnthropicBeta TokenEfficientTools2025_02_19 = new(
        "token-efficient-tools-2025-02-19"
    );

    public static readonly AnthropicBeta Output128k2025_02_19 = new("output-128k-2025-02-19");

    public static readonly AnthropicBeta FilesAPI2025_04_14 = new("files-api-2025-04-14");

    public static readonly AnthropicBeta MCPClient2025_04_04 = new("mcp-client-2025-04-04");

    public static readonly AnthropicBeta DevFullThinking2025_05_14 = new(
        "dev-full-thinking-2025-05-14"
    );

    public static readonly AnthropicBeta InterleavedThinking2025_05_14 = new(
        "interleaved-thinking-2025-05-14"
    );

    public static readonly AnthropicBeta CodeExecution2025_05_22 = new("code-execution-2025-05-22");

    public static readonly AnthropicBeta ExtendedCacheTTL2025_04_11 = new(
        "extended-cache-ttl-2025-04-11"
    );

    readonly string _value = value;

    public enum Value
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
    }

    public Value Known() =>
        _value switch
        {
            "message-batches-2024-09-24" => Value.MessageBatches2024_09_24,
            "prompt-caching-2024-07-31" => Value.PromptCaching2024_07_31,
            "computer-use-2024-10-22" => Value.ComputerUse2024_10_22,
            "computer-use-2025-01-24" => Value.ComputerUse2025_01_24,
            "pdfs-2024-09-25" => Value.PDFs2024_09_25,
            "token-counting-2024-11-01" => Value.TokenCounting2024_11_01,
            "token-efficient-tools-2025-02-19" => Value.TokenEfficientTools2025_02_19,
            "output-128k-2025-02-19" => Value.Output128k2025_02_19,
            "files-api-2025-04-14" => Value.FilesAPI2025_04_14,
            "mcp-client-2025-04-04" => Value.MCPClient2025_04_04,
            "dev-full-thinking-2025-05-14" => Value.DevFullThinking2025_05_14,
            "interleaved-thinking-2025-05-14" => Value.InterleavedThinking2025_05_14,
            "code-execution-2025-05-22" => Value.CodeExecution2025_05_22,
            "extended-cache-ttl-2025-04-11" => Value.ExtendedCacheTTL2025_04_11,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static AnthropicBeta FromRaw(string value)
    {
        return new(value);
    }
}
