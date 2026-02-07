using Anthropic.Models.Messages;

#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Microsoft.Extensions.AI;

/// <summary>
/// Extension methods for configuring Anthropic prompt caching on <see cref="AIContent"/> instances.
/// </summary>
/// <remarks>
/// <para>
/// Prompt caching allows you to cache frequently used context between API calls, reducing latency
/// and costs for repetitive workloads. Cache breakpoints are placed at the END of content blocks
/// that have cache control set.
/// </para>
/// <para>
/// These extensions are only effective when used with the <see cref="IChatClient"/> returned by
/// <see cref="AnthropicClientExtensions.AsIChatClient"/>. Other implementations will ignore the cache control settings.
/// </para>
/// </remarks>
public static class AIContentCacheExtensions
{
    private const string CacheControlKey = "anthropic:cache_control";

    /// <summary>
    /// Configures Anthropic prompt caching on this content block.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="AIContent"/>.</typeparam>
    /// <param name="content">The content to configure caching for.</param>
    /// <param name="cacheControl">
    /// The cache control configuration. Pass <see langword="null"/> to remove any existing cache control.
    /// </param>
    /// <returns>The same <paramref name="content"/> instance for method chaining.</returns>
    /// <remarks>
    /// <para>
    /// The cache breakpoint is placed at the END of this content block. All content up to and including
    /// this block will be cached together.
    /// </para>
    /// <para>
    /// For optimal caching in agentic loops, place cache breakpoints on:
    /// <list type="bullet">
    ///   <item>System prompts (use <see cref="Ttl.Ttl1h"/> for stable prompts)</item>
    ///   <item>The last content block before the current turn (use <see cref="Ttl.Ttl5m"/>)</item>
    ///   <item>Large tool results that won't change</item>
    /// </list>
    /// </para>
    /// </remarks>
    /// <example>
    /// <code>
    /// var systemContent = new TextContent(systemPrompt).WithCacheControl(new CacheControlEphemeral { Ttl = Ttl.Ttl1h });
    /// chatMessages.Add(new ChatMessage(ChatRole.System, [systemContent]));
    /// </code>
    /// </example>
    public static T WithCacheControl<T>(this T content, CacheControlEphemeral? cacheControl)
        where T : AIContent
    {
        if (cacheControl is null)
        {
            content.AdditionalProperties?.Remove(CacheControlKey);
        }
        else
        {
            (content.AdditionalProperties ??= [])[CacheControlKey] = cacheControl;
        }

        return content;
    }

    /// <summary>
    /// Configures Anthropic prompt caching on this content block with the specified TTL.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="AIContent"/>.</typeparam>
    /// <param name="content">The content to configure caching for.</param>
    /// <param name="ttl">
    /// The time-to-live for the cache. Use <see cref="Ttl.Ttl5m"/> (5 minutes) for dynamic content
    /// or <see cref="Ttl.Ttl1h"/> (1 hour) for stable content like system prompts.
    /// Pass <see langword="null"/> for the default TTL (5 minutes).
    /// </param>
    /// <returns>The same <paramref name="content"/> instance for method chaining.</returns>
    /// <example>
    /// <code>
    /// // Cache system prompt for 1 hour
    /// var systemContent = new TextContent(systemPrompt).WithCacheControl(Ttl.Ttl1h);
    ///
    /// // Cache conversation context for 5 minutes (default)
    /// var lastMessage = messages[^1].Contents.Last();
    /// lastMessage.WithCacheControl(Ttl.Ttl5m);
    /// </code>
    /// </example>
    public static T WithCacheControl<T>(this T content, Ttl? ttl)
        where T : AIContent => content.WithCacheControl(new CacheControlEphemeral { Ttl = ttl });

    /// <summary>
    /// Gets the cache control configuration for this content block, if any.
    /// </summary>
    /// <param name="content">The content to check.</param>
    /// <returns>
    /// The <see cref="CacheControlEphemeral"/> if configured, or <see langword="null"/> if no cache control is set.
    /// </returns>
    internal static CacheControlEphemeral? GetCacheControl(this AIContent content) =>
        content.AdditionalProperties?.TryGetValue(CacheControlKey, out var cc) == true
            ? cc as CacheControlEphemeral
            : null;
}
