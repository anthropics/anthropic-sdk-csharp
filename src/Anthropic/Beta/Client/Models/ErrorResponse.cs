using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models;

[JsonConverter(typeof(ModelConverter<ErrorResponse>))]
public sealed record class ErrorResponse : ModelBase, IFromRaw<ErrorResponse>
{
    public required ErrorObject Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out JsonElement element))
                throw new ArgumentOutOfRangeException("error", "Missing required argument");

            return JsonSerializer.Deserialize<ErrorObject>(element, ModelBase.SerializerOptions)
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

    public ErrorResponse()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ErrorResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ErrorResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ErrorResponse(ErrorObject error)
        : this()
    {
        this.Error = error;
    }
}
