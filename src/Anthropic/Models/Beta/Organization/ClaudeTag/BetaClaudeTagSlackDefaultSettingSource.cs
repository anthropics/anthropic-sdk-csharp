using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The value comes from the organization's Slack defaults, which have no identifier.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackDefaultSettingSource,
        BetaClaudeTagSlackDefaultSettingSourceFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackDefaultSettingSource : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("slack_default")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagSlackDefaultSettingSource()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_default");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackDefaultSettingSource(
        BetaClaudeTagSlackDefaultSettingSource betaClaudeTagSlackDefaultSettingSource
    )
        : base(betaClaudeTagSlackDefaultSettingSource) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackDefaultSettingSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_default");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackDefaultSettingSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackDefaultSettingSourceFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackDefaultSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagSlackDefaultSettingSourceFromRaw
    : IFromRawJson<BetaClaudeTagSlackDefaultSettingSource>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackDefaultSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackDefaultSettingSource.FromRawUnchecked(rawData);
}
