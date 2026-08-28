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
        BetaComplianceSettingsStateDisabledParam,
        BetaComplianceSettingsStateDisabledParamFromRaw
    >)
)]
public sealed record class BetaComplianceSettingsStateDisabledParam : JsonModel
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

    public BetaComplianceSettingsStateDisabledParam()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceSettingsStateDisabledParam(
        BetaComplianceSettingsStateDisabledParam betaComplianceSettingsStateDisabledParam
    )
        : base(betaComplianceSettingsStateDisabledParam) { }
#pragma warning restore CS8618

    public BetaComplianceSettingsStateDisabledParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceSettingsStateDisabledParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceSettingsStateDisabledParamFromRaw.FromRawUnchecked"/>
    public static BetaComplianceSettingsStateDisabledParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceSettingsStateDisabledParamFromRaw
    : IFromRawJson<BetaComplianceSettingsStateDisabledParam>
{
    /// <inheritdoc/>
    public BetaComplianceSettingsStateDisabledParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceSettingsStateDisabledParam.FromRawUnchecked(rawData);
}
