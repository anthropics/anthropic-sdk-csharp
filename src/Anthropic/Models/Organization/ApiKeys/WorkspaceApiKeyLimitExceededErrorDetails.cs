using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ApiKeys;

/// <summary>
/// The workspace has reached its limit of active API keys.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspaceApiKeyLimitExceededErrorDetails,
        WorkspaceApiKeyLimitExceededErrorDetailsFromRaw
    >)
)]
public sealed record class WorkspaceApiKeyLimitExceededErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("workspace_api_key_limit_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WorkspaceApiKeyLimitExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_api_key_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceApiKeyLimitExceededErrorDetails(
        WorkspaceApiKeyLimitExceededErrorDetails workspaceApiKeyLimitExceededErrorDetails
    )
        : base(workspaceApiKeyLimitExceededErrorDetails) { }
#pragma warning restore CS8618

    public WorkspaceApiKeyLimitExceededErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_api_key_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceApiKeyLimitExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceApiKeyLimitExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static WorkspaceApiKeyLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceApiKeyLimitExceededErrorDetailsFromRaw
    : IFromRawJson<WorkspaceApiKeyLimitExceededErrorDetails>
{
    /// <inheritdoc/>
    public WorkspaceApiKeyLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspaceApiKeyLimitExceededErrorDetails.FromRawUnchecked(rawData);
}
