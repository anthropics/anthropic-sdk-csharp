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
        ComplianceSettingsStateDisabledParam,
        ComplianceSettingsStateDisabledParamFromRaw
    >)
)]
public sealed record class ComplianceSettingsStateDisabledParam : JsonModel
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

    public ComplianceSettingsStateDisabledParam()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComplianceSettingsStateDisabledParam(
        ComplianceSettingsStateDisabledParam complianceSettingsStateDisabledParam
    )
        : base(complianceSettingsStateDisabledParam) { }
#pragma warning restore CS8618

    public ComplianceSettingsStateDisabledParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComplianceSettingsStateDisabledParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComplianceSettingsStateDisabledParamFromRaw.FromRawUnchecked"/>
    public static ComplianceSettingsStateDisabledParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComplianceSettingsStateDisabledParamFromRaw
    : IFromRawJson<ComplianceSettingsStateDisabledParam>
{
    /// <inheritdoc/>
    public ComplianceSettingsStateDisabledParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComplianceSettingsStateDisabledParam.FromRawUnchecked(rawData);
}
