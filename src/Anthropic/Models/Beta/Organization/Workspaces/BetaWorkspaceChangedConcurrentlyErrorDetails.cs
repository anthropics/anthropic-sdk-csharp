using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// Another request changed the Workspace, so this request left the setting named
/// in `field` as it is. The error's `message` says which of this request's other
/// changes are in place. Read the Workspace and send the request again if you still
/// want the change.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaWorkspaceChangedConcurrentlyErrorDetails,
        BetaWorkspaceChangedConcurrentlyErrorDetailsFromRaw
    >)
)]
public sealed record class BetaWorkspaceChangedConcurrentlyErrorDetails : JsonModel
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
    /// The request field whose change was refused. Other values may be returned.
    /// The value is a name with no data of its own.
    /// </summary>
    public required ApiEnum<string, BetaWorkspaceChangedConcurrentlyField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaWorkspaceChangedConcurrentlyField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("workspace_changed_concurrently")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Field.Validate();
    }

    public BetaWorkspaceChangedConcurrentlyErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_changed_concurrently");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkspaceChangedConcurrentlyErrorDetails(
        BetaWorkspaceChangedConcurrentlyErrorDetails betaWorkspaceChangedConcurrentlyErrorDetails
    )
        : base(betaWorkspaceChangedConcurrentlyErrorDetails) { }
#pragma warning restore CS8618

    public BetaWorkspaceChangedConcurrentlyErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("workspace_changed_concurrently");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkspaceChangedConcurrentlyErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceChangedConcurrentlyErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaWorkspaceChangedConcurrentlyErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaWorkspaceChangedConcurrentlyErrorDetails(
        ApiEnum<string, BetaWorkspaceChangedConcurrentlyField> field
    )
        : this()
    {
        this.Field = field;
    }
}

class BetaWorkspaceChangedConcurrentlyErrorDetailsFromRaw
    : IFromRawJson<BetaWorkspaceChangedConcurrentlyErrorDetails>
{
    /// <inheritdoc/>
    public BetaWorkspaceChangedConcurrentlyErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWorkspaceChangedConcurrentlyErrorDetails.FromRawUnchecked(rawData);
}
