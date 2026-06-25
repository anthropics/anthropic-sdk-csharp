using System;
using System.Collections.Generic;

#pragma warning disable MEAI001 // [Experimental] APIs in Microsoft.Extensions.AI
#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Microsoft.Extensions.AI;

/// <summary>
/// Extension methods for selecting the search algorithm used by a <see cref="HostedToolSearchTool"/>.
/// </summary>
public static class HostedToolSearchToolExtensions
{
    /// <summary>
    /// Specializes the <paramref name="tool"/> to use the BM25 ranking algorithm when discovering
    /// deferred tools.
    /// </summary>
    /// <param name="tool">The tool to specialize.</param>
    /// <returns>
    /// An <see cref="AITool"/> that the Anthropic <see cref="IChatClient"/> maps to the
    /// <c>tool_search_tool_bm25</c> server tool.
    /// </returns>
    /// <remarks>
    /// The default algorithm for a plain <see cref="HostedToolSearchTool"/> is the regular-expression
    /// based <c>tool_search_tool_regex</c> server tool; use this method to opt into BM25 instead. The
    /// returned tool is only meaningful to the <see cref="IChatClient"/> returned by the Anthropic
    /// <c>AsIChatClient</c> extensions; other <see cref="IChatClient"/> implementations treat it as a
    /// plain <see cref="HostedToolSearchTool"/>.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="tool"/> is <see langword="null"/>.</exception>
    public static AITool AsBm25(this HostedToolSearchTool tool)
    {
        if (tool is null)
        {
            throw new ArgumentNullException(nameof(tool));
        }

        Bm25HostedToolSearchTool result =
            tool.AdditionalProperties is { } properties
                ? new Bm25HostedToolSearchTool(properties)
                : new Bm25HostedToolSearchTool();
        result.DeferredTools = tool.DeferredTools;
        result.Namespace = tool.Namespace;
        result.NamespaceDescription = tool.NamespaceDescription;
        return result;
    }

    /// <summary>
    /// Represents a <see cref="HostedToolSearchTool"/> specialized to use the BM25 ranking algorithm.
    /// </summary>
    internal sealed class Bm25HostedToolSearchTool : HostedToolSearchTool
    {
        public Bm25HostedToolSearchTool() { }

        public Bm25HostedToolSearchTool(IReadOnlyDictionary<string, object?> additionalProperties)
            : base(additionalProperties) { }
    }
}
