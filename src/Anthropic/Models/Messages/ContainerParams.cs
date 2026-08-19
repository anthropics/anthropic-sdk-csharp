using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Container parameters with skills to be loaded.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContainerParams, ContainerParamsFromRaw>))]
public sealed record class ContainerParams : JsonModel
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
    public IReadOnlyList<SkillParams>? Skills
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SkillParams>>("skills");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SkillParams>?>(
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

    public ContainerParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContainerParams(ContainerParams containerParams)
        : base(containerParams) { }
#pragma warning restore CS8618

    public ContainerParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContainerParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContainerParamsFromRaw.FromRawUnchecked"/>
    public static ContainerParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContainerParamsFromRaw : IFromRawJson<ContainerParams>
{
    /// <inheritdoc/>
    public ContainerParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContainerParams.FromRawUnchecked(rawData);
}
