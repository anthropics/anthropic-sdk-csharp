using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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

    public required ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public BetaManagedAgentsAgentThinkingPreview() { }

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
}

class BetaManagedAgentsAgentThinkingPreviewFromRaw
    : IFromRawJson<BetaManagedAgentsAgentThinkingPreview>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentThinkingPreview FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentThinkingPreview.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAgentThinkingPreviewTypeConverter))]
public enum BetaManagedAgentsAgentThinkingPreviewType
{
    AgentThinking,
}

sealed class BetaManagedAgentsAgentThinkingPreviewTypeConverter
    : JsonConverter<BetaManagedAgentsAgentThinkingPreviewType>
{
    public override BetaManagedAgentsAgentThinkingPreviewType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.thinking" => BetaManagedAgentsAgentThinkingPreviewType.AgentThinking,
            _ => (BetaManagedAgentsAgentThinkingPreviewType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentThinkingPreviewType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentThinkingPreviewType.AgentThinking => "agent.thinking",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
