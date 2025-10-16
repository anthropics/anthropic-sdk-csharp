using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;

namespace Anthropic.Client.Models.Beta.Messages;

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
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("skills", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BetaSkillParams>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["skills"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainerParams(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaContainerParams FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
