using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request's Workspace has Human Review turned off, and this operation is not
/// available there. Use a Workspace with Human Review on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspaceHumanReviewDisabledErrorDetails,
        WorkspaceHumanReviewDisabledErrorDetailsFromRaw
    >)
)]
public sealed record class WorkspaceHumanReviewDisabledErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("workspace_human_review_disabled")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WorkspaceHumanReviewDisabledErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_human_review_disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceHumanReviewDisabledErrorDetails(
        WorkspaceHumanReviewDisabledErrorDetails workspaceHumanReviewDisabledErrorDetails
    )
        : base(workspaceHumanReviewDisabledErrorDetails) { }
#pragma warning restore CS8618

    public WorkspaceHumanReviewDisabledErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_human_review_disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceHumanReviewDisabledErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceHumanReviewDisabledErrorDetailsFromRaw.FromRawUnchecked"/>
    public static WorkspaceHumanReviewDisabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceHumanReviewDisabledErrorDetailsFromRaw
    : IFromRawJson<WorkspaceHumanReviewDisabledErrorDetails>
{
    /// <inheritdoc/>
    public WorkspaceHumanReviewDisabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspaceHumanReviewDisabledErrorDetails.FromRawUnchecked(rawData);
}
