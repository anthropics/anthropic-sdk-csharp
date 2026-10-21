using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Text content within a search result.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSearchResultContent,
        BetaManagedAgentsSearchResultContentFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSearchResultContent : JsonModel
{
    /// <summary>
    /// The text content.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSearchResultContent()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSearchResultContent(
        BetaManagedAgentsSearchResultContent betaManagedAgentsSearchResultContent
    )
        : base(betaManagedAgentsSearchResultContent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSearchResultContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSearchResultContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSearchResultContentFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSearchResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSearchResultContent(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaManagedAgentsSearchResultContentFromRaw
    : IFromRawJson<BetaManagedAgentsSearchResultContent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSearchResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSearchResultContent.FromRawUnchecked(rawData);
}
