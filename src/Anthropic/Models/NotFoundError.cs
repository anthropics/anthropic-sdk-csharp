using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models;

[JsonConverter(typeof(Anthropic::ModelConverter<NotFoundError>))]
public sealed record class NotFoundError : Anthropic::ModelBase, Anthropic::IFromRaw<NotFoundError>
{
    public required string Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "message",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("message");
        }
        set { this.Properties["message"] = JsonSerializer.SerializeToElement(value); }
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
        _ = this.Message;
    }

    public NotFoundError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"not_found_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotFoundError(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NotFoundError FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public NotFoundError(string message)
        : this()
    {
        this.Message = message;
    }
}
