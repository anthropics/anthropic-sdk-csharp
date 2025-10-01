using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;

namespace Anthropic.Client.Models.Beta.Messages;

/// <summary>
/// Configuration for context management operations.
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaContextManagementConfig>))]
public sealed record class BetaContextManagementConfig
    : ModelBase,
        IFromRaw<BetaContextManagementConfig>
{
    /// <summary>
    /// List of context management edits to apply
    /// </summary>
    public List<BetaClearToolUses20250919Edit>? Edits
    {
        get
        {
            if (!this.Properties.TryGetValue("edits", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BetaClearToolUses20250919Edit>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["edits"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Edits ?? [])
        {
            item.Validate();
        }
    }

    public BetaContextManagementConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContextManagementConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaContextManagementConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
