using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsStreamSessionEventsTest : TestBase
{
    [Fact]
    public void UserMessageEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsUserInterruptEvent()
            {
                ID = "id",
                Type = Events::BetaManagedAgentsUserInterruptEventType.UserInterrupt,
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        value.Validate();
    }

    [Fact]
    public void UserToolConfirmationEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsUserToolConfirmationEvent()
            {
                ID = "id",
                Result = Events::Result.Allow,
                ToolUseID = "tool_use_id",
                Type = Events::BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
                DenyMessage = "deny_message",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        value.Validate();
    }

    [Fact]
    public void UserCustomToolResultEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
            };
        value.Validate();
    }

    [Fact]
    public void AgentCustomToolUseEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
            };
        value.Validate();
    }

    [Fact]
    public void AgentMessageEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
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
            };
        value.Validate();
    }

    [Fact]
    public void AgentMcpToolResultEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
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
            };
        value.Validate();
    }

    [Fact]
    public void AgentToolResultEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
    public void AgentThreadContextCompactedEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
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
    public void SpanModelRequestStartEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        Events::BetaManagedAgentsStreamSessionEvents value =
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
    public void SessionDeletedEventValidationWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsSessionDeletedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSessionDeletedEventType.SessionDeleted,
            };
        value.Validate();
    }

    [Fact]
    public void UserMessageEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserInterruptEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsUserInterruptEvent()
            {
                ID = "id",
                Type = Events::BetaManagedAgentsUserInterruptEventType.UserInterrupt,
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserToolConfirmationEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsUserToolConfirmationEvent()
            {
                ID = "id",
                Result = Events::Result.Allow,
                ToolUseID = "tool_use_id",
                Type = Events::BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
                DenyMessage = "deny_message",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserCustomToolResultEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentCustomToolUseEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMessageEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThinkingEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsAgentThinkingEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsAgentThinkingEventType.AgentThinking,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMcpToolUseEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMcpToolResultEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentToolUseEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentToolResultEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadContextCompactedEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsAgentThreadContextCompactedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsAgentThreadContextCompactedEventType.AgentThreadContextCompacted,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionErrorEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusRescheduledEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsSessionStatusRescheduledEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsSessionStatusRescheduledEventType.SessionStatusRescheduled,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusRunningEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsSessionStatusRunningEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSessionStatusRunningEventType.SessionStatusRunning,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusIdleEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusTerminatedEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsSessionStatusTerminatedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsSessionStatusTerminatedEventType.SessionStatusTerminated,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanModelRequestStartEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsSpanModelRequestStartEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type =
                    Events::BetaManagedAgentsSpanModelRequestStartEventType.SpanModelRequestStart,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanModelRequestEndEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
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
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionDeletedEventSerializationRoundtripWorks()
    {
        Events::BetaManagedAgentsStreamSessionEvents value =
            new Events::BetaManagedAgentsSessionDeletedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Events::BetaManagedAgentsSessionDeletedEventType.SessionDeleted,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
