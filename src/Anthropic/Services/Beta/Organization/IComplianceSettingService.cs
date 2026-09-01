using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ComplianceSettings;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IComplianceSettingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IComplianceSettingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IComplianceSettingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve your organization's Compliance Settings.
    ///
    /// <para>Compliance Settings is a singleton resource: there is exactly one per
    /// organization, addressed without an identifier. The `state` field reflects
    /// whether the Compliance API is enabled. An organization with a parent
    /// organization reads the state inherited from the parent's configuration.</para>
    /// </summary>
    Task<BetaComplianceSettings> Retrieve(
        ComplianceSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update your organization's Compliance Settings.
    ///
    /// <para>Setting `state` to `enabled` turns on the Compliance API and begins
    /// capturing organization activity events. Setting it to `disabled` turns both off.
    /// `state` reflects whether the Compliance API is enabled.</para>
    ///
    /// <para>A request that sets `state` to its current value succeeds and leaves the
    /// resource unchanged. A `disabled` request stays in effect until a later `enabled`
    /// request or the organization's next provisioning action that enables Access
    /// Transparency: enabling Access Transparency also enables the Compliance API,
    /// which serves its activity events, so such provisioning (including re-runs)
    /// re-enables the Compliance API even after a `disabled` request. Automated
    /// provisioning never disables compliance settings.</para>
    /// </summary>
    Task<BetaComplianceSettings> Update(
        ComplianceSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IComplianceSettingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IComplianceSettingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IComplianceSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/compliance_settings?beta=true</c>, but is otherwise the
    /// same as <see cref="IComplianceSettingService.Retrieve(ComplianceSettingRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaComplianceSettings>> Retrieve(
        ComplianceSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/compliance_settings?beta=true</c>, but is otherwise the
    /// same as <see cref="IComplianceSettingService.Update(ComplianceSettingUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaComplianceSettings>> Update(
        ComplianceSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}
