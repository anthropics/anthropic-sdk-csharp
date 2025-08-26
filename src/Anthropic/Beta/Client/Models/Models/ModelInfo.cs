using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Models;

[JsonConverter(typeof(ModelConverter<ModelInfo>))]
public sealed record class ModelInfo : ModelBase, IFromRaw<ModelInfo>
{
    /// <summary>
    /// Unique model identifier.
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
    /// RFC 3339 datetime string representing the time at which the model was released.
    /// May be set to an epoch value if the release date is unknown.
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A human-readable name for the model.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            if (!this.Properties.TryGetValue("display_name", out JsonElement element))
                throw new ArgumentOutOfRangeException("display_name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("display_name");
        }
        set
        {
            this.Properties["display_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Object type.
    ///
    /// For Models, this is always `"model"`.
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
    }

    public ModelInfo()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"model\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelInfo(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ModelInfo FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
