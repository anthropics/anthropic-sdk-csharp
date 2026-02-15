using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Configuration for a group of tools from an MCP server.
///
/// <para>Allows configuring enabled status and defer_loading for all tools from
/// an MCP server, with optional per-tool overrides.</para>
/// </summary>
[JsonConverter(typeof(BetaToolUnionConverter))]
public record class BetaToolUnion : ModelBase
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

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<BetaCacheControlEphemeral?>(
                betaTool: (x) => x.CacheControl,
                bash20241022: (x) => x.CacheControl,
                bash20250124: (x) => x.CacheControl,
                codeExecutionTool20250522: (x) => x.CacheControl,
                codeExecutionTool20250825: (x) => x.CacheControl,
                computerUse20241022: (x) => x.CacheControl,
                memoryTool20250818: (x) => x.CacheControl,
                computerUse20250124: (x) => x.CacheControl,
                textEditor20241022: (x) => x.CacheControl,
                computerUse20251124: (x) => x.CacheControl,
                textEditor20250124: (x) => x.CacheControl,
                textEditor20250429: (x) => x.CacheControl,
                textEditor20250728: (x) => x.CacheControl,
                webSearchTool20250305: (x) => x.CacheControl,
                webFetchTool20250910: (x) => x.CacheControl,
                searchToolBm25_20251119: (x) => x.CacheControl,
                searchToolRegex20251119: (x) => x.CacheControl,
                mcpToolset: (x) => x.CacheControl
            );
        }
    }

    public bool? DeferLoading
    {
        get
        {
            return Match<bool?>(
                betaTool: (x) => x.DeferLoading,
                bash20241022: (x) => x.DeferLoading,
                bash20250124: (x) => x.DeferLoading,
                codeExecutionTool20250522: (x) => x.DeferLoading,
                codeExecutionTool20250825: (x) => x.DeferLoading,
                computerUse20241022: (x) => x.DeferLoading,
                memoryTool20250818: (x) => x.DeferLoading,
                computerUse20250124: (x) => x.DeferLoading,
                textEditor20241022: (x) => x.DeferLoading,
                computerUse20251124: (x) => x.DeferLoading,
                textEditor20250124: (x) => x.DeferLoading,
                textEditor20250429: (x) => x.DeferLoading,
                textEditor20250728: (x) => x.DeferLoading,
                webSearchTool20250305: (x) => x.DeferLoading,
                webFetchTool20250910: (x) => x.DeferLoading,
                searchToolBm25_20251119: (x) => x.DeferLoading,
                searchToolRegex20251119: (x) => x.DeferLoading,
                mcpToolset: (_) => null
            );
        }
    }

    public bool? Strict
    {
        get
        {
            return Match<bool?>(
                betaTool: (x) => x.Strict,
                bash20241022: (x) => x.Strict,
                bash20250124: (x) => x.Strict,
                codeExecutionTool20250522: (x) => x.Strict,
                codeExecutionTool20250825: (x) => x.Strict,
                computerUse20241022: (x) => x.Strict,
                memoryTool20250818: (x) => x.Strict,
                computerUse20250124: (x) => x.Strict,
                textEditor20241022: (x) => x.Strict,
                computerUse20251124: (x) => x.Strict,
                textEditor20250124: (x) => x.Strict,
                textEditor20250429: (x) => x.Strict,
                textEditor20250728: (x) => x.Strict,
                webSearchTool20250305: (x) => x.Strict,
                webFetchTool20250910: (x) => x.Strict,
                searchToolBm25_20251119: (x) => x.Strict,
                searchToolRegex20251119: (x) => x.Strict,
                mcpToolset: (_) => null
            );
        }
    }

    public long? DisplayHeightPx
    {
        get
        {
            return Match<long?>(
                betaTool: (_) => null,
                bash20241022: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                computerUse20241022: (x) => x.DisplayHeightPx,
                memoryTool20250818: (_) => null,
                computerUse20250124: (x) => x.DisplayHeightPx,
                textEditor20241022: (_) => null,
                computerUse20251124: (x) => x.DisplayHeightPx,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (_) => null,
                webFetchTool20250910: (_) => null,
                searchToolBm25_20251119: (_) => null,
                searchToolRegex20251119: (_) => null,
                mcpToolset: (_) => null
            );
        }
    }

    public long? DisplayWidthPx
    {
        get
        {
            return Match<long?>(
                betaTool: (_) => null,
                bash20241022: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                computerUse20241022: (x) => x.DisplayWidthPx,
                memoryTool20250818: (_) => null,
                computerUse20250124: (x) => x.DisplayWidthPx,
                textEditor20241022: (_) => null,
                computerUse20251124: (x) => x.DisplayWidthPx,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (_) => null,
                webFetchTool20250910: (_) => null,
                searchToolBm25_20251119: (_) => null,
                searchToolRegex20251119: (_) => null,
                mcpToolset: (_) => null
            );
        }
    }

    public long? DisplayNumber
    {
        get
        {
            return Match<long?>(
                betaTool: (_) => null,
                bash20241022: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                computerUse20241022: (x) => x.DisplayNumber,
                memoryTool20250818: (_) => null,
                computerUse20250124: (x) => x.DisplayNumber,
                textEditor20241022: (_) => null,
                computerUse20251124: (x) => x.DisplayNumber,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (_) => null,
                webFetchTool20250910: (_) => null,
                searchToolBm25_20251119: (_) => null,
                searchToolRegex20251119: (_) => null,
                mcpToolset: (_) => null
            );
        }
    }

    public long? MaxUses
    {
        get
        {
            return Match<long?>(
                betaTool: (_) => null,
                bash20241022: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                computerUse20241022: (_) => null,
                memoryTool20250818: (_) => null,
                computerUse20250124: (_) => null,
                textEditor20241022: (_) => null,
                computerUse20251124: (_) => null,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (x) => x.MaxUses,
                webFetchTool20250910: (x) => x.MaxUses,
                searchToolBm25_20251119: (_) => null,
                searchToolRegex20251119: (_) => null,
                mcpToolset: (_) => null
            );
        }
    }

    public BetaToolUnion(BetaTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolBash20241022 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolBash20250124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaCodeExecutionTool20250522 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaCodeExecutionTool20250825 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolComputerUse20241022 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaMemoryTool20250818 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolComputerUse20250124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolTextEditor20241022 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolComputerUse20251124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolTextEditor20250124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolTextEditor20250429 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolTextEditor20250728 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaWebSearchTool20250305 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaWebFetchTool20250910 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolSearchToolBm25_20251119 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaToolSearchToolRegex20251119 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(BetaMcpToolset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUnion(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTool(out var value)) {
    ///     // `value` is of type `BetaTool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTool([NotNullWhen(true)] out BetaTool? value)
    {
        value = this.Value as BetaTool;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolBash20241022"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBash20241022(out var value)) {
    ///     // `value` is of type `BetaToolBash20241022`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBash20241022([NotNullWhen(true)] out BetaToolBash20241022? value)
    {
        value = this.Value as BetaToolBash20241022;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolBash20250124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBash20250124(out var value)) {
    ///     // `value` is of type `BetaToolBash20250124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBash20250124([NotNullWhen(true)] out BetaToolBash20250124? value)
    {
        value = this.Value as BetaToolBash20250124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCodeExecutionTool20250522"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionTool20250522(out var value)) {
    ///     // `value` is of type `BetaCodeExecutionTool20250522`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionTool20250522(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250522? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250522;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCodeExecutionTool20250825"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionTool20250825(out var value)) {
    ///     // `value` is of type `BetaCodeExecutionTool20250825`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionTool20250825(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250825? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250825;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolComputerUse20241022"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComputerUse20241022(out var value)) {
    ///     // `value` is of type `BetaToolComputerUse20241022`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComputerUse20241022(
        [NotNullWhen(true)] out BetaToolComputerUse20241022? value
    )
    {
        value = this.Value as BetaToolComputerUse20241022;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMemoryTool20250818"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMemoryTool20250818(out var value)) {
    ///     // `value` is of type `BetaMemoryTool20250818`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMemoryTool20250818([NotNullWhen(true)] out BetaMemoryTool20250818? value)
    {
        value = this.Value as BetaMemoryTool20250818;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolComputerUse20250124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComputerUse20250124(out var value)) {
    ///     // `value` is of type `BetaToolComputerUse20250124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComputerUse20250124(
        [NotNullWhen(true)] out BetaToolComputerUse20250124? value
    )
    {
        value = this.Value as BetaToolComputerUse20250124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolTextEditor20241022"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditor20241022(out var value)) {
    ///     // `value` is of type `BetaToolTextEditor20241022`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditor20241022([NotNullWhen(true)] out BetaToolTextEditor20241022? value)
    {
        value = this.Value as BetaToolTextEditor20241022;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolComputerUse20251124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComputerUse20251124(out var value)) {
    ///     // `value` is of type `BetaToolComputerUse20251124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComputerUse20251124(
        [NotNullWhen(true)] out BetaToolComputerUse20251124? value
    )
    {
        value = this.Value as BetaToolComputerUse20251124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolTextEditor20250124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditor20250124(out var value)) {
    ///     // `value` is of type `BetaToolTextEditor20250124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditor20250124([NotNullWhen(true)] out BetaToolTextEditor20250124? value)
    {
        value = this.Value as BetaToolTextEditor20250124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolTextEditor20250429"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditor20250429(out var value)) {
    ///     // `value` is of type `BetaToolTextEditor20250429`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditor20250429([NotNullWhen(true)] out BetaToolTextEditor20250429? value)
    {
        value = this.Value as BetaToolTextEditor20250429;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolTextEditor20250728"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditor20250728(out var value)) {
    ///     // `value` is of type `BetaToolTextEditor20250728`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditor20250728([NotNullWhen(true)] out BetaToolTextEditor20250728? value)
    {
        value = this.Value as BetaToolTextEditor20250728;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebSearchTool20250305"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebSearchTool20250305(out var value)) {
    ///     // `value` is of type `BetaWebSearchTool20250305`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebSearchTool20250305(
        [NotNullWhen(true)] out BetaWebSearchTool20250305? value
    )
    {
        value = this.Value as BetaWebSearchTool20250305;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchTool20250910"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchTool20250910(out var value)) {
    ///     // `value` is of type `BetaWebFetchTool20250910`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchTool20250910([NotNullWhen(true)] out BetaWebFetchTool20250910? value)
    {
        value = this.Value as BetaWebFetchTool20250910;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolSearchToolBm25_20251119"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSearchToolBm25_20251119(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolBm25_20251119`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSearchToolBm25_20251119(
        [NotNullWhen(true)] out BetaToolSearchToolBm25_20251119? value
    )
    {
        value = this.Value as BetaToolSearchToolBm25_20251119;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolSearchToolRegex20251119"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSearchToolRegex20251119(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolRegex20251119`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSearchToolRegex20251119(
        [NotNullWhen(true)] out BetaToolSearchToolRegex20251119? value
    )
    {
        value = this.Value as BetaToolSearchToolRegex20251119;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMcpToolset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpToolset(out var value)) {
    ///     // `value` is of type `BetaMcpToolset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpToolset([NotNullWhen(true)] out BetaMcpToolset? value)
    {
        value = this.Value as BetaMcpToolset;
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
    ///     (BetaTool value) => {...},
    ///     (BetaToolBash20241022 value) => {...},
    ///     (BetaToolBash20250124 value) => {...},
    ///     (BetaCodeExecutionTool20250522 value) => {...},
    ///     (BetaCodeExecutionTool20250825 value) => {...},
    ///     (BetaToolComputerUse20241022 value) => {...},
    ///     (BetaMemoryTool20250818 value) => {...},
    ///     (BetaToolComputerUse20250124 value) => {...},
    ///     (BetaToolTextEditor20241022 value) => {...},
    ///     (BetaToolComputerUse20251124 value) => {...},
    ///     (BetaToolTextEditor20250124 value) => {...},
    ///     (BetaToolTextEditor20250429 value) => {...},
    ///     (BetaToolTextEditor20250728 value) => {...},
    ///     (BetaWebSearchTool20250305 value) => {...},
    ///     (BetaWebFetchTool20250910 value) => {...},
    ///     (BetaToolSearchToolBm25_20251119 value) => {...},
    ///     (BetaToolSearchToolRegex20251119 value) => {...},
    ///     (BetaMcpToolset value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaTool> betaTool,
        System::Action<BetaToolBash20241022> bash20241022,
        System::Action<BetaToolBash20250124> bash20250124,
        System::Action<BetaCodeExecutionTool20250522> codeExecutionTool20250522,
        System::Action<BetaCodeExecutionTool20250825> codeExecutionTool20250825,
        System::Action<BetaToolComputerUse20241022> computerUse20241022,
        System::Action<BetaMemoryTool20250818> memoryTool20250818,
        System::Action<BetaToolComputerUse20250124> computerUse20250124,
        System::Action<BetaToolTextEditor20241022> textEditor20241022,
        System::Action<BetaToolComputerUse20251124> computerUse20251124,
        System::Action<BetaToolTextEditor20250124> textEditor20250124,
        System::Action<BetaToolTextEditor20250429> textEditor20250429,
        System::Action<BetaToolTextEditor20250728> textEditor20250728,
        System::Action<BetaWebSearchTool20250305> webSearchTool20250305,
        System::Action<BetaWebFetchTool20250910> webFetchTool20250910,
        System::Action<BetaToolSearchToolBm25_20251119> searchToolBm25_20251119,
        System::Action<BetaToolSearchToolRegex20251119> searchToolRegex20251119,
        System::Action<BetaMcpToolset> mcpToolset
    )
    {
        switch (this.Value)
        {
            case BetaTool value:
                betaTool(value);
                break;
            case BetaToolBash20241022 value:
                bash20241022(value);
                break;
            case BetaToolBash20250124 value:
                bash20250124(value);
                break;
            case BetaCodeExecutionTool20250522 value:
                codeExecutionTool20250522(value);
                break;
            case BetaCodeExecutionTool20250825 value:
                codeExecutionTool20250825(value);
                break;
            case BetaToolComputerUse20241022 value:
                computerUse20241022(value);
                break;
            case BetaMemoryTool20250818 value:
                memoryTool20250818(value);
                break;
            case BetaToolComputerUse20250124 value:
                computerUse20250124(value);
                break;
            case BetaToolTextEditor20241022 value:
                textEditor20241022(value);
                break;
            case BetaToolComputerUse20251124 value:
                computerUse20251124(value);
                break;
            case BetaToolTextEditor20250124 value:
                textEditor20250124(value);
                break;
            case BetaToolTextEditor20250429 value:
                textEditor20250429(value);
                break;
            case BetaToolTextEditor20250728 value:
                textEditor20250728(value);
                break;
            case BetaWebSearchTool20250305 value:
                webSearchTool20250305(value);
                break;
            case BetaWebFetchTool20250910 value:
                webFetchTool20250910(value);
                break;
            case BetaToolSearchToolBm25_20251119 value:
                searchToolBm25_20251119(value);
                break;
            case BetaToolSearchToolRegex20251119 value:
                searchToolRegex20251119(value);
                break;
            case BetaMcpToolset value:
                mcpToolset(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolUnion"
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
    ///     (BetaTool value) => {...},
    ///     (BetaToolBash20241022 value) => {...},
    ///     (BetaToolBash20250124 value) => {...},
    ///     (BetaCodeExecutionTool20250522 value) => {...},
    ///     (BetaCodeExecutionTool20250825 value) => {...},
    ///     (BetaToolComputerUse20241022 value) => {...},
    ///     (BetaMemoryTool20250818 value) => {...},
    ///     (BetaToolComputerUse20250124 value) => {...},
    ///     (BetaToolTextEditor20241022 value) => {...},
    ///     (BetaToolComputerUse20251124 value) => {...},
    ///     (BetaToolTextEditor20250124 value) => {...},
    ///     (BetaToolTextEditor20250429 value) => {...},
    ///     (BetaToolTextEditor20250728 value) => {...},
    ///     (BetaWebSearchTool20250305 value) => {...},
    ///     (BetaWebFetchTool20250910 value) => {...},
    ///     (BetaToolSearchToolBm25_20251119 value) => {...},
    ///     (BetaToolSearchToolRegex20251119 value) => {...},
    ///     (BetaMcpToolset value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaTool, T> betaTool,
        System::Func<BetaToolBash20241022, T> bash20241022,
        System::Func<BetaToolBash20250124, T> bash20250124,
        System::Func<BetaCodeExecutionTool20250522, T> codeExecutionTool20250522,
        System::Func<BetaCodeExecutionTool20250825, T> codeExecutionTool20250825,
        System::Func<BetaToolComputerUse20241022, T> computerUse20241022,
        System::Func<BetaMemoryTool20250818, T> memoryTool20250818,
        System::Func<BetaToolComputerUse20250124, T> computerUse20250124,
        System::Func<BetaToolTextEditor20241022, T> textEditor20241022,
        System::Func<BetaToolComputerUse20251124, T> computerUse20251124,
        System::Func<BetaToolTextEditor20250124, T> textEditor20250124,
        System::Func<BetaToolTextEditor20250429, T> textEditor20250429,
        System::Func<BetaToolTextEditor20250728, T> textEditor20250728,
        System::Func<BetaWebSearchTool20250305, T> webSearchTool20250305,
        System::Func<BetaWebFetchTool20250910, T> webFetchTool20250910,
        System::Func<BetaToolSearchToolBm25_20251119, T> searchToolBm25_20251119,
        System::Func<BetaToolSearchToolRegex20251119, T> searchToolRegex20251119,
        System::Func<BetaMcpToolset, T> mcpToolset
    )
    {
        return this.Value switch
        {
            BetaTool value => betaTool(value),
            BetaToolBash20241022 value => bash20241022(value),
            BetaToolBash20250124 value => bash20250124(value),
            BetaCodeExecutionTool20250522 value => codeExecutionTool20250522(value),
            BetaCodeExecutionTool20250825 value => codeExecutionTool20250825(value),
            BetaToolComputerUse20241022 value => computerUse20241022(value),
            BetaMemoryTool20250818 value => memoryTool20250818(value),
            BetaToolComputerUse20250124 value => computerUse20250124(value),
            BetaToolTextEditor20241022 value => textEditor20241022(value),
            BetaToolComputerUse20251124 value => computerUse20251124(value),
            BetaToolTextEditor20250124 value => textEditor20250124(value),
            BetaToolTextEditor20250429 value => textEditor20250429(value),
            BetaToolTextEditor20250728 value => textEditor20250728(value),
            BetaWebSearchTool20250305 value => webSearchTool20250305(value),
            BetaWebFetchTool20250910 value => webFetchTool20250910(value),
            BetaToolSearchToolBm25_20251119 value => searchToolBm25_20251119(value),
            BetaToolSearchToolRegex20251119 value => searchToolRegex20251119(value),
            BetaMcpToolset value => mcpToolset(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolUnion"
            ),
        };
    }

    public static implicit operator BetaToolUnion(BetaTool value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolBash20241022 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolBash20250124 value) => new(value);

    public static implicit operator BetaToolUnion(BetaCodeExecutionTool20250522 value) =>
        new(value);

    public static implicit operator BetaToolUnion(BetaCodeExecutionTool20250825 value) =>
        new(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20241022 value) => new(value);

    public static implicit operator BetaToolUnion(BetaMemoryTool20250818 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20250124 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20241022 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20251124 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250124 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250429 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250728 value) => new(value);

    public static implicit operator BetaToolUnion(BetaWebSearchTool20250305 value) => new(value);

    public static implicit operator BetaToolUnion(BetaWebFetchTool20250910 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolSearchToolBm25_20251119 value) =>
        new(value);

    public static implicit operator BetaToolUnion(BetaToolSearchToolRegex20251119 value) =>
        new(value);

    public static implicit operator BetaToolUnion(BetaMcpToolset value) => new(value);

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
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolUnion"
            );
        }
        this.Switch(
            (betaTool) => betaTool.Validate(),
            (bash20241022) => bash20241022.Validate(),
            (bash20250124) => bash20250124.Validate(),
            (codeExecutionTool20250522) => codeExecutionTool20250522.Validate(),
            (codeExecutionTool20250825) => codeExecutionTool20250825.Validate(),
            (computerUse20241022) => computerUse20241022.Validate(),
            (memoryTool20250818) => memoryTool20250818.Validate(),
            (computerUse20250124) => computerUse20250124.Validate(),
            (textEditor20241022) => textEditor20241022.Validate(),
            (computerUse20251124) => computerUse20251124.Validate(),
            (textEditor20250124) => textEditor20250124.Validate(),
            (textEditor20250429) => textEditor20250429.Validate(),
            (textEditor20250728) => textEditor20250728.Validate(),
            (webSearchTool20250305) => webSearchTool20250305.Validate(),
            (webFetchTool20250910) => webFetchTool20250910.Validate(),
            (searchToolBm25_20251119) => searchToolBm25_20251119.Validate(),
            (searchToolRegex20251119) => searchToolRegex20251119.Validate(),
            (mcpToolset) => mcpToolset.Validate()
        );
    }

    public virtual bool Equals(BetaToolUnion? other) =>
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
            BetaTool _ => 0,
            BetaToolBash20241022 _ => 1,
            BetaToolBash20250124 _ => 2,
            BetaCodeExecutionTool20250522 _ => 3,
            BetaCodeExecutionTool20250825 _ => 4,
            BetaToolComputerUse20241022 _ => 5,
            BetaMemoryTool20250818 _ => 6,
            BetaToolComputerUse20250124 _ => 7,
            BetaToolTextEditor20241022 _ => 8,
            BetaToolComputerUse20251124 _ => 9,
            BetaToolTextEditor20250124 _ => 10,
            BetaToolTextEditor20250429 _ => 11,
            BetaToolTextEditor20250728 _ => 12,
            BetaWebSearchTool20250305 _ => 13,
            BetaWebFetchTool20250910 _ => 14,
            BetaToolSearchToolBm25_20251119 _ => 15,
            BetaToolSearchToolRegex20251119 _ => 16,
            BetaMcpToolset _ => 17,
            _ => -1,
        };
    }
}

sealed class BetaToolUnionConverter : JsonConverter<BetaToolUnion>
{
    public override BetaToolUnion? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTool>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20241022>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20250124>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250522>(
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
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250825>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20241022>(
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
            var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20250124>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20241022>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20251124>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250124>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250429>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250728>(
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
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchTool20250305>(
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
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchTool20250910>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolBm25_20251119>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolRegex20251119>(
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
            var deserialized = JsonSerializer.Deserialize<BetaMcpToolset>(element, options);
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
        BetaToolUnion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
