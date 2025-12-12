using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Information about the container used in the request (for the code execution tool)
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaContainer, BetaContainerFromRaw>))]
public sealed record class BetaContainer : ModelBase
{
    /// <summary>
    /// Identifier for the container used in this request
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The time at which the container will expire.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "expires_at"); }
        init { ModelBase.Set(this._rawData, "expires_at", value); }
    }

    /// <summary>
    /// Skills loaded in the container
    /// </summary>
    public required IReadOnlyList<BetaSkill>? Skills
    {
        get { return ModelBase.GetNullableClass<List<BetaSkill>>(this.RawData, "skills"); }
        init { ModelBase.Set(this._rawData, "skills", value); }
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

    public BetaContainer(BetaContainer betaContainer)
        : base(betaContainer) { }

    public BetaContainer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaContainerFromRaw.FromRawUnchecked"/>
    public static BetaContainer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaContainerFromRaw : IFromRaw<BetaContainer>
{
    /// <inheritdoc/>
    public BetaContainer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaContainer.FromRawUnchecked(rawData);
}
