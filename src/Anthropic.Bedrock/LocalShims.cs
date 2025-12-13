#if !NET
using System.Buffers;

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

    /// <summary>
    /// Reads bytes from the current stream and advances the position within the stream until the <paramref name="buffer"/> is filled.
    /// </summary>
    /// <param name="buffer">A region of memory. When this method returns, the contents of this region are replaced by the bytes read from the current stream.</param>
    /// <exception cref="EndOfStreamException">
    /// The end of the stream is reached before filling the <paramref name="buffer"/>.
    /// </exception>
    /// <remarks>
    /// When <paramref name="buffer"/> is empty, this read operation will be completed without waiting for available data in the stream.
    /// </remarks>
    public static void ReadExactly(this Stream stream, Span<byte> buffer) =>
        _ = stream.ReadAtLeastCore(buffer, buffer.Length, throwOnEndOfStream: true);

    // No argument checking is done here. It is up to the caller.
    private static int ReadAtLeastCore(
        this Stream stream,
        Span<byte> buffer,
        int minimumBytes,
        bool throwOnEndOfStream
    )
    {
        int totalRead = 0;
        while (totalRead < minimumBytes)
        {
            int read = stream.Read(buffer.Slice(totalRead));
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

    public static int Read(this Stream stream, Span<byte> buffer)
    {
        byte[] sharedBuffer = ArrayPool<byte>.Shared.Rent(buffer.Length);
        try
        {
            int numRead = stream.Read(sharedBuffer, 0, buffer.Length);
            if ((uint)numRead > (uint)buffer.Length)
            {
                throw new IOException("The provided stream is too long");
            }

            new ReadOnlySpan<byte>(sharedBuffer, 0, numRead).CopyTo(buffer);
            return numRead;
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(sharedBuffer);
        }
    }
}


#endif
