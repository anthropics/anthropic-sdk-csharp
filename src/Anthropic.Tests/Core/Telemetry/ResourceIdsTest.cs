using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces.Members;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Threads;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Core.Telemetry;

/// <summary>
/// The resource IDs of a method's span: one for each parameter of the request's path, from the
/// method's arguments, and one for an object that the method creates, from its response.
/// </summary>
public class ResourceIdsTest : TracingTestBase
{
    static readonly IReadOnlyDictionary<string, JsonElement> NoData =
        new Dictionary<string, JsonElement>();

    const string SessionJson = """
        {"id":"sesn_1","environment_id":"env_1","agent":{"id":"agent_1","name":"Researcher","model":{"id":"claude-test-20260101"}}}
        """;

    [Fact]
    public async Task PathParameters_AreNamedAfterThePathsHierarchy()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("""{"id":"sthr_1"}""");
        var client = Fixtures.Client(handler);

        await client.Beta.Sessions.Threads.Retrieve(
            "sthr_1",
            new ThreadRetrieveParams { SessionID = "sesn_1" },
            TestContext.Current.CancellationToken
        );

        var span = trace.Single("anthropic.sessions.threads.retrieve");
        Assert.Equal("sesn_1", span.GetTagItem("anthropic.session.id"));
        Assert.Equal("sthr_1", span.GetTagItem("anthropic.session.thread.id"));
        // The application named no conversation, so the thread is the conversation.
        Assert.Equal("sthr_1", span.GetTagItem("gen_ai.conversation.id"));
    }

    [Fact]
    public async Task SessionThread_IsTheConversationThatASamplerSees_UnlessTheApplicationNamesOne()
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
            .RespondJson("{}")
            .Respond(HttpStatusCode.NotFound, Fixtures.ErrorJson)
            .RespondJson("{}");
        var client = Fixtures.Client(handler, maxRetries: 0);
        var named = client.WithOptions(options =>
            options with
            {
                OpenTelemetryRequest = new() { ConversationId = "conv_42" },
            }
        );

        await client.Beta.Sessions.Threads.Archive(
            "sthr_1",
            new() { SessionID = "sesn_1" },
            TestContext.Current.CancellationToken
        );
        await client.Beta.Sessions.Threads.Events.List(
            "sthr_2",
            new() { SessionID = "sesn_1" },
            TestContext.Current.CancellationToken
        );
        await named.Beta.Sessions.Threads.Events.List(
            "sthr_3",
            new() { SessionID = "sesn_1" },
            TestContext.Current.CancellationToken
        );
        // A failed call keeps it, and a path without a thread has none.
        await Assert.ThrowsAsync<AnthropicNotFoundException>(() =>
            client.Beta.Sessions.Threads.Retrieve(
                "latest",
                new ThreadRetrieveParams { SessionID = "sesn_1" },
                TestContext.Current.CancellationToken
            )
        );
        await client.Beta.Sessions.Retrieve(
            "sesn_1",
            cancellationToken: TestContext.Current.CancellationToken
        );

        (string?, string?)[] expected =
        [
            ("sthr_1", "sthr_1"),
            ("sthr_2", "sthr_2"),
            ("sthr_3", "conv_42"),
            ("latest", "latest"),
            (null, null),
        ];
        Assert.Equal(
            expected,
            atStart.Select(tags =>
                (
                    tags.TryGetValue("anthropic.session.thread.id", out var thread)
                        ? thread as string
                        : null,
                    tags.TryGetValue("gen_ai.conversation.id", out var conversation)
                        ? conversation as string
                        : null
                )
            )
        );
        Assert.Equal(
            expected,
            trace.Spans.Select(span =>
                (
                    span.GetTagItem("anthropic.session.thread.id") as string,
                    span.GetTagItem("gen_ai.conversation.id") as string
                )
            )
        );
        Assert.Equal(ActivityStatusCode.Error, trace.Spans[3].Status);
    }

    [Fact]
    public async Task PathParameters_WithAGenAiName_UseIt()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson("""{"id":"agent_1"}""")
            .RespondJson("""{"id":"mem_1"}""");
        var client = Fixtures.Client(handler);

        await client.Beta.Agents.Retrieve(
            "agent_1",
            cancellationToken: TestContext.Current.CancellationToken
        );
        await client.Beta.MemoryStores.Memories.Retrieve(
            "mem_1",
            new() { MemoryStoreID = "memstore_1" },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(
            "agent_1",
            trace.Single("anthropic.agents.retrieve").GetTagItem("gen_ai.agent.id")
        );
        var memory = trace.Single("anthropic.memory_stores.memories.retrieve");
        Assert.Equal("memstore_1", memory.GetTagItem("gen_ai.memory.store.id"));
        Assert.Equal("mem_1", memory.GetTagItem("gen_ai.memory.record.id"));
    }

    [Fact]
    public async Task PathParameter_ThatIsNotAnId_IsRecordedAsThePathHasIt()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("""{"id":"claude-test-20260101"}""");
        var client = Fixtures.Client(handler);

        await client.Models.Retrieve(
            "claude-test-latest",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal(
            "claude-test-latest",
            trace.Single("anthropic.models.retrieve").GetTagItem("anthropic.model.id")
        );
    }

    [Fact]
    public async Task FailedCall_KeepsThePathIdsAndHasNoCreatedId()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .Respond(HttpStatusCode.NotFound, Fixtures.ErrorJson, "req_1")
            .Respond(HttpStatusCode.BadRequest, Fixtures.ErrorJson, "req_2");
        var client = Fixtures.Client(handler, maxRetries: 0);

        await Assert.ThrowsAsync<AnthropicNotFoundException>(() =>
            client.Beta.Sessions.Retrieve(
                "sesn_missing",
                cancellationToken: TestContext.Current.CancellationToken
            )
        );
        await Assert.ThrowsAsync<AnthropicBadRequestException>(() =>
            client.Beta.Sessions.Create(
                SessionCreateParams.FromRawUnchecked(NoData, NoData, NoData),
                TestContext.Current.CancellationToken
            )
        );

        var retrieve = trace.Single("anthropic.sessions.retrieve");
        Assert.Equal(ActivityStatusCode.Error, retrieve.Status);
        Assert.Equal("sesn_missing", retrieve.GetTagItem("anthropic.session.id"));
        var create = trace.Single("anthropic.sessions.create");
        Assert.Equal(ActivityStatusCode.Error, create.Status);
        Assert.Null(create.GetTagItem("anthropic.session.id"));
    }

    [Fact]
    public async Task CreatedObject_IdComesFromTheResponse()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("""{"id":"sesn_new"}""");
        var client = Fixtures.Client(handler);

        await client.Beta.Sessions.Create(
            SessionCreateParams.FromRawUnchecked(NoData, NoData, NoData),
            TestContext.Current.CancellationToken
        );

        Assert.Equal(
            "sesn_new",
            trace.Single("anthropic.sessions.create").GetTagItem("anthropic.session.id")
        );
    }

    [Fact]
    public async Task CreatedObject_WithoutAnIdInTheResponse_HasNoIdAndTheCallSucceeds()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("""{"type":"session"}""");
        var client = Fixtures.Client(handler);

        await client.Beta.Sessions.Create(
            SessionCreateParams.FromRawUnchecked(NoData, NoData, NoData),
            TestContext.Current.CancellationToken
        );

        var span = trace.Single("anthropic.sessions.create");
        Assert.Equal(ActivityStatusCode.Ok, span.Status);
        Assert.Null(span.GetTagItem("anthropic.session.id"));
    }

    [Fact]
    public async Task SessionsCreate_HasTheAgentTheModelAndTheEnvironment()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(SessionJson);
        var client = Fixtures.Client(handler);

        await client.Beta.Sessions.Create(
            new() { Agent = "agent_1", EnvironmentID = "env_1" },
            TestContext.Current.CancellationToken
        );

        var span = trace.Single("anthropic.sessions.create");
        Assert.Equal("agent_1", span.GetTagItem("gen_ai.agent.id"));
        Assert.Equal("env_1", span.GetTagItem("anthropic.session.environment.id"));
        Assert.Equal("Researcher", span.GetTagItem("gen_ai.agent.name"));
        Assert.Equal("claude-test-20260101", span.GetTagItem("gen_ai.request.model"));
    }

    [Fact]
    public async Task SessionsCreate_WithAnAgentObject_HasItsIdAndTheModelOfTheResponse()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(SessionJson);
        var client = Fixtures.Client(handler);

        await client.Beta.Sessions.Create(
            new()
            {
                Agent = new BetaManagedAgentsAgentWithOverridesParams
                {
                    ID = "agent_1",
                    Type = BetaManagedAgentsAgentWithOverridesParamsType.AgentWithOverrides,
                    Model = (ApiEnum<string, Agents::BetaManagedAgentsModel>)"claude-test-override",
                },
                EnvironmentID = "env_1",
            },
            TestContext.Current.CancellationToken
        );

        var span = trace.Single("anthropic.sessions.create");
        Assert.Equal("agent_1", span.GetTagItem("gen_ai.agent.id"));
        Assert.Equal("claude-test-20260101", span.GetTagItem("gen_ai.request.model"));
    }

    [Fact]
    public async Task SessionsCreate_ThatFails_KeepsTheAgentAndTheEnvironment()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().Respond(
            HttpStatusCode.BadRequest,
            Fixtures.ErrorJson,
            "req_1"
        );
        var client = Fixtures.Client(handler, maxRetries: 0);

        await Assert.ThrowsAsync<AnthropicBadRequestException>(() =>
            client.Beta.Sessions.Create(
                new() { Agent = "agent_1", EnvironmentID = "env_1" },
                TestContext.Current.CancellationToken
            )
        );

        var span = trace.Single("anthropic.sessions.create");
        Assert.Equal(ActivityStatusCode.Error, span.Status);
        Assert.Equal("agent_1", span.GetTagItem("gen_ai.agent.id"));
        Assert.Equal("env_1", span.GetTagItem("anthropic.session.environment.id"));
        Assert.Null(span.GetTagItem("gen_ai.agent.name"));
        Assert.Null(span.GetTagItem("gen_ai.request.model"));
    }

    [Fact]
    public async Task SessionsRetrieve_HasNeitherTheAgentNorTheEnvironment()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(SessionJson);
        var client = Fixtures.Client(handler);

        await client.Beta.Sessions.Retrieve(
            "sesn_1",
            cancellationToken: TestContext.Current.CancellationToken
        );

        var span = trace.Single("anthropic.sessions.retrieve");
        Assert.Equal("sesn_1", span.GetTagItem("anthropic.session.id"));
        Assert.Null(span.GetTagItem("gen_ai.agent.id"));
        Assert.Null(span.GetTagItem("anthropic.session.environment.id"));
        Assert.Null(span.GetTagItem("gen_ai.agent.name"));
        Assert.Null(span.GetTagItem("gen_ai.request.model"));
    }

    [Fact]
    public async Task MembershipAdd_ReadsTheNamedFieldOfTheResponse()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson(
            """{"type":"workspace_member","user_id":"user_1","workspace_id":"wrkspc_1","workspace_role":"workspace_user"}"""
        );
        var client = Fixtures.Client(handler);

        await client.Beta.Organization.Workspaces.Members.Add(
            MemberAddParams.FromRawUnchecked(NoData, NoData, NoData, "wrkspc_1"),
            TestContext.Current.CancellationToken
        );

        var span = trace.Single("anthropic.organization.workspaces.members.add");
        Assert.Equal("wrkspc_1", span.GetTagItem("anthropic.organization.workspace.id"));
        Assert.Equal("user_1", span.GetTagItem("anthropic.organization.workspace.member.id"));
        // The response header's workspace, not the path's, would be `anthropic.workspace.id`.
        Assert.Null(span.GetTagItem("anthropic.workspace.id"));
    }

    [Fact]
    public async Task List_HasOnlyThePathIds_OnEveryPage()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler()
            .RespondJson("""{"data":[{"id":"sthr_1"}],"next_page":"page_2"}""")
            .RespondJson("""{"data":[{"id":"sthr_2"}],"next_page":null}""")
            .RespondJson("""{"data":[],"has_more":false,"first_id":null,"last_id":null}""");
        var client = Fixtures.Client(handler);

        var page = await client.Beta.Sessions.Threads.List(
            "sesn_1",
            cancellationToken: TestContext.Current.CancellationToken
        );
        await page.Next(TestContext.Current.CancellationToken);
        await client.Models.List(cancellationToken: TestContext.Current.CancellationToken);

        var pages = trace
            .Spans.Where(span => span.OperationName == "anthropic.sessions.threads.list")
            .ToList();
        Assert.Equal(2, pages.Count);
        Assert.All(
            pages,
            span =>
            {
                Assert.Equal("sesn_1", span.GetTagItem("anthropic.session.id"));
                Assert.Null(span.GetTagItem("anthropic.session.thread.id"));
            }
        );
        Assert.Empty(ResourceIds(trace.Single("anthropic.models.list")));
    }

    [Fact]
    public async Task TracingOff_NamesNoSpanAndCallsSucceed()
    {
        using var trace = new RecordedTrace();
        var handler = new ScriptedHandler().RespondJson("""{"id":"sesn_new"}""");
        var client = Fixtures.Client(handler, openTelemetry: false);

        var session = await client.Beta.Sessions.Create(
            SessionCreateParams.FromRawUnchecked(NoData, NoData, NoData),
            TestContext.Current.CancellationToken
        );

        Assert.Equal("sesn_new", session.ID);
        Assert.Empty(trace.Spans);
    }

    /// <summary>
    /// The attributes that every call span can have and that end in <c>.id</c> without being a
    /// resource ID of the method.
    /// </summary>
    static readonly HashSet<string> CommonIds =
    [
        "anthropic.request.id",
        "anthropic.organization.id",
        "anthropic.workspace.id",
        "gen_ai.conversation.id",
        "gen_ai.response.id",
    ];

    static Dictionary<string, string?> ResourceIds(Activity span) =>
        span
            .TagObjects.Where(tag =>
                tag.Key.EndsWith(".id", StringComparison.Ordinal) && !CommonIds.Contains(tag.Key)
            )
            .ToDictionary(tag => tag.Key, tag => tag.Value as string);
}
