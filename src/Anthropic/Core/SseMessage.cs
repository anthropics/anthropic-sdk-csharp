using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Anthropic.Exceptions;

namespace Anthropic.Core;

sealed record class SseMessage(string? Event, string Data, string? ID, int? Retry)
{
    internal static async IAsyncEnumerable<SseMessage> GetEnumerable(
        HttpResponseMessage response,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var state = new SseState();

        using var stream = await response
            .Content.ReadAsStreamAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);
        using var reader = new StreamReader(stream);
        while (true)
        {
            string line;
            try
            {
                var maybeLine = await reader.ReadLineAsync(
#if NET
                    cancellationToken
#endif
                ).ConfigureAwait(false);
                if (maybeLine == null)
                {
                    break;
                }
                else
                {
                    line = maybeLine;
                }
            }
            catch (HttpRequestException e)
            {
                throw new AnthropicIOException("I/O Exception", e);
            }
            // Check for cancellation before decoding the line.
            cancellationToken.ThrowIfCancellationRequested();

            var message = state.Decode(line);
            if (message == null)
            {
                continue;
            }

            switch (message.Event)
            {
                case "completion":
                case "message_start":
                case "message_delta":
                case "message_stop":
                case "content_block_start":
                case "content_block_delta":
                case "content_block_stop":
                    yield return message;
                    break;
                case "ping":
                    continue;
                case "error":
                    throw new AnthropicSseException(
                        string.Format("SSE error returned from server: '{0}'", message)
                    );
            }
        }
    }

    internal T Deserialize<T>()
    {
        return JsonSerializer.Deserialize<T>(this.Data)
            ?? throw new AnthropicInvalidDataException("Message cannot be null");
    }
}
