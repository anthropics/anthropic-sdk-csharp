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

    public required ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Type>
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

    public BetaManagedAgentsAgentMessagePreview() { }

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
}

class BetaManagedAgentsAgentMessagePreviewFromRaw
    : IFromRawJson<BetaManagedAgentsAgentMessagePreview>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentMessagePreview FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentMessagePreview.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AgentMessage,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Sessions.Type>
{
    public override global::Anthropic.Models.Beta.Sessions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.message" => global::Anthropic.Models.Beta.Sessions.Type.AgentMessage,
            _ => (global::Anthropic.Models.Beta.Sessions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Sessions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Sessions.Type.AgentMessage => "agent.message",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
