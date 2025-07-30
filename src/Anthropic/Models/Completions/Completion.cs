using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Completions;

[JsonConverter(typeof(ModelConverter<Completion>))]
public sealed record class Completion : ModelBase, IFromRaw<Completion>
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
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The resulting completion up to and excluding the stop sequences.
    /// </summary>
    public required string Completion1
    {
        get
        {
            if (!this.Properties.TryGetValue("completion", out JsonElement element))
                throw new ArgumentOutOfRangeException("completion", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("completion");
        }
        set { this.Properties["completion"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The model that will complete your prompt.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
    /// for additional details and options.
    /// </summary>
    public required Messages::Model Model
    {
        get
        {
            if (!this.Properties.TryGetValue("model", out JsonElement element))
                throw new ArgumentOutOfRangeException("model", "Missing required argument");

            return JsonSerializer.Deserialize<Messages::Model>(element)
                ?? throw new ArgumentNullException("model");
        }
        set { this.Properties["model"] = JsonSerializer.SerializeToElement(value); }
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
            if (!this.Properties.TryGetValue("stop_reason", out JsonElement element))
                throw new ArgumentOutOfRangeException("stop_reason", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["stop_reason"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// For Text Completions, this is always `"completion"`.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Completion1;
        this.Model.Validate();
        _ = this.StopReason;
    }

    public Completion()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"completion\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Completion(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Completion FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
