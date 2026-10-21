using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsTextBlock, BetaManagedAgentsTextBlockFromRaw>)
)]
public sealed record class BetaManagedAgentsTextBlock : JsonModel
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

    public BetaManagedAgentsTextBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTextBlock(BetaManagedAgentsTextBlock betaManagedAgentsTextBlock)
        : base(betaManagedAgentsTextBlock) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTextBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTextBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTextBlockFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTextBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTextBlock(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaManagedAgentsTextBlockFromRaw : IFromRawJson<BetaManagedAgentsTextBlock>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTextBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTextBlock.FromRawUnchecked(rawData);
}
