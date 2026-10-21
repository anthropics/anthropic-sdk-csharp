using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Helpers;
using Anthropic.Models.Beta.Files;
using Anthropic.Models.Beta.Messages;
using Threads = Anthropic.Models.Beta.Sessions.Threads;

namespace Anthropic.Tests.Core.Telemetry;

/// <summary>
/// The HTTP attributes of a call span: the method and the route, which it starts with, the URL of
/// the first request that the call sends, and how many requests followed that one.
/// </summary>
public class HttpAttributesTest : TracingTestBase
{
    static readonly string[] UrlAttributes = ["url.scheme", "url.path", "url.query", "url.full"];

    [Fact]
    public async Task MethodAndRoute_AreWhatASamplerSeesWhenTheSpanStarts()
    {
        using var trace = new RecordedTrace();
        var atStart = new List<Dictionary<string, object?>>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = RecordedTrace.IsSdkSource,
            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
            {
                if (options.Parent.TraceId == trace.Root.TraceId)
                {
                    lock (atStart)
                    {
                        atStart.Add(
                            (options.Tags ?? []).ToDictionary(tag => tag.Key, tag => tag.Value)
                        );
                    }
                }
                return ActivitySamplingResult.AllDataAndRecorded;
            },
        };
        ActivitySource.AddActivityListener(listener);
        var handler = new ScriptedHandler()
            .RespondJson("{}")
            .RespondJson("{}")
            .RespondJson(Fixtures.MessageJson)
            .RespondJson("""{"input_tokens": 21}""");
        var client = Fixtures.Client(handler);

        await client.Beta.Files.RetrieveMetadata(
            "file_1",
            cancellationToken: TestContext.Current.CancellationToken
        );
        await client.Beta.Files.Delete(
            "file_1",
            cancellationToken: TestContext.Current.CancellationToken
        );
        await client.Beta.Messages.Create(BetaParams(), TestContext.Current.CancellationToken);
        await client.Beta.Messages.CountTokens(
            new()
            {
                Messages = [new() { Role = Role.User, Content = "Hi" }],
                Model = "claude-test",
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(
            [
                ("GET", "/v1/files/{file_id}"),
                ("DELETE", "/v1/files/{file_id}"),
                ("POST", "/v1/messages"),
                ("POST", "/v1/messages/count_tokens"),
            ],
            atStart.Select(tags =>
                ((string?)tags["http.request.method"], (string?)tags["http.route"])
            )
        );
        // The URL is only known once the first request is built.
        Assert.All(
            atStart,
            tags => Assert.DoesNotContain(tags.Keys, name => UrlAttributes.Contains(name))
        );
        Assert.All(
            trace.Spans,
            span => Assert.All(UrlAttributes.Except(["url.query"]), name => HasTag(span, name))
        );
    }

    static void HasTag(Activity span, string name) => Assert.NotNull(span.GetTagItem(name));

    [Theory]
    [InlineData("https://api.example.test", "https://api.example.test")]
    [InlineData("https://api.example.test/", "https://api.example.test")]
    [InlineData("https://api.example.test:443", "https://api.example.test")]
    [InlineData("https://api.example.test:8443", "https://api.example.test:8443")]
    [InlineData("http://localhost:8080", "http://localhost:8080")]
    [InlineData("http://[::1]:8080", "http://[::1]:8080")]
    [InlineData("https://gateway.example.test/anthropic", "https://gateway.example.test/anthropic")]
    // Credentials in the base URL are no part of what the span records.
    [InlineData("https://user:secret@gateway.example.test", "https://gateway.example.test")]
    [InlineData(
        "https://user:secret@gateway.example.test:8443",
        "https://gateway.example.test:8443"
    )]
    public async Task UrlAttributes_AreThoseOfTheUrlThatIsSent(string baseUrl, string prefix)
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}");
        var client = Fixtures
            .Client(handler)
            .WithOptions(options => options with { BaseUrl = baseUrl });

        await client.Beta.Files.RetrieveMetadata(
            "file 1",
            cancellationToken: TestContext.Current.CancellationToken
        );

        var sent = Assert.Single(handler.Requests).Uri!;
        var span = trace.Single("anthropic.files.retrieve_metadata");
        Assert.Equal(sent.Scheme, span.GetTagItem("url.scheme"));
        Assert.Equal(sent.AbsolutePath, span.GetTagItem("url.path"));
        Assert.EndsWith("/v1/files/file%201", sent.AbsolutePath, StringComparison.Ordinal);
        // The request's only query parameter is `beta=true`, which the endpoint does not define.
        Assert.Equal("?beta=true", sent.Query);
        Assert.Null(span.GetTagItem("url.query"));
        Assert.Equal(prefix + "/v1/files/file%201", span.GetTagItem("url.full"));
        Assert.All(
            span.TagObjects,
            tag =>
                Assert.DoesNotContain(
                    "secret",
                    tag.Value?.ToString() ?? "",
                    StringComparison.Ordinal
                )
        );
        // The server is that of the base URL, which has the port even when it is the default.
        Assert.Equal(sent.Host.Trim('[', ']'), span.GetTagItem("server.address"));
        Assert.Equal(sent.Port, span.GetTagItem("server.port"));
    }

    [Theory]
    [InlineData("https://api.example.test", 443)]
    [InlineData("http://api.example.test", 80)]
    [InlineData("https://api.example.test:8443", 8443)]
    [InlineData("http://api.example.test:443", 443)]
    public async Task ServerPort_IsThatOfTheBaseUrl_OrTheDefaultOfItsScheme(
        string baseUrl,
        int port
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}");
        var client = Fixtures
            .Client(handler)
            .WithOptions(options => options with { BaseUrl = baseUrl });

        await client.Beta.Files.RetrieveMetadata(
            "file_1",
            cancellationToken: TestContext.Current.CancellationToken
        );

        var span = trace.Single("anthropic.files.retrieve_metadata");
        Assert.Equal("api.example.test", span.GetTagItem("server.address"));
        Assert.Equal(port, span.GetTagItem("server.port"));
    }

    [Fact]
    public async Task UrlQuery_HasOnlyTheParametersThatTheEndpointDefines()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson("""{"data":[],"has_more":false,"first_id":null,"last_id":null}""")
            .RespondJson("""{"data":[],"has_more":false,"first_id":null,"last_id":null}""");
        var client = Fixtures.Client(handler);

        await client.Beta.Files.List(
            new() { Limit = 5, ScopeID = "scope 1/2" },
            TestContext.Current.CancellationToken
        );
        // Raw query data reaches the URL whatever its names.
        await client.Beta.Files.List(
            FileListParams.FromRawUnchecked(
                new Dictionary<string, JsonElement>(),
                new Dictionary<string, JsonElement>
                {
                    ["trace"] = JsonSerializer.SerializeToElement("on"),
                    ["limit"] = JsonSerializer.SerializeToElement(7),
                    ["limits"] = JsonSerializer.SerializeToElement(8),
                    ["beta"] = JsonSerializer.SerializeToElement("false"),
                }
            ),
            TestContext.Current.CancellationToken
        );

        var requests = handler.Requests.ToArray();
        var spans = trace.Spans.Where(span => span.OperationName == "anthropic.files.list");
        Assert.Collection(
            spans,
            span =>
            {
                var sent = requests[0].Uri!.Query.TrimStart('?').Split('&');
                Assert.Contains("beta=true", sent);
                // What is kept is as it was sent, in the order sent.
                var kept = string.Join("&", sent.Where(pair => pair != "beta=true"));
                Assert.Contains("scope_id=scope+1%2f2", kept, StringComparison.Ordinal);
                Assert.Contains("limit=5", kept, StringComparison.Ordinal);
                Assert.Equal(kept, span.GetTagItem("url.query"));
                Assert.Equal(
                    "https://api.example.test/v1/files?" + kept,
                    span.GetTagItem("url.full")
                );
            },
            span =>
            {
                var sent = requests[1].Uri!.Query;
                Assert.Contains("trace=on", sent, StringComparison.Ordinal);
                Assert.Contains("limits=8", sent, StringComparison.Ordinal);
                Assert.Contains("beta=false", sent, StringComparison.Ordinal);
                Assert.Equal("limit=7", span.GetTagItem("url.query"));
                Assert.Equal(
                    "https://api.example.test/v1/files?limit=7",
                    span.GetTagItem("url.full")
                );
            }
        );
    }

    public static TheoryData<string, string[], string?, bool> Queries =>
        new()
        {
            // Nothing is left, or there is no query string.
            { "", ["limit"], null, false },
            { "beta=true", ["limit"], null, false },
            { "beta=true&trace=on", [], null, false },
            // What the SDK and the application add is left out.
            { "beta=true&limit=5", ["limit"], "limit=5", false },
            { "limit=5&trace=on&page=p", ["limit", "page"], "limit=5&page=p", false },
            // The order and the bytes are those sent.
            { "page=a+b%2Fc%2fd&limit=1", ["limit", "page"], "page=a+b%2Fc%2fd&limit=1", false },
            {
                "limit=1&limit=2&flag&empty=",
                ["limit", "flag", "empty"],
                "limit=1&limit=2&flag&empty=",
                false
            },
            // The name is compared decoded, in full.
            { "l%69mit=1&Limit=2&limits=3", ["limit"], "l%69mit=1", false },
            { "after+id=1&after%20id=2", ["after id"], "after+id=1&after%20id=2", false },
            // A name with brackets is first a parameter of its own.
            {
                "created_at%5Bgte%5D=1&created_at[lte]=2&created_at%5bgt%5d=3&created_at=4",
                ["created_at[gte]", "created_at[lte]"],
                "created_at%5Bgte%5D=1&created_at[lte]=2",
                false
            },
            // Otherwise it is the parameter before a final "[]", an array.
            { "ids%5b%5d=a&ids%5B%5D=b&id%5B%5D=c", ["ids"], "ids%5b%5d=a&ids%5B%5D=b", false },
            // Any other brackets make it another name.
            { "limit[x]=1&limit%5Bx%5D%5B%5D=2&limit=5", ["limit"], "limit=5", false },
            { "filter[kind][]=a&filters[kind]=b", ["filter"], null, false },
            { "%5Bids%5D=a&[]=b", ["ids", ""], null, false },
            // A parameter that filters like a search, or whose value comes from stored content,
            // makes what is kept content.
            { "limit=5&email=a%40b.test", ["email", "limit"], "limit=5&email=a%40b.test", true },
            { "path_prefix=%2Fnotes", ["path_prefix"], "path_prefix=%2Fnotes", true },
            {
                "expected_content_sha256=abc&beta=true",
                ["expected_content_sha256"],
                "expected_content_sha256=abc",
                true
            },
            { "e%6Dail%5B%5D=a", ["email"], "e%6Dail%5B%5D=a", true },
            // Only as a parameter of the endpoint, under its own name.
            { "email=a&limit=5", ["limit"], "limit=5", false },
            { "emails=a&Email=b", ["emails", "Email"], "emails=a&Email=b", false },
            { "email[x]=a&limit=5", ["email", "limit"], "limit=5", false },
        };

    [Theory]
    [MemberData(nameof(Queries))]
    public void DefinedQuery_KeepsThePairsOfDefinedParametersAsSent(
        string query,
        string[] queryParams,
        string? expected,
        bool expectedIsContent
    )
    {
        Assert.Equal(expected, Tracing.DefinedQuery(query, queryParams, [], out var isContent));
        Assert.Equal(expectedIsContent, isContent);
    }

    [Theory]
    // A parameter that the endpoint names as content makes what is kept content.
    [InlineData("filter%5B%5D=skill_name%3AQuarterly&limit=5", new[] { "filter" }, true)]
    [InlineData("filter=skill_name%3AQuarterly", new[] { "filter" }, true)]
    // Only on that endpoint, and only when it is sent.
    [InlineData("filter%5B%5D=user_id%3Auser_1&limit=5", new string[0], false)]
    [InlineData("limit=5", new[] { "filter" }, false)]
    [InlineData("filters=a&Filter=b&limit=5", new[] { "filter" }, false)]
    // The parameters that are content on every endpoint are so whatever the endpoint names.
    [InlineData("email=a%40b.test&limit=5", new string[0], true)]
    [InlineData("email=a%40b.test&limit=5", new[] { "filter" }, true)]
    public void DefinedQuery_IsContentWithAParameterThatIsContentOnTheEndpoint(
        string query,
        string[] contentQueryParams,
        bool expectedIsContent
    )
    {
        string[] queryParams = ["email", "filter", "filters", "Filter", "limit"];

        Assert.Equal(
            query,
            Tracing.DefinedQuery(query, queryParams, contentQueryParams, out var isContent)
        );
        Assert.Equal(expectedIsContent, isContent);
    }

    /// <summary>
    /// Calls the endpoint that defines the query parameter <paramref name="parameter"/>, with a
    /// value for it and a <c>limit</c> where the endpoint has one.
    /// </summary>
    static Task CallWithQueryParam(AnthropicClient client, string parameter) =>
        parameter switch
        {
            "email" => client.Beta.Organization.Users.List(
                new() { Email = "a@b.test", Limit = 5 },
                TestContext.Current.CancellationToken
            ),
            "invites.email" => client.Beta.Organization.Invites.List(
                new() { Email = "a@b.test", Limit = 5 },
                TestContext.Current.CancellationToken
            ),
            "path_prefix" => client.Beta.MemoryStores.Memories.List(
                "memstore_1",
                new() { PathPrefix = "/notes", Limit = 5 },
                TestContext.Current.CancellationToken
            ),
            "expected_content_sha256" => client.Beta.MemoryStores.Memories.Delete(
                "mem_1",
                new() { MemoryStoreID = "memstore_1", ExpectedContentSha256 = "abc" },
                TestContext.Current.CancellationToken
            ),
            "limit" => client.Beta.Organization.Users.List(
                new() { Limit = 5 },
                TestContext.Current.CancellationToken
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(parameter)),
        };

    [Theory]
    [InlineData("email", "/v1/organizations/users")]
    [InlineData("invites.email", "/v1/organizations/invites")]
    [InlineData("path_prefix", "/v1/memory_stores/{memory_store_id}/memories")]
    [InlineData(
        "expected_content_sha256",
        "/v1/memory_stores/{memory_store_id}/memories/{memory_id}"
    )]
    public async Task UrlQuery_ThatIsContent_IsOnlyOnASpanThatHoldsContent(
        string parameter,
        string route
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}").RespondJson("{}");

        await CallWithQueryParam(Fixtures.Client(handler), parameter);
        await CallWithQueryParam(
            Fixtures.Client(
                handler,
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
            ),
            parameter
        );

        var name = parameter.Substring(parameter.IndexOf('.') + 1);
        Assert.Collection(
            trace.Spans,
            metadataOnly =>
            {
                Assert.Null(metadataOnly.GetTagItem("url.query"));
                Assert.Null(metadataOnly.GetTagItem("url.full"));
            },
            content =>
            {
                var query = Assert.IsType<string>(content.GetTagItem("url.query"));
                Assert.Contains(name + "=", query, StringComparison.Ordinal);
                Assert.DoesNotContain("beta=", query, StringComparison.Ordinal);
                Assert.Equal(
                    Fixtures.BaseUrl + content.GetTagItem("url.path") + "?" + query,
                    content.GetTagItem("url.full")
                );
            }
        );
        // The request has the parameter either way, and so has the rest of the span its values.
        var requests = handler.Requests.ToArray();
        Assert.Contains(name + "=", requests[0].Uri!.Query, StringComparison.Ordinal);
        Assert.Equal(TagsBesidesTheQuery(trace.Spans[1]), TagsBesidesTheQuery(trace.Spans[0]));
        var span = trace.Spans[0];
        Assert.Equal(route, span.GetTagItem("http.route"));
        Assert.Equal("https", span.GetTagItem("url.scheme"));
        Assert.Equal(requests[0].Uri!.AbsolutePath, span.GetTagItem("url.path"));
        Assert.Equal(
            route.Count(character => character == '{'),
            span.TagObjects.Count(tag =>
                tag.Key is "gen_ai.memory.store.id" or "gen_ai.memory.record.id"
            )
        );
    }

    static Dictionary<string, object?> TagsBesidesTheQuery(Activity span) =>
        span
            .TagObjects.Where(tag => tag.Key is not ("url.query" or "url.full"))
            .ToDictionary(tag => tag.Key, tag => tag.Value);

    [Theory]
    [InlineData(OpenTelemetryContentMode.MetadataOnly)]
    [InlineData(OpenTelemetryContentMode.Content)]
    public async Task UrlQuery_ThatIsNotContent_IsOnTheSpanInEitherMode(
        OpenTelemetryContentMode contentMode
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}");

        await CallWithQueryParam(
            Fixtures.Client(handler, new() { Traces = new() { ContentMode = contentMode } }),
            "limit"
        );

        var span = trace.Single("anthropic.organization.users.list");
        Assert.Equal("limit=5", span.GetTagItem("url.query"));
        Assert.Equal(
            "https://api.example.test/v1/organizations/users?limit=5",
            span.GetTagItem("url.full")
        );
    }

    /// <summary>
    /// Lists <paramref name="resource"/> with a <c>limit</c> and the query parameter that the
    /// endpoint's description gained after its other ones.
    /// </summary>
    static Task ListWithALaterQueryParam(AnthropicClient client, string resource)
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        return resource switch
        {
            "models" => client.Models.List(
                new() { Lifecycle = [Anthropic.Models.Models.Lifecycle.Active], Limit = 5 },
                cancellationToken
            ),
            "beta.models" => client.Beta.Models.List(
                new() { Lifecycle = [Anthropic.Models.Beta.Models.Lifecycle.Active], Limit = 5 },
                cancellationToken
            ),
            "workspaces" => client.Organization.Workspaces.List(
                new() { IncludeDefault = true, Limit = 5 },
                cancellationToken
            ),
            "beta.workspaces" => client.Beta.Organization.Workspaces.List(
                new() { IncludeDefault = true, Limit = 5 },
                cancellationToken
            ),
            "beta.threads" => client.Beta.Sessions.Threads.List(
                "sesn_1",
                new() { Statuses = [Threads.BetaManagedAgentsSessionThreadStatus.Idle], Limit = 5 },
                cancellationToken
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(resource)),
        };
    }

    [Theory]
    [InlineData("models", "lifecycle")]
    [InlineData("beta.models", "lifecycle")]
    [InlineData("workspaces", "include_default")]
    [InlineData("beta.workspaces", "include_default")]
    [InlineData("beta.threads", "statuses")]
    public async Task UrlQuery_HasTheQueryParamsThatAnEndpointGainedLater(
        string resource,
        string name
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}");

        await ListWithALaterQueryParam(Fixtures.Client(handler), resource);

        var sent = Assert.Single(handler.Requests).Uri!.Query;
        Assert.Contains(name, sent, StringComparison.Ordinal);
        Assert.Contains("limit=5", sent, StringComparison.Ordinal);
        var span = Assert.Single(trace.Spans);
        Assert.Equal(DefinedPairs(sent), span.GetTagItem("url.query"));
    }

    /// <summary>
    /// Lists the part of the organization's analytics that <paramref name="resource"/> names,
    /// with <paramref name="filter"/> and a <c>limit</c>.
    /// </summary>
    static Task ListAnalytics(AnthropicClient client, string resource, string filter)
    {
        var analytics = client.Beta.Organization.Analytics;
        var cancellationToken = TestContext.Current.CancellationToken;
        return resource switch
        {
            "skills" => analytics.Skills.List(
                new() { Filter = [filter], Limit = 5 },
                cancellationToken
            ),
            "plugins" => analytics.Plugins.List(
                new() { Filter = [filter], Limit = 5 },
                cancellationToken
            ),
            "connectors" => analytics.Connectors.List(
                new() { Filter = [filter], Limit = 5 },
                cancellationToken
            ),
            "users" => analytics.Users.List(
                new() { Filter = [filter], Limit = 5 },
                cancellationToken
            ),
            "artifacts" => analytics.Artifacts.List(
                new()
                {
                    Date = "2026-01-01",
                    Filter = [filter],
                    Limit = 5,
                },
                cancellationToken
            ),
            "apps/chat/projects" => analytics.Apps.Chat.Projects.List(
                new() { Filter = [filter], Limit = 5 },
                cancellationToken
            ),
            "summaries" => analytics.Summaries.List(
                new()
                {
                    StartingDate = "2026-01-01",
                    Filter = [filter],
                    Limit = 5,
                },
                cancellationToken
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(resource)),
        };
    }

    /// <summary>
    /// What <c>url.query</c> keeps of <paramref name="sent"/>, the query string of a request with
    /// <c>beta=true</c> and parameters that its endpoint defines.
    /// </summary>
    static string DefinedPairs(string sent) =>
        string.Join("&", sent.TrimStart('?').Split('&').Where(pair => pair != "beta=true"));

    // The `filter` of these lists matches names, like a search.
    [Theory]
    [InlineData("skills", "skill_name:Quarterly")]
    [InlineData("plugins", "plugin_name:Quarterly")]
    [InlineData("connectors", "connector_name:Quarterly")]
    public async Task UrlQuery_WithAFilterThatMatchesNames_IsOnlyOnASpanThatHoldsContent(
        string resource,
        string filter
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}").RespondJson("{}");

        await ListAnalytics(Fixtures.Client(handler), resource, filter);
        await ListAnalytics(
            Fixtures.Client(
                handler,
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
            ),
            resource,
            filter
        );

        // The request has the filter either way.
        var sent = handler.Requests.Select(request => request.Uri!.Query).ToArray();
        Assert.Equal(sent[0], sent[1]);
        Assert.Contains("filter", sent[0], StringComparison.Ordinal);
        Assert.Contains("Quarterly", sent[0], StringComparison.Ordinal);
        Assert.Contains("limit=5", sent[0], StringComparison.Ordinal);
        var route = "/v1/organizations/analytics/" + resource;
        Assert.Collection(
            trace.Spans,
            metadataOnly =>
            {
                Assert.Null(metadataOnly.GetTagItem("url.query"));
                Assert.Null(metadataOnly.GetTagItem("url.full"));
                Assert.All(
                    metadataOnly.TagObjects,
                    tag =>
                        Assert.DoesNotContain(
                            "Quarterly",
                            tag.Value?.ToString() ?? "",
                            StringComparison.Ordinal
                        )
                );
            },
            content =>
            {
                Assert.Equal(DefinedPairs(sent[1]), content.GetTagItem("url.query"));
                Assert.Equal(
                    Fixtures.BaseUrl + route + "?" + DefinedPairs(sent[1]),
                    content.GetTagItem("url.full")
                );
            }
        );
        // The rest of the span has its values either way.
        Assert.Equal(TagsBesidesTheQuery(trace.Spans[1]), TagsBesidesTheQuery(trace.Spans[0]));
        var span = trace.Spans[0];
        Assert.Equal("anthropic.organization.analytics." + resource + ".list", span.OperationName);
        Assert.Equal(route, span.GetTagItem("http.route"));
        Assert.Equal("https", span.GetTagItem("url.scheme"));
        Assert.Equal(route, span.GetTagItem("url.path"));
    }

    // The `filter` of these lists takes only IDs or fixed values.
    [Theory]
    [InlineData("users", "user_id:user_1")]
    [InlineData("artifacts", "rbac_group_id:group_1")]
    [InlineData("apps/chat/projects", "rbac_group_id:group_1")]
    [InlineData("summaries", "rbac_group_id:group_1")]
    public async Task UrlQuery_WithAFilterThatTakesOnlyIds_IsOnTheSpanInEitherMode(
        string resource,
        string filter
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}").RespondJson("{}");

        await ListAnalytics(Fixtures.Client(handler), resource, filter);
        await ListAnalytics(
            Fixtures.Client(
                handler,
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
            ),
            resource,
            filter
        );

        var sent = Assert.Single(handler.Requests.Select(request => request.Uri!.Query).Distinct());
        Assert.Contains("filter", sent, StringComparison.Ordinal);
        Assert.Contains("_1", sent, StringComparison.Ordinal);
        var route = "/v1/organizations/analytics/" + resource;
        Assert.Equal(2, trace.Spans.Count);
        Assert.All(
            trace.Spans,
            span =>
            {
                Assert.Equal(
                    "anthropic.organization.analytics." + resource.Replace('/', '.') + ".list",
                    span.OperationName
                );
                Assert.Equal(route, span.GetTagItem("http.route"));
                Assert.Equal(DefinedPairs(sent), span.GetTagItem("url.query"));
                Assert.Equal(
                    Fixtures.BaseUrl + route + "?" + DefinedPairs(sent),
                    span.GetTagItem("url.full")
                );
            }
        );
    }

    /// <summary>
    /// Lists <paramref name="resource"/> from the page that <paramref name="page"/> names, with
    /// a <c>limit</c>.
    /// </summary>
    static Task ListFromAPage(AnthropicClient client, string resource, string page) =>
        resource switch
        {
            "analytics.users" => client.Beta.Organization.Analytics.Users.List(
                new() { Page = page, Limit = 5 },
                TestContext.Current.CancellationToken
            ),
            "memories" => client.Beta.MemoryStores.Memories.List(
                "memstore_1",
                new() { Page = page, Limit = 5 },
                TestContext.Current.CancellationToken
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(resource)),
        };

    // The `page` of these lists is a cursor made of a value of the last row before it.
    [Theory]
    [InlineData("analytics.users", "/v1/organizations/analytics/users")]
    [InlineData("memories", "/v1/memory_stores/{memory_store_id}/memories")]
    public async Task UrlQuery_WithAPageThatHoldsContent_IsOnlyOnASpanThatHoldsContent(
        string resource,
        string route
    )
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}").RespondJson("{}");

        await ListFromAPage(Fixtures.Client(handler), resource, "cursor_abc");
        await ListFromAPage(
            Fixtures.Client(
                handler,
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
            ),
            resource,
            "cursor_abc"
        );

        // The request has the page either way.
        var sent = handler.Requests.Select(request => request.Uri!.Query).ToArray();
        Assert.Equal(sent[0], sent[1]);
        Assert.Contains("page=cursor_abc", sent[0], StringComparison.Ordinal);
        Assert.Contains("limit=5", sent[0], StringComparison.Ordinal);
        var path = handler.Requests.First().Uri!.AbsolutePath;
        Assert.Collection(
            trace.Spans,
            metadataOnly =>
            {
                Assert.Null(metadataOnly.GetTagItem("url.query"));
                Assert.Null(metadataOnly.GetTagItem("url.full"));
                Assert.All(
                    metadataOnly.TagObjects,
                    tag =>
                        Assert.DoesNotContain(
                            "cursor_abc",
                            tag.Value?.ToString() ?? "",
                            StringComparison.Ordinal
                        )
                );
            },
            content =>
            {
                Assert.Equal(DefinedPairs(sent[1]), content.GetTagItem("url.query"));
                Assert.Equal(
                    Fixtures.BaseUrl + path + "?" + DefinedPairs(sent[1]),
                    content.GetTagItem("url.full")
                );
            }
        );
        // The rest of the span has its values either way.
        Assert.Equal(TagsBesidesTheQuery(trace.Spans[1]), TagsBesidesTheQuery(trace.Spans[0]));
        var span = trace.Spans[0];
        Assert.Equal(route, span.GetTagItem("http.route"));
        Assert.Equal(path, span.GetTagItem("url.path"));
    }

    [Fact]
    public async Task UrlQuery_WithAParameterThatIsContentEverywhere_NeedsNoListOfTheEndpoint()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}").RespondJson("{}");
        Anthropic.Models.Organization.Users.UserListParams parameters = new()
        {
            Email = "a@b.test",
            Limit = 5,
        };

        Assert.Empty(parameters.ContentQueryParams);
        await Fixtures
            .Client(handler)
            .Organization.Users.List(parameters, TestContext.Current.CancellationToken);
        await Fixtures
            .Client(
                handler,
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
            )
            .Organization.Users.List(parameters, TestContext.Current.CancellationToken);

        var sent = handler.Requests.Select(request => request.Uri!.Query).ToArray();
        Assert.Equal(sent[0], sent[1]);
        Assert.Contains("email=", sent[0], StringComparison.Ordinal);
        Assert.All(
            trace.Spans,
            span =>
            {
                Assert.Equal("anthropic.organization.users.list", span.OperationName);
                Assert.Equal("/v1/organizations/users", span.GetTagItem("http.route"));
                Assert.Equal("/v1/organizations/users", span.GetTagItem("url.path"));
            }
        );
        Assert.Collection(
            trace.Spans,
            metadataOnly =>
            {
                Assert.Null(metadataOnly.GetTagItem("url.query"));
                Assert.Null(metadataOnly.GetTagItem("url.full"));
                Assert.All(
                    metadataOnly.TagObjects,
                    tag =>
                        Assert.DoesNotContain(
                            "b.test",
                            tag.Value?.ToString() ?? "",
                            StringComparison.Ordinal
                        )
                );
            },
            content =>
            {
                Assert.Equal(DefinedPairs(sent[1]), content.GetTagItem("url.query"));
                Assert.Equal(
                    Fixtures.BaseUrl + "/v1/organizations/users?" + DefinedPairs(sent[1]),
                    content.GetTagItem("url.full")
                );
            }
        );
    }

    /// <summary>
    /// Sends each attempt to another path, as no SDK code does, to tell the attempts apart.
    /// </summary>
    sealed class PathPerAttemptHandler : DelegatingHandler
    {
        int _attempts;

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var attempt = Interlocked.Increment(ref _attempts);
            request.RequestUri = new UriBuilder(request.RequestUri!)
            {
                Path = request.RequestUri!.AbsolutePath + "/attempt_" + attempt,
            }.Uri;
            return base.SendAsync(request, cancellationToken);
        }
    }

    [Fact]
    public async Task Retries_KeepTheUrlOfTheFirstRequestAndAreCounted()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .Respond(HttpStatusCode.InternalServerError, Fixtures.ErrorJson)
            .Throw(() => new HttpRequestException("connection reset"))
            .RespondJson("{}")
            .RespondJson("{}");
        var client = Fixtures
            .Client(handler)
            .WithOptions(options => options with { Handlers = [new PathPerAttemptHandler()] });

        await client.Beta.Files.RetrieveMetadata(
            "file_1",
            cancellationToken: TestContext.Current.CancellationToken
        );
        await client.Beta.Files.RetrieveMetadata(
            "file_2",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal(
            [
                "/v1/files/file_1/attempt_1",
                "/v1/files/file_1/attempt_2",
                "/v1/files/file_1/attempt_3",
                "/v1/files/file_2/attempt_4",
            ],
            handler.Requests.Select(request => request.Uri!.AbsolutePath)
        );
        Assert.Collection(
            trace.Spans,
            retried =>
            {
                Assert.Equal("/v1/files/file_1/attempt_1", retried.GetTagItem("url.path"));
                Assert.Equal(
                    "https://api.example.test/v1/files/file_1/attempt_1",
                    retried.GetTagItem("url.full")
                );
                Assert.Equal(2, retried.GetTagItem("http.request.resend_count"));
                // The response is that of the final attempt.
                Assert.Equal(200, retried.GetTagItem("http.response.status_code"));
                Assert.Equal("/v1/files/{file_id}", retried.GetTagItem("http.route"));
            },
            sentOnce =>
            {
                Assert.Equal("/v1/files/file_2/attempt_4", sentOnce.GetTagItem("url.path"));
                // Absent, not zero.
                Assert.DoesNotContain(
                    sentOnce.TagObjects,
                    tag => tag.Key == "http.request.resend_count"
                );
            }
        );
    }

    [Fact]
    public async Task FailedCall_HasTheResendsThatItMade()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .Respond(HttpStatusCode.InternalServerError, Fixtures.ErrorJson)
            .Respond(HttpStatusCode.InternalServerError, Fixtures.ErrorJson);
        var client = Fixtures.Client(handler, maxRetries: 1);

        await Assert.ThrowsAsync<Anthropic5xxException>(() =>
            client.Beta.Files.RetrieveMetadata(
                "file_1",
                cancellationToken: TestContext.Current.CancellationToken
            )
        );

        var span = trace.Single("anthropic.files.retrieve_metadata");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal(1, span.GetTagItem("http.request.resend_count"));
        Assert.Equal("/v1/files/file_1", span.GetTagItem("url.path"));
    }

    [Fact]
    public async Task CallThatFailsToConnect_HasTheUrlThatItSent()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Throw(() =>
            new HttpRequestException("connection refused")
        );
        var client = Fixtures.Client(handler, maxRetries: 0);

        await Assert.ThrowsAsync<AnthropicIOException>(() =>
            client.Beta.Files.RetrieveMetadata(
                "file_1",
                cancellationToken: TestContext.Current.CancellationToken
            )
        );

        var span = trace.Single("anthropic.files.retrieve_metadata");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("connection_error", span.GetTagItem("error.type"));
        Assert.Null(span.GetTagItem("http.response.status_code"));
        Assert.Equal("https", span.GetTagItem("url.scheme"));
        Assert.Equal("/v1/files/file_1", span.GetTagItem("url.path"));
        Assert.Equal("https://api.example.test/v1/files/file_1", span.GetTagItem("url.full"));
    }

    [Fact]
    public async Task Fallback_ThatSendsTheRequestAgain_IsCounted()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson(Refusal("claude-test"))
            .RespondJson(Fixtures.MessageJson);
        var client = Fixtures
            .Client(handler)
            .WithOptions(options =>
                options with
                {
                    Handlers =
                    [
                        new BetaRefusalFallbackHandler { Fallbacks = [new("claude-fallback")] },
                    ],
                }
            );

        // A fresh state, so that falling back writes no warning to the standard error.
        using var _ = BetaFallbackState.Create().Use();
        var message = await client.Beta.Messages.Create(
            BetaParams(),
            TestContext.Current.CancellationToken
        );

        Assert.Equal(2, handler.Requests.Count);
        Assert.NotEqual(BetaStopReason.Refusal, message.StopReason?.Value());
        var span = trace.Single("anthropic.messages.create");
        Assert.Equal(1, span.GetTagItem("http.request.resend_count"));
        Assert.Equal("https://api.example.test/v1/messages", span.GetTagItem("url.full"));
    }

    static string Refusal(string model) =>
        $$"""
            {
              "id": "msg_1", "type": "message", "role": "assistant", "model": "{{model}}",
              "content": [], "stop_reason": "refusal", "stop_sequence": null,
              "stop_details": {"type": "refusal", "reason": "other", "explanation": null, "fallback_credit_token": "credit"},
              "usage": {"input_tokens": 1, "output_tokens": 1}
            }
            """;

    [Fact]
    public async Task CallThatFailsBeforeARequestIsBuilt_HasNoUrl()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler();
        var client = Fixtures.Client(handler);

        // A dot-segment cannot be a path parameter, so the URL cannot be built.
        await Assert.ThrowsAsync<AnthropicInvalidDataException>(() =>
            client.Beta.Files.RetrieveMetadata(
                "..",
                cancellationToken: TestContext.Current.CancellationToken
            )
        );

        Assert.Empty(handler.Requests);
        var span = trace.Single("anthropic.files.retrieve_metadata");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("GET", span.GetTagItem("http.request.method"));
        Assert.Equal("/v1/files/{file_id}", span.GetTagItem("http.route"));
        Assert.DoesNotContain(
            span.TagObjects,
            tag =>
                tag.Key.StartsWith("url.", StringComparison.Ordinal)
                || tag.Key == "http.request.resend_count"
        );
    }

    [Fact]
    public async Task AttemptThatFailsBeforeItIsSent_IsNotARequest()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("{}");
        var client = Fixtures
            .Client(handler)
            .WithOptions(options => options with { Handlers = [new FailingFirstAttemptHandler()] });

        await client.Beta.Files.RetrieveMetadata(
            "file_1",
            cancellationToken: TestContext.Current.CancellationToken
        );

        // The first attempt never reached the transport, so the second sent the first request.
        Assert.Single(handler.Requests);
        var span = trace.Single("anthropic.files.retrieve_metadata");
        Assert.Equal("/v1/files/file_1", span.GetTagItem("url.path"));
        Assert.Null(span.GetTagItem("http.request.resend_count"));
    }

    sealed class FailingFirstAttemptHandler : DelegatingHandler
    {
        int _attempts;

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        ) =>
            Interlocked.Increment(ref _attempts) == 1
                ? throw new HttpRequestException("no route to host")
                : base.SendAsync(request, cancellationToken);
    }

    [Fact]
    public void SpanThatIsNotRecorded_GetsNoUrl()
    {
        using var span = new Activity("anthropic.ping") { IsAllDataRequested = false }.Start();
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.example.test/v1");

        Tracing.TrackRequest(request, span, new PingParams(), recordsContent: true);
        Tracing.RecordRequest(request);
        Tracing.RecordRequest(request);
        Tracing.EndApiCallSpan(span);

        Assert.Empty(span.TagObjects);
    }

    [Fact]
    public void RequestOfNoCall_IsNotRecorded()
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.example.test/v1");

        Tracing.RecordRequest(request);
    }

    [Fact]
    public async Task PlatformClient_HasTheApisRouteAndThePathThatItSends()
    {
        using var trace = new RecordedTrace();

        async Task<Activity> MessagesCreate(AnthropicClient client)
        {
            var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);
            var configured = client.WithOptions(options =>
                options with
                {
                    HttpClient = new HttpClient(handler),
                }
            );
            await configured.Messages.Create(
                MessageParams(),
                TestContext.Current.CancellationToken
            );
            var span = trace.Spans[trace.Spans.Count - 1];
            Assert.Equal("anthropic.messages.create", span.OperationName);
            Assert.Equal("POST", span.GetTagItem("http.request.method"));
            Assert.Equal("/v1/messages", span.GetTagItem("http.route"));
            Assert.Equal(
                Assert.Single(handler.Requests).Uri!.AbsolutePath,
                span.GetTagItem("url.path")
            );
            return span;
        }

        var bedrock = await MessagesCreate(
            new Anthropic.Bedrock.AnthropicBedrockClient(new BedrockCredentials())
        );
        Assert.Equal("/model/claude-test/invoke", bedrock.GetTagItem("url.path"));
        Assert.Equal(
            "https://bedrock-runtime.us-east-1.amazonaws.com/model/claude-test/invoke",
            bedrock.GetTagItem("url.full")
        );

        var vertex = await MessagesCreate(
            new Anthropic.Vertex.AnthropicVertexClient(new VertexCredentials())
        );
        Assert.Equal(
            "/v1/projects/test-project/locations/us-east5/publishers/anthropic/models/claude-test:rawPredict",
            vertex.GetTagItem("url.path")
        );

        var foundry = await MessagesCreate(
            new Anthropic.Foundry.AnthropicFoundryClient(
                new Anthropic.Foundry.AnthropicFoundryApiKeyCredentials("key", "resource")
            )
        );
        Assert.Equal(
            "https://resource.services.ai.azure.com/anthropic/v1/messages",
            foundry.GetTagItem("url.full")
        );
    }

    internal static AnthropicClient PlatformClient(string name) =>
        name switch
        {
            "Bedrock" => new Anthropic.Bedrock.AnthropicBedrockClient(new BedrockCredentials()),
            "BedrockMantle" => new Anthropic.Bedrock.AnthropicBedrockMantleClient(
                new()
                {
                    ApiKey = "test-key",
                    AwsRegion = "us-east-1",
                    BaseUrl = "https://mantle.example.test",
                }
            ),
            "Vertex" => new Anthropic.Vertex.AnthropicVertexClient(new VertexCredentials()),
            "Foundry" => new Anthropic.Foundry.AnthropicFoundryClient(
                new Anthropic.Foundry.AnthropicFoundryApiKeyCredentials("key", "resource")
            ),
            "Aws" => new Anthropic.Aws.AnthropicAwsClient(
                new()
                {
                    ApiKey = "test-key",
                    WorkspaceId = "wrkspc_1",
                    BaseUrl = "https://aws.example.test",
                }
            ),
            "GoogleCloud" => new Anthropic.GoogleCloud.AnthropicGoogleCloudClient(
                new() { SkipAuth = true, BaseUrl = "https://google.example.test" }
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(name)),
        };

    [Theory]
    [InlineData("bedrock", "Bedrock")]
    [InlineData("bedrock", "BedrockMantle")]
    [InlineData("vertex", "Vertex")]
    [InlineData("foundry", "Foundry")]
    [InlineData("aws", "Aws")]
    [InlineData("googlecloud", "GoogleCloud")]
    public async Task PlatformClient_HasTheScopeAndTheVersionOfItsPackage(
        string platform,
        string clientName
    )
    {
        using var trace = new RecordedTrace();
        var client = PlatformClient(clientName);
        var handler = new ScriptedHandler()
            .RespondJson(Fixtures.MessageJson)
            .RespondJson("""{"input_tokens": 21}""")
            .RespondJson("{}");
        // A copy keeps the scope, whether it keeps the options or starts from new ones.
        var copy = (AnthropicClient)
            client
                .WithOptions(options => options with { HttpClient = new HttpClient(handler) })
                .WithOptions(options => new ClientOptions
                {
                    HttpClient = options.HttpClient,
                    BaseUrl = options.BaseUrl,
                    MaxRetries = 0,
                });

        await copy.Messages.Create(MessageParams(), TestContext.Current.CancellationToken);
        try
        {
            await copy.Beta.Messages.CountTokens(
                new()
                {
                    Messages = [new() { Role = Role.User, Content = "Hi" }],
                    Model = "claude-test",
                },
                TestContext.Current.CancellationToken
            );
        }
        catch (AnthropicInvalidDataException)
        {
            // The clients for Bedrock and Vertex refuse the endpoint, once the span has started.
        }
        // The same holds for a copy of the client that gives the raw responses.
        var raw = copy.WithRawResponse.WithOptions(options => new ClientOptions
        {
            HttpClient = options.HttpClient,
            BaseUrl = options.BaseUrl,
            MaxRetries = 0,
        });
        (
            await raw.Execute(
                new HttpRequest<PingParams>
                {
                    Method = HttpMethod.Post,
                    Params = new(),
                    SpanName = "anthropic.ping",
                },
                TestContext.Current.CancellationToken
            )
        ).Dispose();

        var package = client.GetType().Assembly.GetName();
        Assert.Equal("Anthropic." + platform, package.Name, ignoreCase: true);
        Assert.Equal(
            ["anthropic.messages.create", "anthropic.messages.count_tokens", "anthropic.ping"],
            trace.Spans.Select(span => span.OperationName)
        );
        Assert.All(
            trace.Spans,
            span =>
            {
                Assert.Equal("com.anthropic.sdk.csharp." + platform, span.Source.Name);
                // The package's own version, which is not the SDK's.
                Assert.StartsWith(
                    package.Version!.ToString(3),
                    span.Source.Version,
                    StringComparison.Ordinal
                );
            }
        );
        Assert.NotEqual(typeof(AnthropicClient).Assembly.GetName().Version, package.Version);
    }

    [Fact]
    public async Task FirstPartyClient_HasTheSdksScopeAndVersion()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(Fixtures.MessageJson);

        await Fixtures
            .Client(handler)
            .Messages.Create(MessageParams(), TestContext.Current.CancellationToken);

        var source = trace.Single("anthropic.messages.create").Source;
        Assert.Equal("com.anthropic.sdk.csharp", source.Name);
        Assert.StartsWith(
            typeof(AnthropicClient).Assembly.GetName().Version!.ToString(3),
            source.Version,
            StringComparison.Ordinal
        );
    }

    sealed class BedrockCredentials : Anthropic.Bedrock.IAnthropicBedrockCredentials
    {
        public string Region => "us-east-1";

        public Task Apply(HttpRequestMessage requestMessage) => Task.CompletedTask;
    }

    sealed class VertexCredentials : Anthropic.Vertex.IAnthropicVertexCredentials
    {
        public string Region => "us-east5";
        public string Project => "test-project";

        public ValueTask ApplyAsync(HttpRequestMessage requestMessage) => default;
    }
}
