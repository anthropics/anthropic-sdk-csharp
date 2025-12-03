using System.Net;

namespace Anthropic.Bedrock;

/// <summary>
/// Wraps an HTTP content stream to provide Server-Sent Events (SSE) processing with asynchronous streaming capabilities.
/// This class converts incoming SSE data from the original stream into a format that can be consumed by HTTP clients,
/// using a custom memory stream to buffer data as it's loaded from the remote server.
/// </summary>
/// <remarks>
/// This wrapper is designed to handle streaming SSE responses, particularly for AWS Bedrock streaming APIs.
/// It processes SSE messages asynchronously while providing a synchronous read interface for compatibility
/// with standard HTTP content readers. The class uses a <see cref="LimitedMemoryStream"/> to buffer
/// data between the writer (SSE processor) and reader (HTTP client) threads.
/// </remarks>
internal class AsyncSseEventContentWrapper : HttpContent
{
    private readonly Stream _originalStream;

    public AsyncSseEventContentWrapper(Stream originalStream)
    {
        _originalStream = originalStream;
    }

    protected override Task<Stream> CreateContentReadStreamAsync(CancellationToken cancellationToken)
    {
        var stream = new LimitedMemoryStream();
        Task.Run(async () =>
        {
            try
            {
                await SerializeToStreamAsync(stream, null).ConfigureAwait(false);
            }
            finally
            {
                stream.WriteComplete();
            }
        }, cancellationToken);
        return Task.FromResult<Stream>(stream);
    }

    protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        while (await SseEventHelpers.SyncStreamMessage(_originalStream, stream).ConfigureAwait(false))
        {
        }
    }

    protected override bool TryComputeLength(out long length)
    {
        length = -1;
        return false;
    }

    protected override void Dispose(bool disposing)
    {
        _originalStream.Dispose();
        base.Dispose(disposing);
    }

    private class LimitedMemoryStream : Stream
    {
        private AutoResetEvent _writeDone = new(false);
        private ReaderWriterLockSlim _readerWriterLockSlim = new();
        private CancellationTokenSource _writeComplete = new();
        private MemoryStream _dataStream = new();

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => -1;

        public override long Position { get; set; }

        public void WriteComplete()
        {
            _writeComplete.Cancel();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            // this should only ever be used with the SseMessage reader though StreamReader which only uses the sync read method so we only implement that
            do
            {
                _readerWriterLockSlim.EnterReadLock();
                try
                {
                    if (_dataStream.Length - Position >= count || _writeComplete.IsCancellationRequested)
                    {
                        break;
                    }
                }
                finally
                {
                    _readerWriterLockSlim.ExitReadLock();
                }
                _writeDone.WaitOne(TimeSpan.FromMicroseconds(100)); // there is still a small chance for a deadlock to happen here so use a small timeout to mitigate that.
            } while (true);

            try
            {
                _readerWriterLockSlim.EnterWriteLock();
                _dataStream.Seek(Position, SeekOrigin.Begin);
                var result = _dataStream.Read(buffer, offset, count);
                Position += result;
                return result;
            }
            finally
            {
                _dataStream.Seek(0, SeekOrigin.End);
                _readerWriterLockSlim.ExitWriteLock();
            }
        }

        public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
        {
            _readerWriterLockSlim.EnterWriteLock();
            try
            {
                _dataStream.WriteAsync(buffer, cancellationToken);
                return ValueTask.CompletedTask;
            }
            finally
            {
                _readerWriterLockSlim.ExitWriteLock();
                _writeDone.Set();
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _readerWriterLockSlim.EnterWriteLock();
            try
            {
                _dataStream.Write(buffer, offset, count);
            }
            finally
            {
                _readerWriterLockSlim.ExitWriteLock();
                _writeDone.Set();
            }
        }

        public override void Flush()
        {
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("Seek is not supported on this Stream");
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("SetLength is not supported on this Stream");
        }
    }
}
