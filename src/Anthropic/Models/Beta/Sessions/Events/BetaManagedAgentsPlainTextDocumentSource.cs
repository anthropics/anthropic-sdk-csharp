using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Plain text document content.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsPlainTextDocumentSource,
        BetaManagedAgentsPlainTextDocumentSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsPlainTextDocumentSource : JsonModel
{
    /// <summary>
    /// The plain text content.
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
    /// MIME type of the text content. Must be "text/plain".
    /// </summary>
    public JsonElement MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("media_type");
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
        if (
            !JsonElement.DeepEquals(this.MediaType, JsonSerializer.SerializeToElement("text/plain"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsPlainTextDocumentSource()
    {
        this.MediaType = JsonSerializer.SerializeToElement("text/plain");
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsPlainTextDocumentSource(
        BetaManagedAgentsPlainTextDocumentSource betaManagedAgentsPlainTextDocumentSource
    )
        : base(betaManagedAgentsPlainTextDocumentSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsPlainTextDocumentSource(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.MediaType = JsonSerializer.SerializeToElement("text/plain");
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsPlainTextDocumentSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsPlainTextDocumentSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsPlainTextDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsPlainTextDocumentSource(string data)
        : this()
    {
        this.Data = data;
    }
}

class BetaManagedAgentsPlainTextDocumentSourceFromRaw
    : IFromRawJson<BetaManagedAgentsPlainTextDocumentSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsPlainTextDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsPlainTextDocumentSource.FromRawUnchecked(rawData);
}
