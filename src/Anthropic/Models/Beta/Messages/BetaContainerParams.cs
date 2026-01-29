using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Container parameters with skills to be loaded.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaContainerParams, BetaContainerParamsFromRaw>))]
public sealed record class BetaContainerParams : JsonModel
{
    /// <summary>
    /// Container id
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// List of skills to load in the container
    /// </summary>
    public IReadOnlyList<BetaSkillParams>? Skills
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaSkillParams>>("skills");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaSkillParams>?>(
                "skills",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Skills ?? [])
        {
            item.Validate();
        }
    }

    public BetaContainerParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaContainerParams(BetaContainerParams betaContainerParams)
        : base(betaContainerParams) { }
#pragma warning restore CS8618

    public BetaContainerParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainerParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaContainerParamsFromRaw.FromRawUnchecked"/>
    public static BetaContainerParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaContainerParamsFromRaw : IFromRawJson<BetaContainerParams>
{
    /// <inheritdoc/>
    public BetaContainerParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaContainerParams.FromRawUnchecked(rawData);
}
