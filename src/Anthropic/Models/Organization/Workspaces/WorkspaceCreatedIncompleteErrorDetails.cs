using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The Workspace was created, but some of what the request asked for did not take
/// effect, or may not have. Don't send the create again. The error's `message` says
/// what to do with the Workspace at `workspace_id`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspaceCreatedIncompleteErrorDetails,
        WorkspaceCreatedIncompleteErrorDetailsFromRaw
    >)
)]
public sealed record class WorkspaceCreatedIncompleteErrorDetails : JsonModel
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

    /// <summary>
    /// ID of the Workspace the request created.
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("workspace_created_incomplete")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public WorkspaceCreatedIncompleteErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_created_incomplete");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceCreatedIncompleteErrorDetails(
        WorkspaceCreatedIncompleteErrorDetails workspaceCreatedIncompleteErrorDetails
    )
        : base(workspaceCreatedIncompleteErrorDetails) { }
#pragma warning restore CS8618

    public WorkspaceCreatedIncompleteErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_created_incomplete");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceCreatedIncompleteErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceCreatedIncompleteErrorDetailsFromRaw.FromRawUnchecked"/>
    public static WorkspaceCreatedIncompleteErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WorkspaceCreatedIncompleteErrorDetails(string workspaceID)
        : this()
    {
        this.WorkspaceID = workspaceID;
    }
}

class WorkspaceCreatedIncompleteErrorDetailsFromRaw
    : IFromRawJson<WorkspaceCreatedIncompleteErrorDetails>
{
    /// <inheritdoc/>
    public WorkspaceCreatedIncompleteErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspaceCreatedIncompleteErrorDetails.FromRawUnchecked(rawData);
}
