using Anthropic = Anthropic;
using BetaThinkingConfigParamVariants = Anthropic.Models.Beta.Messages.BetaThinkingConfigParamVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Configuration for enabling Claude's extended thinking.
///
/// When enabled, responses include `thinking` content blocks showing Claude's thinking
/// process before the final answer. Requires a minimum budget of 1,024 tokens and
/// counts towards your `max_tokens` limit.
///
/// See [extended thinking](https://docs.anthropic.com/en/docs/build-with-claude/extended-thinking)
/// for details.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaThinkingConfigParam>))]
public abstract record class BetaThinkingConfigParam
{
    internal BetaThinkingConfigParam() { }

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigEnabled value) =>
        new BetaThinkingConfigParamVariants::BetaThinkingConfigEnabled(value);

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigDisabled value) =>
        new BetaThinkingConfigParamVariants::BetaThinkingConfigDisabled(value);

    public abstract void Validate();
}
