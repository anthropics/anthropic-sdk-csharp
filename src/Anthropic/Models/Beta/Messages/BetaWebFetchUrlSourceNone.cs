using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The ``url_sources`` variant under which a source contributes nothing: no result
/// of the tool filter's source, or no user input.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaWebFetchUrlSourceNone, BetaWebFetchUrlSourceNoneFromRaw>)
)]
public sealed record class BetaWebFetchUrlSourceNone : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("none")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebFetchUrlSourceNone()
    {
        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchUrlSourceNone(BetaWebFetchUrlSourceNone betaWebFetchUrlSourceNone)
        : base(betaWebFetchUrlSourceNone) { }
#pragma warning restore CS8618

    public BetaWebFetchUrlSourceNone(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchUrlSourceNone(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchUrlSourceNoneFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchUrlSourceNone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchUrlSourceNoneFromRaw : IFromRawJson<BetaWebFetchUrlSourceNone>
{
    /// <inheritdoc/>
    public BetaWebFetchUrlSourceNone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchUrlSourceNone.FromRawUnchecked(rawData);
}
