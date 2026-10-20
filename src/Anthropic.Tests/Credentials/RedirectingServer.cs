using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Anthropic.Tests.Credentials;

/// <summary>
/// Answers the first request with a 307 to another path, and a request that follows it with a 404.
/// </summary>
internal sealed class RedirectingServer : IDisposable
{
    private readonly HttpListener _listener = new();

    public string BaseUrl { get; }

    public RedirectingServer()
    {
        var tcp = new TcpListener(IPAddress.Loopback, 0);
        tcp.Start();
        BaseUrl = $"http://127.0.0.1:{((IPEndPoint)tcp.LocalEndpoint).Port}";
        tcp.Stop();

        _listener.Prefixes.Add(BaseUrl + "/");
        _listener.Start();
        _ = Task.Run(async () =>
        {
            try
            {
                var redirected = (await _listener.GetContextAsync().ConfigureAwait(false)).Response;
                redirected.StatusCode = (int)HttpStatusCode.TemporaryRedirect;
                redirected.RedirectLocation = BaseUrl + "/elsewhere";
                redirected.Close();

                var followed = (await _listener.GetContextAsync().ConfigureAwait(false)).Response;
                followed.StatusCode = (int)HttpStatusCode.NotFound;
                followed.Close();
            }
            catch (Exception e) when (e is HttpListenerException or ObjectDisposedException)
            {
                // Closing the listener fails the wait for a request that never comes. Nothing
                // awaits this task, so the failure would surface as an unobserved exception in
                // whichever test runs when the task is collected.
            }
        });
    }

    public void Dispose() => _listener.Close();
}
