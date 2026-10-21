using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsStreamSessionEventsTest : TestBase
{
    [Fact]
    public void UserMessageEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserMessageEvent()
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        value.Validate();
    }

    [Fact]
    public void UserInterruptEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserInterruptEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void UserToolConfirmationEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsUserToolConfirmationEvent()
            {
                ID = "id",
                Result = Result.Allow,
                ToolUseID = "tool_use_id",
                DenyMessage = "deny_message",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void UserCustomToolResultEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsUserCustomToolResultEvent()
            {
                ID = "id",
                CustomToolUseID = "custom_tool_use_id",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                IsError = true,
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void AgentCustomToolUseEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentCustomToolUseEvent()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void AgentMessageEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentMessageEvent()
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        value.Validate();
    }

    [Fact]
    public void AgentThinkingEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentThinkingEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void AgentMcpToolUseEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentMcpToolUseEvent()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EvaluatedPermission = BetaManagedAgentsAgentEvaluatedPermission.Allow,
            Evaluation = new BetaManagedAgentsAgentToolEvaluationAlwaysAllow(),
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void AgentMcpToolResultEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentMcpToolResultEvent()
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        value.Validate();
    }

    [Fact]
    public void AgentToolUseEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentToolUseEvent()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EvaluatedPermission = BetaManagedAgentsAgentEvaluatedPermission.Allow,
            Evaluation = new BetaManagedAgentsAgentToolEvaluationAlwaysAllow(),
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void AgentToolResultEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentToolResultEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        value.Validate();
    }

    [Fact]
    public void AgentThreadMessageReceivedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsAgentThreadMessageReceivedEvent()
            {
                ID = "id",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                FromSessionThreadID = "from_session_thread_id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FromAgentName = "from_agent_name",
            };
        value.Validate();
    }

    [Fact]
    public void AgentThreadMessageSentEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsAgentThreadMessageSentEvent()
            {
                ID = "id",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ToSessionThreadID = "to_session_thread_id",
                ToAgentName = "to_agent_name",
            };
        value.Validate();
    }

    [Fact]
    public void AgentThreadContextCompactedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsAgentThreadContextCompactedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        value.Validate();
    }

    [Fact]
    public void SessionErrorEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionErrorEvent()
        {
            ID = "id",
            Error = new BetaManagedAgentsRepositoryAuthenticationError()
            {
                Message =
                    "The repository host rejected the credentials for the repository, or required credentials and received none.",
                RepositoryUrl = "https://github.com/example-org/example-repo",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SessionStatusRescheduledEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionStatusRescheduledEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        value.Validate();
    }

    [Fact]
    public void SessionStatusRunningEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionStatusRunningEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        value.Validate();
    }

    [Fact]
    public void SessionStatusIdleEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionStatusIdleEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };
        value.Validate();
    }

    [Fact]
    public void SessionStatusTerminatedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionStatusTerminatedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        value.Validate();
    }

    [Fact]
    public void SessionThreadCreatedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadCreatedEvent()
            {
                ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
                WorkflowRunID = null,
            };
        value.Validate();
    }

    [Fact]
    public void SpanOutcomeEvaluationStartEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanOutcomeEvaluationStartEvent()
            {
                ID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            };
        value.Validate();
    }

    [Fact]
    public void SpanOutcomeEvaluationEndEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanOutcomeEvaluationEndEvent()
            {
                ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
                Explanation = "All five sections present with inline citations.",
                Iteration = 0,
                OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
                Result = "satisfied",
                Usage = new()
                {
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 1536,
                    InputTokens = 1842,
                    OutputTokens = 213,
                    Speed = Speed.Standard,
                },
            };
        value.Validate();
    }

    [Fact]
    public void SpanModelRequestStartEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanModelRequestStartEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        value.Validate();
    }

    [Fact]
    public void SpanModelRequestEndEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSpanModelRequestEndEvent()
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
                Speed = Speed.Standard,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SpanOutcomeEvaluationOngoingEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent()
            {
                ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            };
        value.Validate();
    }

    [Fact]
    public void UserDefineOutcomeEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserDefineOutcomeEvent()
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };
        value.Validate();
    }

    [Fact]
    public void SessionDeletedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionDeletedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SessionThreadStatusRunningEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusRunningEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void SessionThreadStatusIdleEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusIdleEvent()
            {
                ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
                StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
                StopReason = new BetaManagedAgentsSessionEndTurn(),
            };
        value.Validate();
    }

    [Fact]
    public void SessionThreadStatusTerminatedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusTerminatedEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void UserToolResultEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserToolResultEvent()
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionThreadStatusRescheduledEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusRescheduledEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        value.Validate();
    }

    [Fact]
    public void SessionUpdatedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionUpdatedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
                Description = "A general-purpose starter agent.",
                ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new Agents::BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new Agents::BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                            McpServers =
                            [
                                new()
                                {
                                    Name = "example-mcp",
                                    Url = "https://example-server.modelcontextprotocol.io/sse",
                                },
                            ],
                            Model = new()
                            {
                                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                                Effort = new Agents::BetaManagedAgentsEffortLow(),
                                InferenceGeo = "inference_geo",
                                Speed = Agents::Speed.Standard,
                            },
                            Name = "Researcher",
                            Skills =
                            [
                                new Agents::BetaManagedAgentsAnthropicSkill()
                                {
                                    SkillID = "xlsx",
                                    Version = "1",
                                },
                            ],
                            System =
                                "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                            Tools =
                            [
                                new Agents::BetaManagedAgentsAgentToolset20260401()
                                {
                                    Configs =
                                    [
                                        new Agents::BetaManagedAgentsBashToolConfig()
                                        {
                                            Enabled = true,
                                            PermissionPolicy =
                                                new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                        },
                                    ],
                                    DefaultConfig = new()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                    },
                                },
                            ],
                            Version = 1,
                        },
                    ]
                ),
                Name = "My First Agent",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Version = "1",
                    },
                    new Agents::BetaManagedAgentsCustomSkill()
                    {
                        SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                        Version = "2",
                    },
                ],
                System =
                    "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
                Tools =
                [
                    new Agents::BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new Agents::BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };
        value.Validate();
    }

    [Fact]
    public void StartEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsStartEvent(
            new BetaManagedAgentsAgentMessagePreview("id")
        );
        value.Validate();
    }

    [Fact]
    public void DeltaEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsDeltaEvent()
        {
            Delta = new() { Content = new("Where is my order #1234?"), Index = 0 },
            EventID = "event_id",
        };
        value.Validate();
    }

    [Fact]
    public void SystemMessageEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSystemMessageEvent()
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SessionUsageEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionUsageEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
        };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunCreatedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsWorkflowRunCreatedEvent()
        {
            ID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E",
            Description = "Reads each vendor's pricing page and tabulates the plans.",
            Name = "Compare the vendors",
            Phases =
            [
                new()
                {
                    ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                    Description = null,
                    Name = "Collect the sources",
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunStatusEndedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunStatusEndedEvent()
            {
                ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
                Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunPhaseStartedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunPhaseStartedEvent()
            {
                ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
                WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunPhaseEndedEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunPhaseEndedEvent()
            {
                ID = "sevt_01JQ8ZB9W2Y4A6C8E1G2J4L6",
                PhaseStartedID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:04:47.905Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
                WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunStatusRunningEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunStatusRunningEvent()
            {
                ID = "sevt_01JQ8Z6Y1M3P5R7T9V1X3Z5B",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.430Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunStatusIdleEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunStatusIdleEvent()
            {
                ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunErrorEventValidationWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsWorkflowRunErrorEvent()
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };
        value.Validate();
    }

    [Fact]
    public void UserMessageEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserMessageEvent()
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserInterruptEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserInterruptEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserToolConfirmationEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsUserToolConfirmationEvent()
            {
                ID = "id",
                Result = Result.Allow,
                ToolUseID = "tool_use_id",
                DenyMessage = "deny_message",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserCustomToolResultEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsUserCustomToolResultEvent()
            {
                ID = "id",
                CustomToolUseID = "custom_tool_use_id",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                IsError = true,
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentCustomToolUseEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentCustomToolUseEvent()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMessageEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentMessageEvent()
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThinkingEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentThinkingEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMcpToolUseEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentMcpToolUseEvent()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EvaluatedPermission = BetaManagedAgentsAgentEvaluatedPermission.Allow,
            Evaluation = new BetaManagedAgentsAgentToolEvaluationAlwaysAllow(),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMcpToolResultEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentMcpToolResultEvent()
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentToolUseEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentToolUseEvent()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EvaluatedPermission = BetaManagedAgentsAgentEvaluatedPermission.Allow,
            Evaluation = new BetaManagedAgentsAgentToolEvaluationAlwaysAllow(),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentToolResultEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentToolResultEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadMessageReceivedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsAgentThreadMessageReceivedEvent()
            {
                ID = "id",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                FromSessionThreadID = "from_session_thread_id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FromAgentName = "from_agent_name",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadMessageSentEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsAgentThreadMessageSentEvent()
            {
                ID = "id",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ToSessionThreadID = "to_session_thread_id",
                ToAgentName = "to_agent_name",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadContextCompactedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsAgentThreadContextCompactedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionErrorEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionErrorEvent()
        {
            ID = "id",
            Error = new BetaManagedAgentsRepositoryAuthenticationError()
            {
                Message =
                    "The repository host rejected the credentials for the repository, or required credentials and received none.",
                RepositoryUrl = "https://github.com/example-org/example-repo",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusRescheduledEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionStatusRescheduledEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusRunningEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionStatusRunningEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusIdleEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionStatusIdleEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusTerminatedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionStatusTerminatedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadCreatedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadCreatedEvent()
            {
                ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
                WorkflowRunID = null,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanOutcomeEvaluationStartEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanOutcomeEvaluationStartEvent()
            {
                ID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanOutcomeEvaluationEndEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanOutcomeEvaluationEndEvent()
            {
                ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
                Explanation = "All five sections present with inline citations.",
                Iteration = 0,
                OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
                Result = "satisfied",
                Usage = new()
                {
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 1536,
                    InputTokens = 1842,
                    OutputTokens = 213,
                    Speed = Speed.Standard,
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanModelRequestStartEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanModelRequestStartEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanModelRequestEndEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSpanModelRequestEndEvent()
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
                Speed = Speed.Standard,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanOutcomeEvaluationOngoingEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent()
            {
                ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserDefineOutcomeEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserDefineOutcomeEvent()
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionDeletedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionDeletedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadStatusRunningEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusRunningEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadStatusIdleEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusIdleEvent()
            {
                ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
                StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
                StopReason = new BetaManagedAgentsSessionEndTurn(),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadStatusTerminatedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusTerminatedEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserToolResultEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserToolResultEvent()
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadStatusRescheduledEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusRescheduledEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionUpdatedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionUpdatedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
                Description = "A general-purpose starter agent.",
                ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new Agents::BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new Agents::BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                            McpServers =
                            [
                                new()
                                {
                                    Name = "example-mcp",
                                    Url = "https://example-server.modelcontextprotocol.io/sse",
                                },
                            ],
                            Model = new()
                            {
                                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                                Effort = new Agents::BetaManagedAgentsEffortLow(),
                                InferenceGeo = "inference_geo",
                                Speed = Agents::Speed.Standard,
                            },
                            Name = "Researcher",
                            Skills =
                            [
                                new Agents::BetaManagedAgentsAnthropicSkill()
                                {
                                    SkillID = "xlsx",
                                    Version = "1",
                                },
                            ],
                            System =
                                "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                            Tools =
                            [
                                new Agents::BetaManagedAgentsAgentToolset20260401()
                                {
                                    Configs =
                                    [
                                        new Agents::BetaManagedAgentsBashToolConfig()
                                        {
                                            Enabled = true,
                                            PermissionPolicy =
                                                new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                        },
                                    ],
                                    DefaultConfig = new()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                    },
                                },
                            ],
                            Version = 1,
                        },
                    ]
                ),
                Name = "My First Agent",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Version = "1",
                    },
                    new Agents::BetaManagedAgentsCustomSkill()
                    {
                        SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                        Version = "2",
                    },
                ],
                System =
                    "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
                Tools =
                [
                    new Agents::BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new Agents::BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StartEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsStartEvent(
            new BetaManagedAgentsAgentMessagePreview("id")
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DeltaEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsDeltaEvent()
        {
            Delta = new() { Content = new("Where is my order #1234?"), Index = 0 },
            EventID = "event_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SystemMessageEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSystemMessageEvent()
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionUsageEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionUsageEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunCreatedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsWorkflowRunCreatedEvent()
        {
            ID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E",
            Description = "Reads each vendor's pricing page and tabulates the plans.",
            Name = "Compare the vendors",
            Phases =
            [
                new()
                {
                    ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                    Description = null,
                    Name = "Collect the sources",
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunStatusEndedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunStatusEndedEvent()
            {
                ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
                Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunPhaseStartedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunPhaseStartedEvent()
            {
                ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
                WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunPhaseEndedEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunPhaseEndedEvent()
            {
                ID = "sevt_01JQ8ZB9W2Y4A6C8E1G2J4L6",
                PhaseStartedID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:04:47.905Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
                WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunStatusRunningEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunStatusRunningEvent()
            {
                ID = "sevt_01JQ8Z6Y1M3P5R7T9V1X3Z5B",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.430Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunStatusIdleEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunStatusIdleEvent()
            {
                ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunErrorEventSerializationRoundtripWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsWorkflowRunErrorEvent()
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStreamSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserMessageEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserMessageEvent()
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.UserMessage, value.Type.Value());
    }

    [Fact]
    public void UserInterruptEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserInterruptEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.UserInterrupt, value.Type.Value());
    }

    [Fact]
    public void UserToolConfirmationEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsUserToolConfirmationEvent()
            {
                ID = "id",
                Result = Result.Allow,
                ToolUseID = "tool_use_id",
                DenyMessage = "deny_message",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.UserToolConfirmation,
            value.Type.Value()
        );
    }

    [Fact]
    public void UserCustomToolResultEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsUserCustomToolResultEvent()
            {
                ID = "id",
                CustomToolUseID = "custom_tool_use_id",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                IsError = true,
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.UserCustomToolResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void AgentCustomToolUseEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentCustomToolUseEvent()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.AgentCustomToolUse,
            value.Type.Value()
        );
    }

    [Fact]
    public void AgentMessageEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentMessageEvent()
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.AgentMessage, value.Type.Value());
    }

    [Fact]
    public void AgentThinkingEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentThinkingEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.AgentThinking, value.Type.Value());
    }

    [Fact]
    public void AgentMcpToolUseEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentMcpToolUseEvent()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EvaluatedPermission = BetaManagedAgentsAgentEvaluatedPermission.Allow,
            Evaluation = new BetaManagedAgentsAgentToolEvaluationAlwaysAllow(),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.AgentMcpToolUse, value.Type.Value());
    }

    [Fact]
    public void AgentMcpToolResultEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentMcpToolResultEvent()
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.AgentMcpToolResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void AgentToolUseEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentToolUseEvent()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EvaluatedPermission = BetaManagedAgentsAgentEvaluatedPermission.Allow,
            Evaluation = new BetaManagedAgentsAgentToolEvaluationAlwaysAllow(),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.AgentToolUse, value.Type.Value());
    }

    [Fact]
    public void AgentToolResultEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsAgentToolResultEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.AgentToolResult, value.Type.Value());
    }

    [Fact]
    public void AgentThreadMessageReceivedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsAgentThreadMessageReceivedEvent()
            {
                ID = "id",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                FromSessionThreadID = "from_session_thread_id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FromAgentName = "from_agent_name",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.AgentThreadMessageReceived,
            value.Type.Value()
        );
    }

    [Fact]
    public void AgentThreadMessageSentEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsAgentThreadMessageSentEvent()
            {
                ID = "id",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ToSessionThreadID = "to_session_thread_id",
                ToAgentName = "to_agent_name",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.AgentThreadMessageSent,
            value.Type.Value()
        );
    }

    [Fact]
    public void AgentThreadContextCompactedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsAgentThreadContextCompactedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.AgentThreadContextCompacted,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionErrorEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionErrorEvent()
        {
            ID = "id",
            Error = new BetaManagedAgentsRepositoryAuthenticationError()
            {
                Message =
                    "The repository host rejected the credentials for the repository, or required credentials and received none.",
                RepositoryUrl = "https://github.com/example-org/example-repo",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.SessionError, value.Type.Value());
    }

    [Fact]
    public void SessionStatusRescheduledEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionStatusRescheduledEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SessionStatusRescheduled,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionStatusRunningEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionStatusRunningEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SessionStatusRunning,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionStatusIdleEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionStatusIdleEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SessionStatusIdle,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionStatusTerminatedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionStatusTerminatedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SessionStatusTerminated,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionThreadCreatedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadCreatedEvent()
            {
                ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
                WorkflowRunID = null,
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SessionThreadCreated,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanOutcomeEvaluationStartEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanOutcomeEvaluationStartEvent()
            {
                ID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SpanOutcomeEvaluationStart,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanOutcomeEvaluationEndEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanOutcomeEvaluationEndEvent()
            {
                ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
                Explanation = "All five sections present with inline citations.",
                Iteration = 0,
                OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
                Result = "satisfied",
                Usage = new()
                {
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 1536,
                    InputTokens = 1842,
                    OutputTokens = 213,
                    Speed = Speed.Standard,
                },
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SpanOutcomeEvaluationEnd,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanModelRequestStartEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanModelRequestStartEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SpanModelRequestStart,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanModelRequestEndEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSpanModelRequestEndEvent()
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
                Speed = Speed.Standard,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SpanModelRequestEnd,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanOutcomeEvaluationOngoingEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent()
            {
                ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SpanOutcomeEvaluationOngoing,
            value.Type.Value()
        );
    }

    [Fact]
    public void UserDefineOutcomeEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserDefineOutcomeEvent()
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.UserDefineOutcome,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionDeletedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionDeletedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.SessionDeleted, value.Type.Value());
    }

    [Fact]
    public void SessionThreadStatusRunningEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusRunningEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusRunning,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionThreadStatusIdleEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusIdleEvent()
            {
                ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
                AgentName = "Researcher",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
                StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
                StopReason = new BetaManagedAgentsSessionEndTurn(),
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusIdle,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionThreadStatusTerminatedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusTerminatedEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusTerminated,
            value.Type.Value()
        );
    }

    [Fact]
    public void UserToolResultEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsUserToolResultEvent()
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.UserToolResult, value.Type.Value());
    }

    [Fact]
    public void SessionThreadStatusRescheduledEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsSessionThreadStatusRescheduledEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusRescheduled,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionUpdatedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionUpdatedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Agent = new()
            {
                ID = "agent_011CZkYpogX7uDKUyvBTophP",
                Description = "A general-purpose starter agent.",
                ExecutionIdentity = new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                McpServers =
                [
                    new()
                    {
                        Name = "example-mcp",
                        Url = "https://example-server.modelcontextprotocol.io/sse",
                    },
                ],
                Model = new()
                {
                    ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                    Effort = new Agents::BetaManagedAgentsEffortLow(),
                    InferenceGeo = "inference_geo",
                    Speed = Agents::Speed.Standard,
                },
                Multiagent = new BetaManagedAgentsSessionMultiagentCoordinator(
                    [
                        new Agents::BetaManagedAgentsSessionThreadAgent()
                        {
                            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                            Description = "A focused research subagent.",
                            ExecutionIdentity =
                                new Agents::BetaManagedAgentsServiceAccountExecutionIdentity(),
                            McpServers =
                            [
                                new()
                                {
                                    Name = "example-mcp",
                                    Url = "https://example-server.modelcontextprotocol.io/sse",
                                },
                            ],
                            Model = new()
                            {
                                ID = Agents::BetaManagedAgentsModel.ClaudeOpus5_5,
                                Effort = new Agents::BetaManagedAgentsEffortLow(),
                                InferenceGeo = "inference_geo",
                                Speed = Agents::Speed.Standard,
                            },
                            Name = "Researcher",
                            Skills =
                            [
                                new Agents::BetaManagedAgentsAnthropicSkill()
                                {
                                    SkillID = "xlsx",
                                    Version = "1",
                                },
                            ],
                            System =
                                "You are a research subagent that gathers and summarises sources for the coordinating agent.",
                            Tools =
                            [
                                new Agents::BetaManagedAgentsAgentToolset20260401()
                                {
                                    Configs =
                                    [
                                        new Agents::BetaManagedAgentsBashToolConfig()
                                        {
                                            Enabled = true,
                                            PermissionPolicy =
                                                new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                                        },
                                    ],
                                    DefaultConfig = new()
                                    {
                                        Enabled = true,
                                        PermissionPolicy =
                                            new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                                    },
                                },
                            ],
                            Version = 1,
                        },
                    ]
                ),
                Name = "My First Agent",
                Skills =
                [
                    new Agents::BetaManagedAgentsAnthropicSkill()
                    {
                        SkillID = "xlsx",
                        Version = "1",
                    },
                    new Agents::BetaManagedAgentsCustomSkill()
                    {
                        SkillID = "skill_011CZkZFNu9hAbo3jZPRgTmx",
                        Version = "2",
                    },
                ],
                System =
                    "You are a general-purpose agent that can research, write code, run commands, and use connected tools to complete the user's task end to end.",
                Tools =
                [
                    new Agents::BetaManagedAgentsAgentToolset20260401()
                    {
                        Configs =
                        [
                            new Agents::BetaManagedAgentsBashToolConfig()
                            {
                                Enabled = true,
                                PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAllowPolicy(),
                            },
                        ],
                        DefaultConfig = new()
                        {
                            Enabled = true,
                            PermissionPolicy = new Agents::BetaManagedAgentsAlwaysAskPolicy(),
                        },
                    },
                ],
                Version = 1,
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Title = "title",
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.SessionUpdated, value.Type.Value());
    }

    [Fact]
    public void StartEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsStartEvent(
            new BetaManagedAgentsAgentMessagePreview("id")
        );
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.EventStart, value.Type.Value());
    }

    [Fact]
    public void DeltaEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsDeltaEvent()
        {
            Delta = new() { Content = new("Where is my order #1234?"), Index = 0 },
            EventID = "event_id",
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.EventDelta, value.Type.Value());
    }

    [Fact]
    public void SystemMessageEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSystemMessageEvent()
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.SystemMessage, value.Type.Value());
    }

    [Fact]
    public void SessionUsageEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsSessionUsageEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new()
            {
                ActiveSeconds = 0,
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                InputTokens = 0,
                ListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
                OutputTokens = 0,
                ServerToolUse = new() { WebFetchRequests = 0, WebSearchRequests = 3 },
            },
            Budget = new(new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }),
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.SessionUsage, value.Type.Value());
    }

    [Fact]
    public void WorkflowRunCreatedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsWorkflowRunCreatedEvent()
        {
            ID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E",
            Description = "Reads each vendor's pricing page and tabulates the plans.",
            Name = "Compare the vendors",
            Phases =
            [
                new()
                {
                    ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                    Description = null,
                    Name = "Collect the sources",
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.WorkflowRunCreated,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunStatusEndedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunStatusEndedEvent()
            {
                ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
                Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.WorkflowRunStatusEnded,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunPhaseStartedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunPhaseStartedEvent()
            {
                ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
                WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.WorkflowRunPhaseStarted,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunPhaseEndedEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunPhaseEndedEvent()
            {
                ID = "sevt_01JQ8ZB9W2Y4A6C8E1G2J4L6",
                PhaseStartedID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:04:47.905Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
                WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.WorkflowRunPhaseEnded,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunStatusRunningEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunStatusRunningEvent()
            {
                ID = "sevt_01JQ8Z6Y1M3P5R7T9V1X3Z5B",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.430Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.WorkflowRunStatusRunning,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunStatusIdleEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value =
            new BetaManagedAgentsWorkflowRunStatusIdleEvent()
            {
                ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
                ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
                WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            };
        Assert.Equal(
            BetaManagedAgentsStreamSessionEventsType.WorkflowRunStatusIdle,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunErrorEventTypeWorks()
    {
        BetaManagedAgentsStreamSessionEvents value = new BetaManagedAgentsWorkflowRunErrorEvent()
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };
        Assert.Equal(BetaManagedAgentsStreamSessionEventsType.WorkflowRunError, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsStreamSessionEvents value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "sevt_011CZkZGPp1iBcp4kaQSihUm",
                  "type": "user.message",
                  "processed_at": "2026-03-15T10:00:00Z",
                  "session_thread_id": "session_thread_id",
                  "tool_use_id": "tool_use_id",
                  "is_error": true,
                  "name": "name",
                  "evaluated_permission": "allow",
                  "evaluation": {
                    "type": "always_allow"
                  },
                  "stop_details": {
                    "category": "cyber",
                    "explanation": "explanation",
                    "type": "refusal"
                  },
                  "agent_name": "Researcher",
                  "workflow_run_id": null,
                  "iteration": 0,
                  "outcome_id": "outc_011CZkZRSw2kEfs6ncTVmjxP",
                  "description": "Produce a 2-page summary as summary.md",
                  "budget": {
                    "max_list_cost": {
                      "amount": "2500",
                      "currency": "USD"
                    },
                    "type": "limit"
                  },
                  "workflow_run_phase_id": "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "sevt_011CZkZGPp1iBcp4kaQSihUm";
        ApiEnum<string, BetaManagedAgentsStreamSessionEventsType> expectedType =
            BetaManagedAgentsStreamSessionEventsType.UserMessage;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "session_thread_id";
        string expectedToolUseID = "tool_use_id";
        bool expectedIsError = true;
        string expectedName = "name";
        ApiEnum<string, BetaManagedAgentsAgentEvaluatedPermission> expectedEvaluatedPermission =
            BetaManagedAgentsAgentEvaluatedPermission.Allow;
        BetaManagedAgentsAgentToolEvaluation expectedEvaluation =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAllow();
        BetaManagedAgentsSessionRefusalStopDetails expectedStopDetails = new()
        {
            Category = Category.Cyber,
            Explanation = "explanation",
        };
        string expectedAgentName = "Researcher";
        int expectedIteration = 0;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP";
        string expectedDescription = "Produce a 2-page summary as summary.md";
        BetaManagedAgentsBudgetLimit expectedBudget = new(
            new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
        );
        string expectedWorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd";

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedProcessedAt, value.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, value.SessionThreadID);
        Assert.Equal(expectedToolUseID, value.ToolUseID);
        Assert.Equal(expectedIsError, value.IsError);
        Assert.Equal(expectedName, value.Name);
        Assert.Equal(expectedEvaluatedPermission, value.EvaluatedPermission);
        Assert.Equal(expectedEvaluation, value.Evaluation);
        Assert.Equal(expectedStopDetails, value.StopDetails);
        Assert.Equal(expectedAgentName, value.AgentName);
        Assert.Null(value.WorkflowRunID);
        Assert.Equal(expectedIteration, value.Iteration);
        Assert.Equal(expectedOutcomeID, value.OutcomeID);
        Assert.Equal(expectedDescription, value.Description);
        Assert.Equal(expectedBudget, value.Budget);
        Assert.Equal(expectedWorkflowRunPhaseID, value.WorkflowRunPhaseID);

        BetaManagedAgentsStreamSessionEvents emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ProcessedAt);
        Assert.Null(emptyValue.SessionThreadID);
        Assert.Null(emptyValue.ToolUseID);
        Assert.Null(emptyValue.IsError);
        Assert.Null(emptyValue.Name);
        Assert.Null(emptyValue.EvaluatedPermission);
        Assert.Null(emptyValue.Evaluation);
        Assert.Null(emptyValue.StopDetails);
        Assert.Null(emptyValue.AgentName);
        Assert.Null(emptyValue.WorkflowRunID);
        Assert.Null(emptyValue.Iteration);
        Assert.Null(emptyValue.OutcomeID);
        Assert.Null(emptyValue.Description);
        Assert.Null(emptyValue.Budget);
        Assert.Null(emptyValue.WorkflowRunPhaseID);

        BetaManagedAgentsStreamSessionEvents mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ],
                  "processed_at": [
                    "invalid"
                  ],
                  "session_thread_id": [
                    "invalid"
                  ],
                  "tool_use_id": [
                    "invalid"
                  ],
                  "is_error": [
                    "invalid"
                  ],
                  "name": [
                    "invalid"
                  ],
                  "stop_details": [
                    "invalid"
                  ],
                  "agent_name": [
                    "invalid"
                  ],
                  "workflow_run_id": [
                    "invalid"
                  ],
                  "iteration": [
                    "invalid"
                  ],
                  "outcome_id": [
                    "invalid"
                  ],
                  "description": [
                    "invalid"
                  ],
                  "budget": [
                    "invalid"
                  ],
                  "workflow_run_phase_id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ID);
        Assert.Null(mismatchedValue.ProcessedAt);
        Assert.Null(mismatchedValue.SessionThreadID);
        Assert.Null(mismatchedValue.ToolUseID);
        Assert.Null(mismatchedValue.IsError);
        Assert.Null(mismatchedValue.Name);
        Assert.Null(mismatchedValue.StopDetails);
        Assert.Null(mismatchedValue.AgentName);
        Assert.Null(mismatchedValue.WorkflowRunID);
        Assert.Null(mismatchedValue.Iteration);
        Assert.Null(mismatchedValue.OutcomeID);
        Assert.Null(mismatchedValue.Description);
        Assert.Null(mismatchedValue.Budget);
        Assert.Null(mismatchedValue.WorkflowRunPhaseID);
    }
}

public class BetaManagedAgentsStreamSessionEventsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserMessage)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserInterrupt)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserToolConfirmation)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserCustomToolResult)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentCustomToolUse)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentMessage)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentThinking)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentMcpToolUse)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentMcpToolResult)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentToolUse)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentToolResult)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentThreadMessageReceived)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentThreadMessageSent)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentThreadContextCompacted)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionError)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionStatusRescheduled)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionStatusRunning)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionStatusIdle)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionStatusTerminated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadCreated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanOutcomeEvaluationStart)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanOutcomeEvaluationEnd)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanModelRequestStart)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanModelRequestEnd)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanOutcomeEvaluationOngoing)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionDeleted)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusRunning)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusIdle)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusTerminated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserToolResult)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusRescheduled)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionUpdated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.EventStart)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.EventDelta)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SystemMessage)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionUsage)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunCreated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunStatusEnded)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunPhaseStarted)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunPhaseEnded)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunStatusRunning)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunStatusIdle)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunError)]
    public void Validation_Works(BetaManagedAgentsStreamSessionEventsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsStreamSessionEventsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStreamSessionEventsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserMessage)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserInterrupt)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserToolConfirmation)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserCustomToolResult)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentCustomToolUse)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentMessage)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentThinking)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentMcpToolUse)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentMcpToolResult)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentToolUse)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentToolResult)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentThreadMessageReceived)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentThreadMessageSent)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.AgentThreadContextCompacted)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionError)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionStatusRescheduled)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionStatusRunning)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionStatusIdle)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionStatusTerminated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadCreated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanOutcomeEvaluationStart)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanOutcomeEvaluationEnd)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanModelRequestStart)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanModelRequestEnd)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SpanOutcomeEvaluationOngoing)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionDeleted)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusRunning)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusIdle)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusTerminated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.UserToolResult)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionThreadStatusRescheduled)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionUpdated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.EventStart)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.EventDelta)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SystemMessage)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.SessionUsage)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunCreated)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunStatusEnded)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunPhaseStarted)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunPhaseEnded)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunStatusRunning)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunStatusIdle)]
    [InlineData(BetaManagedAgentsStreamSessionEventsType.WorkflowRunError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsStreamSessionEventsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsStreamSessionEventsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStreamSessionEventsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStreamSessionEventsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStreamSessionEventsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
