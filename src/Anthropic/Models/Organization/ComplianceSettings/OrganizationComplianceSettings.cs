using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ComplianceSettings;

[JsonConverter(
    typeof(JsonModelConverter<
        OrganizationComplianceSettings,
        OrganizationComplianceSettingsFromRaw
    >)
)]
public sealed record class OrganizationComplianceSettings : JsonModel
{
    /// <summary>
    /// Whether the Compliance API is enabled for this organization.
    /// </summary>
    public required ComplianceSettingsState State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ComplianceSettingsState>("state");
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

    public OrganizationComplianceSettings()
    {
        this.Type = JsonSerializer.SerializeToElement("compliance_settings");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationComplianceSettings(
        OrganizationComplianceSettings organizationComplianceSettings
    )
        : base(organizationComplianceSettings) { }
#pragma warning restore CS8618

    public OrganizationComplianceSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compliance_settings");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationComplianceSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationComplianceSettingsFromRaw.FromRawUnchecked"/>
    public static OrganizationComplianceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OrganizationComplianceSettings(ComplianceSettingsState state)
        : this()
    {
        this.State = state;
    }
}

class OrganizationComplianceSettingsFromRaw : IFromRawJson<OrganizationComplianceSettings>
{
    /// <inheritdoc/>
    public OrganizationComplianceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationComplianceSettings.FromRawUnchecked(rawData);
}
