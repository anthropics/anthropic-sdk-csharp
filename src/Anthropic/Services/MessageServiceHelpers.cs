using System;
using Anthropic.Models.Messages;

namespace Anthropic.Services;

internal static class MessageServiceHelpers
{
    internal static void WarnIfDeprecatedThinkingConfig(MessageCreateParams parameters)
    {
        WarnIfDeprecatedThinkingConfigImpl(parameters.Model.Raw(), parameters.Thinking);
    }

    internal static void WarnIfDeprecatedThinkingConfig(
        Models.Beta.Messages.MessageCreateParams parameters
    )
    {
        WarnIfDeprecatedThinkingConfigImpl(parameters.Model.Raw(), parameters.Thinking);
    }

    internal static void WarnIfDeprecatedThinkingConfig(MessageCountTokensParams parameters)
    {
        WarnIfDeprecatedThinkingConfigImpl(parameters.Model.Raw(), parameters.Thinking);
    }

    internal static void WarnIfDeprecatedThinkingConfig(
        Models.Beta.Messages.MessageCountTokensParams parameters
    )
    {
        WarnIfDeprecatedThinkingConfigImpl(parameters.Model.Raw(), parameters.Thinking);
    }

    private static void WarnIfDeprecatedThinkingConfigImpl(string? modelString, object? thinking)
    {
        // Check if model is claude-opus-4-6 and thinking type is enabled
        if (modelString == "claude-opus-4-6" && thinking != null)
        {
            // Check if thinking is enabled for non-beta
            if (thinking is ThinkingConfigParam thinkingConfig)
            {
                if (thinkingConfig.TryPickEnabled(out _))
                {
                    Console.Error.WriteLine(
                        $"WARNING: Using Claude with {modelString} and 'thinking.type=enabled' is deprecated. "
                            + "Use thinking.type=adaptive instead which results in better model performance in our testing: "
                            + "https://platform.claude.com/docs/en/build-with-claude/adaptive-thinking"
                    );
                }
            }
            // Check if thinking is enabled for beta
            else if (thinking is Models.Beta.Messages.BetaThinkingConfigParam betaThinkingConfig)
            {
                if (betaThinkingConfig.TryPickEnabled(out _))
                {
                    Console.Error.WriteLine(
                        $"WARNING: Using Claude with {modelString} and 'thinking.type=enabled' is deprecated. "
                            + "Use thinking.type=adaptive instead which results in better model performance in our testing: "
                            + "https://platform.claude.com/docs/en/build-with-claude/adaptive-thinking"
                    );
                }
            }
        }
    }
}
