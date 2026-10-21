using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Connectors;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IConnectorService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConnectorServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConnectorService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get per-connector usage for a given day, with cursor-based pagination.
    ///
    /// <para>Returns connector usage metrics for the organization, sorted by connector
    /// name. Connector names are normalized from their various sources — for example,
    /// "Atlassian MCP server" and "mcp-atlassian" both appear as "atlassian". Use
    /// `group_by[]` to break usage out per member, per RBAC group, or per product
    /// surface, and `filter[]` to scope results; the parameter descriptions list the
    /// supported dimensions. Available to organizations on a Claude Enterprise plan.
    /// Requires an API key with the `read:analytics` scope.</para>
    /// </summary>
    Task<ConnectorListPage> List(
        ConnectorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IConnectorService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConnectorServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConnectorServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/connectors?beta=true</c>, but is otherwise the
    /// same as <see cref="IConnectorService.List(ConnectorListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConnectorListPage>> List(
        ConnectorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
