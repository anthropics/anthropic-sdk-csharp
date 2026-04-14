using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Helpers;

/// <summary>
/// A <see cref="Message"/> wrapper returned by <c>Create&lt;T&gt;</c> that replaces
/// <see cref="Content"/> with <see cref="StructuredContentBlock{T}"/> entries, giving
/// each text block a strongly-typed <see cref="StructuredContentBlock{T}.Parsed"/> method.
/// </summary>
/// <typeparam name="T">The structured output model type.</typeparam>
public sealed class StructuredMessage<T>
    where T : class, new()
{
    /// <summary>The underlying message.</summary>
    public Message Message { get; }

    /// <summary>
    /// The message content blocks, with text blocks wrapped as
    /// <see cref="StructuredContentBlock{T}"/> for structured output access.
    /// </summary>
    public IReadOnlyList<StructuredContentBlock<T>> Content { get; }

    /// <inheritdoc cref="Message.ID"/>
    public string ID => Message.ID;

    /// <inheritdoc cref="Message.Container"/>
    public Container? Container => Message.Container;

    /// <inheritdoc cref="Message.Model"/>
    public ApiEnum<string, Model> Model => Message.Model;

    /// <inheritdoc cref="Message.Role"/>
    public JsonElement Role => Message.Role;

    /// <inheritdoc cref="Message.StopReason"/>
    public ApiEnum<string, StopReason>? StopReason => Message.StopReason;

    /// <inheritdoc cref="Message.StopSequence"/>
    public string? StopSequence => Message.StopSequence;

    /// <inheritdoc cref="Message.Type"/>
    public JsonElement Type => Message.Type;

    /// <inheritdoc cref="Message.Usage"/>
    public Usage Usage => Message.Usage;

    /// <inheritdoc cref="Anthropic.Core.JsonModel.RawData"/>
    public IReadOnlyDictionary<string, JsonElement> RawData => Message.RawData;

    /// <inheritdoc cref="Message.Validate"/>
    public void Validate() => Message.Validate();

    /// <summary>Implicitly converts to the underlying <see cref="Message"/>.</summary>
    public static implicit operator Message(StructuredMessage<T> m) => m.Message;

    internal StructuredMessage(Message message)
    {
        Message = message;
        Content = [.. message.Content.Select(b => new StructuredContentBlock<T>(b))];
    }
}
