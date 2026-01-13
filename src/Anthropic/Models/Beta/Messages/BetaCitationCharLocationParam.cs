using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaCitationCharLocationParam, BetaCitationCharLocationParamFromRaw>)
)]
public sealed record class BetaCitationCharLocationParam : JsonModel
{
    public required string CitedText
    {
        get { return this._rawData.GetNotNullClass<string>("cited_text"); }
        init { this._rawData.Set("cited_text", value); }
    }

    public required long DocumentIndex
    {
        get { return this._rawData.GetNotNullStruct<long>("document_index"); }
        init { this._rawData.Set("document_index", value); }
    }

    public required string? DocumentTitle
    {
        get { return this._rawData.GetNullableClass<string>("document_title"); }
        init { this._rawData.Set("document_title", value); }
    }

    public required long EndCharIndex
    {
        get { return this._rawData.GetNotNullStruct<long>("end_char_index"); }
        init { this._rawData.Set("end_char_index", value); }
    }

    public required long StartCharIndex
    {
        get { return this._rawData.GetNotNullStruct<long>("start_char_index"); }
        init { this._rawData.Set("start_char_index", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.DocumentIndex;
        _ = this.DocumentTitle;
        _ = this.EndCharIndex;
        _ = this.StartCharIndex;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"char_location\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCitationCharLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");
    }

    public BetaCitationCharLocationParam(
        BetaCitationCharLocationParam betaCitationCharLocationParam
    )
        : base(betaCitationCharLocationParam) { }

    public BetaCitationCharLocationParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationCharLocationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationCharLocationParamFromRaw.FromRawUnchecked"/>
    public static BetaCitationCharLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationCharLocationParamFromRaw : IFromRawJson<BetaCitationCharLocationParam>
{
    /// <inheritdoc/>
    public BetaCitationCharLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationCharLocationParam.FromRawUnchecked(rawData);
}
