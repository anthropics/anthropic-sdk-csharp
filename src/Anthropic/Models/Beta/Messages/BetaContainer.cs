using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Information about the container used in the request (for the code execution tool)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaContainer, BetaContainerFromRaw>))]
public sealed record class BetaContainer : JsonModel
{
    /// <summary>
    /// Identifier for the container used in this request
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

    /// <summary>
    /// The time at which the container will expire.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Skills loaded in the container
    /// </summary>
    public required IReadOnlyList<BetaSkill>? Skills
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaSkill>>("skills");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaSkill>?>(
                "skills",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExpiresAt;
        foreach (var item in this.Skills ?? [])
        {
            item.Validate();
        }
    }

    public BetaContainer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaContainer(BetaContainer betaContainer)
        : base(betaContainer) { }
#pragma warning restore CS8618

    public BetaContainer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaContainerFromRaw.FromRawUnchecked"/>
    public static BetaContainer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaContainerFromRaw : IFromRawJson<BetaContainer>
{
    /// <inheritdoc/>
    public BetaContainer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaContainer.FromRawUnchecked(rawData);
}
