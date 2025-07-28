using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Completions;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<Completion>))]
public sealed record class Completion : Anthropic::ModelBase, Anthropic::IFromRaw<Completion>
{
    /// <summary>
    /// Unique object identifier.
    ///
    /// The format and length of IDs may change over time.
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
    /// The resulting completion up to and excluding the stop sequences.
    /// </summary>
    public required string Completion1
    {
        get
        {
            if (!this.Properties.TryGetValue("completion", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "completion",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("completion");
        }
        set { this.Properties["completion"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The model that will complete your prompt.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
    /// for additional details and options.
    /// </summary>
    public required Messages::Model Model
    {
        get
        {
            if (!this.Properties.TryGetValue("model", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("model", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Messages::Model>(element)
                ?? throw new System::ArgumentNullException("model");
        }
        set { this.Properties["model"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The reason that we stopped.
    ///
    /// This may be one the following values: * `"stop_sequence"`: we reached a stop
    /// sequence — either provided by you via the `stop_sequences` parameter, or a
    /// stop sequence built into the model * `"max_tokens"`: we exceeded `max_tokens_to_sample`
    /// or the model's maximum
    /// </summary>
    public required string? StopReason
    {
        get
        {
            if (!this.Properties.TryGetValue("stop_reason", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "stop_reason",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["stop_reason"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// For Text Completions, this is always `"completion"`.
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
        _ = this.Completion1;
        this.Model.Validate();
        _ = this.StopReason;
        if (
            !this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"completion\""))
        )
        {
            throw new System::Exception();
        }
    }

    public Completion()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"completion\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Completion(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Completion FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
