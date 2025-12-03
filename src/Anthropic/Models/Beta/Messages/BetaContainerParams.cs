using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Container parameters with skills to be loaded.
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaContainerParams, BetaContainerParamsFromRaw>))]
public sealed record class BetaContainerParams : ModelBase
{
    /// <summary>
    /// Container id
    /// </summary>
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// List of skills to load in the container
    /// </summary>
    public IReadOnlyList<BetaSkillParams>? Skills
    {
        get { return ModelBase.GetNullableClass<List<BetaSkillParams>>(this.RawData, "skills"); }
        init { ModelBase.Set(this._rawData, "skills", value); }
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

    public BetaContainerParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainerParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaContainerParamsFromRaw : IFromRaw<BetaContainerParams>
{
    /// <inheritdoc/>
    public BetaContainerParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaContainerParams.FromRawUnchecked(rawData);
}
