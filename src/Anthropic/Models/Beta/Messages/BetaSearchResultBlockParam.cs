using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<BetaSearchResultBlockParam, BetaSearchResultBlockParamFromRaw>)
)]
public sealed record class BetaSearchResultBlockParam : ModelBase
{
    public required IReadOnlyList<BetaTextBlockParam> Content
    {
        get { return ModelBase.GetNotNullClass<List<BetaTextBlockParam>>(this.RawData, "content"); }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public required string Source
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "source"); }
        init { ModelBase.Set(this._rawData, "source", value); }
    }

    public required string Title
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "title"); }
        init { ModelBase.Set(this._rawData, "title", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    public BetaCitationsConfigParam? Citations
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCitationsConfigParam>(this.RawData, "citations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "citations", value);
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"search_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Citations?.Validate();
    }

    public BetaSearchResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
    }

    public BetaSearchResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSearchResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaSearchResultBlockParamFromRaw : IFromRaw<BetaSearchResultBlockParam>
{
    /// <inheritdoc/>
    public BetaSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSearchResultBlockParam.FromRawUnchecked(rawData);
}
