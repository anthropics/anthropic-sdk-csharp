using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ComplianceSettings;

[JsonConverter(typeof(JsonModelConverter<BetaComplianceSettings, BetaComplianceSettingsFromRaw>))]
public sealed record class BetaComplianceSettings : JsonModel
{
    /// <summary>
    /// Whether the Compliance API is enabled for this organization.
    /// </summary>
    public required BetaComplianceSettingsState State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaComplianceSettingsState>("state");
        }
        init { this._rawData.Set("state", value); }
    }

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
        this.State.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("compliance_settings")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceSettings()
    {
        this.Type = JsonSerializer.SerializeToElement("compliance_settings");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceSettings(BetaComplianceSettings betaComplianceSettings)
        : base(betaComplianceSettings) { }
#pragma warning restore CS8618

    public BetaComplianceSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compliance_settings");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceSettingsFromRaw.FromRawUnchecked"/>
    public static BetaComplianceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComplianceSettings(BetaComplianceSettingsState state)
        : this()
    {
        this.State = state;
    }
}

class BetaComplianceSettingsFromRaw : IFromRawJson<BetaComplianceSettings>
{
    /// <inheritdoc/>
    public BetaComplianceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceSettings.FromRawUnchecked(rawData);
}
