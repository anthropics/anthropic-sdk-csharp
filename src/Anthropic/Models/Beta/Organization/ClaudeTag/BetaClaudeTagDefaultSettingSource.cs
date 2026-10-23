using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// No settings level sets a value, and the built-in default applies.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagDefaultSettingSource,
        BetaClaudeTagDefaultSettingSourceFromRaw
    >)
)]
public sealed record class BetaClaudeTagDefaultSettingSource : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("default")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagDefaultSettingSource()
    {
        this.Type = JsonSerializer.SerializeToElement("default");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagDefaultSettingSource(
        BetaClaudeTagDefaultSettingSource betaClaudeTagDefaultSettingSource
    )
        : base(betaClaudeTagDefaultSettingSource) { }
#pragma warning restore CS8618

    public BetaClaudeTagDefaultSettingSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("default");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagDefaultSettingSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagDefaultSettingSourceFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagDefaultSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagDefaultSettingSourceFromRaw : IFromRawJson<BetaClaudeTagDefaultSettingSource>
{
    /// <inheritdoc/>
    public BetaClaudeTagDefaultSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagDefaultSettingSource.FromRawUnchecked(rawData);
}
