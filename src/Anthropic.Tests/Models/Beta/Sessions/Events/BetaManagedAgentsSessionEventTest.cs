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

public class BetaManagedAgentsSessionEventTest : TestBase
{
    [Fact]
    public void UserMessageValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserMessageEvent()
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        value.Validate();
    }

    [Fact]
    public void UserInterruptValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserInterruptEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void UserToolConfirmationValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserToolConfirmationEvent()
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
    public void UserCustomToolResultValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserCustomToolResultEvent()
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
    public void AgentCustomToolUseValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentCustomToolUseEvent()
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
    public void AgentMessageValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentMessageEvent()
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        value.Validate();
    }

    [Fact]
    public void AgentThinkingValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentThinkingEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void AgentMcpToolUseValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentMcpToolUseEvent()
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
    public void AgentMcpToolResultValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentMcpToolResultEvent()
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
    public void AgentToolUseValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentToolUseEvent()
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
    public void AgentToolResultValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentToolResultEvent()
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
    public void AgentThreadMessageReceivedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentThreadMessageReceivedEvent()
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
    public void AgentThreadMessageSentValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentThreadMessageSentEvent()
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
    public void AgentThreadContextCompactedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value =
            new BetaManagedAgentsAgentThreadContextCompactedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        value.Validate();
    }

    [Fact]
    public void ErrorValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionErrorEvent()
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
    public void StatusRescheduledValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusRescheduledEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void StatusRunningValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusRunningEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void StatusIdleValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusIdleEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };
        value.Validate();
    }

    [Fact]
    public void StatusTerminatedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusTerminatedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void ThreadCreatedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionThreadCreatedEvent()
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
    public void SpanOutcomeEvaluationStartValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanOutcomeEvaluationStartEvent()
        {
            ID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SpanOutcomeEvaluationEndValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanOutcomeEvaluationEndEvent()
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
    public void SpanModelRequestStartValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanModelRequestStartEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void SpanModelRequestEndValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanModelRequestEndEvent()
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
    public void SpanOutcomeEvaluationOngoingValidationWorks()
    {
        BetaManagedAgentsSessionEvent value =
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
    public void UserDefineOutcomeValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserDefineOutcomeEvent()
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
    public void DeletedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionDeletedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void ThreadStatusRunningValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionThreadStatusRunningEvent()
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void ThreadStatusIdleValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionThreadStatusIdleEvent()
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
    public void ThreadStatusTerminatedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value =
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
    public void UserToolResultValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserToolResultEvent()
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
    public void ThreadStatusRescheduledValidationWorks()
    {
        BetaManagedAgentsSessionEvent value =
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
    public void UpdatedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionUpdatedEvent()
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
    public void SystemMessageValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSystemMessageEvent()
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void UsageValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionUsageEvent()
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
    public void WorkflowRunCreatedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunCreatedEvent()
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
    public void WorkflowRunStatusEndedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunStatusEndedEvent()
        {
            ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
            Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunPhaseStartedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunPhaseStartedEvent()
        {
            ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunPhaseEndedValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunPhaseEndedEvent()
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
    public void WorkflowRunStatusRunningValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunStatusRunningEvent()
        {
            ID = "sevt_01JQ8Z6Y1M3P5R7T9V1X3Z5B",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.430Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunStatusIdleValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunStatusIdleEvent()
        {
            ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        value.Validate();
    }

    [Fact]
    public void WorkflowRunErrorValidationWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunErrorEvent()
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };
        value.Validate();
    }

    [Fact]
    public void UserMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserMessageEvent()
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserInterruptSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserInterruptEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserToolConfirmationSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserToolConfirmationEvent()
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserCustomToolResultSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserCustomToolResultEvent()
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentCustomToolUseSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentCustomToolUseEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentMessageEvent()
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThinkingSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentThinkingEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMcpToolUseSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentMcpToolUseEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMcpToolResultSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentMcpToolResultEvent()
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentToolUseSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentToolUseEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentToolResultSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentToolResultEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadMessageReceivedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentThreadMessageReceivedEvent()
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FromAgentName = "from_agent_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadMessageSentSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentThreadMessageSentEvent()
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            ToAgentName = "to_agent_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThreadContextCompactedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value =
            new BetaManagedAgentsAgentThreadContextCompactedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionErrorEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StatusRescheduledSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusRescheduledEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StatusRunningSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusRunningEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StatusIdleSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusIdleEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StatusTerminatedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusTerminatedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadCreatedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionThreadCreatedEvent()
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            WorkflowRunID = null,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanOutcomeEvaluationStartSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanOutcomeEvaluationStartEvent()
        {
            ID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanOutcomeEvaluationEndSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanOutcomeEvaluationEndEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanModelRequestStartSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanModelRequestStartEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanModelRequestEndSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanModelRequestEndEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpanOutcomeEvaluationOngoingSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value =
            new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent()
            {
                ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserDefineOutcomeSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserDefineOutcomeEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DeletedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionDeletedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadStatusRunningSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionThreadStatusRunningEvent()
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadStatusIdleSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionThreadStatusIdleEvent()
        {
            ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadStatusTerminatedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value =
            new BetaManagedAgentsSessionThreadStatusTerminatedEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserToolResultSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserToolResultEvent()
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThreadStatusRescheduledSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value =
            new BetaManagedAgentsSessionThreadStatusRescheduledEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UpdatedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionUpdatedEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SystemMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSystemMessageEvent()
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UsageSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionUsageEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunCreatedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunCreatedEvent()
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
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunStatusEndedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunStatusEndedEvent()
        {
            ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
            Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunPhaseStartedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunPhaseStartedEvent()
        {
            ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunPhaseEndedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunPhaseEndedEvent()
        {
            ID = "sevt_01JQ8ZB9W2Y4A6C8E1G2J4L6",
            PhaseStartedID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:04:47.905Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunStatusRunningSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunStatusRunningEvent()
        {
            ID = "sevt_01JQ8Z6Y1M3P5R7T9V1X3Z5B",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.430Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunStatusIdleSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunStatusIdleEvent()
        {
            ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkflowRunErrorSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunErrorEvent()
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserMessageTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserMessageEvent()
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.UserMessage, value.Type.Value());
    }

    [Fact]
    public void UserInterruptTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserInterruptEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.UserInterrupt, value.Type.Value());
    }

    [Fact]
    public void UserToolConfirmationTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserToolConfirmationEvent()
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.UserToolConfirmation,
            value.Type.Value()
        );
    }

    [Fact]
    public void UserCustomToolResultTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserCustomToolResultEvent()
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.UserCustomToolResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void AgentCustomToolUseTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentCustomToolUseEvent()
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
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.AgentCustomToolUse, value.Type.Value());
    }

    [Fact]
    public void AgentMessageTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentMessageEvent()
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.AgentMessage, value.Type.Value());
    }

    [Fact]
    public void AgentThinkingTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentThinkingEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.AgentThinking, value.Type.Value());
    }

    [Fact]
    public void AgentMcpToolUseTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentMcpToolUseEvent()
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
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.AgentMcpToolUse, value.Type.Value());
    }

    [Fact]
    public void AgentMcpToolResultTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentMcpToolResultEvent()
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.AgentMcpToolResult, value.Type.Value());
    }

    [Fact]
    public void AgentToolUseTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentToolUseEvent()
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
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.AgentToolUse, value.Type.Value());
    }

    [Fact]
    public void AgentToolResultTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentToolResultEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.AgentToolResult, value.Type.Value());
    }

    [Fact]
    public void AgentThreadMessageReceivedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentThreadMessageReceivedEvent()
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FromAgentName = "from_agent_name",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.AgentThreadMessageReceived,
            value.Type.Value()
        );
    }

    [Fact]
    public void AgentThreadMessageSentTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsAgentThreadMessageSentEvent()
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            ToAgentName = "to_agent_name",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.AgentThreadMessageSent,
            value.Type.Value()
        );
    }

    [Fact]
    public void AgentThreadContextCompactedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value =
            new BetaManagedAgentsAgentThreadContextCompactedEvent()
            {
                ID = "id",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.AgentThreadContextCompacted,
            value.Type.Value()
        );
    }

    [Fact]
    public void ErrorTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionErrorEvent()
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
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.SessionError, value.Type.Value());
    }

    [Fact]
    public void StatusRescheduledTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusRescheduledEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SessionStatusRescheduled,
            value.Type.Value()
        );
    }

    [Fact]
    public void StatusRunningTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusRunningEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SessionStatusRunning,
            value.Type.Value()
        );
    }

    [Fact]
    public void StatusIdleTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusIdleEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.SessionStatusIdle, value.Type.Value());
    }

    [Fact]
    public void StatusTerminatedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionStatusTerminatedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SessionStatusTerminated,
            value.Type.Value()
        );
    }

    [Fact]
    public void ThreadCreatedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionThreadCreatedEvent()
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            WorkflowRunID = null,
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SessionThreadCreated,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanOutcomeEvaluationStartTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanOutcomeEvaluationStartEvent()
        {
            ID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SpanOutcomeEvaluationStart,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanOutcomeEvaluationEndTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanOutcomeEvaluationEndEvent()
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
            BetaManagedAgentsSessionEventTypeValue.SpanOutcomeEvaluationEnd,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanModelRequestStartTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanModelRequestStartEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SpanModelRequestStart,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanModelRequestEndTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSpanModelRequestEndEvent()
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
            BetaManagedAgentsSessionEventTypeValue.SpanModelRequestEnd,
            value.Type.Value()
        );
    }

    [Fact]
    public void SpanOutcomeEvaluationOngoingTypeWorks()
    {
        BetaManagedAgentsSessionEvent value =
            new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent()
            {
                ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
                Iteration = 0,
                OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SpanOutcomeEvaluationOngoing,
            value.Type.Value()
        );
    }

    [Fact]
    public void UserDefineOutcomeTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserDefineOutcomeEvent()
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
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.UserDefineOutcome, value.Type.Value());
    }

    [Fact]
    public void DeletedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionDeletedEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.SessionDeleted, value.Type.Value());
    }

    [Fact]
    public void ThreadStatusRunningTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionThreadStatusRunningEvent()
        {
            ID = "id",
            AgentName = "agent_name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusRunning,
            value.Type.Value()
        );
    }

    [Fact]
    public void ThreadStatusIdleTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionThreadStatusIdleEvent()
        {
            ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusIdle,
            value.Type.Value()
        );
    }

    [Fact]
    public void ThreadStatusTerminatedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value =
            new BetaManagedAgentsSessionThreadStatusTerminatedEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusTerminated,
            value.Type.Value()
        );
    }

    [Fact]
    public void UserToolResultTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsUserToolResultEvent()
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.UserToolResult, value.Type.Value());
    }

    [Fact]
    public void ThreadStatusRescheduledTypeWorks()
    {
        BetaManagedAgentsSessionEvent value =
            new BetaManagedAgentsSessionThreadStatusRescheduledEvent()
            {
                ID = "id",
                AgentName = "agent_name",
                ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SessionThreadID = "session_thread_id",
            };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusRescheduled,
            value.Type.Value()
        );
    }

    [Fact]
    public void UpdatedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionUpdatedEvent()
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
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.SessionUpdated, value.Type.Value());
    }

    [Fact]
    public void SystemMessageTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSystemMessageEvent()
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.SystemMessage, value.Type.Value());
    }

    [Fact]
    public void UsageTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsSessionUsageEvent()
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
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.SessionUsage, value.Type.Value());
    }

    [Fact]
    public void WorkflowRunCreatedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunCreatedEvent()
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
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.WorkflowRunCreated, value.Type.Value());
    }

    [Fact]
    public void WorkflowRunStatusEndedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunStatusEndedEvent()
        {
            ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
            Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.WorkflowRunStatusEnded,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunPhaseStartedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunPhaseStartedEvent()
        {
            ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.WorkflowRunPhaseStarted,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunPhaseEndedTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunPhaseEndedEvent()
        {
            ID = "sevt_01JQ8ZB9W2Y4A6C8E1G2J4L6",
            PhaseStartedID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:04:47.905Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.WorkflowRunPhaseEnded,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunStatusRunningTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunStatusRunningEvent()
        {
            ID = "sevt_01JQ8Z6Y1M3P5R7T9V1X3Z5B",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.430Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.WorkflowRunStatusRunning,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunStatusIdleTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunStatusIdleEvent()
        {
            ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };
        Assert.Equal(
            BetaManagedAgentsSessionEventTypeValue.WorkflowRunStatusIdle,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkflowRunErrorTypeWorks()
    {
        BetaManagedAgentsSessionEvent value = new BetaManagedAgentsWorkflowRunErrorEvent()
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };
        Assert.Equal(BetaManagedAgentsSessionEventTypeValue.WorkflowRunError, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSessionEvent value = new(
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
        ApiEnum<string, BetaManagedAgentsSessionEventTypeValue> expectedType =
            BetaManagedAgentsSessionEventTypeValue.UserMessage;
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

        BetaManagedAgentsSessionEvent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
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

        BetaManagedAgentsSessionEvent mismatchedValue = new(
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

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.ID);
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

public class BetaManagedAgentsSessionEventTypeValueTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserMessage)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserInterrupt)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserToolConfirmation)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserCustomToolResult)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentCustomToolUse)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentMessage)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentThinking)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentMcpToolUse)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentMcpToolResult)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentToolUse)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentToolResult)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentThreadMessageReceived)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentThreadMessageSent)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentThreadContextCompacted)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionError)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionStatusRescheduled)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionStatusTerminated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadCreated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanOutcomeEvaluationStart)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanOutcomeEvaluationEnd)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanModelRequestStart)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanModelRequestEnd)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanOutcomeEvaluationOngoing)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionDeleted)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusTerminated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserToolResult)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusRescheduled)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionUpdated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SystemMessage)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionUsage)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunCreated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunStatusEnded)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunPhaseStarted)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunPhaseEnded)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunError)]
    public void Validation_Works(BetaManagedAgentsSessionEventTypeValue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionEventTypeValue> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionEventTypeValue>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserMessage)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserInterrupt)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserToolConfirmation)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserCustomToolResult)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentCustomToolUse)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentMessage)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentThinking)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentMcpToolUse)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentMcpToolResult)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentToolUse)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentToolResult)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentThreadMessageReceived)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentThreadMessageSent)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.AgentThreadContextCompacted)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionError)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionStatusRescheduled)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionStatusTerminated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadCreated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanOutcomeEvaluationStart)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanOutcomeEvaluationEnd)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanModelRequestStart)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanModelRequestEnd)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SpanOutcomeEvaluationOngoing)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionDeleted)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusTerminated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.UserToolResult)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionThreadStatusRescheduled)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionUpdated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SystemMessage)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.SessionUsage)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunCreated)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunStatusEnded)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunPhaseStarted)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunPhaseEnded)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventTypeValue.WorkflowRunError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionEventTypeValue rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionEventTypeValue> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionEventTypeValue>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionEventTypeValue>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionEventTypeValue>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
