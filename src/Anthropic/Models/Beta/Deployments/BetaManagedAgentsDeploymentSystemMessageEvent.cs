using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

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
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("system.message")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsDeploymentSystemMessageEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("system.message");
    }

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

        this.Type = JsonSerializer.SerializeToElement("system.message");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsDeploymentSystemMessageEvent(
        IReadOnlyList<BetaManagedAgentsSystemContentBlock> content
    )
        : this()
    {
        this.Content = content;
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
