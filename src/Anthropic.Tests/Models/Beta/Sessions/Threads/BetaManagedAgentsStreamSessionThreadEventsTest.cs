using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Threads;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads;

public class BetaManagedAgentsStreamSessionThreadEventsTest : TestBase
{
    [Fact]
    public void UserMessageEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserMessageEvent()
            {
                ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            };
        value.Validate();
    }

    [Fact]
    public void UserInterruptEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserInterruptEvent()
            {
                ID = "id",
                Type = Events::BetaManagedAgentsUserInterruptEventType.UserInterrupt,
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void UserToolConfirmationEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserToolConfirmationEvent()
            {
                ID = "id",
                Result = Events::Result.Allow,
                ToolUseID = "tool_use_id",
                Type = Events::BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
                DenyMessage = "deny_message",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void UserCustomToolResultEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserCustomToolResultEvent()
            {
                ID = "id",
                CustomToolUseID = "custom_tool_use_id",
                Type = Events::BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                IsError = true,
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void AgentCustomToolUseEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentCustomToolUseEvent()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::Type.AgentCustomToolUse,
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void AgentMessageEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentMessageEvent()
            {
                ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                Content =
                [
                    new()
                    {
                        Text = "Let me look up order #1234 for you.",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Type = Events::BetaManagedAgentsAgentMessageEventType.AgentMessage,
            };
        value.Validate();
    }

    [Fact]
    public void AgentThinkingEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentThinkingEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsAgentThinkingEventType.AgentThinking,
            };
        value.Validate();
    }

    [Fact]
    public void AgentMcpToolUseEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentMcpToolUseEvent()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                McpServerName = "mcp_server_name",
                Name = "name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
                EvaluatedPermission = Events::EvaluatedPermission.Allow,
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void AgentMcpToolResultEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentMcpToolResultEvent()
            {
                ID = "id",
                McpToolUseID = "mcp_tool_use_id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                IsError = true,
            };
        value.Validate();
    }

    [Fact]
    public void AgentToolUseEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentToolUseEvent()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsAgentToolUseEventType.AgentToolUse,
                EvaluatedPermission =
                    Events::BetaManagedAgentsAgentToolUseEventEvaluatedPermission.Allow,
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void AgentToolResultEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentToolResultEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ToolUseID = "tool_use_id",
                Type = Events::BetaManagedAgentsAgentToolResultEventType.AgentToolResult,
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                IsError = true,
            };
        value.Validate();
    }

    [Fact]
    public void AgentThreadMessageReceivedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentThreadMessageReceivedEvent()
            {
                ID = "id",
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                FromSessionThreadID = "from_session_thread_id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
                FromAgentName = "from_agent_name",
            };
        value.Validate();
    }

    [Fact]
    public void AgentThreadMessageSentEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentThreadMessageSentEvent()
            {
                ID = "id",
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ToSessionThreadID = "to_session_thread_id",
                Type =
                    Events::BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,
                ToAgentName = "to_agent_name",
            };
        value.Validate();
    }

    [Fact]
    public void AgentThreadContextCompactedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentThreadContextCompactedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsAgentThreadContextCompactedEventType.AgentThreadContextCompacted,
            };
        value.Validate();
    }

    [Fact]
    public void SessionErrorEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionErrorEvent()
            {
                ID = "id",
                Error = new Events::BetaManagedAgentsUnknownError()
                {
                    Message = "message",
                    RetryStatus = new Events::BetaManagedAgentsRetryStatusRetrying(
                        Events::BetaManagedAgentsRetryStatusRetryingType.Retrying
                    ),
                    Type = Events::BetaManagedAgentsUnknownErrorType.UnknownError,
                },
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSessionErrorEventType.SessionError,
            };
        value.Validate();
    }

    [Fact]
    public void SessionStatusRescheduledEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionStatusRescheduledEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsSessionStatusRescheduledEventType.SessionStatusRescheduled,
            };
        value.Validate();
    }

    [Fact]
    public void SessionStatusRunningEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionStatusRunningEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSessionStatusRunningEventType.SessionStatusRunning,
            };
        value.Validate();
    }

    [Fact]
    public void SessionStatusIdleEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionStatusIdleEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StopReason = new Events::BetaManagedAgentsSessionEndTurn(
                    Events::BetaManagedAgentsSessionEndTurnType.EndTurn
                ),
                Type = Events::BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle,
            };
        value.Validate();
    }

    [Fact]
    public void SessionStatusTerminatedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionStatusTerminatedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsSessionStatusTerminatedEventType.SessionStatusTerminated,
            };
        value.Validate();
    }

    [Fact]
    public void SessionThreadCreatedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadCreatedEvent()
            {
                ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                Type = Events::BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated,
            };
        value.Validate();
    }

    [Fact]
    public void SpanOutcomeEvaluationStartEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanOutcomeEvaluationStartEvent()
            {
                ID = "sevt_011CZkZTUy4mGhu8peVXnlzr",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
                Type =
                    Events::BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart,
            };
        value.Validate();
    }

    [Fact]
    public void SpanOutcomeEvaluationEndEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanOutcomeEvaluationEndEvent()
            {
                ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
                Explanation = "All five sections present with inline citations.",
                Iteration = 0,
                OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnlzr",
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
                Result = "satisfied",
                Type =
                    Events::BetaManagedAgentsSpanOutcomeEvaluationEndEventType.SpanOutcomeEvaluationEnd,
                Usage = new()
                {
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 1536,
                    InputTokens = 1842,
                    OutputTokens = 213,
                    Speed = Events::Speed.Standard,
                },
            };
        value.Validate();
    }

    [Fact]
    public void SpanModelRequestStartEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanModelRequestStartEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsSpanModelRequestStartEventType.SpanModelRequestStart,
            };
        value.Validate();
    }

    [Fact]
    public void SpanModelRequestEndEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanModelRequestEndEvent()
            {
                ID = "id",
                IsError = true,
                ModelRequestStartID = "model_request_start_id",
                ModelUsage = new()
                {
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                    Speed = Events::Speed.Standard,
                },
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd,
            };
        value.Validate();
    }

    [Fact]
    public void SpanOutcomeEvaluationOngoingEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent()
            {
                ID = "sevt_011CZkZbCG2uOpc6xmDfvTzh",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
                Type =
                    Events::BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing,
            };
        value.Validate();
    }

    [Fact]
    public void UserDefineOutcomeEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserDefineOutcomeEvent()
            {
                ID = "sevt_011CZkZSTx3lFgt7odUWmkyq",
                Description = "Produce a 2-page summary as summary.md",
                MaxIterations = 3,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
                Rubric = new Events::BetaManagedAgentsTextRubric()
                {
                    Content = "Must cover all five sections; cite sources inline.",
                    Type = Events::BetaManagedAgentsTextRubricType.Text,
                },
                Type = Events::BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome,
            };
        value.Validate();
    }

    [Fact]
    public void SessionDeletedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionDeletedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSessionDeletedEventType.SessionDeleted,
            };
        value.Validate();
    }

    [Fact]
    public void SessionThreadStatusRunningEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadStatusRunningEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
                Type =
                    Events::BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning,
            };
        value.Validate();
    }

    [Fact]
    public void SessionThreadStatusIdleEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadStatusIdleEvent()
            {
                ID = "sevt_011CZkZXYc8qKly2tiZbrpDv",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                StopReason = new Events::BetaManagedAgentsSessionEndTurn(
                    Events::BetaManagedAgentsSessionEndTurnType.EndTurn
                ),
                Type =
                    Events::BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle,
            };
        value.Validate();
    }

    [Fact]
    public void SessionThreadStatusTerminatedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadStatusTerminatedEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
                Type =
                    Events::BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated,
            };
        value.Validate();
    }

    [Fact]
    public void SessionThreadStatusRescheduledEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadStatusRescheduledEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
                Type =
                    Events::BetaManagedAgentsSessionThreadStatusRescheduledEventType.SessionThreadStatusRescheduled,
            };
        value.Validate();
    }

    [Fact]
    public void UserMessageEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserMessageEvent()
            {
                ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserInterruptEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserInterruptEvent()
            {
                ID = "id",
                Type = Events::BetaManagedAgentsUserInterruptEventType.UserInterrupt,
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserToolConfirmationEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserToolConfirmationEvent()
            {
                ID = "id",
                Result = Events::Result.Allow,
                ToolUseID = "tool_use_id",
                Type = Events::BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
                DenyMessage = "deny_message",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserCustomToolResultEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserCustomToolResultEvent()
            {
                ID = "id",
                CustomToolUseID = "custom_tool_use_id",
                Type = Events::BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                IsError = true,
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentCustomToolUseEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentCustomToolUseEvent()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::Type.AgentCustomToolUse,
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMessageEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentMessageEvent()
            {
                ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                Content =
                [
                    new()
                    {
                        Text = "Let me look up order #1234 for you.",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Type = Events::BetaManagedAgentsAgentMessageEventType.AgentMessage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThinkingEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentThinkingEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsAgentThinkingEventType.AgentThinking,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMcpToolUseEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentMcpToolUseEvent()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                McpServerName = "mcp_server_name",
                Name = "name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
                EvaluatedPermission = Events::EvaluatedPermission.Allow,
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMcpToolResultEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentMcpToolResultEvent()
            {
                ID = "id",
                McpToolUseID = "mcp_tool_use_id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                IsError = true,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentToolUseEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentToolUseEvent()
            {
                ID = "id",
                Input = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsAgentToolUseEventType.AgentToolUse,
                EvaluatedPermission =
                    Events::BetaManagedAgentsAgentToolUseEventEvaluatedPermission.Allow,
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentToolResultEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentToolResultEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ToolUseID = "tool_use_id",
                Type = Events::BetaManagedAgentsAgentToolResultEventType.AgentToolResult,
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                IsError = true,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadMessageReceivedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentThreadMessageReceivedEvent()
            {
                ID = "id",
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                FromSessionThreadID = "from_session_thread_id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
                FromAgentName = "from_agent_name",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadMessageSentEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentThreadMessageSentEvent()
            {
                ID = "id",
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ToSessionThreadID = "to_session_thread_id",
                Type =
                    Events::BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,
                ToAgentName = "to_agent_name",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadContextCompactedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsAgentThreadContextCompactedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsAgentThreadContextCompactedEventType.AgentThreadContextCompacted,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionErrorEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionErrorEvent()
            {
                ID = "id",
                Error = new Events::BetaManagedAgentsUnknownError()
                {
                    Message = "message",
                    RetryStatus = new Events::BetaManagedAgentsRetryStatusRetrying(
                        Events::BetaManagedAgentsRetryStatusRetryingType.Retrying
                    ),
                    Type = Events::BetaManagedAgentsUnknownErrorType.UnknownError,
                },
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSessionErrorEventType.SessionError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusRescheduledEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionStatusRescheduledEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsSessionStatusRescheduledEventType.SessionStatusRescheduled,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusRunningEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionStatusRunningEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSessionStatusRunningEventType.SessionStatusRunning,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusIdleEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionStatusIdleEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StopReason = new Events::BetaManagedAgentsSessionEndTurn(
                    Events::BetaManagedAgentsSessionEndTurnType.EndTurn
                ),
                Type = Events::BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusTerminatedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionStatusTerminatedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsSessionStatusTerminatedEventType.SessionStatusTerminated,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadCreatedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadCreatedEvent()
            {
                ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                Type = Events::BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanOutcomeEvaluationStartEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanOutcomeEvaluationStartEvent()
            {
                ID = "sevt_011CZkZTUy4mGhu8peVXnlzr",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
                Type =
                    Events::BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanOutcomeEvaluationEndEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanOutcomeEvaluationEndEvent()
            {
                ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
                Explanation = "All five sections present with inline citations.",
                Iteration = 0,
                OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnlzr",
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
                Result = "satisfied",
                Type =
                    Events::BetaManagedAgentsSpanOutcomeEvaluationEndEventType.SpanOutcomeEvaluationEnd,
                Usage = new()
                {
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 1536,
                    InputTokens = 1842,
                    OutputTokens = 213,
                    Speed = Events::Speed.Standard,
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanModelRequestStartEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanModelRequestStartEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsSpanModelRequestStartEventType.SpanModelRequestStart,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanModelRequestEndEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanModelRequestEndEvent()
            {
                ID = "id",
                IsError = true,
                ModelRequestStartID = "model_request_start_id",
                ModelUsage = new()
                {
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    OutputTokens = 0,
                    Speed = Events::Speed.Standard,
                },
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanOutcomeEvaluationOngoingEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent()
            {
                ID = "sevt_011CZkZbCG2uOpc6xmDfvTzh",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
                Type =
                    Events::BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserDefineOutcomeEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsUserDefineOutcomeEvent()
            {
                ID = "sevt_011CZkZSTx3lFgt7odUWmkyq",
                Description = "Produce a 2-page summary as summary.md",
                MaxIterations = 3,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
                Rubric = new Events::BetaManagedAgentsTextRubric()
                {
                    Content = "Must cover all five sections; cite sources inline.",
                    Type = Events::BetaManagedAgentsTextRubricType.Text,
                },
                Type = Events::BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionDeletedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionDeletedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSessionDeletedEventType.SessionDeleted,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadStatusRunningEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadStatusRunningEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
                Type =
                    Events::BetaManagedAgentsSessionThreadStatusRunningEventType.SessionThreadStatusRunning,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadStatusIdleEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadStatusIdleEvent()
            {
                ID = "sevt_011CZkZXYc8qKly2tiZbrpDv",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
                StopReason = new Events::BetaManagedAgentsSessionEndTurn(
                    Events::BetaManagedAgentsSessionEndTurnType.EndTurn
                ),
                Type =
                    Events::BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadStatusTerminatedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadStatusTerminatedEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
                Type =
                    Events::BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadStatusRescheduledEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionThreadEvents value =
            new Events::BetaManagedAgentsSessionThreadStatusRescheduledEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
                Type =
                    Events::BetaManagedAgentsSessionThreadStatusRescheduledEventType.SessionThreadStatusRescheduled,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionThreadEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
