using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMetadata>))]
public sealed record class BetaMetadata : ModelBase, IFromRaw<BetaMetadata>
{
    /// <summary>
    /// An external identifier for the user who is associated with the request.
    ///
    /// This should be a uuid, hash value, or other opaque identifier. Anthropic may
    /// use this id to help detect abuse. Do not include any identifying information
    /// such as name, email address, or phone number.
    /// </summary>
    public string? UserID
    {
        get
        {
            if (!this.Properties.TryGetValue("user_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["user_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UserID;
    }

    public BetaMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMetadata(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMetadata FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
