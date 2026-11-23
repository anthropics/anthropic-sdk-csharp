using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The External Storage can't be deleted while an Enterprise Frontier Safeguards
/// workspace policy lists it as allowed storage.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaExternalStorageInWorkspacePolicyErrorDetails,
        BetaExternalStorageInWorkspacePolicyErrorDetailsFromRaw
    >)
)]
public sealed record class BetaExternalStorageInWorkspacePolicyErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("external_storage_in_workspace_policy")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaExternalStorageInWorkspacePolicyErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("external_storage_in_workspace_policy");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalStorageInWorkspacePolicyErrorDetails(
        BetaExternalStorageInWorkspacePolicyErrorDetails betaExternalStorageInWorkspacePolicyErrorDetails
    )
        : base(betaExternalStorageInWorkspacePolicyErrorDetails) { }
#pragma warning restore CS8618

    public BetaExternalStorageInWorkspacePolicyErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("external_storage_in_workspace_policy");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalStorageInWorkspacePolicyErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalStorageInWorkspacePolicyErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaExternalStorageInWorkspacePolicyErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalStorageInWorkspacePolicyErrorDetailsFromRaw
    : IFromRawJson<BetaExternalStorageInWorkspacePolicyErrorDetails>
{
    /// <inheritdoc/>
    public BetaExternalStorageInWorkspacePolicyErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaExternalStorageInWorkspacePolicyErrorDetails.FromRawUnchecked(rawData);
}
