using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// Code execution tool with REPL state persistence (daemon mode + gVisor checkpoint).
/// </summary>
[JsonConverter(typeof(ToolUnionConverter))]
public record class ToolUnion : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<CacheControlEphemeral?>(
                tool: (x) => x.CacheControl,
                bash20250124: (x) => x.CacheControl,
                codeExecutionTool20250522: (x) => x.CacheControl,
                codeExecutionTool20250825: (x) => x.CacheControl,
                codeExecutionTool20260120: (x) => x.CacheControl,
                memoryTool20250818: (x) => x.CacheControl,
                textEditor20250124: (x) => x.CacheControl,
                textEditor20250429: (x) => x.CacheControl,
                textEditor20250728: (x) => x.CacheControl,
                webSearchTool20250305: (x) => x.CacheControl,
                webFetchTool20250910: (x) => x.CacheControl,
                webSearchTool20260209: (x) => x.CacheControl,
                webFetchTool20260209: (x) => x.CacheControl,
                searchToolBm25_20251119: (x) => x.CacheControl,
                searchToolRegex20251119: (x) => x.CacheControl
            );
        }
    }

    public bool? DeferLoading
    {
        get
        {
            return Match<bool?>(
                tool: (x) => x.DeferLoading,
                bash20250124: (x) => x.DeferLoading,
                codeExecutionTool20250522: (x) => x.DeferLoading,
                codeExecutionTool20250825: (x) => x.DeferLoading,
                codeExecutionTool20260120: (x) => x.DeferLoading,
                memoryTool20250818: (x) => x.DeferLoading,
                textEditor20250124: (x) => x.DeferLoading,
                textEditor20250429: (x) => x.DeferLoading,
                textEditor20250728: (x) => x.DeferLoading,
                webSearchTool20250305: (x) => x.DeferLoading,
                webFetchTool20250910: (x) => x.DeferLoading,
                webSearchTool20260209: (x) => x.DeferLoading,
                webFetchTool20260209: (x) => x.DeferLoading,
                searchToolBm25_20251119: (x) => x.DeferLoading,
                searchToolRegex20251119: (x) => x.DeferLoading
            );
        }
    }

    public bool? Strict
    {
        get
        {
            return Match<bool?>(
                tool: (x) => x.Strict,
                bash20250124: (x) => x.Strict,
                codeExecutionTool20250522: (x) => x.Strict,
                codeExecutionTool20250825: (x) => x.Strict,
                codeExecutionTool20260120: (x) => x.Strict,
                memoryTool20250818: (x) => x.Strict,
                textEditor20250124: (x) => x.Strict,
                textEditor20250429: (x) => x.Strict,
                textEditor20250728: (x) => x.Strict,
                webSearchTool20250305: (x) => x.Strict,
                webFetchTool20250910: (x) => x.Strict,
                webSearchTool20260209: (x) => x.Strict,
                webFetchTool20260209: (x) => x.Strict,
                searchToolBm25_20251119: (x) => x.Strict,
                searchToolRegex20251119: (x) => x.Strict
            );
        }
    }

    public long? MaxUses
    {
        get
        {
            return Match<long?>(
                tool: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                codeExecutionTool20260120: (_) => null,
                memoryTool20250818: (_) => null,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (x) => x.MaxUses,
                webFetchTool20250910: (x) => x.MaxUses,
                webSearchTool20260209: (x) => x.MaxUses,
                webFetchTool20260209: (x) => x.MaxUses,
                searchToolBm25_20251119: (_) => null,
                searchToolRegex20251119: (_) => null
            );
        }
    }

    public CitationsConfigParam? Citations
    {
        get
        {
            return Match<CitationsConfigParam?>(
                tool: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                codeExecutionTool20260120: (_) => null,
                memoryTool20250818: (_) => null,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (_) => null,
                webFetchTool20250910: (x) => x.Citations,
                webSearchTool20260209: (_) => null,
                webFetchTool20260209: (x) => x.Citations,
                searchToolBm25_20251119: (_) => null,
                searchToolRegex20251119: (_) => null
            );
        }
    }

    public long? MaxContentTokens
    {
        get
        {
            return Match<long?>(
                tool: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                codeExecutionTool20260120: (_) => null,
                memoryTool20250818: (_) => null,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (_) => null,
                webFetchTool20250910: (x) => x.MaxContentTokens,
                webSearchTool20260209: (_) => null,
                webFetchTool20260209: (x) => x.MaxContentTokens,
                searchToolBm25_20251119: (_) => null,
                searchToolRegex20251119: (_) => null
            );
        }
    }

    public ToolUnion(Tool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(ToolBash20250124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(CodeExecutionTool20250522 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(CodeExecutionTool20250825 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(ToolUnionCodeExecutionTool20260120 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(MemoryTool20250818 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(ToolTextEditor20250124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(ToolTextEditor20250429 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(ToolTextEditor20250728 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(WebSearchTool20250305 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(WebFetchTool20250910 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(ToolUnionWebSearchTool20260209 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(ToolUnionWebFetchTool20260209 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(ToolSearchToolBm25_20251119 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(ToolSearchToolRegex20251119 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUnion(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Tool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool(out var value)) {
    ///     // `value` is of type `Tool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool([NotNullWhen(true)] out Tool? value)
    {
        value = this.Value as Tool;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolBash20250124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBash20250124(out var value)) {
    ///     // `value` is of type `ToolBash20250124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBash20250124([NotNullWhen(true)] out ToolBash20250124? value)
    {
        value = this.Value as ToolBash20250124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionTool20250522"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionTool20250522(out var value)) {
    ///     // `value` is of type `CodeExecutionTool20250522`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionTool20250522(
        [NotNullWhen(true)] out CodeExecutionTool20250522? value
    )
    {
        value = this.Value as CodeExecutionTool20250522;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionTool20250825"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionTool20250825(out var value)) {
    ///     // `value` is of type `CodeExecutionTool20250825`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionTool20250825(
        [NotNullWhen(true)] out CodeExecutionTool20250825? value
    )
    {
        value = this.Value as CodeExecutionTool20250825;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolUnionCodeExecutionTool20260120"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionTool20260120(out var value)) {
    ///     // `value` is of type `ToolUnionCodeExecutionTool20260120`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionTool20260120(
        [NotNullWhen(true)] out ToolUnionCodeExecutionTool20260120? value
    )
    {
        value = this.Value as ToolUnionCodeExecutionTool20260120;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MemoryTool20250818"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMemoryTool20250818(out var value)) {
    ///     // `value` is of type `MemoryTool20250818`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMemoryTool20250818([NotNullWhen(true)] out MemoryTool20250818? value)
    {
        value = this.Value as MemoryTool20250818;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolTextEditor20250124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditor20250124(out var value)) {
    ///     // `value` is of type `ToolTextEditor20250124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditor20250124([NotNullWhen(true)] out ToolTextEditor20250124? value)
    {
        value = this.Value as ToolTextEditor20250124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolTextEditor20250429"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditor20250429(out var value)) {
    ///     // `value` is of type `ToolTextEditor20250429`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditor20250429([NotNullWhen(true)] out ToolTextEditor20250429? value)
    {
        value = this.Value as ToolTextEditor20250429;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolTextEditor20250728"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditor20250728(out var value)) {
    ///     // `value` is of type `ToolTextEditor20250728`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditor20250728([NotNullWhen(true)] out ToolTextEditor20250728? value)
    {
        value = this.Value as ToolTextEditor20250728;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebSearchTool20250305"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebSearchTool20250305(out var value)) {
    ///     // `value` is of type `WebSearchTool20250305`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebSearchTool20250305([NotNullWhen(true)] out WebSearchTool20250305? value)
    {
        value = this.Value as WebSearchTool20250305;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchTool20250910"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchTool20250910(out var value)) {
    ///     // `value` is of type `WebFetchTool20250910`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchTool20250910([NotNullWhen(true)] out WebFetchTool20250910? value)
    {
        value = this.Value as WebFetchTool20250910;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolUnionWebSearchTool20260209"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebSearchTool20260209(out var value)) {
    ///     // `value` is of type `ToolUnionWebSearchTool20260209`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebSearchTool20260209(
        [NotNullWhen(true)] out ToolUnionWebSearchTool20260209? value
    )
    {
        value = this.Value as ToolUnionWebSearchTool20260209;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolUnionWebFetchTool20260209"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchTool20260209(out var value)) {
    ///     // `value` is of type `ToolUnionWebFetchTool20260209`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchTool20260209(
        [NotNullWhen(true)] out ToolUnionWebFetchTool20260209? value
    )
    {
        value = this.Value as ToolUnionWebFetchTool20260209;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolSearchToolBm25_20251119"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSearchToolBm25_20251119(out var value)) {
    ///     // `value` is of type `ToolSearchToolBm25_20251119`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSearchToolBm25_20251119(
        [NotNullWhen(true)] out ToolSearchToolBm25_20251119? value
    )
    {
        value = this.Value as ToolSearchToolBm25_20251119;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolSearchToolRegex20251119"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSearchToolRegex20251119(out var value)) {
    ///     // `value` is of type `ToolSearchToolRegex20251119`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSearchToolRegex20251119(
        [NotNullWhen(true)] out ToolSearchToolRegex20251119? value
    )
    {
        value = this.Value as ToolSearchToolRegex20251119;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Tool value) => {...},
    ///     (ToolBash20250124 value) => {...},
    ///     (CodeExecutionTool20250522 value) => {...},
    ///     (CodeExecutionTool20250825 value) => {...},
    ///     (ToolUnionCodeExecutionTool20260120 value) => {...},
    ///     (MemoryTool20250818 value) => {...},
    ///     (ToolTextEditor20250124 value) => {...},
    ///     (ToolTextEditor20250429 value) => {...},
    ///     (ToolTextEditor20250728 value) => {...},
    ///     (WebSearchTool20250305 value) => {...},
    ///     (WebFetchTool20250910 value) => {...},
    ///     (ToolUnionWebSearchTool20260209 value) => {...},
    ///     (ToolUnionWebFetchTool20260209 value) => {...},
    ///     (ToolSearchToolBm25_20251119 value) => {...},
    ///     (ToolSearchToolRegex20251119 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Tool> tool,
        System::Action<ToolBash20250124> bash20250124,
        System::Action<CodeExecutionTool20250522> codeExecutionTool20250522,
        System::Action<CodeExecutionTool20250825> codeExecutionTool20250825,
        System::Action<ToolUnionCodeExecutionTool20260120> codeExecutionTool20260120,
        System::Action<MemoryTool20250818> memoryTool20250818,
        System::Action<ToolTextEditor20250124> textEditor20250124,
        System::Action<ToolTextEditor20250429> textEditor20250429,
        System::Action<ToolTextEditor20250728> textEditor20250728,
        System::Action<WebSearchTool20250305> webSearchTool20250305,
        System::Action<WebFetchTool20250910> webFetchTool20250910,
        System::Action<ToolUnionWebSearchTool20260209> webSearchTool20260209,
        System::Action<ToolUnionWebFetchTool20260209> webFetchTool20260209,
        System::Action<ToolSearchToolBm25_20251119> searchToolBm25_20251119,
        System::Action<ToolSearchToolRegex20251119> searchToolRegex20251119
    )
    {
        switch (this.Value)
        {
            case Tool value:
                tool(value);
                break;
            case ToolBash20250124 value:
                bash20250124(value);
                break;
            case CodeExecutionTool20250522 value:
                codeExecutionTool20250522(value);
                break;
            case CodeExecutionTool20250825 value:
                codeExecutionTool20250825(value);
                break;
            case ToolUnionCodeExecutionTool20260120 value:
                codeExecutionTool20260120(value);
                break;
            case MemoryTool20250818 value:
                memoryTool20250818(value);
                break;
            case ToolTextEditor20250124 value:
                textEditor20250124(value);
                break;
            case ToolTextEditor20250429 value:
                textEditor20250429(value);
                break;
            case ToolTextEditor20250728 value:
                textEditor20250728(value);
                break;
            case WebSearchTool20250305 value:
                webSearchTool20250305(value);
                break;
            case WebFetchTool20250910 value:
                webFetchTool20250910(value);
                break;
            case ToolUnionWebSearchTool20260209 value:
                webSearchTool20260209(value);
                break;
            case ToolUnionWebFetchTool20260209 value:
                webFetchTool20260209(value);
                break;
            case ToolSearchToolBm25_20251119 value:
                searchToolBm25_20251119(value);
                break;
            case ToolSearchToolRegex20251119 value:
                searchToolRegex20251119(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolUnion"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Tool value) => {...},
    ///     (ToolBash20250124 value) => {...},
    ///     (CodeExecutionTool20250522 value) => {...},
    ///     (CodeExecutionTool20250825 value) => {...},
    ///     (ToolUnionCodeExecutionTool20260120 value) => {...},
    ///     (MemoryTool20250818 value) => {...},
    ///     (ToolTextEditor20250124 value) => {...},
    ///     (ToolTextEditor20250429 value) => {...},
    ///     (ToolTextEditor20250728 value) => {...},
    ///     (WebSearchTool20250305 value) => {...},
    ///     (WebFetchTool20250910 value) => {...},
    ///     (ToolUnionWebSearchTool20260209 value) => {...},
    ///     (ToolUnionWebFetchTool20260209 value) => {...},
    ///     (ToolSearchToolBm25_20251119 value) => {...},
    ///     (ToolSearchToolRegex20251119 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Tool, T> tool,
        System::Func<ToolBash20250124, T> bash20250124,
        System::Func<CodeExecutionTool20250522, T> codeExecutionTool20250522,
        System::Func<CodeExecutionTool20250825, T> codeExecutionTool20250825,
        System::Func<ToolUnionCodeExecutionTool20260120, T> codeExecutionTool20260120,
        System::Func<MemoryTool20250818, T> memoryTool20250818,
        System::Func<ToolTextEditor20250124, T> textEditor20250124,
        System::Func<ToolTextEditor20250429, T> textEditor20250429,
        System::Func<ToolTextEditor20250728, T> textEditor20250728,
        System::Func<WebSearchTool20250305, T> webSearchTool20250305,
        System::Func<WebFetchTool20250910, T> webFetchTool20250910,
        System::Func<ToolUnionWebSearchTool20260209, T> webSearchTool20260209,
        System::Func<ToolUnionWebFetchTool20260209, T> webFetchTool20260209,
        System::Func<ToolSearchToolBm25_20251119, T> searchToolBm25_20251119,
        System::Func<ToolSearchToolRegex20251119, T> searchToolRegex20251119
    )
    {
        return this.Value switch
        {
            Tool value => tool(value),
            ToolBash20250124 value => bash20250124(value),
            CodeExecutionTool20250522 value => codeExecutionTool20250522(value),
            CodeExecutionTool20250825 value => codeExecutionTool20250825(value),
            ToolUnionCodeExecutionTool20260120 value => codeExecutionTool20260120(value),
            MemoryTool20250818 value => memoryTool20250818(value),
            ToolTextEditor20250124 value => textEditor20250124(value),
            ToolTextEditor20250429 value => textEditor20250429(value),
            ToolTextEditor20250728 value => textEditor20250728(value),
            WebSearchTool20250305 value => webSearchTool20250305(value),
            WebFetchTool20250910 value => webFetchTool20250910(value),
            ToolUnionWebSearchTool20260209 value => webSearchTool20260209(value),
            ToolUnionWebFetchTool20260209 value => webFetchTool20260209(value),
            ToolSearchToolBm25_20251119 value => searchToolBm25_20251119(value),
            ToolSearchToolRegex20251119 value => searchToolRegex20251119(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolUnion"
            ),
        };
    }

    public static implicit operator ToolUnion(Tool value) => new(value);

    public static implicit operator ToolUnion(ToolBash20250124 value) => new(value);

    public static implicit operator ToolUnion(CodeExecutionTool20250522 value) => new(value);

    public static implicit operator ToolUnion(CodeExecutionTool20250825 value) => new(value);

    public static implicit operator ToolUnion(ToolUnionCodeExecutionTool20260120 value) =>
        new(value);

    public static implicit operator ToolUnion(MemoryTool20250818 value) => new(value);

    public static implicit operator ToolUnion(ToolTextEditor20250124 value) => new(value);

    public static implicit operator ToolUnion(ToolTextEditor20250429 value) => new(value);

    public static implicit operator ToolUnion(ToolTextEditor20250728 value) => new(value);

    public static implicit operator ToolUnion(WebSearchTool20250305 value) => new(value);

    public static implicit operator ToolUnion(WebFetchTool20250910 value) => new(value);

    public static implicit operator ToolUnion(ToolUnionWebSearchTool20260209 value) => new(value);

    public static implicit operator ToolUnion(ToolUnionWebFetchTool20260209 value) => new(value);

    public static implicit operator ToolUnion(ToolSearchToolBm25_20251119 value) => new(value);

    public static implicit operator ToolUnion(ToolSearchToolRegex20251119 value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of ToolUnion");
        }
        this.Switch(
            (tool) => tool.Validate(),
            (bash20250124) => bash20250124.Validate(),
            (codeExecutionTool20250522) => codeExecutionTool20250522.Validate(),
            (codeExecutionTool20250825) => codeExecutionTool20250825.Validate(),
            (codeExecutionTool20260120) => codeExecutionTool20260120.Validate(),
            (memoryTool20250818) => memoryTool20250818.Validate(),
            (textEditor20250124) => textEditor20250124.Validate(),
            (textEditor20250429) => textEditor20250429.Validate(),
            (textEditor20250728) => textEditor20250728.Validate(),
            (webSearchTool20250305) => webSearchTool20250305.Validate(),
            (webFetchTool20250910) => webFetchTool20250910.Validate(),
            (webSearchTool20260209) => webSearchTool20260209.Validate(),
            (webFetchTool20260209) => webFetchTool20260209.Validate(),
            (searchToolBm25_20251119) => searchToolBm25_20251119.Validate(),
            (searchToolRegex20251119) => searchToolRegex20251119.Validate()
        );
    }

    public virtual bool Equals(ToolUnion? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Tool _ => 0,
            ToolBash20250124 _ => 1,
            CodeExecutionTool20250522 _ => 2,
            CodeExecutionTool20250825 _ => 3,
            ToolUnionCodeExecutionTool20260120 _ => 4,
            MemoryTool20250818 _ => 5,
            ToolTextEditor20250124 _ => 6,
            ToolTextEditor20250429 _ => 7,
            ToolTextEditor20250728 _ => 8,
            WebSearchTool20250305 _ => 9,
            WebFetchTool20250910 _ => 10,
            ToolUnionWebSearchTool20260209 _ => 11,
            ToolUnionWebFetchTool20260209 _ => 12,
            ToolSearchToolBm25_20251119 _ => 13,
            ToolSearchToolRegex20251119 _ => 14,
            _ => -1,
        };
    }
}

sealed class ToolUnionConverter : JsonConverter<ToolUnion>
{
    public override ToolUnion? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Tool>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolBash20250124>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CodeExecutionTool20250522>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CodeExecutionTool20250825>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolUnionCodeExecutionTool20260120>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<MemoryTool20250818>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250124>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250429>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250728>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchTool20250305>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebFetchTool20250910>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolUnionWebSearchTool20260209>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolUnionWebFetchTool20260209>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolSearchToolBm25_20251119>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolSearchToolRegex20251119>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolUnion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Code execution tool with REPL state persistence (daemon mode + gVisor checkpoint).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ToolUnionCodeExecutionTool20260120,
        ToolUnionCodeExecutionTool20260120FromRaw
    >)
)]
public sealed record class ToolUnionCodeExecutionTool20260120 : JsonModel
{
    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<
        ApiEnum<string, ToolUnionCodeExecutionTool20260120AllowedCaller>
    >? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ToolUnionCodeExecutionTool20260120AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, ToolUnionCodeExecutionTool20260120AllowedCaller>
            >?>("allowed_callers", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <summary>
    /// If true, tool will not be included in initial system prompt. Only loaded when
    /// returned via tool_reference from tool search.
    /// </summary>
    public bool? DeferLoading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defer_loading");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defer_loading", value);
        }
    }

    /// <summary>
    /// When true, guarantees schema validation on tool names and inputs
    /// </summary>
    public bool? Strict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("strict", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("code_execution")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_20260120")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        this.CacheControl?.Validate();
        _ = this.DeferLoading;
        _ = this.Strict;
    }

    public ToolUnionCodeExecutionTool20260120()
    {
        this.Name = JsonSerializer.SerializeToElement("code_execution");
        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolUnionCodeExecutionTool20260120(
        ToolUnionCodeExecutionTool20260120 toolUnionCodeExecutionTool20260120
    )
        : base(toolUnionCodeExecutionTool20260120) { }
#pragma warning restore CS8618

    public ToolUnionCodeExecutionTool20260120(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("code_execution");
        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolUnionCodeExecutionTool20260120(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolUnionCodeExecutionTool20260120FromRaw.FromRawUnchecked"/>
    public static ToolUnionCodeExecutionTool20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolUnionCodeExecutionTool20260120FromRaw : IFromRawJson<ToolUnionCodeExecutionTool20260120>
{
    /// <inheritdoc/>
    public ToolUnionCodeExecutionTool20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolUnionCodeExecutionTool20260120.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolUnionCodeExecutionTool20260120AllowedCallerConverter))]
public enum ToolUnionCodeExecutionTool20260120AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class ToolUnionCodeExecutionTool20260120AllowedCallerConverter
    : JsonConverter<ToolUnionCodeExecutionTool20260120AllowedCaller>
{
    public override ToolUnionCodeExecutionTool20260120AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => ToolUnionCodeExecutionTool20260120AllowedCaller.Direct,
            "code_execution_20250825" =>
                ToolUnionCodeExecutionTool20260120AllowedCaller.CodeExecution20250825,
            _ => (ToolUnionCodeExecutionTool20260120AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolUnionCodeExecutionTool20260120AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolUnionCodeExecutionTool20260120AllowedCaller.Direct => "direct",
                ToolUnionCodeExecutionTool20260120AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ToolUnionWebSearchTool20260209,
        ToolUnionWebSearchTool20260209FromRaw
    >)
)]
public sealed record class ToolUnionWebSearchTool20260209 : JsonModel
{
    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<
        ApiEnum<string, ToolUnionWebSearchTool20260209AllowedCaller>
    >? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ToolUnionWebSearchTool20260209AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, ToolUnionWebSearchTool20260209AllowedCaller>
            >?>("allowed_callers", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// If provided, only these domains will be included in results. Cannot be used
    /// alongside `blocked_domains`.
    /// </summary>
    public IReadOnlyList<string>? AllowedDomains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowed_domains");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If provided, these domains will never appear in results. Cannot be used alongside `allowed_domains`.
    /// </summary>
    public IReadOnlyList<string>? BlockedDomains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("blocked_domains");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "blocked_domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <summary>
    /// If true, tool will not be included in initial system prompt. Only loaded when
    /// returned via tool_reference from tool search.
    /// </summary>
    public bool? DeferLoading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defer_loading");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defer_loading", value);
        }
    }

    /// <summary>
    /// Maximum number of times the tool can be used in the API request.
    /// </summary>
    public long? MaxUses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_uses");
        }
        init { this._rawData.Set("max_uses", value); }
    }

    /// <summary>
    /// When true, guarantees schema validation on tool names and inputs
    /// </summary>
    public bool? Strict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("strict", value);
        }
    }

    /// <summary>
    /// Parameters for the user's location. Used to provide more relevant search results.
    /// </summary>
    public ToolUnionWebSearchTool20260209UserLocation? UserLocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ToolUnionWebSearchTool20260209UserLocation>(
                "user_location"
            );
        }
        init { this._rawData.Set("user_location", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("web_search")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_search_20260209")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        _ = this.AllowedDomains;
        _ = this.BlockedDomains;
        this.CacheControl?.Validate();
        _ = this.DeferLoading;
        _ = this.MaxUses;
        _ = this.Strict;
        this.UserLocation?.Validate();
    }

    public ToolUnionWebSearchTool20260209()
    {
        this.Name = JsonSerializer.SerializeToElement("web_search");
        this.Type = JsonSerializer.SerializeToElement("web_search_20260209");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolUnionWebSearchTool20260209(
        ToolUnionWebSearchTool20260209 toolUnionWebSearchTool20260209
    )
        : base(toolUnionWebSearchTool20260209) { }
#pragma warning restore CS8618

    public ToolUnionWebSearchTool20260209(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("web_search");
        this.Type = JsonSerializer.SerializeToElement("web_search_20260209");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolUnionWebSearchTool20260209(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolUnionWebSearchTool20260209FromRaw.FromRawUnchecked"/>
    public static ToolUnionWebSearchTool20260209 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolUnionWebSearchTool20260209FromRaw : IFromRawJson<ToolUnionWebSearchTool20260209>
{
    /// <inheritdoc/>
    public ToolUnionWebSearchTool20260209 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolUnionWebSearchTool20260209.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolUnionWebSearchTool20260209AllowedCallerConverter))]
public enum ToolUnionWebSearchTool20260209AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class ToolUnionWebSearchTool20260209AllowedCallerConverter
    : JsonConverter<ToolUnionWebSearchTool20260209AllowedCaller>
{
    public override ToolUnionWebSearchTool20260209AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => ToolUnionWebSearchTool20260209AllowedCaller.Direct,
            "code_execution_20250825" =>
                ToolUnionWebSearchTool20260209AllowedCaller.CodeExecution20250825,
            _ => (ToolUnionWebSearchTool20260209AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolUnionWebSearchTool20260209AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolUnionWebSearchTool20260209AllowedCaller.Direct => "direct",
                ToolUnionWebSearchTool20260209AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Parameters for the user's location. Used to provide more relevant search results.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ToolUnionWebSearchTool20260209UserLocation,
        ToolUnionWebSearchTool20260209UserLocationFromRaw
    >)
)]
public sealed record class ToolUnionWebSearchTool20260209UserLocation : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The city of the user.
    /// </summary>
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The two letter [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// of the user.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The region of the user.
    /// </summary>
    public string? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// The [IANA timezone](https://nodatime.org/TimeZones) of the user.
    /// </summary>
    public string? Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timezone");
        }
        init { this._rawData.Set("timezone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("approximate")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.City;
        _ = this.Country;
        _ = this.Region;
        _ = this.Timezone;
    }

    public ToolUnionWebSearchTool20260209UserLocation()
    {
        this.Type = JsonSerializer.SerializeToElement("approximate");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolUnionWebSearchTool20260209UserLocation(
        ToolUnionWebSearchTool20260209UserLocation toolUnionWebSearchTool20260209UserLocation
    )
        : base(toolUnionWebSearchTool20260209UserLocation) { }
#pragma warning restore CS8618

    public ToolUnionWebSearchTool20260209UserLocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("approximate");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolUnionWebSearchTool20260209UserLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolUnionWebSearchTool20260209UserLocationFromRaw.FromRawUnchecked"/>
    public static ToolUnionWebSearchTool20260209UserLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolUnionWebSearchTool20260209UserLocationFromRaw
    : IFromRawJson<ToolUnionWebSearchTool20260209UserLocation>
{
    /// <inheritdoc/>
    public ToolUnionWebSearchTool20260209UserLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolUnionWebSearchTool20260209UserLocation.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ToolUnionWebFetchTool20260209, ToolUnionWebFetchTool20260209FromRaw>)
)]
public sealed record class ToolUnionWebFetchTool20260209 : JsonModel
{
    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<
        ApiEnum<string, ToolUnionWebFetchTool20260209AllowedCaller>
    >? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ToolUnionWebFetchTool20260209AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, ToolUnionWebFetchTool20260209AllowedCaller>
            >?>("allowed_callers", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// List of domains to allow fetching from
    /// </summary>
    public IReadOnlyList<string>? AllowedDomains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowed_domains");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of domains to block fetching from
    /// </summary>
    public IReadOnlyList<string>? BlockedDomains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("blocked_domains");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "blocked_domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <summary>
    /// Citations configuration for fetched documents. Citations are disabled by default.
    /// </summary>
    public CitationsConfigParam? Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CitationsConfigParam>("citations");
        }
        init { this._rawData.Set("citations", value); }
    }

    /// <summary>
    /// If true, tool will not be included in initial system prompt. Only loaded when
    /// returned via tool_reference from tool search.
    /// </summary>
    public bool? DeferLoading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defer_loading");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defer_loading", value);
        }
    }

    /// <summary>
    /// Maximum number of tokens used by including web page text content in the context.
    /// The limit is approximate and does not apply to binary content such as PDFs.
    /// </summary>
    public long? MaxContentTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_content_tokens");
        }
        init { this._rawData.Set("max_content_tokens", value); }
    }

    /// <summary>
    /// Maximum number of times the tool can be used in the API request.
    /// </summary>
    public long? MaxUses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_uses");
        }
        init { this._rawData.Set("max_uses", value); }
    }

    /// <summary>
    /// When true, guarantees schema validation on tool names and inputs
    /// </summary>
    public bool? Strict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("strict", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("web_fetch")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_fetch_20260209")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        _ = this.AllowedDomains;
        _ = this.BlockedDomains;
        this.CacheControl?.Validate();
        this.Citations?.Validate();
        _ = this.DeferLoading;
        _ = this.MaxContentTokens;
        _ = this.MaxUses;
        _ = this.Strict;
    }

    public ToolUnionWebFetchTool20260209()
    {
        this.Name = JsonSerializer.SerializeToElement("web_fetch");
        this.Type = JsonSerializer.SerializeToElement("web_fetch_20260209");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolUnionWebFetchTool20260209(
        ToolUnionWebFetchTool20260209 toolUnionWebFetchTool20260209
    )
        : base(toolUnionWebFetchTool20260209) { }
#pragma warning restore CS8618

    public ToolUnionWebFetchTool20260209(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("web_fetch");
        this.Type = JsonSerializer.SerializeToElement("web_fetch_20260209");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolUnionWebFetchTool20260209(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolUnionWebFetchTool20260209FromRaw.FromRawUnchecked"/>
    public static ToolUnionWebFetchTool20260209 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolUnionWebFetchTool20260209FromRaw : IFromRawJson<ToolUnionWebFetchTool20260209>
{
    /// <inheritdoc/>
    public ToolUnionWebFetchTool20260209 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolUnionWebFetchTool20260209.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolUnionWebFetchTool20260209AllowedCallerConverter))]
public enum ToolUnionWebFetchTool20260209AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class ToolUnionWebFetchTool20260209AllowedCallerConverter
    : JsonConverter<ToolUnionWebFetchTool20260209AllowedCaller>
{
    public override ToolUnionWebFetchTool20260209AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => ToolUnionWebFetchTool20260209AllowedCaller.Direct,
            "code_execution_20250825" =>
                ToolUnionWebFetchTool20260209AllowedCaller.CodeExecution20250825,
            _ => (ToolUnionWebFetchTool20260209AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolUnionWebFetchTool20260209AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolUnionWebFetchTool20260209AllowedCaller.Direct => "direct",
                ToolUnionWebFetchTool20260209AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
