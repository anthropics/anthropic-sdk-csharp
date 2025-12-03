using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaCitationWebSearchResultLocationParam,
        BetaCitationWebSearchResultLocationParamFromRaw
    >)
)]
public sealed record class BetaCitationWebSearchResultLocationParam : ModelBase
{
    public required string CitedText
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "cited_text"); }
        init { ModelBase.Set(this._rawData, "cited_text", value); }
    }

    public required string EncryptedIndex
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "encrypted_index"); }
        init { ModelBase.Set(this._rawData, "encrypted_index", value); }
    }

    public required string? Title
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "title"); }
        init { ModelBase.Set(this._rawData, "title", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.EncryptedIndex;
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_search_result_location\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.URL;
    }

    public BetaCitationWebSearchResultLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result_location\"");
    }

    public BetaCitationWebSearchResultLocationParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationWebSearchResultLocationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationWebSearchResultLocationParamFromRaw.FromRawUnchecked"/>
    public static BetaCitationWebSearchResultLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationWebSearchResultLocationParamFromRaw
    : IFromRaw<BetaCitationWebSearchResultLocationParam>
{
    /// <inheritdoc/>
    public BetaCitationWebSearchResultLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationWebSearchResultLocationParam.FromRawUnchecked(rawData);
}
