using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;
using Anthropic.Models.Beta.Organization.Workspaces.Members;

namespace Anthropic.Services.Beta.Organization.Workspaces;

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
    public async Task<BetaWorkspaceMember> Retrieve(
        MemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaWorkspaceMember> Retrieve(
        string userID,
        MemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaWorkspaceMember> Update(
        MemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaWorkspaceMember> Update(
        string userID,
        MemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { UserID = userID }, cancellationToken);
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
        string workspaceID,
        MemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaWorkspaceMember> Add(
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
    public Task<BetaWorkspaceMember> Add(
        string workspaceID,
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MemberRemoveResponse> Remove(
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
    public Task<MemberRemoveResponse> Remove(
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
    public async Task<HttpResponse<BetaWorkspaceMember>> Retrieve(
        MemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<MemberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaWorkspaceMember = await response
                    .Deserialize<BetaWorkspaceMember>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaWorkspaceMember.Validate();
                }
                return betaWorkspaceMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaWorkspaceMember>> Retrieve(
        string userID,
        MemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaWorkspaceMember>> Update(
        MemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<MemberUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaWorkspaceMember = await response
                    .Deserialize<BetaWorkspaceMember>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaWorkspaceMember.Validate();
                }
                return betaWorkspaceMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaWorkspaceMember>> Update(
        string userID,
        MemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemberListPage>> List(
        MemberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<MemberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
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
        string workspaceID,
        MemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaWorkspaceMember>> Add(
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<MemberAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaWorkspaceMember = await response
                    .Deserialize<BetaWorkspaceMember>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaWorkspaceMember.Validate();
                }
                return betaWorkspaceMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaWorkspaceMember>> Add(
        string workspaceID,
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemberRemoveResponse>> Remove(
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
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var member = await response
                    .Deserialize<MemberRemoveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    member.Validate();
                }
                return member;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MemberRemoveResponse>> Remove(
        string userID,
        MemberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { UserID = userID }, cancellationToken);
    }
}
