using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Anthropic.Client;

sealed record class SseMessage(string? Event, string Data, string? ID, int? Retry)
{
    internal static async IAsyncEnumerable<SseMessage> GetEnumerable(
        HttpResponseMessage response,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var state = new SseState();

        using var stream = await response
            .Content.ReadAsStreamAsync(cancellationToken)
            .ConfigureAwait(false);
        using var reader = new StreamReader(stream);
        string? line;
        while ((line = await reader.ReadLineAsync(cancellationToken).ConfigureAwait(false)) != null)
        {
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
                    throw new Exception();
            }
        }
    }
}
