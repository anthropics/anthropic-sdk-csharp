using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Models;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaModelInfo>))]
public sealed record class BetaModelInfo : Anthropic::ModelBase, Anthropic::IFromRaw<BetaModelInfo>
{
    /// <summary>
    /// Unique model identifier.
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
    /// RFC 3339 datetime string representing the time at which the model was released.
    /// May be set to an epoch value if the release date is unknown.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A human-readable name for the model.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            if (!this.Properties.TryGetValue("display_name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "display_name",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("display_name");
        }
        set { this.Properties["display_name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// For Models, this is always `"model"`.
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
        _ = this.CreatedAt;
        _ = this.DisplayName;
    }

    public BetaModelInfo()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"model\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaModelInfo(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaModelInfo FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
