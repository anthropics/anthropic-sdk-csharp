using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// This RBAC Group has no Claude Code managed settings.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaRbacGroupManagedSettingsNotFoundErrorDetails,
        BetaRbacGroupManagedSettingsNotFoundErrorDetailsFromRaw
    >)
)]
public sealed record class BetaRbacGroupManagedSettingsNotFoundErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("rbac_group_managed_settings_not_found")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRbacGroupManagedSettingsNotFoundErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_managed_settings_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacGroupManagedSettingsNotFoundErrorDetails(
        BetaRbacGroupManagedSettingsNotFoundErrorDetails betaRbacGroupManagedSettingsNotFoundErrorDetails
    )
        : base(betaRbacGroupManagedSettingsNotFoundErrorDetails) { }
#pragma warning restore CS8618

    public BetaRbacGroupManagedSettingsNotFoundErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_managed_settings_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacGroupManagedSettingsNotFoundErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacGroupManagedSettingsNotFoundErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaRbacGroupManagedSettingsNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacGroupManagedSettingsNotFoundErrorDetailsFromRaw
    : IFromRawJson<BetaRbacGroupManagedSettingsNotFoundErrorDetails>
{
    /// <inheritdoc/>
    public BetaRbacGroupManagedSettingsNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRbacGroupManagedSettingsNotFoundErrorDetails.FromRawUnchecked(rawData);
}
