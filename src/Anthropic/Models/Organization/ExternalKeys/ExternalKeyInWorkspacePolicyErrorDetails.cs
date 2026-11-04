using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

/// <summary>
/// The External Key can't be deleted or reconfigured while the organization's Workspace
/// Policy lists it as an allowed key.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExternalKeyInWorkspacePolicyErrorDetails,
        ExternalKeyInWorkspacePolicyErrorDetailsFromRaw
    >)
)]
public sealed record class ExternalKeyInWorkspacePolicyErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("external_key_in_workspace_policy")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ExternalKeyInWorkspacePolicyErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_in_workspace_policy");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyInWorkspacePolicyErrorDetails(
        ExternalKeyInWorkspacePolicyErrorDetails externalKeyInWorkspacePolicyErrorDetails
    )
        : base(externalKeyInWorkspacePolicyErrorDetails) { }
#pragma warning restore CS8618

    public ExternalKeyInWorkspacePolicyErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_in_workspace_policy");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKeyInWorkspacePolicyErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyInWorkspacePolicyErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ExternalKeyInWorkspacePolicyErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalKeyInWorkspacePolicyErrorDetailsFromRaw
    : IFromRawJson<ExternalKeyInWorkspacePolicyErrorDetails>
{
    /// <inheritdoc/>
    public ExternalKeyInWorkspacePolicyErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalKeyInWorkspacePolicyErrorDetails.FromRawUnchecked(rawData);
}
