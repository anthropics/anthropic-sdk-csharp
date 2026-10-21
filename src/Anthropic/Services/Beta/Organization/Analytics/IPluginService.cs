using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Plugins;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPluginService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPluginServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPluginService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get per-plugin install + invocation usage for a given day, with pagination.
    ///
    /// <para>Returns plugin usage metrics for the organization across Cowork and Claude
    /// Code, sorted by plugin name. The `plugin_name` value `third-party` is an
    /// aggregate bucket, not a plugin: it collects plugin activity, from either
    /// surface, for which the reporting client did not provide a plugin name — so an
    /// organization's own plugins can contribute both to their own named rows and to
    /// this bucket. Use `group_by[]` to break usage out per member, per RBAC group, or
    /// per product surface (Cowork / Claude Code), and `filter[]` to scope results; the
    /// parameter descriptions list the supported dimensions. Requires an API key with
    /// the `read:analytics` scope. `starting_date` / `ending_date` select range-rollup
    /// mode like `/skills`.</para>
    /// </summary>
    Task<PluginListPage> List(
        PluginListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPluginService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPluginServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPluginServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/plugins?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginService.List(PluginListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PluginListPage>> List(
        PluginListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
