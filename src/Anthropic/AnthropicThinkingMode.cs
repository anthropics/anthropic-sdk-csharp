#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Microsoft.Extensions.AI;

/// <summary>
/// How an <see cref="IChatClient"/> created by <c>AsIChatClient</c> sends
/// <see cref="ChatOptions.Reasoning"/> to the API.
/// </summary>
/// <remarks>
/// The two modes are different request shapes, and each model accepts only some of them, so this
/// has to match the model the client targets. For full control over the thinking configuration,
/// set it on the parameters returned from <see cref="ChatOptions.RawRepresentationFactory"/>
/// instead; the client leaves a caller-supplied configuration untouched.
/// <para>
/// In both modes, <see cref="ReasoningEffort.None"/> sends <c>thinking.type=disabled</c>. Models that
/// always think reject that with an HTTP 400, so leave <see cref="ChatOptions.Reasoning"/> unset for
/// them.
/// </para>
/// </remarks>
public enum AnthropicThinkingMode
{
    /// <summary>
    /// Adaptive thinking: <c>thinking.type=adaptive</c>, with <see cref="ReasoningOptions.Effort"/>
    /// sent as <c>output_config.effort</c> and the model deciding how much to think within it.
    /// With no effort set, thinking is turned on at the model's default effort. This is what
    /// current models take, and the default.
    /// </summary>
    Adaptive,

    /// <summary>
    /// Extended thinking: <c>thinking.type=enabled</c> with an explicit <c>budget_tokens</c>
    /// ceiling derived from <see cref="ReasoningOptions.Effort"/>. With no effort set there is no
    /// budget to send, so no thinking configuration is sent either. For models that predate
    /// adaptive thinking and reject it.
    /// </summary>
    Extended,
}
