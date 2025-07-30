using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model will not be allowed to use tools.
/// </summary>
[JsonConverter(typeof(ModelConverter<ToolChoiceNone>))]
public sealed record class ToolChoiceNone : ModelBase, IFromRaw<ToolChoiceNone>
{
    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(element);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate() { }

    public ToolChoiceNone()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"none\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceNone(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ToolChoiceNone FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
