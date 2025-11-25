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
[JsonConverter(typeof(ModelConverter<BetaContainerParams>))]
public sealed record class BetaContainerParams : ModelBase, IFromRaw<BetaContainerParams>
{
    /// <summary>
    /// Container id
    /// </summary>
    public string? ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of skills to load in the container
    /// </summary>
    public List<BetaSkillParams>? Skills
    {
        get
        {
            if (!this._rawData.TryGetValue("skills", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BetaSkillParams>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["skills"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static BetaContainerParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
