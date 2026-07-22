using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Core;

/// <summary>
/// An <see cref="HttpContent"/> over a lazily produced sequence of SSE byte chunks: the body of
/// a synthetic response whose events are generated while the caller reads. It knows nothing
/// about fallbacks; the chunk source supplies the events and owns the upstream resources.
/// </summary>
internal sealed class LazySseBody : HttpContent
{
    /// <summary>The producer of the chunk sequence, and the teardown hooks for whatever
    /// resources it holds.</summary>
    public interface ISource
    {
        /// <summary>The chunk sequence. Enumerated at most once, starting on the first read;
        /// the token is the first read's, alive while the body is being read.</summary>
        IAsyncEnumerable<byte[]> Chunks(CancellationToken cancellationToken);

        /// <summary>Whether <see cref="Close"/> has run; enumeration must observe this and
        /// finish promptly.</summary>
        bool Closed { get; }

        /// <summary>Tears down the source's resources. Idempotent.</summary>
        void Close();
    }

    readonly ISource _source;

    public LazySseBody(ISource source)
    {
        _source = source;
    }

    protected override Task<Stream> CreateContentReadStreamAsync() =>
        Task.FromResult<Stream>(new ChunkStream(_source));

    protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        using ChunkStream source = new(_source);
        await source.CopyToAsync(stream).ConfigureAwait(false);
    }

    protected override bool TryComputeLength(out long length)
    {
        length = 0;
        return false;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _source.Close();
        }
        base.Dispose(disposing);
    }

    /// <summary>A <see cref="Stream"/> over the lazily produced sequence of byte chunks.</summary>
    sealed class ChunkStream : Stream
    {
        readonly ISource _source;
        IAsyncEnumerator<byte[]>? _chunks;

        /// <summary>
        /// The in-flight iterator step, kept across reads: <c>MoveNextAsync</c> takes no token,
        /// so each read awaits the step under its own token, and a cancelled read leaves the
        /// step for the next read to resume; starting a second <c>MoveNextAsync</c> while one
        /// is pending is illegal.
        /// </summary>
        Task<bool>? _pendingMoveNext;
        byte[] _current = [];
        int _position;

        /// <summary>Whether a read is in progress. Read and written with full fences: this flag
        /// and the source's closed flag form a Dekker-style handshake with <see cref="Dispose"/>:
        /// full fences on both sides guarantee at least one side sees the other, so Dispose
        /// never tears down the iterator while a read is about to advance it. Release/acquire
        /// alone would let both sides read the other's flag as unset.</summary>
        int _reading;

        public ChunkStream(ISource source)
        {
            _source = source;
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush() { }

        public override int Read(byte[] buffer, int offset, int count) =>
            ReadAsync(buffer, offset, count, CancellationToken.None).GetAwaiter().GetResult();

        public override Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken
        ) => ReadCoreAsync(buffer.AsMemory(offset, count), cancellationToken).AsTask();

#if NET
        public override ValueTask<int> ReadAsync(
            Memory<byte> buffer,
            CancellationToken cancellationToken = default
        ) => ReadCoreAsync(buffer, cancellationToken);
#endif

        async ValueTask<int> ReadCoreAsync(Memory<byte> buffer, CancellationToken cancellationToken)
        {
            if (buffer.Length == 0)
            {
                return 0;
            }
            Interlocked.Exchange(ref _reading, 1);
            try
            {
                while (_position >= _current.Length)
                {
                    if (_source.Closed)
                    {
                        return 0;
                    }
                    // Created on the first read so the source works under a token that's alive
                    // while the body is being read; the one the initial request was sent with
                    // belongs to a scope the caller tore down when the response headers arrived.
                    _chunks ??= _source
                        .Chunks(cancellationToken)
                        .GetAsyncEnumerator(CancellationToken.None);
                    var moveNext = _pendingMoveNext ??= _chunks.MoveNextAsync().AsTask();
                    var hasNext = await WaitAsync(moveNext, cancellationToken)
                        .ConfigureAwait(false);
                    _pendingMoveNext = null;
                    if (!hasNext)
                    {
                        return 0;
                    }
                    _current = _chunks.Current;
                    _position = 0;
                }
                var copied = Math.Min(buffer.Length, _current.Length - _position);
                _current.AsMemory(_position, copied).CopyTo(buffer);
                _position += copied;
                return copied;
            }
            finally
            {
                Interlocked.Exchange(ref _reading, 0);
            }
        }

        /// <summary>
        /// Awaits the task, abandoning the wait (not the task) when the token fires.
        /// </summary>
        static async Task<bool> WaitAsync(Task<bool> task, CancellationToken cancellationToken)
        {
#if NET
            return await task.WaitAsync(cancellationToken).ConfigureAwait(false);
#else
            if (task.IsCompleted || !cancellationToken.CanBeCanceled)
            {
                return await task.ConfigureAwait(false);
            }
            TaskCompletionSource<bool> cancelled = new(
                TaskCreationOptions.RunContinuationsAsynchronously
            );
            using (cancellationToken.Register(() => cancelled.TrySetCanceled(cancellationToken)))
            {
                var completed = await Task.WhenAny(task, cancelled.Task).ConfigureAwait(false);
                return await completed.ConfigureAwait(false);
            }
#endif
        }

        public override long Seek(long offset, SeekOrigin origin) =>
            throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) =>
            throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _source.Close();
                // A read may still be awaiting an in-flight step, or a cancelled read may have
                // abandoned a step that's still running; either way the iterator observes the
                // close and finishes on its own, and disposing its enumerator here would race the
                // pending MoveNextAsync.
                if (
                    Interlocked.CompareExchange(ref _reading, 0, 0) == 0
                    && _pendingMoveNext == null
                )
                {
                    var chunks = _chunks;
                    _chunks = null;
                    if (chunks != null)
                    {
                        try
                        {
                            chunks.DisposeAsync().AsTask().GetAwaiter().GetResult();
                        }
                        catch (Exception)
                        {
                            // Tearing down; the consumer already has everything it's getting.
                        }
                    }
                }
                // A step abandoned for good is never awaited again; observe its fault so it
                // doesn't surface as an UnobservedTaskException.
                _pendingMoveNext?.ContinueWith(
                    static task => _ = task.Exception,
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnFaulted
                        | TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default
                );
            }
            base.Dispose(disposing);
        }
    }
}
