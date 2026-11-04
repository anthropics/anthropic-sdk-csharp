using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The workspace has reached the member limit that Anthropic set for it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspaceMemberLimitExceededErrorDetails,
        WorkspaceMemberLimitExceededErrorDetailsFromRaw
    >)
)]
public sealed record class WorkspaceMemberLimitExceededErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("workspace_member_limit_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WorkspaceMemberLimitExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_member_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceMemberLimitExceededErrorDetails(
        WorkspaceMemberLimitExceededErrorDetails workspaceMemberLimitExceededErrorDetails
    )
        : base(workspaceMemberLimitExceededErrorDetails) { }
#pragma warning restore CS8618

    public WorkspaceMemberLimitExceededErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_member_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceMemberLimitExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceMemberLimitExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static WorkspaceMemberLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceMemberLimitExceededErrorDetailsFromRaw
    : IFromRawJson<WorkspaceMemberLimitExceededErrorDetails>
{
    /// <inheritdoc/>
    public WorkspaceMemberLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspaceMemberLimitExceededErrorDetails.FromRawUnchecked(rawData);
}
