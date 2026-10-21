using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Document referenced by file ID.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsFileDocumentSource,
        BetaManagedAgentsFileDocumentSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsFileDocumentSource : JsonModel
{
    /// <summary>
    /// ID of a previously uploaded file.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
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
        _ = this.FileID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsFileDocumentSource()
    {
        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileDocumentSource(
        BetaManagedAgentsFileDocumentSource betaManagedAgentsFileDocumentSource
    )
        : base(betaManagedAgentsFileDocumentSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileDocumentSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileDocumentSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileDocumentSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsFileDocumentSource(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaManagedAgentsFileDocumentSourceFromRaw : IFromRawJson<BetaManagedAgentsFileDocumentSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileDocumentSource.FromRawUnchecked(rawData);
}
