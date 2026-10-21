using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Image referenced by URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUrlImageSource,
        BetaManagedAgentsUrlImageSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUrlImageSource : JsonModel
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
    /// URL of the image to fetch.
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

    public BetaManagedAgentsUrlImageSource()
    {
        this.Type = JsonSerializer.SerializeToElement("url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUrlImageSource(
        BetaManagedAgentsUrlImageSource betaManagedAgentsUrlImageSource
    )
        : base(betaManagedAgentsUrlImageSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUrlImageSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUrlImageSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUrlImageSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUrlImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUrlImageSource(string url)
        : this()
    {
        this.Url = url;
    }
}

class BetaManagedAgentsUrlImageSourceFromRaw : IFromRawJson<BetaManagedAgentsUrlImageSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUrlImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUrlImageSource.FromRawUnchecked(rawData);
}
