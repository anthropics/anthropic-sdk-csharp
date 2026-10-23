using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;
using TelemetryDestinations = Anthropic.Services.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITelemetryDestinationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITelemetryDestinationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelemetryDestinationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    TelemetryDestinations::IWorkspaceService Workspaces { get; }

    /// <summary>
    /// Register an OpenTelemetry destination for the organization.
    ///
    /// <para>The destination starts in state `enabled`. An organization can have at
    /// most 10 destinations, including disabled ones.</para>
    ///
    /// <para>See the [OpenTelemetry export
    /// guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#add-a-destination)
    /// to learn more about adding a destination.</para>
    /// </summary>
    Task<BetaTelemetryDestination> Create(
        TelemetryDestinationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Read a destination's configuration, state, and most recent delivery results.
    ///
    /// <para>See the [OpenTelemetry export
    /// guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#delivery-and-health)
    /// to learn how the API delivers spans and when it disables a destination.</para>
    /// </summary>
    Task<BetaTelemetryDestination> Retrieve(
        TelemetryDestinationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TelemetryDestinationRetrieveParams, CancellationToken)"/>
    Task<BetaTelemetryDestination> Retrieve(
        string destinationID,
        TelemetryDestinationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change a telemetry destination's settings, its state, or which workspaces it
    /// covers.
    ///
    /// <para>Send at least one field. Omitted fields keep their stored values, except
    /// the registered headers, which a change of the endpoint's hostname or port
    /// removes. Only `display_name`, `traces`, `traces.endpoint_url`,
    /// `traces.content_mode`, `traces.max_content_bytes`, and individual `headers`
    /// values accept `null`.</para>
    ///
    /// <para>If another request changes the destination while the update runs, the API
    /// returns a 409 `conflict_error`. Read the destination again, then retry the
    /// update.</para>
    ///
    /// <para>See the [OpenTelemetry export
    /// guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#delivery-and-health)
    /// to learn more about changing a destination.</para>
    /// </summary>
    Task<BetaTelemetryDestination> Update(
        TelemetryDestinationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TelemetryDestinationUpdateParams, CancellationToken)"/>
    Task<BetaTelemetryDestination> Update(
        string destinationID,
        TelemetryDestinationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the organization's destinations, newest first, optionally only those that
    /// cover given workspaces.
    ///
    /// <para>See the [OpenTelemetry export
    /// guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#set-up-api-tracing)
    /// to learn more about destinations.</para>
    /// </summary>
    Task<TelemetryDestinationListPage> List(
        TelemetryDestinationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a destination and its workspace list.
    ///
    /// <para>The API stops sending spans to the destination. The spans of the
    /// workspaces it covered still go to the other destinations that cover them. A
    /// deleted destination can't be read, listed, or restored.</para>
    ///
    /// <para>See the [OpenTelemetry export
    /// guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#delivery-and-health)
    /// to learn more about managing a destination.</para>
    /// </summary>
    Task<BetaDeletedTelemetryDestination> Delete(
        TelemetryDestinationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TelemetryDestinationDeleteParams, CancellationToken)"/>
    Task<BetaDeletedTelemetryDestination> Delete(
        string destinationID,
        TelemetryDestinationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send one test span, named `anthropic.test`, to the destination with its
    /// registered headers, once and without retries, and report the destination's
    /// answer. The response is 200 whether or not the destination answered with a 2xx
    /// status: its `result` has the type `success`, or the type `failure` and the
    /// reason in `error`. The destination's configuration, `state` and
    /// `delivery_health` do not change. A disabled destination can be tested too. Wait
    /// 10 seconds between tests of one destination; a request that comes sooner may be
    /// answered with status 429.
    /// </summary>
    Task<BetaTelemetryDestinationTestResponse> Test(
        TelemetryDestinationTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(TelemetryDestinationTestParams, CancellationToken)"/>
    Task<BetaTelemetryDestinationTestResponse> Test(
        string destinationID,
        TelemetryDestinationTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITelemetryDestinationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITelemetryDestinationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelemetryDestinationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    TelemetryDestinations::IWorkspaceServiceWithRawResponse Workspaces { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/telemetry_destinations</c>, but is otherwise the
    /// same as <see cref="ITelemetryDestinationService.Create(TelemetryDestinationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTelemetryDestination>> Create(
        TelemetryDestinationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/telemetry_destinations/{destination_id}</c>, but is otherwise the
    /// same as <see cref="ITelemetryDestinationService.Retrieve(TelemetryDestinationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTelemetryDestination>> Retrieve(
        TelemetryDestinationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TelemetryDestinationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaTelemetryDestination>> Retrieve(
        string destinationID,
        TelemetryDestinationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/telemetry_destinations/{destination_id}</c>, but is otherwise the
    /// same as <see cref="ITelemetryDestinationService.Update(TelemetryDestinationUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTelemetryDestination>> Update(
        TelemetryDestinationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TelemetryDestinationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaTelemetryDestination>> Update(
        string destinationID,
        TelemetryDestinationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/telemetry_destinations</c>, but is otherwise the
    /// same as <see cref="ITelemetryDestinationService.List(TelemetryDestinationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TelemetryDestinationListPage>> List(
        TelemetryDestinationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/telemetry_destinations/{destination_id}</c>, but is otherwise the
    /// same as <see cref="ITelemetryDestinationService.Delete(TelemetryDestinationDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDeletedTelemetryDestination>> Delete(
        TelemetryDestinationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TelemetryDestinationDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaDeletedTelemetryDestination>> Delete(
        string destinationID,
        TelemetryDestinationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/telemetry_destinations/{destination_id}/test</c>, but is otherwise the
    /// same as <see cref="ITelemetryDestinationService.Test(TelemetryDestinationTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTelemetryDestinationTestResponse>> Test(
        TelemetryDestinationTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(TelemetryDestinationTestParams, CancellationToken)"/>
    Task<HttpResponse<BetaTelemetryDestinationTestResponse>> Test(
        string destinationID,
        TelemetryDestinationTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
