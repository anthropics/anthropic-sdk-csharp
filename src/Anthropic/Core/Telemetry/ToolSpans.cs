using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using Anthropic.Models.Beta.Messages;
using static Anthropic.Core.Telemetry.SemanticConventions;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// The <see cref="ActivityKind.Internal"/> spans of a tool runner: the tool runner span,
/// <c>anthropic.messages.tool_runner</c>, for each loop, and <c>anthropic.custom_tool_use</c> or
/// <c>anthropic.mcp_tool_use</c> for each tool that the runner executes. The runner starts and ends
/// them around its own code.
/// </summary>
static class ToolSpans
{
    /// <summary>
    /// Starts the tool runner span, <c>anthropic.messages.tool_runner</c>, of one loop of a
    /// Messages tool runner whose client has <paramref name="options"/> and whose first request
    /// has <paramref name="parameters"/>, as a child of the current activity, and makes it the
    /// current activity. Returns null when the client emits no spans or nothing listens for this
    /// one, and then reads nothing of <paramref name="parameters"/>.
    /// </summary>
    internal static Activity? StartToolRunnerSpan(
        ClientOptions options,
        MessageCreateParams parameters
    )
    {
        if (!Tracing.IsEnabled(options))
        {
            return null;
        }
        var tags = ApiCallSpans.ClientAttributes(options);
        tags.Add(new(AttributeGenAiOperationName, GenAiOperationName.InvokeAgent));
        tags.AddTag(AttributeGenAiRequestModel, parameters.RawBodyData.Text("model"));
        // The parameters set `output_config.format`, or the deprecated `output_format`. They are
        // read as JSON: a typed read throws for a value that this SDK version has no model for.
        var body = parameters.RawBodyData;
        if (
            body.Property("output_config")?.Property("format")
                is { ValueKind: not JsonValueKind.Null }
            || body.Property("output_format") is { ValueKind: not JsonValueKind.Null }
        )
        {
            tags.Add(new(AttributeGenAiOutputType, GenAiOutputType.Json));
        }
        return Tracing.StartSpan(
            options.ResolvedOpenTelemetry,
            "anthropic.messages.tool_runner",
            ActivityKind.Internal,
            tags,
            options.OpenTelemetrySource
        );
    }

    /// <summary>
    /// Starts the span of one run of the client tool that <paramref name="toolUse"/> calls, as a
    /// child of the current activity, and makes it the current activity.
    /// <paramref name="spanName"/> is <c>anthropic.custom_tool_use</c> for a tool the application
    /// defined and <c>anthropic.mcp_tool_use</c> for a tool an MCP helper made. The span's name
    /// carries the tool's name after a space, and is <paramref name="spanName"/> alone when the
    /// tool has none. The span gets the runner's conversation ID, the block's
    /// <c>toolset_name</c> when it has one, the description of
    /// <paramref name="definition"/>, the tool's definition, when it has one, and in content mode
    /// the tool's input, unless it is over the size limit by itself
    /// (<see cref="Content.SetToolCallArguments"/>). The <c>EndToolUseSpan</c> overloads end it.
    /// Returns null when the client emits no spans or nothing listens for this one. The runner
    /// asks that first (<see cref="Tracing.IsEnabled"/>): the definition is the application's to
    /// compute, and is read only for a span.
    /// </summary>
    internal static Activity? StartToolUseSpan(
        ClientOptions options,
        string spanName,
        BetaToolUseBlock toolUse,
        BetaToolUnion? definition
    )
    {
        var name = toolUse.Name;
        var tags = ApiCallSpans.ClientAttributes(options);
        tags.Add(new(AttributeGenAiOperationName, GenAiOperationName.ExecuteTool));
        tags.Add(new(AttributeGenAiToolName, name));
        tags.AddTag(AttributeGenAiToolDescription, Description(definition));
        tags.AddTag(AttributeGenAiToolCallId, toolUse.RawData.Text("id"));
        tags.AddTag(AttributeAnthropicToolsetName, toolUse.RawData.Text("toolset_name"));
        tags.Add(new(AttributeGenAiToolType, GenAiToolType.Function));
        var span = Tracing.StartSpan(
            options.ResolvedOpenTelemetry,
            name.Length == 0 ? spanName : spanName + " " + name,
            ActivityKind.Internal,
            tags,
            options.OpenTelemetrySource
        );
        if (Content.IsRecorded(options.ResolvedOpenTelemetry))
        {
            // A model throws for a required field that the block does not have.
            ActivityTags.Record(
                span,
                recordingSpan =>
                    Content.SetToolCallArguments(
                        recordingSpan,
                        JsonSerializer.Serialize(toolUse.Input, Content.JsonOptions),
                        Content.Limit(options.ResolvedOpenTelemetry)
                    )
            );
        }
        return span;
    }

    /// <summary>
    /// The description in <paramref name="definition"/>, or null when it has none or an empty
    /// one. Only some kinds of tool definition have one, so it is read from the definition's JSON.
    /// </summary>
    static string? Description(BetaToolUnion? definition)
    {
        try
        {
            return definition?.Json.Text("description") is { Length: > 0 } description
                ? description
                : null;
        }
        catch (Exception)
        {
            // A failure to record telemetry must not fail the run.
            return null;
        }
    }

    /// <summary>
    /// Ends <paramref name="span"/>, the tool span of a run that made <paramref name="result"/>,
    /// what the runner sends back to the model. An error result fails the span with
    /// <c>tool_error</c>. In content mode the span gets the content blocks of the result's content,
    /// of an error result too, within the size limit (<see cref="Content.SetToolResultContent"/>).
    /// </summary>
    internal static void EndToolUseSpan(
        ClientOptions options,
        Activity span,
        BetaToolResultBlockParam result
    )
    {
        if (Content.IsRecorded(options.ResolvedOpenTelemetry))
        {
            ActivityTags.Record(
                span,
                recordingSpan =>
                    Content.SetToolResultContent(
                        recordingSpan,
                        Content.ToolResultContent(result.Content?.Json),
                        Content.Limit(options.ResolvedOpenTelemetry)
                    )
            );
        }
        if (result.IsError == true)
        {
            Tracing.SetErrorStatus(span, "tool_error");
        }
        else
        {
            span.SetStatus(ActivityStatusCode.Ok);
        }
        Tracing.End(span);
    }

    /// <summary>
    /// Ends <paramref name="span"/>, the tool span of a run that threw <paramref name="error"/>
    /// out of the runner, and so made no result: it fails with <c>tool_error</c>, unless
    /// <paramref name="cancellationToken"/>, the application's token for the run, requested the
    /// cancellation, which leaves the status unset, as it does for a canceled API call and for
    /// the tool runner span.
    /// </summary>
    internal static void EndToolUseSpan(
        Activity span,
        Exception error,
        CancellationToken cancellationToken
    )
    {
        if (!(error is OperationCanceledException && cancellationToken.IsCancellationRequested))
        {
            Tracing.SetErrorStatus(span, "tool_error");
        }
        Tracing.End(span);
    }
}
