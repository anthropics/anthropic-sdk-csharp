using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaSearchResultBlockParam, BetaSearchResultBlockParamFromRaw>)
)]
public sealed record class BetaSearchResultBlockParam : JsonModel
{
    public required IReadOnlyList<BetaTextBlockParam> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaTextBlockParam>>("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaTextBlockParam>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    public BetaCitationsConfigParam? Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCitationsConfigParam>("citations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("citations", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.Source;
        _ = this.Title;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("search_result")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Citations?.Validate();
    }

    public BetaSearchResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("search_result");
    }

    public BetaSearchResultBlockParam(BetaSearchResultBlockParam betaSearchResultBlockParam)
        : base(betaSearchResultBlockParam) { }

    public BetaSearchResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSearchResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSearchResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSearchResultBlockParamFromRaw : IFromRawJson<BetaSearchResultBlockParam>
{
    /// <inheritdoc/>
    public BetaSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSearchResultBlockParam.FromRawUnchecked(rawData);
}
