using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(ModelConverter<BetaErrorResponse>))]
public sealed record class BetaErrorResponse : ModelBase, IFromRaw<BetaErrorResponse>
{
    public required BetaError Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "error",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaError>(element, ModelBase.SerializerOptions)
                ?? throw new global::System.ArgumentNullException("error");
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

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
}
