using System.Collections.Generic;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Anthropic.Exceptions;

namespace Anthropic.Core;

static class Sse
{
    internal static async IAsyncEnumerable<T> Enumerate<T>(
        HttpResponseMessage response,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var stream = await response
            .Content.ReadAsStreamAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);

        await foreach (var item in SseParser.Create(stream).EnumerateAsync(cancellationToken))
        {
            switch (item.EventType)
            {
                case "completion":
                case "message_start":
                case "message_delta":
                case "message_stop":
                case "content_block_start":
                case "content_block_delta":
                case "content_block_stop":
                case "message":
                case "user.message":
                case "user.interrupt":
                case "user.tool_confirmation":
                case "user.custom_tool_result":
                case "agent.message":
                case "agent.thinking":
                case "agent.tool_use":
                case "agent.tool_result":
                case "agent.mcp_tool_use":
                case "agent.mcp_tool_result":
                case "agent.custom_tool_use":
                case "agent.thread_context_compacted":
                case "session.status_running":
                case "session.status_idle":
                case "session.status_rescheduled":
                case "session.status_terminated":
                case "session.error":
                case "session.deleted":
                case "span.model_request_start":
                case "span.model_request_end":
                    T? message;
                    try
                    {
                        message = JsonSerializer.Deserialize<T>(
                            item.Data,
                            ModelBase.SerializerOptions
                        );
                    }
                    catch (JsonException e)
                    {
                        throw new AnthropicInvalidDataException(
                            $"Message must be of type {typeof(T).FullName}",
                            e
                        );
                    }
                    yield return message
                        ?? throw new AnthropicInvalidDataException("Message cannot be null");
                    break;
                case "ping":
                    continue;
                case "error":
                    throw new AnthropicSseException(
                        string.Format("SSE error returned from server: '{0}'", item.Data)
                    )
                    {
                        ErrorType = AnthropicExceptionFactory.ExtractErrorType(item.Data),
                    };
            }
        }
    }
}
