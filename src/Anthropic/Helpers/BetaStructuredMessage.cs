using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic.Helpers;

/// <summary>
/// A <see cref="BetaMessage"/> wrapper returned by <c>Create&lt;T&gt;</c> that replaces
/// <see cref="Content"/> with <see cref="BetaStructuredContentBlock{T}"/> entries, giving
/// each text block a strongly-typed <see cref="BetaStructuredContentBlock{T}.Parsed"/> method.
/// </summary>
/// <typeparam name="T">The structured output model type.</typeparam>
public sealed class BetaStructuredMessage<T>
    where T : class, new()
{
    /// <summary>The underlying message.</summary>
    public BetaMessage Message { get; }

    /// <summary>
    /// The message content blocks, with text blocks wrapped as
    /// <see cref="BetaStructuredContentBlock{T}"/> for structured output access.
    /// </summary>
    public IReadOnlyList<BetaStructuredContentBlock<T>> Content { get; }

    /// <inheritdoc cref="BetaMessage.ID"/>
    public string ID => Message.ID;

    /// <inheritdoc cref="BetaMessage.Container"/>
    public BetaContainer? Container => Message.Container;

    /// <inheritdoc cref="BetaMessage.Model"/>
    public ApiEnum<string, Model> Model => Message.Model;

    /// <inheritdoc cref="BetaMessage.Role"/>
    public JsonElement Role => Message.Role;

    /// <inheritdoc cref="BetaMessage.StopReason"/>
    public ApiEnum<string, BetaStopReason>? StopReason => Message.StopReason;

    /// <inheritdoc cref="BetaMessage.StopSequence"/>
    public string? StopSequence => Message.StopSequence;

    /// <inheritdoc cref="BetaMessage.Type"/>
    public JsonElement Type => Message.Type;

    /// <inheritdoc cref="BetaMessage.Usage"/>
    public BetaUsage Usage => Message.Usage;

    /// <inheritdoc cref="Anthropic.Core.JsonModel.RawData"/>
    public IReadOnlyDictionary<string, JsonElement> RawData => Message.RawData;

    /// <inheritdoc cref="BetaMessage.Validate"/>
    public void Validate() => Message.Validate();

    /// <summary>Implicitly converts to the underlying <see cref="BetaMessage"/>.</summary>
    public static implicit operator BetaMessage(BetaStructuredMessage<T> m) => m.Message;

    internal BetaStructuredMessage(BetaMessage message)
    {
        Message = message;
        Content = [.. message.Content.Select(b => new BetaStructuredContentBlock<T>(b))];
    }
}
