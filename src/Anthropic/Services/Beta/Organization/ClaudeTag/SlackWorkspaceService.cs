using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

namespace Anthropic.Services.Beta.Organization.ClaudeTag;

/// <inheritdoc/>
public sealed class SlackWorkspaceService : ISlackWorkspaceService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "experimental-claude-tag-2026-10-21");
    }

    readonly Lazy<ISlackWorkspaceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISlackWorkspaceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ISlackWorkspaceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SlackWorkspaceService(this._client.WithOptions(modifier));
    }

    public SlackWorkspaceService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SlackWorkspaceServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagSlackWorkspace> Retrieve(
        SlackWorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeTagSlackWorkspace> Retrieve(
        string id,
        SlackWorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagSlackWorkspace> Update(
        SlackWorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeTagSlackWorkspace> Update(
        string id,
        SlackWorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SlackWorkspaceListPage> List(
        SlackWorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SlackWorkspaceServiceWithRawResponse : ISlackWorkspaceServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISlackWorkspaceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SlackWorkspaceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SlackWorkspaceServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagSlackWorkspace>> Retrieve(
        SlackWorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SlackWorkspaceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.slack_workspaces.retrieve",
            SpanResourceIds =
            [
                new("anthropic.organization.claude_tag.slack_workspace.id", parameters.ID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeTagSlackWorkspace = await response
                    .Deserialize<BetaClaudeTagSlackWorkspace>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagSlackWorkspace.Validate();
                }
                return betaClaudeTagSlackWorkspace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeTagSlackWorkspace>> Retrieve(
        string id,
        SlackWorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagSlackWorkspace>> Update(
        SlackWorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SlackWorkspaceUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.slack_workspaces.update",
            SpanResourceIds =
            [
                new("anthropic.organization.claude_tag.slack_workspace.id", parameters.ID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeTagSlackWorkspace = await response
                    .Deserialize<BetaClaudeTagSlackWorkspace>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagSlackWorkspace.Validate();
                }
                return betaClaudeTagSlackWorkspace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeTagSlackWorkspace>> Update(
        string id,
        SlackWorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SlackWorkspaceListPage>> List(
        SlackWorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SlackWorkspaceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.slack_workspaces.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<SlackWorkspaceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SlackWorkspaceListPage(this, parameters, page);
            }
        );
    }
}
