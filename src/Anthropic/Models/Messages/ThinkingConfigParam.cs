using Anthropic = Anthropic;
using Serialization = System.Text.Json.Serialization;
using ThinkingConfigParamVariants = Anthropic.Models.Messages.ThinkingConfigParamVariants;

namespace Anthropic.Models.Messages;

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
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ThinkingConfigParam>))]
public abstract record class ThinkingConfigParam
{
    internal ThinkingConfigParam() { }

    public static implicit operator ThinkingConfigParam(ThinkingConfigEnabled value) =>
        new ThinkingConfigParamVariants::ThinkingConfigEnabled(value);

    public static implicit operator ThinkingConfigParam(ThinkingConfigDisabled value) =>
        new ThinkingConfigParamVariants::ThinkingConfigDisabled(value);

    public abstract void Validate();
}
