using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Anthropic.Exceptions;

namespace Anthropic.Core;

static class Jsonl
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
        using var reader = new StreamReader(stream);

        string? line;
        while ((line = await reader.ReadLineAsync(
#if NET
                    cancellationToken
#endif
                ).ConfigureAwait(false)) != null)
        {
            if (line.Length == 0)
            {
                continue;
            }

            T? item;
            try
            {
                item = JsonSerializer.Deserialize<T>(line, ModelBase.SerializerOptions);
            }
            catch (JsonException e)
            {
                throw new AnthropicInvalidDataException(
                    $"Item must be of type {typeof(T).FullName}",
                    e
                );
            }

            yield return item ?? throw new AnthropicInvalidDataException("Item cannot be null");
        }
    }
}
