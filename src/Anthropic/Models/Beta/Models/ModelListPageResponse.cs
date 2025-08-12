using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Models;

[JsonConverter(typeof(Anthropic::ModelConverter<ModelListPageResponse>))]
public sealed record class ModelListPageResponse
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<ModelListPageResponse>
{
    public required List<BetaModelInfo> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<BetaModelInfo>>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// First ID in the `data` list. Can be used as the `before_id` for the previous page.
    /// </summary>
    public required string? FirstID
    {
        get
        {
            if (!this.Properties.TryGetValue("first_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("first_id", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["first_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Indicates if there are more results in the requested page direction.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            if (!this.Properties.TryGetValue("has_more", out JsonElement element))
                throw new ArgumentOutOfRangeException("has_more", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["has_more"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Last ID in the `data` list. Can be used as the `after_id` for the next page.
    /// </summary>
    public required string? LastID
    {
        get
        {
            if (!this.Properties.TryGetValue("last_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("last_id", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["last_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.FirstID;
        _ = this.HasMore;
        _ = this.LastID;
    }

    public ModelListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ModelListPageResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
