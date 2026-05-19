using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Request params for `self_hosted` environment configuration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaSelfHostedConfigParams, BetaSelfHostedConfigParamsFromRaw>)
)]
public sealed record class BetaSelfHostedConfigParams : JsonModel
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

    public BetaSelfHostedConfigParams()
    {
        this.Type = JsonSerializer.SerializeToElement("self_hosted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSelfHostedConfigParams(BetaSelfHostedConfigParams betaSelfHostedConfigParams)
        : base(betaSelfHostedConfigParams) { }
#pragma warning restore CS8618

    public BetaSelfHostedConfigParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("self_hosted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSelfHostedConfigParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSelfHostedConfigParamsFromRaw.FromRawUnchecked"/>
    public static BetaSelfHostedConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSelfHostedConfigParamsFromRaw : IFromRawJson<BetaSelfHostedConfigParams>
{
    /// <inheritdoc/>
    public BetaSelfHostedConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSelfHostedConfigParams.FromRawUnchecked(rawData);
}
