using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages.Batches;

[JsonConverter(typeof(ModelConverter<BetaDeletedMessageBatch>))]
public sealed record class BetaDeletedMessageBatch : ModelBase, IFromRaw<BetaDeletedMessageBatch>
{
    /// <summary>
    /// ID of the Message Batch.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
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
    /// Deleted object type.
    ///
    /// For Message Batches, this is always `"message_batch_deleted"`.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
    }

    public BetaDeletedMessageBatch()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_batch_deleted\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDeletedMessageBatch(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaDeletedMessageBatch FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaDeletedMessageBatch(string id)
        : this()
    {
        this.ID = id;
    }
}
