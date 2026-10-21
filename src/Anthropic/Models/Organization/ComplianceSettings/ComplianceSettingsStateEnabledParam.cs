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
        ComplianceSettingsStateEnabledParam,
        ComplianceSettingsStateEnabledParamFromRaw
    >)
)]
public sealed record class ComplianceSettingsStateEnabledParam : JsonModel
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

    public ComplianceSettingsStateEnabledParam()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceSettingsStateEnabledParam(
        ComplianceSettingsStateEnabledParam complianceSettingsStateEnabledParam
    )
        : base(complianceSettingsStateEnabledParam) { }
#pragma warning restore CS8618

    public ComplianceSettingsStateEnabledParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceSettingsStateEnabledParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceSettingsStateEnabledParamFromRaw.FromRawUnchecked"/>
    public static ComplianceSettingsStateEnabledParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceSettingsStateEnabledParamFromRaw : IFromRawJson<ComplianceSettingsStateEnabledParam>
{
    /// <inheritdoc/>
    public ComplianceSettingsStateEnabledParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComplianceSettingsStateEnabledParam.FromRawUnchecked(rawData);
}
