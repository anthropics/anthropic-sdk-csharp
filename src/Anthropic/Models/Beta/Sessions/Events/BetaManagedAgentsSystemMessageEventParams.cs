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
/// Privileged context for the accompanying turn and all subsequent turns, appended
/// to the session's system context as a `role: "system"` turn rather than replacing
/// the top-level system prompt. At most one per request: it must be the final event
/// and immediately follow the `user.message`, `user.tool_result`, or `user.custom_tool_result`
/// it accompanies. Only supported on models that accept mid-conversation system messages.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSystemMessageEventParams,
        BetaManagedAgentsSystemMessageEventParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSystemMessageEventParams : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType>
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

    public BetaManagedAgentsSystemMessageEventParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSystemMessageEventParams(
        BetaManagedAgentsSystemMessageEventParams betaManagedAgentsSystemMessageEventParams
    )
        : base(betaManagedAgentsSystemMessageEventParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSystemMessageEventParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSystemMessageEventParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSystemMessageEventParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSystemMessageEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSystemMessageEventParamsFromRaw
    : IFromRawJson<BetaManagedAgentsSystemMessageEventParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSystemMessageEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSystemMessageEventParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSystemMessageEventParamsTypeConverter))]
public enum BetaManagedAgentsSystemMessageEventParamsType
{
    SystemMessage,
}

sealed class BetaManagedAgentsSystemMessageEventParamsTypeConverter
    : JsonConverter<BetaManagedAgentsSystemMessageEventParamsType>
{
    public override BetaManagedAgentsSystemMessageEventParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "system.message" => BetaManagedAgentsSystemMessageEventParamsType.SystemMessage,
            _ => (BetaManagedAgentsSystemMessageEventParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSystemMessageEventParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSystemMessageEventParamsType.SystemMessage => "system.message",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
