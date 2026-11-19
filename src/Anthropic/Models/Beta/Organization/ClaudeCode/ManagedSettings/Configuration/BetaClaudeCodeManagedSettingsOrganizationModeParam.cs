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
        BetaClaudeCodeManagedSettingsOrganizationModeParam,
        BetaClaudeCodeManagedSettingsOrganizationModeParamFromRaw
    >)
)]
public sealed record class BetaClaudeCodeManagedSettingsOrganizationModeParam : JsonModel
{
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

    public BetaClaudeCodeManagedSettingsOrganizationModeParam()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeManagedSettingsOrganizationModeParam(
        BetaClaudeCodeManagedSettingsOrganizationModeParam betaClaudeCodeManagedSettingsOrganizationModeParam
    )
        : base(betaClaudeCodeManagedSettingsOrganizationModeParam) { }
#pragma warning restore CS8618

    public BetaClaudeCodeManagedSettingsOrganizationModeParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeManagedSettingsOrganizationModeParam(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeManagedSettingsOrganizationModeParamFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeManagedSettingsOrganizationModeParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeManagedSettingsOrganizationModeParamFromRaw
    : IFromRawJson<BetaClaudeCodeManagedSettingsOrganizationModeParam>
{
    /// <inheritdoc/>
    public BetaClaudeCodeManagedSettingsOrganizationModeParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeManagedSettingsOrganizationModeParam.FromRawUnchecked(rawData);
}
