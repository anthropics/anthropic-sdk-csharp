using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Identifies one hop of a fallback transition.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaFallbackInfo, BetaFallbackInfoFromRaw>))]
public sealed record class BetaFallbackInfo : JsonModel
{
    /// <summary>
    /// The model that will complete your prompt.
    ///
    /// <para>See [models](https://docs.anthropic.com/en/docs/models-overview) for
    /// additional details and options.</para>
    /// </summary>
    public required ApiEnum<string, Model> Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Model>>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Model.Raw();
    }

    public BetaFallbackInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackInfo(BetaFallbackInfo betaFallbackInfo)
        : base(betaFallbackInfo) { }
#pragma warning restore CS8618

    public BetaFallbackInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackInfoFromRaw.FromRawUnchecked"/>
    public static BetaFallbackInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaFallbackInfo(ApiEnum<string, Model> model)
        : this()
    {
        this.Model = model;
    }
}

class BetaFallbackInfoFromRaw : IFromRawJson<BetaFallbackInfo>
{
    /// <inheritdoc/>
    public BetaFallbackInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaFallbackInfo.FromRawUnchecked(rawData);
}
