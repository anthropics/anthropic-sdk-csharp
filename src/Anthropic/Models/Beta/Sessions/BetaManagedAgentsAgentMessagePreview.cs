using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentMessagePreview,
        BetaManagedAgentsAgentMessagePreviewFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentMessagePreview : JsonModel
{
    /// <summary>
    /// The id the buffered agent.message will carry if it is emitted. Matches the
    /// event_id on this preview's event_delta events.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("agent.message")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentMessagePreview()
    {
        this.Type = JsonSerializer.SerializeToElement("agent.message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentMessagePreview(
        BetaManagedAgentsAgentMessagePreview betaManagedAgentsAgentMessagePreview
    )
        : base(betaManagedAgentsAgentMessagePreview) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentMessagePreview(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent.message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentMessagePreview(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentMessagePreviewFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentMessagePreview FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentMessagePreview(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsAgentMessagePreviewFromRaw
    : IFromRawJson<BetaManagedAgentsAgentMessagePreview>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentMessagePreview FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentMessagePreview.FromRawUnchecked(rawData);
}
