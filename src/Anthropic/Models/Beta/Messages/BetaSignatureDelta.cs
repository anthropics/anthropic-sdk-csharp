using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaSignatureDelta>))]
public sealed record class BetaSignatureDelta : ModelBase, IFromRaw<BetaSignatureDelta>
{
    public required string Signature
    {
        get
        {
            if (!this.Properties.TryGetValue("signature", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "signature",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new global::System.ArgumentNullException("signature");
        }
        set { this.Properties["signature"] = JsonSerializer.SerializeToElement(value); }
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
        _ = this.Signature;
    }

    public BetaSignatureDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"signature_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSignatureDelta(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaSignatureDelta FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
