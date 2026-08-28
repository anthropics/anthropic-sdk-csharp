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
        BetaComplianceSettingsStateEnabledParam,
        BetaComplianceSettingsStateEnabledParamFromRaw
    >)
)]
public sealed record class BetaComplianceSettingsStateEnabledParam : JsonModel
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

    public BetaComplianceSettingsStateEnabledParam()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceSettingsStateEnabledParam(
        BetaComplianceSettingsStateEnabledParam betaComplianceSettingsStateEnabledParam
    )
        : base(betaComplianceSettingsStateEnabledParam) { }
#pragma warning restore CS8618

    public BetaComplianceSettingsStateEnabledParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceSettingsStateEnabledParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceSettingsStateEnabledParamFromRaw.FromRawUnchecked"/>
    public static BetaComplianceSettingsStateEnabledParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceSettingsStateEnabledParamFromRaw
    : IFromRawJson<BetaComplianceSettingsStateEnabledParam>
{
    /// <inheritdoc/>
    public BetaComplianceSettingsStateEnabledParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceSettingsStateEnabledParam.FromRawUnchecked(rawData);
}
