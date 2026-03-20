using System.Net;
using System.Text;

namespace Anthropic.Bedrock;

/// <summary>
/// Wraps an HTTP content stream to provide on demand reading of Server-Sent Events (SSE) data.
/// This class transforms the underlying stream into an SSE-compatible format by reading
/// events on-demand and encoding them as UTF-8 data chunks.
/// </summary>
/// <remarks>
/// This wrapper is used internally to adapt AWS Bedrock streaming responses into a format
/// that can be consumed as SSE events. The content is read on demand of the caller, meaning events are only
/// processed when the stream is read from, not when the wrapper is created.
/// </remarks>
internal class SseEventContentWrapper : HttpContent
{
    private readonly Stream _originalStream;

    public SseEventContentWrapper(Stream originalStream)
    {
        _originalStream = originalStream;
    }

    protected override Task<Stream> CreateContentReadStreamAsync(
#if NET
        CancellationToken cancellationToken
#endif
    )
    {
        return Task.FromResult<Stream>(new SseLazyEventStream(_originalStream));
    }

    protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        throw new NotImplementedException();
    }

    protected override bool TryComputeLength(out long length)
    {
        length = -1;
        return false;
    }

    private class SseLazyEventStream : Stream
    {
        private readonly Stream _sourceStream;
        private Memory<byte> _remainder = Memory<byte>.Empty;

        public SseLazyEventStream(Stream source)
        {
            _sourceStream = source;
        }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => -1;

        public override long Position { get; set; }

        public override void Flush() { }

#if NET
        public override async ValueTask<int> ReadAsync(
            Memory<byte> buffer,
            CancellationToken cancellationToken = default
        )
        {
            // Return buffered remainder from a previous oversized event first
            if (_remainder.Length > 0)
            {
                var toCopy = Math.Min(_remainder.Length, buffer.Length);
                _remainder[..toCopy].CopyTo(buffer);
                _remainder = _remainder[toCopy..];
                return toCopy;
            }

            var (data, success) = await AwsEventStreamHelpers
                .ReadStreamMessage(_sourceStream, cancellationToken)
                .ConfigureAwait(false);
            if (!success)
            {
                return 0;
            }

            var encodedData = Encoding.UTF8.GetBytes(data!);
            var bytesToCopy = Math.Min(encodedData.Length, buffer.Length);
            encodedData.AsMemory(0, bytesToCopy).CopyTo(buffer);
            if (bytesToCopy < encodedData.Length)
            {
                _remainder = encodedData.AsMemory(bytesToCopy);
            }
            return bytesToCopy;
        }
#else
        public override async Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken
        )
        {
            // Return buffered remainder from a previous oversized event first
            if (_remainder.Length > 0)
            {
                var toCopy = Math.Min(_remainder.Length, count);
                _remainder[..toCopy].CopyTo(buffer.AsMemory(offset));
                _remainder = _remainder[toCopy..];
                return toCopy;
            }

            var (data, success) = await AwsEventStreamHelpers
                .ReadStreamMessage(_sourceStream, cancellationToken)
                .ConfigureAwait(false);
            if (!success)
            {
                return 0;
            }

            var encodedData = Encoding.UTF8.GetBytes(data!);
            var bytesToCopy = Math.Min(encodedData.Length, count);
            Array.Copy(encodedData, 0, buffer, offset, bytesToCopy);
            if (bytesToCopy < encodedData.Length)
            {
                _remainder = encodedData.AsMemory(bytesToCopy);
            }
            return bytesToCopy;
        }
#endif

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _sourceStream.Dispose();
        }
    }
}
