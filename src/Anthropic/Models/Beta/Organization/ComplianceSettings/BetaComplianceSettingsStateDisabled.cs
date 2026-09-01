using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ComplianceSettings;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceSettingsStateDisabled,
        BetaComplianceSettingsStateDisabledFromRaw
    >)
)]
public sealed record class BetaComplianceSettingsStateDisabled : JsonModel
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

    public BetaComplianceSettingsStateDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceSettingsStateDisabled(
        BetaComplianceSettingsStateDisabled betaComplianceSettingsStateDisabled
    )
        : base(betaComplianceSettingsStateDisabled) { }
#pragma warning restore CS8618

    public BetaComplianceSettingsStateDisabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceSettingsStateDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceSettingsStateDisabledFromRaw.FromRawUnchecked"/>
    public static BetaComplianceSettingsStateDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceSettingsStateDisabledFromRaw : IFromRawJson<BetaComplianceSettingsStateDisabled>
{
    /// <inheritdoc/>
    public BetaComplianceSettingsStateDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceSettingsStateDisabled.FromRawUnchecked(rawData);
}
