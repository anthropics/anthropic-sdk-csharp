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
        ComplianceSettingsStateEnabled,
        ComplianceSettingsStateEnabledFromRaw
    >)
)]
public sealed record class ComplianceSettingsStateEnabled : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ComplianceSettingsStateEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceSettingsStateEnabled(
        ComplianceSettingsStateEnabled complianceSettingsStateEnabled
    )
        : base(complianceSettingsStateEnabled) { }
#pragma warning restore CS8618

    public ComplianceSettingsStateEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceSettingsStateEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceSettingsStateEnabledFromRaw.FromRawUnchecked"/>
    public static ComplianceSettingsStateEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceSettingsStateEnabledFromRaw : IFromRawJson<ComplianceSettingsStateEnabled>
{
    /// <inheritdoc/>
    public ComplianceSettingsStateEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComplianceSettingsStateEnabled.FromRawUnchecked(rawData);
}
