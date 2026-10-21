using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Models.Beta.Sessions;

[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsDeltaContent, BetaManagedAgentsDeltaContentFromRaw>)
)]
public sealed record class BetaManagedAgentsDeltaContent : JsonModel
{
    /// <summary>
    /// A partial element of the content array at index, typed like the element itself
    /// — the same shape the buffered agent.message carries in content.
    /// </summary>
    public required BetaManagedAgentsTextBlock Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsTextBlock>("content");
        }
        init { this._rawData.Set("content", value); }
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

    /// <summary>
    /// Which entry in the previewed event's content array this fragment lands in.
    /// Insert content as that entry when the index is new; append to the existing
    /// entry otherwise.
    /// </summary>
    public long? Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("index");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("index");
                return;
            }

            this._rawData.Set("index", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("content_delta")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Index;
    }

    public BetaManagedAgentsDeltaContent()
    {
        this.Type = JsonSerializer.SerializeToElement("content_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeltaContent(
        BetaManagedAgentsDeltaContent betaManagedAgentsDeltaContent
    )
        : base(betaManagedAgentsDeltaContent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeltaContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("content_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeltaContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeltaContentFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeltaContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsDeltaContent(BetaManagedAgentsTextBlock content)
        : this()
    {
        this.Content = content;
    }
}

class BetaManagedAgentsDeltaContentFromRaw : IFromRawJson<BetaManagedAgentsDeltaContent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeltaContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeltaContent.FromRawUnchecked(rawData);
}
