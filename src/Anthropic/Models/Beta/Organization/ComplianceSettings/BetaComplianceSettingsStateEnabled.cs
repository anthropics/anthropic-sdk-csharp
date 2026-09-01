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
        BetaComplianceSettingsStateEnabled,
        BetaComplianceSettingsStateEnabledFromRaw
    >)
)]
public sealed record class BetaComplianceSettingsStateEnabled : JsonModel
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

    public BetaComplianceSettingsStateEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceSettingsStateEnabled(
        BetaComplianceSettingsStateEnabled betaComplianceSettingsStateEnabled
    )
        : base(betaComplianceSettingsStateEnabled) { }
#pragma warning restore CS8618

    public BetaComplianceSettingsStateEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceSettingsStateEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceSettingsStateEnabledFromRaw.FromRawUnchecked"/>
    public static BetaComplianceSettingsStateEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceSettingsStateEnabledFromRaw : IFromRawJson<BetaComplianceSettingsStateEnabled>
{
    /// <inheritdoc/>
    public BetaComplianceSettingsStateEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceSettingsStateEnabled.FromRawUnchecked(rawData);
}
