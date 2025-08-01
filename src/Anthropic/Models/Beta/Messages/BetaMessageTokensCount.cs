using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMessageTokensCount>))]
public sealed record class BetaMessageTokensCount : ModelBase, IFromRaw<BetaMessageTokensCount>
{
    /// <summary>
    /// The total number of tokens across the provided list of messages, system prompt,
    /// and tools.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("input_tokens", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "input_tokens",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["input_tokens"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.InputTokens;
    }

    public BetaMessageTokensCount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageTokensCount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageTokensCount FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaMessageTokensCount(long inputTokens)
        : this()
    {
        this.InputTokens = inputTokens;
    }
}
