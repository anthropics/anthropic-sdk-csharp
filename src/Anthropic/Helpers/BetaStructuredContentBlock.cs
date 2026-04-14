using System.Text.Json;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers;

/// <summary>
/// Wraps a <see cref="BetaContentBlock"/> and adds lazy, cached structured output parsing
/// via <see cref="Parsed"/> for text blocks. Non-text blocks are accessible through
/// <see cref="ContentBlock"/> for pattern matching.
/// </summary>
/// <typeparam name="T">The structured output model type.</typeparam>
public sealed class BetaStructuredContentBlock<T>
    where T : class, new()
{
    private T? _parsed;

    /// <summary>The underlying content block.</summary>
    public BetaContentBlock ContentBlock { get; }

    /// <summary>
    /// Returns the parsed structured output if this is a text block, or <c>null</c> otherwise.
    /// The result is lazily computed and cached.
    /// </summary>
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown if this is a text block but the content is not valid JSON for <typeparamref name="T"/>.
    /// </exception>
    public T? Parsed()
    {
        if (_parsed != null)
            return _parsed;

        if (ContentBlock.Value is not BetaTextBlock textBlock)
            return null;

        try
        {
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(textBlock.Text);
            _parsed = StructuredOutput.Parse<T?>(jsonElement);
            return _parsed;
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException("Failed to parse structured output", e);
        }
    }

    /// <summary>Implicitly converts to the underlying <see cref="BetaContentBlock"/>.</summary>
    public static implicit operator BetaContentBlock(BetaStructuredContentBlock<T> b) =>
        b.ContentBlock;

    internal BetaStructuredContentBlock(BetaContentBlock raw) => ContentBlock = raw;
}
