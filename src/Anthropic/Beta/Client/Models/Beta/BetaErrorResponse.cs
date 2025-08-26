using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta;

[JsonConverter(typeof(ModelConverter<BetaErrorResponse>))]
public sealed record class BetaErrorResponse : ModelBase, IFromRaw<BetaErrorResponse>
{
    public required BetaError Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out JsonElement element))
                throw new ArgumentOutOfRangeException("error", "Missing required argument");

            return JsonSerializer.Deserialize<BetaError>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("error");
        }
        set
        {
            this.Properties["error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        this.Error.Validate();
    }

    public BetaErrorResponse()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaErrorResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaErrorResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaErrorResponse(BetaError error)
        : this()
    {
        this.Error = error;
    }
}
