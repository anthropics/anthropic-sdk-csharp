using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Items;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Items;

public class BetaComplianceReviewItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewItem
        {
            ID = "id",
            Actor = new BetaComplianceReviewUserActor()
            {
                EmailAddress = "email_address",
                UserID = "user_id",
            },
            ContentExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Details = new BetaComplianceReviewMessageDetails()
            {
                Content = new BetaComplianceReviewCreateMessageContent()
                {
                    Request = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = new()
                    {
                        ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                        Container = new()
                        {
                            ID = "container_011CpZohnwH4vuy7gazohgSP",
                            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::Type.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Content =
                        [
                            new Messages::BetaTextBlock()
                            {
                                Citations = null,
                                Text = "Hi! My name is Claude.",
                            },
                        ],
                        ContextManagement = new(
                            [
                                new Messages::BetaClearToolUses20250919EditResponse()
                                {
                                    ClearedInputTokens = 0,
                                    ClearedToolUses = 0,
                                },
                            ]
                        ),
                        Diagnostics = null,
                        Model = Model.ClaudeOpus5_5,
                        StopDetails = null,
                        StopReason = Messages::BetaStopReason.EndTurn,
                        StopSequence = null,
                        Usage = new()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 2051,
                            CacheReadInputTokens = 2051,
                            FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
                            InferenceGeo = "global",
                            InputTokens = 2095,
                            Iterations =
                            [
                                new Messages::BetaMessageIterationUsage()
                                {
                                    CacheCreation = new()
                                    {
                                        Ephemeral1hInputTokens = 0,
                                        Ephemeral5mInputTokens = 0,
                                    },
                                    CacheCreationInputTokens = 0,
                                    CacheReadInputTokens = 0,
                                    InputTokens = 0,
                                    Model = Model.ClaudeFable5_2,
                                    OutputTokens = 0,
                                },
                            ],
                            OutputTokens = 503,
                            OutputTokensDetails = new(0),
                            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                            ServiceTier = Messages::BetaUsageServiceTier.Standard,
                            Speed = Messages::BetaUsageSpeed.Standard,
                        },
                        InputTransformations =
                        [
                            new Messages::BetaThinkingDroppedInputTransformation()
                            {
                                Path = "path",
                                Reason =
                                    Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                            },
                        ],
                    },
                },
                ContentUnavailableReason = new BetaComplianceReviewContentNotCaptured(),
                Model = "model",
            },
            OrganizationID = "organization_id",
            ReadReason = new BetaComplianceReviewSafeguardsReason(),
            UserProfileID = "user_profile_id",
            WorkspaceID = "workspace_id",
        };

        string expectedID = "id";
        BetaComplianceReviewActor expectedActor = new BetaComplianceReviewUserActor()
        {
            EmailAddress = "email_address",
            UserID = "user_id",
        };
        DateTimeOffset expectedContentExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaComplianceReviewItemDetails expectedDetails = new BetaComplianceReviewMessageDetails()
        {
            Content = new BetaComplianceReviewCreateMessageContent()
            {
                Request = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Response = new()
                {
                    ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                    Container = new()
                    {
                        ID = "container_011CpZohnwH4vuy7gazohgSP",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Skills =
                        [
                            new()
                            {
                                SkillID = "pdf",
                                Type = Messages::Type.Anthropic,
                                Version = "latest",
                            },
                        ],
                    },
                    Content =
                    [
                        new Messages::BetaTextBlock()
                        {
                            Citations = null,
                            Text = "Hi! My name is Claude.",
                        },
                    ],
                    ContextManagement = new(
                        [
                            new Messages::BetaClearToolUses20250919EditResponse()
                            {
                                ClearedInputTokens = 0,
                                ClearedToolUses = 0,
                            },
                        ]
                    ),
                    Diagnostics = null,
                    Model = Model.ClaudeOpus5_5,
                    StopDetails = null,
                    StopReason = Messages::BetaStopReason.EndTurn,
                    StopSequence = null,
                    Usage = new()
                    {
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheCreationInputTokens = 2051,
                        CacheReadInputTokens = 2051,
                        FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
                        InferenceGeo = "global",
                        InputTokens = 2095,
                        Iterations =
                        [
                            new Messages::BetaMessageIterationUsage()
                            {
                                CacheCreation = new()
                                {
                                    Ephemeral1hInputTokens = 0,
                                    Ephemeral5mInputTokens = 0,
                                },
                                CacheCreationInputTokens = 0,
                                CacheReadInputTokens = 0,
                                InputTokens = 0,
                                Model = Model.ClaudeFable5_2,
                                OutputTokens = 0,
                            },
                        ],
                        OutputTokens = 503,
                        OutputTokensDetails = new(0),
                        ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                        ServiceTier = Messages::BetaUsageServiceTier.Standard,
                        Speed = Messages::BetaUsageSpeed.Standard,
                    },
                    InputTransformations =
                    [
                        new Messages::BetaThinkingDroppedInputTransformation()
                        {
                            Path = "path",
                            Reason =
                                Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                        },
                    ],
                },
            },
            ContentUnavailableReason = new BetaComplianceReviewContentNotCaptured(),
            Model = "model",
        };
        string expectedOrganizationID = "organization_id";
        BetaComplianceReviewReadReason expectedReadReason =
            new BetaComplianceReviewSafeguardsReason();
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_review_item");
        string expectedUserProfileID = "user_profile_id";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedContentExpiresAt, model.ContentExpiresAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDetails, model.Details);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedReadReason, model.ReadReason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserProfileID, model.UserProfileID);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewItem
        {
            ID = "id",
            Actor = new BetaComplianceReviewUserActor()
            {
                EmailAddress = "email_address",
                UserID = "user_id",
            },
            ContentExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Details = new BetaComplianceReviewMessageDetails()
            {
                Content = new BetaComplianceReviewCreateMessageContent()
                {
                    Request = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = new()
                    {
                        ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                        Container = new()
                        {
                            ID = "container_011CpZohnwH4vuy7gazohgSP",
                            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::Type.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Content =
                        [
                            new Messages::BetaTextBlock()
                            {
                                Citations = null,
                                Text = "Hi! My name is Claude.",
                            },
                        ],
                        ContextManagement = new(
                            [
                                new Messages::BetaClearToolUses20250919EditResponse()
                                {
                                    ClearedInputTokens = 0,
                                    ClearedToolUses = 0,
                                },
                            ]
                        ),
                        Diagnostics = null,
                        Model = Model.ClaudeOpus5_5,
                        StopDetails = null,
                        StopReason = Messages::BetaStopReason.EndTurn,
                        StopSequence = null,
                        Usage = new()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 2051,
                            CacheReadInputTokens = 2051,
                            FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
                            InferenceGeo = "global",
                            InputTokens = 2095,
                            Iterations =
                            [
                                new Messages::BetaMessageIterationUsage()
                                {
                                    CacheCreation = new()
                                    {
                                        Ephemeral1hInputTokens = 0,
                                        Ephemeral5mInputTokens = 0,
                                    },
                                    CacheCreationInputTokens = 0,
                                    CacheReadInputTokens = 0,
                                    InputTokens = 0,
                                    Model = Model.ClaudeFable5_2,
                                    OutputTokens = 0,
                                },
                            ],
                            OutputTokens = 503,
                            OutputTokensDetails = new(0),
                            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                            ServiceTier = Messages::BetaUsageServiceTier.Standard,
                            Speed = Messages::BetaUsageSpeed.Standard,
                        },
                        InputTransformations =
                        [
                            new Messages::BetaThinkingDroppedInputTransformation()
                            {
                                Path = "path",
                                Reason =
                                    Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                            },
                        ],
                    },
                },
                ContentUnavailableReason = new BetaComplianceReviewContentNotCaptured(),
                Model = "model",
            },
            OrganizationID = "organization_id",
            ReadReason = new BetaComplianceReviewSafeguardsReason(),
            UserProfileID = "user_profile_id",
            WorkspaceID = "workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewItem
        {
            ID = "id",
            Actor = new BetaComplianceReviewUserActor()
            {
                EmailAddress = "email_address",
                UserID = "user_id",
            },
            ContentExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Details = new BetaComplianceReviewMessageDetails()
            {
                Content = new BetaComplianceReviewCreateMessageContent()
                {
                    Request = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = new()
                    {
                        ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                        Container = new()
                        {
                            ID = "container_011CpZohnwH4vuy7gazohgSP",
                            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::Type.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Content =
                        [
                            new Messages::BetaTextBlock()
                            {
                                Citations = null,
                                Text = "Hi! My name is Claude.",
                            },
                        ],
                        ContextManagement = new(
                            [
                                new Messages::BetaClearToolUses20250919EditResponse()
                                {
                                    ClearedInputTokens = 0,
                                    ClearedToolUses = 0,
                                },
                            ]
                        ),
                        Diagnostics = null,
                        Model = Model.ClaudeOpus5_5,
                        StopDetails = null,
                        StopReason = Messages::BetaStopReason.EndTurn,
                        StopSequence = null,
                        Usage = new()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 2051,
                            CacheReadInputTokens = 2051,
                            FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
                            InferenceGeo = "global",
                            InputTokens = 2095,
                            Iterations =
                            [
                                new Messages::BetaMessageIterationUsage()
                                {
                                    CacheCreation = new()
                                    {
                                        Ephemeral1hInputTokens = 0,
                                        Ephemeral5mInputTokens = 0,
                                    },
                                    CacheCreationInputTokens = 0,
                                    CacheReadInputTokens = 0,
                                    InputTokens = 0,
                                    Model = Model.ClaudeFable5_2,
                                    OutputTokens = 0,
                                },
                            ],
                            OutputTokens = 503,
                            OutputTokensDetails = new(0),
                            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                            ServiceTier = Messages::BetaUsageServiceTier.Standard,
                            Speed = Messages::BetaUsageSpeed.Standard,
                        },
                        InputTransformations =
                        [
                            new Messages::BetaThinkingDroppedInputTransformation()
                            {
                                Path = "path",
                                Reason =
                                    Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                            },
                        ],
                    },
                },
                ContentUnavailableReason = new BetaComplianceReviewContentNotCaptured(),
                Model = "model",
            },
            OrganizationID = "organization_id",
            ReadReason = new BetaComplianceReviewSafeguardsReason(),
            UserProfileID = "user_profile_id",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BetaComplianceReviewActor expectedActor = new BetaComplianceReviewUserActor()
        {
            EmailAddress = "email_address",
            UserID = "user_id",
        };
        DateTimeOffset expectedContentExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaComplianceReviewItemDetails expectedDetails = new BetaComplianceReviewMessageDetails()
        {
            Content = new BetaComplianceReviewCreateMessageContent()
            {
                Request = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Response = new()
                {
                    ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                    Container = new()
                    {
                        ID = "container_011CpZohnwH4vuy7gazohgSP",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Skills =
                        [
                            new()
                            {
                                SkillID = "pdf",
                                Type = Messages::Type.Anthropic,
                                Version = "latest",
                            },
                        ],
                    },
                    Content =
                    [
                        new Messages::BetaTextBlock()
                        {
                            Citations = null,
                            Text = "Hi! My name is Claude.",
                        },
                    ],
                    ContextManagement = new(
                        [
                            new Messages::BetaClearToolUses20250919EditResponse()
                            {
                                ClearedInputTokens = 0,
                                ClearedToolUses = 0,
                            },
                        ]
                    ),
                    Diagnostics = null,
                    Model = Model.ClaudeOpus5_5,
                    StopDetails = null,
                    StopReason = Messages::BetaStopReason.EndTurn,
                    StopSequence = null,
                    Usage = new()
                    {
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheCreationInputTokens = 2051,
                        CacheReadInputTokens = 2051,
                        FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
                        InferenceGeo = "global",
                        InputTokens = 2095,
                        Iterations =
                        [
                            new Messages::BetaMessageIterationUsage()
                            {
                                CacheCreation = new()
                                {
                                    Ephemeral1hInputTokens = 0,
                                    Ephemeral5mInputTokens = 0,
                                },
                                CacheCreationInputTokens = 0,
                                CacheReadInputTokens = 0,
                                InputTokens = 0,
                                Model = Model.ClaudeFable5_2,
                                OutputTokens = 0,
                            },
                        ],
                        OutputTokens = 503,
                        OutputTokensDetails = new(0),
                        ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                        ServiceTier = Messages::BetaUsageServiceTier.Standard,
                        Speed = Messages::BetaUsageSpeed.Standard,
                    },
                    InputTransformations =
                    [
                        new Messages::BetaThinkingDroppedInputTransformation()
                        {
                            Path = "path",
                            Reason =
                                Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                        },
                    ],
                },
            },
            ContentUnavailableReason = new BetaComplianceReviewContentNotCaptured(),
            Model = "model",
        };
        string expectedOrganizationID = "organization_id";
        BetaComplianceReviewReadReason expectedReadReason =
            new BetaComplianceReviewSafeguardsReason();
        JsonElement expectedType = JsonSerializer.SerializeToElement("compliance_review_item");
        string expectedUserProfileID = "user_profile_id";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedContentExpiresAt, deserialized.ContentExpiresAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDetails, deserialized.Details);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedReadReason, deserialized.ReadReason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserProfileID, deserialized.UserProfileID);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewItem
        {
            ID = "id",
            Actor = new BetaComplianceReviewUserActor()
            {
                EmailAddress = "email_address",
                UserID = "user_id",
            },
            ContentExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Details = new BetaComplianceReviewMessageDetails()
            {
                Content = new BetaComplianceReviewCreateMessageContent()
                {
                    Request = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = new()
                    {
                        ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                        Container = new()
                        {
                            ID = "container_011CpZohnwH4vuy7gazohgSP",
                            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::Type.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Content =
                        [
                            new Messages::BetaTextBlock()
                            {
                                Citations = null,
                                Text = "Hi! My name is Claude.",
                            },
                        ],
                        ContextManagement = new(
                            [
                                new Messages::BetaClearToolUses20250919EditResponse()
                                {
                                    ClearedInputTokens = 0,
                                    ClearedToolUses = 0,
                                },
                            ]
                        ),
                        Diagnostics = null,
                        Model = Model.ClaudeOpus5_5,
                        StopDetails = null,
                        StopReason = Messages::BetaStopReason.EndTurn,
                        StopSequence = null,
                        Usage = new()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 2051,
                            CacheReadInputTokens = 2051,
                            FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
                            InferenceGeo = "global",
                            InputTokens = 2095,
                            Iterations =
                            [
                                new Messages::BetaMessageIterationUsage()
                                {
                                    CacheCreation = new()
                                    {
                                        Ephemeral1hInputTokens = 0,
                                        Ephemeral5mInputTokens = 0,
                                    },
                                    CacheCreationInputTokens = 0,
                                    CacheReadInputTokens = 0,
                                    InputTokens = 0,
                                    Model = Model.ClaudeFable5_2,
                                    OutputTokens = 0,
                                },
                            ],
                            OutputTokens = 503,
                            OutputTokensDetails = new(0),
                            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                            ServiceTier = Messages::BetaUsageServiceTier.Standard,
                            Speed = Messages::BetaUsageSpeed.Standard,
                        },
                        InputTransformations =
                        [
                            new Messages::BetaThinkingDroppedInputTransformation()
                            {
                                Path = "path",
                                Reason =
                                    Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                            },
                        ],
                    },
                },
                ContentUnavailableReason = new BetaComplianceReviewContentNotCaptured(),
                Model = "model",
            },
            OrganizationID = "organization_id",
            ReadReason = new BetaComplianceReviewSafeguardsReason(),
            UserProfileID = "user_profile_id",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewItem
        {
            ID = "id",
            Actor = new BetaComplianceReviewUserActor()
            {
                EmailAddress = "email_address",
                UserID = "user_id",
            },
            ContentExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Details = new BetaComplianceReviewMessageDetails()
            {
                Content = new BetaComplianceReviewCreateMessageContent()
                {
                    Request = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = new()
                    {
                        ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                        Container = new()
                        {
                            ID = "container_011CpZohnwH4vuy7gazohgSP",
                            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::Type.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Content =
                        [
                            new Messages::BetaTextBlock()
                            {
                                Citations = null,
                                Text = "Hi! My name is Claude.",
                            },
                        ],
                        ContextManagement = new(
                            [
                                new Messages::BetaClearToolUses20250919EditResponse()
                                {
                                    ClearedInputTokens = 0,
                                    ClearedToolUses = 0,
                                },
                            ]
                        ),
                        Diagnostics = null,
                        Model = Model.ClaudeOpus5_5,
                        StopDetails = null,
                        StopReason = Messages::BetaStopReason.EndTurn,
                        StopSequence = null,
                        Usage = new()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 2051,
                            CacheReadInputTokens = 2051,
                            FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
                            InferenceGeo = "global",
                            InputTokens = 2095,
                            Iterations =
                            [
                                new Messages::BetaMessageIterationUsage()
                                {
                                    CacheCreation = new()
                                    {
                                        Ephemeral1hInputTokens = 0,
                                        Ephemeral5mInputTokens = 0,
                                    },
                                    CacheCreationInputTokens = 0,
                                    CacheReadInputTokens = 0,
                                    InputTokens = 0,
                                    Model = Model.ClaudeFable5_2,
                                    OutputTokens = 0,
                                },
                            ],
                            OutputTokens = 503,
                            OutputTokensDetails = new(0),
                            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                            ServiceTier = Messages::BetaUsageServiceTier.Standard,
                            Speed = Messages::BetaUsageSpeed.Standard,
                        },
                        InputTransformations =
                        [
                            new Messages::BetaThinkingDroppedInputTransformation()
                            {
                                Path = "path",
                                Reason =
                                    Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                            },
                        ],
                    },
                },
                ContentUnavailableReason = new BetaComplianceReviewContentNotCaptured(),
                Model = "model",
            },
            OrganizationID = "organization_id",
            ReadReason = new BetaComplianceReviewSafeguardsReason(),
            UserProfileID = "user_profile_id",
            WorkspaceID = "workspace_id",
        };

        BetaComplianceReviewItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
