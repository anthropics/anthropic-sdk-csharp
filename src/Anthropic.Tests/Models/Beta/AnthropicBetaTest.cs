using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class AnthropicBetaTest : TestBase
{
    [Theory]
    [InlineData(AnthropicBeta.ComputerUse2024_10_22)]
    [InlineData(AnthropicBeta.ComputerUse2025_01_24)]
    [InlineData(AnthropicBeta.Output128k2025_02_19)]
    [InlineData(AnthropicBeta.McpClient2025_04_04)]
    [InlineData(AnthropicBeta.McpClient2025_11_20)]
    [InlineData(AnthropicBeta.DevFullThinking2025_05_14)]
    [InlineData(AnthropicBeta.InterleavedThinking2025_05_14)]
    [InlineData(AnthropicBeta.CodeExecution2025_05_22)]
    [InlineData(AnthropicBeta.Context1m2025_08_07)]
    [InlineData(AnthropicBeta.ContextManagement2025_06_27)]
    [InlineData(AnthropicBeta.ModelContextWindowExceeded2025_08_26)]
    [InlineData(AnthropicBeta.FastMode2026_02_01)]
    [InlineData(AnthropicBeta.Output300k2026_03_24)]
    [InlineData(AnthropicBeta.UserProfiles2026_03_24)]
    [InlineData(AnthropicBeta.UserProfiles2026_08_18)]
    [InlineData(AnthropicBeta.UserProfiles2026_09_04)]
    [InlineData(AnthropicBeta.AdvisorTool2026_03_01)]
    [InlineData(AnthropicBeta.ManagedAgents2026_04_01)]
    [InlineData(AnthropicBeta.Dreaming2026_04_21)]
    [InlineData(AnthropicBeta.ThinkingTokenCount2026_05_13)]
    [InlineData(AnthropicBeta.ServerSideFallback2026_06_01)]
    [InlineData(AnthropicBeta.ServerSideFallback2026_07_01)]
    [InlineData(AnthropicBeta.FallbackCredit2026_06_01)]
    [InlineData(AnthropicBeta.FallbackCredit2026_07_01)]
    [InlineData(AnthropicBeta.AgentMemory2026_07_22)]
    [InlineData(AnthropicBeta.MidConversationToolChanges2026_07_01)]
    [InlineData(AnthropicBeta.Compact2026_01_12)]
    [InlineData(AnthropicBeta.ComputerUse2025_11_24)]
    [InlineData(AnthropicBeta.McpTunnels2026_06_22)]
    [InlineData(AnthropicBeta.StructuredOutputs2025_11_13)]
    [InlineData(AnthropicBeta.TaskBudgets2026_03_13)]
    [InlineData(AnthropicBeta.ThinkingDisplayUpdates2026_08_18)]
    [InlineData(AnthropicBeta.MidConversationOutputConfig2026_07_01)]
    [InlineData(AnthropicBeta.ThinkingBindingControls2026_08_01)]
    [InlineData(AnthropicBeta.MidConversationSystemClearAt2026_08_21)]
    [InlineData(AnthropicBeta.Compact2026_09_04)]
    [InlineData(AnthropicBeta.InlineTools2026_09_15)]
    [InlineData(AnthropicBeta.McpClient2026_09_15)]
    [InlineData(AnthropicBeta.CEPlugins2026_09_01)]
    [InlineData(AnthropicBeta.SpendLimitReads2026_09_26)]
    [InlineData(AnthropicBeta.TelemetryDestinations2026_08_11)]
    [InlineData(AnthropicBeta.Webhooks2026_10_07)]
    [InlineData(AnthropicBeta.AdminUserSignOut2026_10_08)]
    [InlineData(AnthropicBeta.MessageThreads2026_08_12)]
    [InlineData(AnthropicBeta.AnalyticsUsageCost2026_08_24)]
    [InlineData(AnthropicBeta.ExperimentalClaudeTag2026_10_21)]
    [InlineData(AnthropicBeta.MessageBatches2024_09_24)]
    [InlineData(AnthropicBeta.PromptCaching2024_07_31)]
    [InlineData(AnthropicBeta.Pdfs2024_09_25)]
    [InlineData(AnthropicBeta.TokenCounting2024_11_01)]
    [InlineData(AnthropicBeta.TokenEfficientTools2025_02_19)]
    [InlineData(AnthropicBeta.FilesApi2025_04_14)]
    [InlineData(AnthropicBeta.ExtendedCacheTtl2025_04_11)]
    [InlineData(AnthropicBeta.Skills2025_10_02)]
    [InlineData(AnthropicBeta.CacheDiagnosis2026_04_07)]
    [InlineData(AnthropicBeta.CEUserManagement2026_07_13)]
    [InlineData(AnthropicBeta.CEClaudeCodeManagedSettings2026_10_06)]
    [InlineData(AnthropicBeta.Efs2026_10_01)]
    [InlineData(AnthropicBeta.UserProfilesBilling2026_10_01)]
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
    [InlineData(AnthropicBeta.ComputerUse2024_10_22, 0, "computer-use-2024-10-22")]
    [InlineData(AnthropicBeta.ComputerUse2025_01_24, 1, "computer-use-2025-01-24")]
    [InlineData(AnthropicBeta.Output128k2025_02_19, 2, "output-128k-2025-02-19")]
    [InlineData(AnthropicBeta.McpClient2025_04_04, 3, "mcp-client-2025-04-04")]
    [InlineData(AnthropicBeta.McpClient2025_11_20, 4, "mcp-client-2025-11-20")]
    [InlineData(AnthropicBeta.DevFullThinking2025_05_14, 5, "dev-full-thinking-2025-05-14")]
    [InlineData(AnthropicBeta.InterleavedThinking2025_05_14, 6, "interleaved-thinking-2025-05-14")]
    [InlineData(AnthropicBeta.CodeExecution2025_05_22, 7, "code-execution-2025-05-22")]
    [InlineData(AnthropicBeta.Context1m2025_08_07, 8, "context-1m-2025-08-07")]
    [InlineData(AnthropicBeta.ContextManagement2025_06_27, 9, "context-management-2025-06-27")]
    [InlineData(
        AnthropicBeta.ModelContextWindowExceeded2025_08_26,
        10,
        "model-context-window-exceeded-2025-08-26"
    )]
    [InlineData(AnthropicBeta.FastMode2026_02_01, 11, "fast-mode-2026-02-01")]
    [InlineData(AnthropicBeta.Output300k2026_03_24, 12, "output-300k-2026-03-24")]
    [InlineData(AnthropicBeta.UserProfiles2026_03_24, 13, "user-profiles-2026-03-24")]
    [InlineData(AnthropicBeta.UserProfiles2026_08_18, 14, "user-profiles-2026-08-18")]
    [InlineData(AnthropicBeta.UserProfiles2026_09_04, 15, "user-profiles-2026-09-04")]
    [InlineData(AnthropicBeta.AdvisorTool2026_03_01, 16, "advisor-tool-2026-03-01")]
    [InlineData(AnthropicBeta.ManagedAgents2026_04_01, 17, "managed-agents-2026-04-01")]
    [InlineData(AnthropicBeta.Dreaming2026_04_21, 18, "dreaming-2026-04-21")]
    [InlineData(AnthropicBeta.ThinkingTokenCount2026_05_13, 19, "thinking-token-count-2026-05-13")]
    [InlineData(AnthropicBeta.ServerSideFallback2026_06_01, 20, "server-side-fallback-2026-06-01")]
    [InlineData(AnthropicBeta.ServerSideFallback2026_07_01, 21, "server-side-fallback-2026-07-01")]
    [InlineData(AnthropicBeta.FallbackCredit2026_06_01, 22, "fallback-credit-2026-06-01")]
    [InlineData(AnthropicBeta.FallbackCredit2026_07_01, 23, "fallback-credit-2026-07-01")]
    [InlineData(AnthropicBeta.AgentMemory2026_07_22, 24, "agent-memory-2026-07-22")]
    [InlineData(
        AnthropicBeta.MidConversationToolChanges2026_07_01,
        25,
        "mid-conversation-tool-changes-2026-07-01"
    )]
    [InlineData(AnthropicBeta.Compact2026_01_12, 26, "compact-2026-01-12")]
    [InlineData(AnthropicBeta.ComputerUse2025_11_24, 27, "computer-use-2025-11-24")]
    [InlineData(AnthropicBeta.McpTunnels2026_06_22, 28, "mcp-tunnels-2026-06-22")]
    [InlineData(AnthropicBeta.StructuredOutputs2025_11_13, 29, "structured-outputs-2025-11-13")]
    [InlineData(AnthropicBeta.TaskBudgets2026_03_13, 30, "task-budgets-2026-03-13")]
    [InlineData(
        AnthropicBeta.ThinkingDisplayUpdates2026_08_18,
        31,
        "thinking-display-updates-2026-08-18"
    )]
    [InlineData(
        AnthropicBeta.MidConversationOutputConfig2026_07_01,
        32,
        "mid-conversation-output-config-2026-07-01"
    )]
    [InlineData(
        AnthropicBeta.ThinkingBindingControls2026_08_01,
        33,
        "thinking-binding-controls-2026-08-01"
    )]
    [InlineData(
        AnthropicBeta.MidConversationSystemClearAt2026_08_21,
        34,
        "mid-conversation-system-clear-at-2026-08-21"
    )]
    [InlineData(AnthropicBeta.Compact2026_09_04, 35, "compact-2026-09-04")]
    [InlineData(AnthropicBeta.InlineTools2026_09_15, 36, "inline-tools-2026-09-15")]
    [InlineData(AnthropicBeta.McpClient2026_09_15, 37, "mcp-client-2026-09-15")]
    [InlineData(AnthropicBeta.CEPlugins2026_09_01, 38, "ce-plugins-2026-09-01")]
    [InlineData(AnthropicBeta.SpendLimitReads2026_09_26, 39, "spend-limit-reads-2026-09-26")]
    [InlineData(
        AnthropicBeta.TelemetryDestinations2026_08_11,
        40,
        "telemetry-destinations-2026-08-11"
    )]
    [InlineData(AnthropicBeta.Webhooks2026_10_07, 41, "webhooks-2026-10-07")]
    [InlineData(AnthropicBeta.AdminUserSignOut2026_10_08, 42, "admin-user-sign-out-2026-10-08")]
    [InlineData(AnthropicBeta.MessageThreads2026_08_12, 43, "message-threads-2026-08-12")]
    [InlineData(AnthropicBeta.AnalyticsUsageCost2026_08_24, 44, "analytics-usage-cost-2026-08-24")]
    [InlineData(
        AnthropicBeta.ExperimentalClaudeTag2026_10_21,
        45,
        "experimental-claude-tag-2026-10-21"
    )]
    [InlineData(AnthropicBeta.MessageBatches2024_09_24, 46, "message-batches-2024-09-24")]
    [InlineData(AnthropicBeta.PromptCaching2024_07_31, 47, "prompt-caching-2024-07-31")]
    [InlineData(AnthropicBeta.Pdfs2024_09_25, 48, "pdfs-2024-09-25")]
    [InlineData(AnthropicBeta.TokenCounting2024_11_01, 49, "token-counting-2024-11-01")]
    [InlineData(
        AnthropicBeta.TokenEfficientTools2025_02_19,
        50,
        "token-efficient-tools-2025-02-19"
    )]
    [InlineData(AnthropicBeta.FilesApi2025_04_14, 51, "files-api-2025-04-14")]
    [InlineData(AnthropicBeta.ExtendedCacheTtl2025_04_11, 52, "extended-cache-ttl-2025-04-11")]
    [InlineData(AnthropicBeta.Skills2025_10_02, 53, "skills-2025-10-02")]
    [InlineData(AnthropicBeta.CacheDiagnosis2026_04_07, 54, "cache-diagnosis-2026-04-07")]
    [InlineData(AnthropicBeta.CEUserManagement2026_07_13, 55, "ce-user-management-2026-07-13")]
    [InlineData(
        AnthropicBeta.CEClaudeCodeManagedSettings2026_10_06,
        56,
        "ce-claude-code-managed-settings-2026-10-06"
    )]
    [InlineData(AnthropicBeta.Efs2026_10_01, 79987699, "efs-2026-10-01")]
    [InlineData(
        AnthropicBeta.UserProfilesBilling2026_10_01,
        57,
        "user-profiles-billing-2026-10-01"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        AnthropicBeta rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AnthropicBeta> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AnthropicBeta>>(
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
