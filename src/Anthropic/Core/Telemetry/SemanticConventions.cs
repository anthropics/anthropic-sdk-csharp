namespace Anthropic.Core.Telemetry;

/// <summary>
/// The names of the attributes that are specific to the Anthropic API: the <c>gen_ai.*</c>
/// attributes of the OpenTelemetry semantic conventions for generative AI, named as the
/// conventions' .NET constants name them, and the SDK's own <c>anthropic.*</c> attributes after
/// the same pattern. <see cref="Tracing"/> has the names of the attributes that the span of any
/// HTTP API call has, and each SDK method names the resource IDs of its own span. The .NET package
/// that has the conventions' constants is not stable yet.
/// </summary>
static class SemanticConventions
{
    /// <summary>The conversation that the application says a call is in.</summary>
    internal const string AttributeGenAiConversationId = "gen_ai.conversation.id";

    /// <summary>The request's messages, in content mode.</summary>
    internal const string AttributeGenAiInputMessages = "gen_ai.input.messages";

    /// <summary>One of <see cref="GenAiOperationName"/>.</summary>
    internal const string AttributeGenAiOperationName = "gen_ai.operation.name";

    /// <summary>The response's content, in content mode.</summary>
    internal const string AttributeGenAiOutputMessages = "gen_ai.output.messages";

    /// <summary>One of <see cref="GenAiOutputType"/>, when the request sets an output format.</summary>
    internal const string AttributeGenAiOutputType = "gen_ai.output.type";

    /// <summary><c>anthropic</c>, or the platform the client goes through.</summary>
    internal const string AttributeGenAiProviderName = "gen_ai.provider.name";

    internal const string AttributeGenAiRequestMaxTokens = "gen_ai.request.max_tokens";

    internal const string AttributeGenAiRequestModel = "gen_ai.request.model";

    /// <summary>The request's <c>output_config.effort</c>.</summary>
    internal const string AttributeGenAiRequestReasoningLevel = "gen_ai.request.reasoning.level";

    /// <summary>The request's <c>stop_sequences</c>, in content mode.</summary>
    internal const string AttributeGenAiRequestStopSequences = "gen_ai.request.stop_sequences";

    /// <summary>Set, to true, when the response is streamed.</summary>
    internal const string AttributeGenAiRequestStream = "gen_ai.request.stream";

    internal const string AttributeGenAiRequestTemperature = "gen_ai.request.temperature";

    internal const string AttributeGenAiRequestTopK = "gen_ai.request.top_k";

    internal const string AttributeGenAiRequestTopP = "gen_ai.request.top_p";

    /// <summary>The Message's <c>id</c>.</summary>
    internal const string AttributeGenAiResponseId = "gen_ai.response.id";

    internal const string AttributeGenAiResponseModel = "gen_ai.response.model";

    /// <summary>
    /// The seconds from the start of the API call to the first <c>content_block_delta</c> event
    /// of its stream, whatever the delta's type. A stream without such an event has none.
    /// </summary>
    internal const string AttributeGenAiResponseTimeToFirstChunk =
        "gen_ai.response.time_to_first_chunk";

    /// <summary>The request's system prompt, in content mode.</summary>
    internal const string AttributeGenAiSystemInstructions = "gen_ai.system_instructions";

    /// <summary>The input of a tool call, in content mode.</summary>
    internal const string AttributeGenAiToolCallArguments = "gen_ai.tool.call.arguments";

    /// <summary>The <c>id</c> of the <c>tool_use</c> block.</summary>
    internal const string AttributeGenAiToolCallId = "gen_ai.tool.call.id";

    /// <summary>The description in the tool's definition.</summary>
    internal const string AttributeGenAiToolDescription = "gen_ai.tool.description";

    internal const string AttributeGenAiToolName = "gen_ai.tool.name";

    /// <summary>One of <see cref="GenAiToolType"/>.</summary>
    internal const string AttributeGenAiToolType = "gen_ai.tool.type";

    internal const string AttributeGenAiUsageCacheWriteInputTokens =
        "gen_ai.usage.cache_write.input_tokens";

    internal const string AttributeGenAiUsageCacheReadInputTokens =
        "gen_ai.usage.cache_read.input_tokens";

    /// <summary>All the input tokens, the cached and cache-writing ones included.</summary>
    internal const string AttributeGenAiUsageInputTokens = "gen_ai.usage.input_tokens";

    internal const string AttributeGenAiUsageOutputTokens = "gen_ai.usage.output_tokens";

    internal const string AttributeGenAiUsageReasoningOutputTokens =
        "gen_ai.usage.reasoning.output_tokens";

    internal const string AttributeAnthropicBeta = "anthropic.beta";

    /// <summary>
    /// Set, to true, when the size limit removed message parts or tool result blocks from the
    /// span's content attributes, or left out the stop sequences or a tool call's arguments.
    /// Absent otherwise.
    /// </summary>
    internal const string AttributeAnthropicContentTruncated = "anthropic.content.truncated";

    internal const string AttributeAnthropicMessageCountTokensInputTokens =
        "anthropic.message.count_tokens.input_tokens";

    /// <summary>The Message's <c>stop_reason</c>, as the API gives it.</summary>
    internal const string AttributeAnthropicMessageStopReason = "anthropic.message.stop_reason";

    /// <summary>From the <c>anthropic-organization-id</c> response header.</summary>
    internal const string AttributeAnthropicOrganizationId = "anthropic.organization.id";

    /// <summary>From the <c>request-id</c> response header.</summary>
    internal const string AttributeAnthropicRequestId = "anthropic.request.id";

    /// <summary>The <c>service_tier</c> the request asks for.</summary>
    internal const string AttributeAnthropicRequestServiceTier = "anthropic.request.service_tier";

    /// <summary>The <c>service_tier</c> of the response's usage.</summary>
    internal const string AttributeAnthropicResponseServiceTier = "anthropic.response.service_tier";

    internal const string AttributeAnthropicThinkingBudgetTokens =
        "anthropic.thinking.budget_tokens";

    internal const string AttributeAnthropicThinkingType = "anthropic.thinking.type";

    /// <summary>
    /// The <c>content</c> of the <c>tool_result</c> block that a tool run sends back, in content
    /// mode: a list of content blocks.
    /// </summary>
    internal const string AttributeAnthropicToolResultContent = "anthropic.tool_result.content";

    /// <summary>The <c>toolset_name</c> of the <c>tool_use</c> block, when it has one.</summary>
    internal const string AttributeAnthropicToolsetName = "anthropic.toolset.name";

    internal const string AttributeAnthropicUsageCacheCreationEphemeral1hInputTokens =
        "anthropic.usage.cache_creation.ephemeral_1h_input_tokens";

    internal const string AttributeAnthropicUsageCacheCreationEphemeral5mInputTokens =
        "anthropic.usage.cache_creation.ephemeral_5m_input_tokens";

    /// <summary>All the input tokens of the response's compactions.</summary>
    internal const string AttributeAnthropicUsageCompactionInputTokens =
        "anthropic.usage.compaction.input_tokens";

    /// <summary>The output tokens of the response's compactions.</summary>
    internal const string AttributeAnthropicUsageCompactionOutputTokens =
        "anthropic.usage.compaction.output_tokens";

    /// <summary>From the <c>anthropic-workspace-id</c> response header.</summary>
    internal const string AttributeAnthropicWorkspaceId = "anthropic.workspace.id";

    /// <summary>The values of <see cref="AttributeGenAiOutputType"/>.</summary>
    internal static class GenAiOutputType
    {
        /// <summary>The request sets an output format, which asks the model for JSON.</summary>
        internal const string Json = "json";
    }

    /// <summary>The values of <see cref="AttributeGenAiOperationName"/>.</summary>
    internal static class GenAiOperationName
    {
        /// <summary>A Messages create call.</summary>
        internal const string Chat = "chat";

        /// <summary>One run of a tool.</summary>
        internal const string ExecuteTool = "execute_tool";

        /// <summary>One loop of a tool runner.</summary>
        internal const string InvokeAgent = "invoke_agent";
    }

    /// <summary>The values of <see cref="AttributeGenAiToolType"/>.</summary>
    internal static class GenAiToolType
    {
        /// <summary>A tool that runs in the application.</summary>
        internal const string Function = "function";
    }
}
