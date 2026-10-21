using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Document referenced by URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUrlDocumentSource,
        BetaManagedAgentsUrlDocumentSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUrlDocumentSource : JsonModel
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

    /// <summary>
    /// URL of the document to fetch.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("url")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public BetaManagedAgentsUrlDocumentSource()
    {
        this.Type = JsonSerializer.SerializeToElement("url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUrlDocumentSource(
        BetaManagedAgentsUrlDocumentSource betaManagedAgentsUrlDocumentSource
    )
        : base(betaManagedAgentsUrlDocumentSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUrlDocumentSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUrlDocumentSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUrlDocumentSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUrlDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUrlDocumentSource(string url)
        : this()
    {
        this.Url = url;
    }
}

class BetaManagedAgentsUrlDocumentSourceFromRaw : IFromRawJson<BetaManagedAgentsUrlDocumentSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUrlDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUrlDocumentSource.FromRawUnchecked(rawData);
}
