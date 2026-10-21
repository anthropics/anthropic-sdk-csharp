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
        BetaManagedAgentsAgentThinkingPreview,
        BetaManagedAgentsAgentThinkingPreviewFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentThinkingPreview : JsonModel
{
    /// <summary>
    /// The id the buffered agent.thinking will carry if it is emitted. Start-only
    /// — no event_delta events follow.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("agent.thinking")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentThinkingPreview()
    {
        this.Type = JsonSerializer.SerializeToElement("agent.thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentThinkingPreview(
        BetaManagedAgentsAgentThinkingPreview betaManagedAgentsAgentThinkingPreview
    )
        : base(betaManagedAgentsAgentThinkingPreview) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentThinkingPreview(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent.thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentThinkingPreview(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentThinkingPreviewFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentThinkingPreview FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentThinkingPreview(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsAgentThinkingPreviewFromRaw
    : IFromRawJson<BetaManagedAgentsAgentThinkingPreview>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentThinkingPreview FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentThinkingPreview.FromRawUnchecked(rawData);
}
