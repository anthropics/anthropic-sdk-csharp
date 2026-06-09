using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// Privileged context for the accompanying turn and all subsequent turns, appended
/// to the session's system context as a `role: "system"` turn rather than replacing
/// the top-level system prompt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeploymentSystemMessageEvent,
        BetaManagedAgentsDeploymentSystemMessageEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeploymentSystemMessageEvent : JsonModel
{
    /// <summary>
    /// System content blocks to append. Text-only.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsSystemContentBlock> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsSystemContentBlock>
            >("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSystemContentBlock>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        this.Type.Validate();
    }

    public BetaManagedAgentsDeploymentSystemMessageEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeploymentSystemMessageEvent(
        BetaManagedAgentsDeploymentSystemMessageEvent betaManagedAgentsDeploymentSystemMessageEvent
    )
        : base(betaManagedAgentsDeploymentSystemMessageEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeploymentSystemMessageEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeploymentSystemMessageEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeploymentSystemMessageEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeploymentSystemMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeploymentSystemMessageEventFromRaw
    : IFromRawJson<BetaManagedAgentsDeploymentSystemMessageEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeploymentSystemMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeploymentSystemMessageEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsDeploymentSystemMessageEventTypeConverter))]
public enum BetaManagedAgentsDeploymentSystemMessageEventType
{
    SystemMessage,
}

sealed class BetaManagedAgentsDeploymentSystemMessageEventTypeConverter
    : JsonConverter<BetaManagedAgentsDeploymentSystemMessageEventType>
{
    public override BetaManagedAgentsDeploymentSystemMessageEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "system.message" => BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage,
            _ => (BetaManagedAgentsDeploymentSystemMessageEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeploymentSystemMessageEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage => "system.message",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
