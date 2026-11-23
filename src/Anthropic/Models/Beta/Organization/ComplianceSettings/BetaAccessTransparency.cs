using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.ComplianceSettings;

/// <summary>
/// Whether Access Transparency is on. Read-only.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaAccessTransparency, BetaAccessTransparencyFromRaw>))]
public sealed record class BetaAccessTransparency : JsonModel
{
    public required ApiEnum<
        string,
        global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaAccessTransparency() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAccessTransparency(BetaAccessTransparency betaAccessTransparency)
        : base(betaAccessTransparency) { }
#pragma warning restore CS8618

    public BetaAccessTransparency(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAccessTransparency(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAccessTransparencyFromRaw.FromRawUnchecked"/>
    public static BetaAccessTransparency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAccessTransparency(
        ApiEnum<string, global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaAccessTransparencyFromRaw : IFromRawJson<BetaAccessTransparency>
{
    /// <inheritdoc/>
    public BetaAccessTransparency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAccessTransparency.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class TypeConverter
    : JsonConverter<global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type>
{
    public override global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => global::Anthropic
                .Models
                .Beta
                .Organization
                .ComplianceSettings
                .Type
                .Disabled,
            "enabled" => global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type.Enabled,
            _ => (global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type.Disabled =>
                    "disabled",
                global::Anthropic.Models.Beta.Organization.ComplianceSettings.Type.Enabled =>
                    "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
