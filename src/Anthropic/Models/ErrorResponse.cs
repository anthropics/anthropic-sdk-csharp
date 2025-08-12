using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models;

[JsonConverter(typeof(Anthropic::ModelConverter<ErrorResponse>))]
public sealed record class ErrorResponse : Anthropic::ModelBase, Anthropic::IFromRaw<ErrorResponse>
{
    public required ErrorObject Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "error",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ErrorObject>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("error");
        }
        set { this.Properties["error"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
