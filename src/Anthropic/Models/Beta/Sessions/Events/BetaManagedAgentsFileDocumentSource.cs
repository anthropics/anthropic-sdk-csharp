using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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

    public required ApiEnum<string, BetaManagedAgentsFileDocumentSourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsFileDocumentSourceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        this.Type.Validate();
    }

    public BetaManagedAgentsFileDocumentSource() { }

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
}

class BetaManagedAgentsFileDocumentSourceFromRaw : IFromRawJson<BetaManagedAgentsFileDocumentSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileDocumentSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsFileDocumentSourceTypeConverter))]
public enum BetaManagedAgentsFileDocumentSourceType
{
    File,
}

sealed class BetaManagedAgentsFileDocumentSourceTypeConverter
    : JsonConverter<BetaManagedAgentsFileDocumentSourceType>
{
    public override BetaManagedAgentsFileDocumentSourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file" => BetaManagedAgentsFileDocumentSourceType.File,
            _ => (BetaManagedAgentsFileDocumentSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsFileDocumentSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsFileDocumentSourceType.File => "file",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
