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
        ComplianceSettingsStateDisabled,
        ComplianceSettingsStateDisabledFromRaw
    >)
)]
public sealed record class ComplianceSettingsStateDisabled : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("disabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ComplianceSettingsStateDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceSettingsStateDisabled(
        ComplianceSettingsStateDisabled complianceSettingsStateDisabled
    )
        : base(complianceSettingsStateDisabled) { }
#pragma warning restore CS8618

    public ComplianceSettingsStateDisabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceSettingsStateDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceSettingsStateDisabledFromRaw.FromRawUnchecked"/>
    public static ComplianceSettingsStateDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceSettingsStateDisabledFromRaw : IFromRawJson<ComplianceSettingsStateDisabled>
{
    /// <inheritdoc/>
    public ComplianceSettingsStateDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComplianceSettingsStateDisabled.FromRawUnchecked(rawData);
}
