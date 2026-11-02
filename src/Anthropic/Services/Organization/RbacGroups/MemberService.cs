using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.RbacGroups.Members;

namespace Anthropic.Services.Organization.RbacGroups;

/// <inheritdoc/>
public sealed class MemberService : IMemberService
{
    readonly Lazy<IMemberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMemberServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IMemberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemberService(this._client.WithOptions(modifier));
    }

    public MemberService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MemberServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<MemberListPage> List(
        MemberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MemberListPage> List(
        string rbacGroupID,
        MemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RbacGroupMember> Add(
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RbacGroupMember> Add(
        string rbacGroupID,
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DeletedRbacGroupMember> Remove(
        MemberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Remove(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DeletedRbacGroupMember> Remove(
        string userID,
        MemberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { UserID = userID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MemberServiceWithRawResponse : IMemberServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMemberServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MemberServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemberListPage>> List(
        MemberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<MemberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            SpanName = "anthropic.organization.rbac_groups.members.list",
            SpanResourceIds = [new("anthropic.organization.rbac_group.id", parameters.RbacGroupID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<MemberListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new MemberListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MemberListPage>> List(
        string rbacGroupID,
        MemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RbacGroupMember>> Add(
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<MemberAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            SpanName = "anthropic.organization.rbac_groups.members.add",
            SpanResourceIds = [new("anthropic.organization.rbac_group.id", parameters.RbacGroupID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var rbacGroupMember = await response
                    .Deserialize<RbacGroupMember>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    rbacGroupMember.Validate();
                }
                Tracing.SetCreatedId(
                    response.Span,
                    "anthropic.organization.rbac_group.member.id",
                    rbacGroupMember,
                    static created => created.UserID
                );
                return rbacGroupMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RbacGroupMember>> Add(
        string rbacGroupID,
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeletedRbacGroupMember>> Remove(
        MemberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<MemberRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            SpanName = "anthropic.organization.rbac_groups.members.remove",
            SpanResourceIds =
            [
                new("anthropic.organization.rbac_group.id", parameters.RbacGroupID),
                new("anthropic.organization.rbac_group.member.id", parameters.UserID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deletedRbacGroupMember = await response
                    .Deserialize<DeletedRbacGroupMember>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deletedRbacGroupMember.Validate();
                }
                return deletedRbacGroupMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DeletedRbacGroupMember>> Remove(
        string userID,
        MemberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { UserID = userID }, cancellationToken);
    }
}
