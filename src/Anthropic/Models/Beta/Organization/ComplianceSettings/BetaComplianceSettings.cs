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

    /// <summary>
    /// Read-only. Whether Access Transparency is on for the organization. Returned
    /// only when the request sends the `anthropic-beta: efs-2026-10-01` header and
    /// Access Transparency is available to the organization; otherwise omitted. If
    /// the status can't be read, getting Compliance Settings returns an error; an
    /// update still saves, but then reports `disabled` whatever the real status,
    /// so get the settings again to check it.
    /// </summary>
    public BetaAccessTransparency? AccessTransparency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaAccessTransparency>("access_transparency");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("access_transparency");
                return;
            }

            this._rawData.Set("access_transparency", value);
        }
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
        this.AccessTransparency?.Validate();
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
