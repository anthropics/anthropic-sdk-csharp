using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Base64-encoded document data.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsBase64DocumentSource,
        BetaManagedAgentsBase64DocumentSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsBase64DocumentSource : JsonModel
{
    /// <summary>
    /// Base64-encoded document data.
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
    /// MIME type of the document (e.g., "application/pdf").
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

    public BetaManagedAgentsBase64DocumentSource()
    {
        this.Type = JsonSerializer.SerializeToElement("base64");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsBase64DocumentSource(
        BetaManagedAgentsBase64DocumentSource betaManagedAgentsBase64DocumentSource
    )
        : base(betaManagedAgentsBase64DocumentSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsBase64DocumentSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("base64");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsBase64DocumentSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsBase64DocumentSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsBase64DocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsBase64DocumentSourceFromRaw
    : IFromRawJson<BetaManagedAgentsBase64DocumentSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsBase64DocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsBase64DocumentSource.FromRawUnchecked(rawData);
}
