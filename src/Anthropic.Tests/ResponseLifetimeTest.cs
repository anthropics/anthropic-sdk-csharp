using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Credentials;
using Anthropic.Models.Messages;
using Anthropic.Tests.Helpers;

namespace Anthropic.Tests;

/// <summary>
/// The body of a response is only read after <c>Execute</c> has returned, i.e. after the request's
/// own cancellation scope is gone. These pin what has to hold across that boundary: nothing handed
/// out on the response may hang off the disposed scope
/// (https://github.com/anthropics/anthropic-sdk-csharp/issues/231), the tokens passed to body
/// reads reach the read for as long as it runs, and responses <c>Execute</c> abandons on its
/// error paths are disposed of rather than dropped.
/// </summary>
public class ResponseLifetimeTest
{
    const string MessageStopEvent = "event: message_stop\ndata: {\"type\":\"message_stop\"}\n\n";

    record class BlankParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        ) { }

        public override Uri Url(ClientOptions _options) => new("http://localhost/something");
    }

    static HttpRequest<BlankParams> BlankRequest =>
        new() { Method = HttpMethod.Get, Params = new() };

    static MessageCreateParams MessageParams =>
        new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Role.User }],
            Model = Model.ClaudeOpus4_6,
        };

    [Fact]
    public async Task Execute_DoesNotHandOutATokenFromItsDisposedScope()
    {
        using AnthropicClient client = new() { HttpClient = new(Stalling()) };

        using var response = await client.WithRawResponse.Execute(
            BlankRequest,
            TestContext.Current.CancellationToken
        );

        // Throws ObjectDisposedException on every target framework when the token's source has been
        // disposed, which is the state that made linking against it throw in the issue.
        _ = response.CancellationToken.WaitHandle;
    }

    [Fact]
    public async Task CreateToken_EndsAStalledBodyRead()
    {
        using AnthropicClient client = new() { HttpClient = new(Stalling()) };
        using CancellationTokenSource cancellation = new();

        var message = client.Messages.Create(MessageParams, cancellation.Token);
        cancellation.Cancel();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            FailInsteadOfHanging(message)
        );
    }

    [Fact]
    public async Task DeserializeToken_EndsAStalledBodyRead()
    {
        using AnthropicClient client = new() { HttpClient = new(Stalling()) };
        using CancellationTokenSource readCancellation = new();

        using var response = await client.WithRawResponse.Messages.Create(
            MessageParams,
            TestContext.Current.CancellationToken
        );
        var message = response.Deserialize(readCancellation.Token);
        readCancellation.Cancel();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            FailInsteadOfHanging(message)
        );
    }

    [Fact]
    public async Task CreateStreamingToken_EndsAStalledStream()
    {
        using AnthropicClient client = new()
        {
            HttpClient = new(Stalling(MessageStopEvent, "text/event-stream")),
        };
        using CancellationTokenSource cancellation = new();

        var events = client
            .Messages.CreateStreaming(MessageParams, cancellation.Token)
            .GetAsyncEnumerator(TestContext.Current.CancellationToken);

        Assert.True(await events.MoveNextAsync(), "the event sent before the stall never arrived");
        var next = events.MoveNextAsync();
        cancellation.Cancel();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            FailInsteadOfHanging(next.AsTask())
        );
        // Only now: an async iterator refuses disposal while a MoveNextAsync is still pending.
        await events.DisposeAsync();
    }

    [Fact]
    public async Task Execute_DisposesOfTheResponseWhenTheBackoffCannotBeComputed()
    {
        TrackedStream body = new(Encoding.UTF8.GetBytes("{}"));
        using AnthropicClient client = new()
        {
            HttpClient = new(
                new CannedHandler(() =>
                {
                    var response = Respond(HttpStatusCode.ServiceUnavailable, body);
                    // Parses as a float, but lies far outside what a TimeSpan can hold.
                    response.Headers.TryAddWithoutValidation("Retry-After-Ms", "1e20");
                    return response;
                })
            ),
            MaxRetries = 1,
        };

        await Assert.ThrowsAsync<OverflowException>(() =>
            client.WithRawResponse.Execute(BlankRequest, TestContext.Current.CancellationToken)
        );

        Assert.True(body.Disposed, "the abandoned 503 response was never disposed of");
    }

    [Fact]
    public async Task Execute_DisposesOfTheResponseWhenTheTokenRefreshFails()
    {
        TrackedStream body = new(Encoding.UTF8.GetBytes("{}"));
        using AnthropicClient client = new(
            new ClientOptions
            {
                Credentials = new UnrefreshableCredentials(),
                HttpClient = new(
                    new CannedHandler(() => Respond(HttpStatusCode.Unauthorized, body))
                ),
                MaxRetries = 0,
            }
        );

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            client.WithRawResponse.Execute(BlankRequest, TestContext.Current.CancellationToken)
        );

        Assert.Equal(UnrefreshableCredentials.RefreshFailure, exception.Message);
        Assert.True(body.Disposed, "the abandoned 401 response was never disposed of");
    }

    /// <summary>Turns "never completes" into a failure rather than a hung run.</summary>
    static async Task FailInsteadOfHanging(Task task)
    {
        var first = await Task.WhenAny(
            task,
            Task.Delay(TimeSpan.FromSeconds(30), TestContext.Current.CancellationToken)
        );
        Assert.True(ReferenceEquals(task, first), "the stalled read was never cancelled");
        await task;
    }

    static HttpResponseMessage Respond(
        HttpStatusCode status,
        Stream body,
        string contentType = "application/json"
    )
    {
        StreamContent content = new(body);
        content.Headers.TryAddWithoutValidation("Content-Type", contentType);
        return new HttpResponseMessage(status) { Content = content };
    }

    /// <summary>
    /// A 200 whose body serves <paramref name="prefix"/> and then stalls, like a server that goes
    /// quiet mid-body.
    /// </summary>
    static CannedHandler Stalling(string prefix = "", string contentType = "application/json") =>
        new(() => Respond(HttpStatusCode.OK, new StallingStream(prefix), contentType));

    /// <summary>Answers every request straight away with a freshly built response.</summary>
    sealed class CannedHandler : HttpMessageHandler
    {
        readonly Func<HttpResponseMessage> _respond;

        public CannedHandler(Func<HttpResponseMessage> respond)
        {
            _respond = respond;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        ) => Task.FromResult(_respond());
    }

    /// <summary>Serves a first token but cannot come up with a fresh one after a 401.</summary>
    sealed class UnrefreshableCredentials : IAccessTokenProvider
    {
        public const string RefreshFailure = "the token endpoint is down";

        public ValueTask<AccessToken> GetTokenAsync(
            bool forceRefresh = false,
            CancellationToken cancellationToken = default
        ) =>
            forceRefresh
                ? throw new InvalidOperationException(RefreshFailure)
                : new(new AccessToken("expired-token"));

        public void Dispose() { }
    }

    /// <summary>A body that serves its prefix, then parks every read until it is cancelled.</summary>
    sealed class StallingStream : Stream
    {
        readonly byte[] _prefix;
        int _served;

        public StallingStream(string prefix)
        {
            _prefix = Encoding.UTF8.GetBytes(prefix);
        }

        public override Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken
        ) => ServeOrStall(buffer.AsMemory(offset, count), cancellationToken);

#if NET
        // On .NET the HTTP stack and the parsers read through the memory-based overload.
        public override ValueTask<int> ReadAsync(
            Memory<byte> buffer,
            CancellationToken cancellationToken = default
        ) => new(ServeOrStall(buffer, cancellationToken));
#endif

        async Task<int> ServeOrStall(Memory<byte> buffer, CancellationToken cancellationToken)
        {
            if (_served < _prefix.Length)
            {
                var copied = Math.Min(buffer.Length, _prefix.Length - _served);
                _prefix.AsMemory(_served, copied).CopyTo(buffer);
                _served += copied;
                return copied;
            }
            await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
            return 0;
        }

        // A synchronous read could only hang, so fail loudly if anything reaches for one.
        public override int Read(byte[] buffer, int offset, int count) =>
            throw new NotSupportedException();

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

        public override long Seek(long offset, SeekOrigin origin) =>
            throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) =>
            throw new NotSupportedException();
    }
}
