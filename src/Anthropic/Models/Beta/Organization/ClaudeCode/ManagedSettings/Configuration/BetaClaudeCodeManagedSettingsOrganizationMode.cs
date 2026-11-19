using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeCodeManagedSettingsOrganizationMode,
        BetaClaudeCodeManagedSettingsOrganizationModeFromRaw
    >)
)]
public sealed record class BetaClaudeCodeManagedSettingsOrganizationMode : JsonModel
{
    /// <summary>
    /// Always `organization`.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("organization")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeCodeManagedSettingsOrganizationMode()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeManagedSettingsOrganizationMode(
        BetaClaudeCodeManagedSettingsOrganizationMode betaClaudeCodeManagedSettingsOrganizationMode
    )
        : base(betaClaudeCodeManagedSettingsOrganizationMode) { }
#pragma warning restore CS8618

    public BetaClaudeCodeManagedSettingsOrganizationMode(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeManagedSettingsOrganizationMode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeManagedSettingsOrganizationModeFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeManagedSettingsOrganizationMode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeManagedSettingsOrganizationModeFromRaw
    : IFromRawJson<BetaClaudeCodeManagedSettingsOrganizationMode>
{
    /// <inheritdoc/>
    public BetaClaudeCodeManagedSettingsOrganizationMode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeManagedSettingsOrganizationMode.FromRawUnchecked(rawData);
}
