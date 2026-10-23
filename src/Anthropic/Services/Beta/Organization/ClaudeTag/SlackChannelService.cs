using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackChannels;

namespace Anthropic.Services.Beta.Organization.ClaudeTag;

/// <inheritdoc/>
public sealed class SlackChannelService : ISlackChannelService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "experimental-claude-tag-2026-10-21");
    }

    readonly Lazy<ISlackChannelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISlackChannelServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ISlackChannelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SlackChannelService(this._client.WithOptions(modifier));
    }

    public SlackChannelService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SlackChannelServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagSlackChannel> Create(
        SlackChannelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagSlackChannel> Retrieve(
        SlackChannelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeTagSlackChannel> Retrieve(
        string id,
        SlackChannelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagSlackChannel> Update(
        SlackChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeTagSlackChannel> Update(
        string id,
        SlackChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SlackChannelListPage> List(
        SlackChannelListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagDeletedSlackChannel> Delete(
        SlackChannelDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeTagDeletedSlackChannel> Delete(
        string id,
        SlackChannelDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SlackChannelServiceWithRawResponse : ISlackChannelServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISlackChannelServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SlackChannelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SlackChannelServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagSlackChannel>> Create(
        SlackChannelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SlackChannelCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.slack_channels.create",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeTagSlackChannel = await response
                    .Deserialize<BetaClaudeTagSlackChannel>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagSlackChannel.Validate();
                }
                Tracing.SetCreatedId(
                    response.Span,
                    "anthropic.organization.claude_tag.slack_channel.id",
                    betaClaudeTagSlackChannel,
                    static created => created.ID
                );
                return betaClaudeTagSlackChannel;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagSlackChannel>> Retrieve(
        SlackChannelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SlackChannelRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.slack_channels.retrieve",
            SpanResourceIds =
            [
                new("anthropic.organization.claude_tag.slack_channel.id", parameters.ID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeTagSlackChannel = await response
                    .Deserialize<BetaClaudeTagSlackChannel>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagSlackChannel.Validate();
                }
                return betaClaudeTagSlackChannel;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeTagSlackChannel>> Retrieve(
        string id,
        SlackChannelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagSlackChannel>> Update(
        SlackChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SlackChannelUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.slack_channels.update",
            SpanResourceIds =
            [
                new("anthropic.organization.claude_tag.slack_channel.id", parameters.ID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeTagSlackChannel = await response
                    .Deserialize<BetaClaudeTagSlackChannel>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagSlackChannel.Validate();
                }
                return betaClaudeTagSlackChannel;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeTagSlackChannel>> Update(
        string id,
        SlackChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SlackChannelListPage>> List(
        SlackChannelListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SlackChannelListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.slack_channels.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<SlackChannelListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SlackChannelListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagDeletedSlackChannel>> Delete(
        SlackChannelDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SlackChannelDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.slack_channels.delete",
            SpanResourceIds =
            [
                new("anthropic.organization.claude_tag.slack_channel.id", parameters.ID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeTagDeletedSlackChannel = await response
                    .Deserialize<BetaClaudeTagDeletedSlackChannel>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagDeletedSlackChannel.Validate();
                }
                return betaClaudeTagDeletedSlackChannel;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeTagDeletedSlackChannel>> Delete(
        string id,
        SlackChannelDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}
