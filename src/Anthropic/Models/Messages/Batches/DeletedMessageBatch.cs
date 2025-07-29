using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages.Batches;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<DeletedMessageBatch>))]
public sealed record class DeletedMessageBatch
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<DeletedMessageBatch>
{
    /// <summary>
    /// ID of the Message Batch.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Deleted object type.
    ///
    /// For Message Batches, this is always `"message_batch_deleted"`.
    /// </summary>
    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
    }

    public DeletedMessageBatch()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"message_batch_deleted\""
        );
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    DeletedMessageBatch(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DeletedMessageBatch FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
