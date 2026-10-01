using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPluginMarketplaceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPluginMarketplaceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPluginMarketplaceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a plugin marketplace by ID.
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `read:plugins` or
    /// `read:org_audit` scope, or a Compliance Access Key with the
    /// `read:compliance_org_data` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaPluginMarketplace> Retrieve(
        PluginMarketplaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PluginMarketplaceRetrieveParams, CancellationToken)"/>
    Task<BetaPluginMarketplace> Retrieve(
        string marketplaceID,
        PluginMarketplaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set the default installation setting of one of the organization's own plugin
    /// marketplaces. Every Plugin in it without a setting of its own gets this default
    /// as its organization-wide setting, including Plugins added later.
    ///
    /// <para>Pass it as `default_installation_preference`. A member's personal
    /// marketplace cannot be updated here (403).</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `write:plugins` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaPluginMarketplace> Update(
        PluginMarketplaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PluginMarketplaceUpdateParams, CancellationToken)"/>
    Task<BetaPluginMarketplace> Update(
        string marketplaceID,
        PluginMarketplaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the plugin marketplaces Plugins live in, newest first: the organization's
    /// own and its members' personal ones.
    ///
    /// <para>Plugin marketplaces are created, connected to a repository and deleted in
    /// claude.ai, not through this API. The organization's library marketplace, the
    /// organization-owned `manual` marketplace that uploads go to when no marketplace
    /// is named, is created the first time something is put in it and is listed from
    /// then on.</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `read:plugins` or
    /// `read:org_audit` scope, or a Compliance Access Key with the
    /// `read:compliance_org_data` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<PluginMarketplaceListPage> List(
        PluginMarketplaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check whether a plugin marketplace, uploaded as a `.zip` of the marketplace
    /// directory, would synchronize into claude.ai, without connecting or storing it.
    ///
    /// <para>To check a public GitHub repository instead, use Validate Plugin
    /// Marketplace Repository.</para>
    ///
    /// <para>The report says whether `marketplace.json` is well-formed, which plugins a
    /// synchronization would skip and why, and which plugins would synchronize only in
    /// part, with some files left out. An archive that cannot be read as a marketplace
    /// is reported, not refused: the response is a report with `valid: false`. Plugin
    /// sources outside the marketplace are fetched anonymously from GitHub, so a
    /// private one is reported as not found; a source on any other host is not fetched
    /// here, and the report notes that it will be checked when the marketplace actually
    /// synchronizes.</para>
    ///
    /// <para>Nothing is recorded on the Compliance API activity feed.</para>
    ///
    /// <para>For a worked example, see [Validate marketplace
    /// content](/docs/en/manage-claude/plugins-api#validate-marketplace-content) in the
    /// Plugins API guide.</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `read:plugins` or
    /// `write:plugins` scope; `read:org_audit` and `read:compliance_org_data` do not
    /// grant it.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaPluginMarketplaceValidationReport> ValidateArchive(
        PluginMarketplaceValidateArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check whether a plugin marketplace held in a public GitHub repository would
    /// synchronize into claude.ai, without connecting or storing it.
    ///
    /// <para>To check a `.zip` of the marketplace directory instead, use Validate
    /// Plugin Marketplace Archive.</para>
    ///
    /// <para>The report says whether `marketplace.json` is well-formed, which plugins a
    /// synchronization would skip and why, and which plugins would synchronize only in
    /// part, with some files left out. A repository that is missing, private, or has no
    /// such branch or commit is reported, not refused: the response is a report with
    /// `valid: false`. Plugin sources outside the marketplace are fetched anonymously
    /// from GitHub, so a private one is reported as not found; a source on any other
    /// host is not fetched here, and the report notes that it will be checked when the
    /// marketplace actually synchronizes.</para>
    ///
    /// <para>Nothing is recorded on the Compliance API activity feed.</para>
    ///
    /// <para>For a worked example, see [Validate marketplace
    /// content](/docs/en/manage-claude/plugins-api#validate-marketplace-content) in the
    /// Plugins API guide.</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `read:plugins` or
    /// `write:plugins` scope; `read:org_audit` and `read:compliance_org_data` do not
    /// grant it.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaPluginMarketplaceValidationReport> ValidateRepository(
        PluginMarketplaceValidateRepositoryParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPluginMarketplaceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPluginMarketplaceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPluginMarketplaceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/plugin_marketplaces/{marketplace_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginMarketplaceService.Retrieve(PluginMarketplaceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPluginMarketplace>> Retrieve(
        PluginMarketplaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PluginMarketplaceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaPluginMarketplace>> Retrieve(
        string marketplaceID,
        PluginMarketplaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/plugin_marketplaces/{marketplace_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginMarketplaceService.Update(PluginMarketplaceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPluginMarketplace>> Update(
        PluginMarketplaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PluginMarketplaceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaPluginMarketplace>> Update(
        string marketplaceID,
        PluginMarketplaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/plugin_marketplaces?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginMarketplaceService.List(PluginMarketplaceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PluginMarketplaceListPage>> List(
        PluginMarketplaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/plugin_marketplaces/validate_archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginMarketplaceService.ValidateArchive(PluginMarketplaceValidateArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPluginMarketplaceValidationReport>> ValidateArchive(
        PluginMarketplaceValidateArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/plugin_marketplaces/validate_repository?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginMarketplaceService.ValidateRepository(PluginMarketplaceValidateRepositoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPluginMarketplaceValidationReport>> ValidateRepository(
        PluginMarketplaceValidateRepositoryParams parameters,
        CancellationToken cancellationToken = default
    );
}
