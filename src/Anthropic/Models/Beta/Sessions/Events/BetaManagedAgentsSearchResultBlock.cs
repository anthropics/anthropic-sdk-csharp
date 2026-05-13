using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// A block containing a web search result.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSearchResultBlock,
        BetaManagedAgentsSearchResultBlockFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSearchResultBlock : JsonModel
{
    /// <summary>
    /// Citation settings for a search result.
    /// </summary>
    public required BetaManagedAgentsSearchResultCitations Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSearchResultCitations>(
                "citations"
            );
        }
        init { this._rawData.Set("citations", value); }
    }

    /// <summary>
    /// Array of text content blocks from the search result.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsSearchResultContent> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsSearchResultContent>
            >("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSearchResultContent>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The URL source of the search result.
    /// </summary>
    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The title of the search result.
    /// </summary>
    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <summary>
    /// The ID of the tool use that produced this search result.
    /// </summary>
    public required string ToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_use_id");
        }
        init { this._rawData.Set("tool_use_id", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSearchResultBlockType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSearchResultBlockType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Citations.Validate();
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.Source;
        _ = this.Title;
        _ = this.ToolUseID;
        this.Type.Validate();
    }

    public BetaManagedAgentsSearchResultBlock() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSearchResultBlock(
        BetaManagedAgentsSearchResultBlock betaManagedAgentsSearchResultBlock
    )
        : base(betaManagedAgentsSearchResultBlock) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSearchResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSearchResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSearchResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSearchResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSearchResultBlockFromRaw : IFromRawJson<BetaManagedAgentsSearchResultBlock>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSearchResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSearchResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSearchResultBlockTypeConverter))]
public enum BetaManagedAgentsSearchResultBlockType
{
    SearchResult,
}

sealed class BetaManagedAgentsSearchResultBlockTypeConverter
    : JsonConverter<BetaManagedAgentsSearchResultBlockType>
{
    public override BetaManagedAgentsSearchResultBlockType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "search_result" => BetaManagedAgentsSearchResultBlockType.SearchResult,
            _ => (BetaManagedAgentsSearchResultBlockType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSearchResultBlockType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSearchResultBlockType.SearchResult => "search_result",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
