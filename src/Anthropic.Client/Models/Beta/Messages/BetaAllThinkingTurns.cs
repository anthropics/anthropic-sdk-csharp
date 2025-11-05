using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaAllThinkingTurns>))]
public sealed record class BetaAllThinkingTurns : ModelBase, IFromRaw<BetaAllThinkingTurns>
{
    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

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
        _ = this.Type;
    }

    public BetaAllThinkingTurns()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"all\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAllThinkingTurns(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaAllThinkingTurns FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
