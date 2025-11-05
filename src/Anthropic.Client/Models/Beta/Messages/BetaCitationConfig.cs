using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCitationConfig>))]
public sealed record class BetaCitationConfig : ModelBase, IFromRaw<BetaCitationConfig>
{
    public required bool Enabled
    {
        get
        {
            if (!this.Properties.TryGetValue("enabled", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'enabled' cannot be null",
                    new System::ArgumentOutOfRangeException("enabled", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Enabled;
    }

    public BetaCitationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCitationConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaCitationConfig(bool enabled)
        : this()
    {
        this.Enabled = enabled;
    }
}
