using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The ``url_sources`` variant under which a source contributes in full: every result
/// of the tool filter's source, or all user input.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebFetchUrlSourceAll, WebFetchUrlSourceAllFromRaw>))]
public sealed record class WebFetchUrlSourceAll : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("all")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WebFetchUrlSourceAll()
    {
        this.Type = JsonSerializer.SerializeToElement("all");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebFetchUrlSourceAll(WebFetchUrlSourceAll webFetchUrlSourceAll)
        : base(webFetchUrlSourceAll) { }
#pragma warning restore CS8618

    public WebFetchUrlSourceAll(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("all");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebFetchUrlSourceAll(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebFetchUrlSourceAllFromRaw.FromRawUnchecked"/>
    public static WebFetchUrlSourceAll FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebFetchUrlSourceAllFromRaw : IFromRawJson<WebFetchUrlSourceAll>
{
    /// <inheritdoc/>
    public WebFetchUrlSourceAll FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebFetchUrlSourceAll.FromRawUnchecked(rawData);
}
