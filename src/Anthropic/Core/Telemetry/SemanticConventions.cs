namespace Anthropic.Core.Telemetry;

/// <summary>
/// The names of the attributes that are specific to the Anthropic API: the <c>gen_ai.*</c>
/// attributes of the OpenTelemetry semantic conventions for generative AI, named as the
/// conventions' .NET constants name them, and the SDK's own <c>anthropic.*</c> attributes after
/// the same pattern. They are those that this code computes: <see cref="SpanAttributes"/> has the
/// attributes that the SDK's configuration names, <see cref="Tracing"/> has the names of the
/// attributes that the span of any HTTP API call has, and each SDK method names the resource IDs
/// of its own span. The .NET package that has the conventions' constants is not stable yet.
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

    internal const string AttributeGenAiRequestModel = "gen_ai.request.model";

    /// <summary>The request's <c>stop_sequences</c>, in content mode.</summary>
    internal const string AttributeGenAiRequestStopSequences = "gen_ai.request.stop_sequences";

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

    /// <summary>All the input tokens, the cached and cache-writing ones included.</summary>
    internal const string AttributeGenAiUsageInputTokens = "gen_ai.usage.input_tokens";

    /// <summary>
    /// Set, to true, when the size limit removed message parts or tool result blocks from the
    /// span's content attributes, or left out the stop sequences or a tool call's arguments.
    /// Absent otherwise.
    /// </summary>
    internal const string AttributeAnthropicContentTruncated = "anthropic.content.truncated";

    /// <summary>
    /// The <c>content</c> of the <c>tool_result</c> block that a tool run sends back, in content
    /// mode: a list of content blocks.
    /// </summary>
    internal const string AttributeAnthropicToolResultContent = "anthropic.tool_result.content";

    /// <summary>The <c>toolset_name</c> of the <c>tool_use</c> block, when it has one.</summary>
    internal const string AttributeAnthropicToolsetName = "anthropic.toolset.name";

    /// <summary>All the input tokens of the response's compactions.</summary>
    internal const string AttributeAnthropicUsageCompactionInputTokens =
        "anthropic.usage.compaction.input_tokens";

    /// <summary>The output tokens of the response's compactions.</summary>
    internal const string AttributeAnthropicUsageCompactionOutputTokens =
        "anthropic.usage.compaction.output_tokens";

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
