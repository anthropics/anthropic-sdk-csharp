#if !NET
using System.Buffers;
using System.Runtime.InteropServices;

/// <summary>
/// Contains Shims for .Net 9 available methods to compile on an NetStandard2.0 target.
/// </summary>
internal static class StreamExtensions
{
    public static ValueTask WriteAsync(
        this Stream stream,
        Span<byte> bytes,
        CancellationToken cancellationToken
    )
    {
        return new ValueTask(
            stream.WriteAsync(bytes.ToArray(), 0, bytes.Length, cancellationToken)
        );
    }

    public static ValueTask<int> ReadExactlyAsync(this Stream stream, Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        ValueTask<int> vt = stream.ReadAtLeastAsyncCore(buffer, buffer.Length, throwOnEndOfStream: true, cancellationToken);

        return vt;
    }

    private static async ValueTask<int> ReadAtLeastAsyncCore(this Stream stream, Memory<byte> buffer, int minimumBytes, bool throwOnEndOfStream, CancellationToken cancellationToken)
    {
        int totalRead = 0;
        while (totalRead < minimumBytes)
        {
            int read = await stream.ReadAsync(buffer.Slice(totalRead), cancellationToken).ConfigureAwait(false);
            if (read == 0)
            {
                if (throwOnEndOfStream)
                {
                    throw new EndOfStreamException();
                }

                return totalRead;
            }

            totalRead += read;
        }

        return totalRead;
    }

    public static ValueTask<int> ReadAsync(this Stream stream, Memory<byte> buffer, CancellationToken cancellationToken = default)
    {
        if (MemoryMarshal.TryGetArray(buffer, out ArraySegment<byte> array))
        {
            return new ValueTask<int>(stream.ReadAsync(array.Array!, array.Offset, array.Count, cancellationToken));
        }

        byte[] sharedBuffer = ArrayPool<byte>.Shared.Rent(buffer.Length);
        return FinishReadAsync(stream.ReadAsync(sharedBuffer, 0, buffer.Length, cancellationToken), sharedBuffer, buffer);

        static async ValueTask<int> FinishReadAsync(Task<int> readTask, byte[] localBuffer, Memory<byte> localDestination)
        {
            try
            {
                int result = await readTask.ConfigureAwait(false);
                new ReadOnlySpan<byte>(localBuffer, 0, result).CopyTo(localDestination.Span);
                return result;
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(localBuffer);
            }
        }
    }
}


#endif
