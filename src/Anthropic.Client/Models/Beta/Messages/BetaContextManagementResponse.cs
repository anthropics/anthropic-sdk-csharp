using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Client.Models.Beta.Messages;

/// <summary>
/// Information about context management operations applied during the request.
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaContextManagementResponse>))]
public sealed record class BetaContextManagementResponse
    : ModelBase,
        IFromRaw<BetaContextManagementResponse>
{
    /// <summary>
    /// List of context management edits that were applied.
    /// </summary>
    public required List<BetaClearToolUses20250919EditResponse> AppliedEdits
    {
        get
        {
            if (!this.Properties.TryGetValue("applied_edits", out JsonElement element))
                throw new ArgumentOutOfRangeException("applied_edits", "Missing required argument");

            return JsonSerializer.Deserialize<List<BetaClearToolUses20250919EditResponse>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("applied_edits");
        }
        set
        {
            this.Properties["applied_edits"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.AppliedEdits)
        {
            item.Validate();
        }
    }

    public BetaContextManagementResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContextManagementResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaContextManagementResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaContextManagementResponse(List<BetaClearToolUses20250919EditResponse> appliedEdits)
        : this()
    {
        this.AppliedEdits = appliedEdits;
    }
}
