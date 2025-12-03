using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<Base64PDFSource, Base64PDFSourceFromRaw>))]
public sealed record class Base64PDFSource : ModelBase
{
    public required string Data
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public JsonElement MediaType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "media_type"); }
        init { ModelBase.Set(this._rawData, "media_type", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        if (
            !JsonElement.DeepEquals(
                this.MediaType,
                JsonSerializer.Deserialize<JsonElement>("\"application/pdf\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"base64\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public Base64PDFSource()
    {
        this.MediaType = JsonSerializer.Deserialize<JsonElement>("\"application/pdf\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"base64\"");
    }

    public Base64PDFSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.MediaType = JsonSerializer.Deserialize<JsonElement>("\"application/pdf\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"base64\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Base64PDFSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Base64PDFSourceFromRaw.FromRawUnchecked"/>
    public static Base64PDFSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Base64PDFSource(string data)
        : this()
    {
        this.Data = data;
    }
}

class Base64PDFSourceFromRaw : IFromRaw<Base64PDFSource>
{
    /// <inheritdoc/>
    public Base64PDFSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Base64PDFSource.FromRawUnchecked(rawData);
}
