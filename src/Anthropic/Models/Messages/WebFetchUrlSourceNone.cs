using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The ``url_sources`` variant under which a source contributes nothing: no result
/// of the tool filter's source, or no user input.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebFetchUrlSourceNone, WebFetchUrlSourceNoneFromRaw>))]
public sealed record class WebFetchUrlSourceNone : JsonModel
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

    public WebFetchUrlSourceNone()
    {
        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebFetchUrlSourceNone(WebFetchUrlSourceNone webFetchUrlSourceNone)
        : base(webFetchUrlSourceNone) { }
#pragma warning restore CS8618

    public WebFetchUrlSourceNone(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebFetchUrlSourceNone(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebFetchUrlSourceNoneFromRaw.FromRawUnchecked"/>
    public static WebFetchUrlSourceNone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebFetchUrlSourceNoneFromRaw : IFromRawJson<WebFetchUrlSourceNone>
{
    /// <inheritdoc/>
    public WebFetchUrlSourceNone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebFetchUrlSourceNone.FromRawUnchecked(rawData);
}
