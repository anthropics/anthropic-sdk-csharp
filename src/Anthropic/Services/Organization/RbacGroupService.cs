using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.RbacGroups;
using Anthropic.Services.Organization.RbacGroups;

namespace Anthropic.Services.Organization;

/// <inheritdoc/>
public sealed class RbacGroupService : IRbacGroupService
{
    readonly Lazy<IRbacGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRbacGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IRbacGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RbacGroupService(this._client.WithOptions(modifier));
    }

    public RbacGroupService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RbacGroupServiceWithRawResponse(client.WithRawResponse));
        _members = new(() => new MemberService(client));
    }

    readonly Lazy<IMemberService> _members;
    public IMemberService Members
    {
        get { return _members.Value; }
    }

    /// <inheritdoc/>
    public async Task<RbacGroup> Create(
        RbacGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RbacGroup> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RbacGroup> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RbacGroup> Update(
        RbacGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RbacGroup> Update(
        string rbacGroupID,
        RbacGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RbacGroupListPage> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DeletedRbacGroup> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DeletedRbacGroup> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RbacGroupServiceWithRawResponse : IRbacGroupServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRbacGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RbacGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RbacGroupServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _members = new(() => new MemberServiceWithRawResponse(client));
    }

    readonly Lazy<IMemberServiceWithRawResponse> _members;
    public IMemberServiceWithRawResponse Members
    {
        get { return _members.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RbacGroup>> Create(
        RbacGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RbacGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            SpanName = "anthropic.organization.rbac_groups.create",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var rbacGroup = await response.Deserialize<RbacGroup>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    rbacGroup.Validate();
                }
                Tracing.SetCreatedId(
                    response.Span,
                    "anthropic.organization.rbac_group.id",
                    rbacGroup,
                    static created => created.ID
                );
                return rbacGroup;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RbacGroup>> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<RbacGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            SpanName = "anthropic.organization.rbac_groups.retrieve",
            SpanResourceIds = [new("anthropic.organization.rbac_group.id", parameters.RbacGroupID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var rbacGroup = await response.Deserialize<RbacGroup>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    rbacGroup.Validate();
                }
                return rbacGroup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RbacGroup>> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RbacGroup>> Update(
        RbacGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<RbacGroupUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            SpanName = "anthropic.organization.rbac_groups.update",
            SpanResourceIds = [new("anthropic.organization.rbac_group.id", parameters.RbacGroupID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var rbacGroup = await response.Deserialize<RbacGroup>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    rbacGroup.Validate();
                }
                return rbacGroup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RbacGroup>> Update(
        string rbacGroupID,
        RbacGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RbacGroupListPage>> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RbacGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            SpanName = "anthropic.organization.rbac_groups.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<RbacGroupListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RbacGroupListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeletedRbacGroup>> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<RbacGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            SpanName = "anthropic.organization.rbac_groups.delete",
            SpanResourceIds = [new("anthropic.organization.rbac_group.id", parameters.RbacGroupID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deletedRbacGroup = await response
                    .Deserialize<DeletedRbacGroup>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deletedRbacGroup.Validate();
                }
                return deletedRbacGroup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DeletedRbacGroup>> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }
}
