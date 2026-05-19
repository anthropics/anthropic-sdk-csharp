using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Configuration for self-hosted environments.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaSelfHostedConfig, BetaSelfHostedConfigFromRaw>))]
public sealed record class BetaSelfHostedConfig : JsonModel
{
    /// <summary>
    /// Environment type
    /// </summary>
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("self_hosted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSelfHostedConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("self_hosted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSelfHostedConfig(BetaSelfHostedConfig betaSelfHostedConfig)
        : base(betaSelfHostedConfig) { }
#pragma warning restore CS8618

    public BetaSelfHostedConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("self_hosted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSelfHostedConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSelfHostedConfigFromRaw.FromRawUnchecked"/>
    public static BetaSelfHostedConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSelfHostedConfigFromRaw : IFromRawJson<BetaSelfHostedConfig>
{
    /// <inheritdoc/>
    public BetaSelfHostedConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSelfHostedConfig.FromRawUnchecked(rawData);
}
