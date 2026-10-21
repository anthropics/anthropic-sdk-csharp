using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Base64-encoded image data.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsBase64ImageSource,
        BetaManagedAgentsBase64ImageSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsBase64ImageSource : JsonModel
{
    /// <summary>
    /// Base64-encoded image data.
    /// </summary>
    public required string Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// MIME type of the image (e.g., "image/png", "image/jpeg", "image/gif", "image/webp").
    /// </summary>
    public required string MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("media_type");
        }
        init { this._rawData.Set("media_type", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        _ = this.MediaType;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("base64")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsBase64ImageSource()
    {
        this.Type = JsonSerializer.SerializeToElement("base64");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsBase64ImageSource(
        BetaManagedAgentsBase64ImageSource betaManagedAgentsBase64ImageSource
    )
        : base(betaManagedAgentsBase64ImageSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsBase64ImageSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("base64");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsBase64ImageSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsBase64ImageSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsBase64ImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsBase64ImageSourceFromRaw : IFromRawJson<BetaManagedAgentsBase64ImageSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsBase64ImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsBase64ImageSource.FromRawUnchecked(rawData);
}
