using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models;
using Anthropic.Models.Messages;
using Anthropic.Models.Skills;
using Anthropic.Services.Messages;

namespace Anthropic.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBatchService Batches { get; }

    /// <summary>
    /// Send a structured list of input messages with text and/or image content, and the
    /// model will generate the next message in the conversation.
    ///
    /// <para>The Messages API can be used for either single queries or stateless
    /// multi-turn conversations.</para>
    ///
    /// <para>Learn more about the Messages API in our [user
    /// guide](https://platform.claude.com/docs/en/get-started)</para>
    /// </summary>
    /// <exception cref="AnthropicAvailableToolsLimitExceededException"/>
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException"/>
    /// <exception cref="AnthropicClaudeCodeVersionTooOldException"/>
    /// <exception cref="AnthropicCmekKeyDisabledException"/>
    /// <exception cref="AnthropicCmekKeyNetworkBlockedException"/>
    /// <exception cref="AnthropicCompactionBlockAmbiguousException"/>
    /// <exception cref="AnthropicCompactionBlockMisplacedException"/>
    /// <exception cref="AnthropicCompactionContentMismatchException"/>
    /// <exception cref="AnthropicCompactionIncompleteTurnException"/>
    /// <exception cref="AnthropicCompactionNothingToSummarizeException"/>
    /// <exception cref="AnthropicCompactionSignatureInvalidException"/>
    /// <exception cref="AnthropicCompactionTooManyToolReferencesException"/>
    /// <exception cref="AnthropicCompactionToolChangesMismatchException"/>
    /// <exception cref="AnthropicOrganizationOnHoldException"/>
    /// <exception cref="AnthropicRequestBodyEncodingInvalidException"/>
    /// <exception cref="AnthropicRequestBodyEncodingUnsupportedException"/>
    /// <exception cref="AnthropicThreadAlreadyContinuedException"/>
    /// <exception cref="AnthropicThreadContinueInFlightException"/>
    /// <exception cref="AnthropicThreadFingerprintMismatchException"/>
    /// <exception cref="AnthropicThreadUnsupportedRequestException"/>
    /// <exception cref="AnthropicToolNameConflictException"/>
    /// <exception cref="AnthropicToolReferenceUnresolvedException"/>
    /// <exception cref="AnthropicThreadNotFoundException"/>
    /// <exception cref="AnthropicSkillReadBlockedUndecryptableException"/>
    /// <exception cref="AnthropicRequestBodyTooLargeAfterDecodingException"/>
    /// <exception cref="AnthropicEnforcedSpendLimitReachedException"/>
    /// <exception cref="AnthropicRampLimitExceededException"/>
    /// <exception cref="AnthropicCmekKeyUnreachableException"/>
    /// <exception cref="AnthropicCompactionUnavailableException"/>
    Task<Message> Create(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send a structured list of input messages with text and/or image content, and the
    /// model will generate the next message in the conversation.
    ///
    /// <para>The Messages API can be used for either single queries or stateless
    /// multi-turn conversations.</para>
    ///
    /// <para>Learn more about the Messages API in our [user
    /// guide](https://platform.claude.com/docs/en/get-started)</para>
    /// </summary>
    /// <exception cref="AnthropicAvailableToolsLimitExceededException"/>
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException"/>
    /// <exception cref="AnthropicClaudeCodeVersionTooOldException"/>
    /// <exception cref="AnthropicCmekKeyDisabledException"/>
    /// <exception cref="AnthropicCmekKeyNetworkBlockedException"/>
    /// <exception cref="AnthropicCompactionBlockAmbiguousException"/>
    /// <exception cref="AnthropicCompactionBlockMisplacedException"/>
    /// <exception cref="AnthropicCompactionContentMismatchException"/>
    /// <exception cref="AnthropicCompactionIncompleteTurnException"/>
    /// <exception cref="AnthropicCompactionNothingToSummarizeException"/>
    /// <exception cref="AnthropicCompactionSignatureInvalidException"/>
    /// <exception cref="AnthropicCompactionTooManyToolReferencesException"/>
    /// <exception cref="AnthropicCompactionToolChangesMismatchException"/>
    /// <exception cref="AnthropicOrganizationOnHoldException"/>
    /// <exception cref="AnthropicRequestBodyEncodingInvalidException"/>
    /// <exception cref="AnthropicRequestBodyEncodingUnsupportedException"/>
    /// <exception cref="AnthropicThreadAlreadyContinuedException"/>
    /// <exception cref="AnthropicThreadContinueInFlightException"/>
    /// <exception cref="AnthropicThreadFingerprintMismatchException"/>
    /// <exception cref="AnthropicThreadUnsupportedRequestException"/>
    /// <exception cref="AnthropicToolNameConflictException"/>
    /// <exception cref="AnthropicToolReferenceUnresolvedException"/>
    /// <exception cref="AnthropicThreadNotFoundException"/>
    /// <exception cref="AnthropicSkillReadBlockedUndecryptableException"/>
    /// <exception cref="AnthropicRequestBodyTooLargeAfterDecodingException"/>
    /// <exception cref="AnthropicEnforcedSpendLimitReachedException"/>
    /// <exception cref="AnthropicRampLimitExceededException"/>
    /// <exception cref="AnthropicCmekKeyUnreachableException"/>
    /// <exception cref="AnthropicCompactionUnavailableException"/>
    IAsyncEnumerable<RawMessageStreamEvent> CreateStreaming(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Count the number of tokens in a Message.
    ///
    /// <para>The Token Count API can be used to count the number of tokens in a
    /// Message, including tools, images, and documents, without creating it.</para>
    ///
    /// <para>Learn more about token counting in our [user
    /// guide](https://platform.claude.com/docs/en/build-with-claude/token-counting)</para>
    /// </summary>
    /// <exception cref="AnthropicAvailableToolsLimitExceededException"/>
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException"/>
    /// <exception cref="AnthropicCompactionBlockAmbiguousException"/>
    /// <exception cref="AnthropicCompactionBlockMisplacedException"/>
    /// <exception cref="AnthropicCompactionContentMismatchException"/>
    /// <exception cref="AnthropicCompactionNothingToSummarizeException"/>
    /// <exception cref="AnthropicCompactionSignatureInvalidException"/>
    /// <exception cref="AnthropicCompactionToolChangesMismatchException"/>
    /// <exception cref="AnthropicOrganizationOnHoldException"/>
    /// <exception cref="AnthropicRequestBodyEncodingInvalidException"/>
    /// <exception cref="AnthropicRequestBodyEncodingUnsupportedException"/>
    /// <exception cref="AnthropicToolNameConflictException"/>
    /// <exception cref="AnthropicToolReferenceUnresolvedException"/>
    /// <exception cref="AnthropicRequestBodyTooLargeAfterDecodingException"/>
    /// <exception cref="AnthropicEnforcedSpendLimitReachedException"/>
    /// <exception cref="AnthropicCompactionUnavailableException"/>
    Task<MessageTokensCount> CountTokens(
        MessageCountTokensParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBatchServiceWithRawResponse Batches { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/messages</c>, but is otherwise the
    /// same as <see cref="IMessageService.Create(MessageCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Message>> Create(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/messages</c>, but is otherwise the
    /// same as <see cref="IMessageService.CreateStreaming(MessageCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<RawMessageStreamEvent>> CreateStreaming(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/messages/count_tokens</c>, but is otherwise the
    /// same as <see cref="IMessageService.CountTokens(MessageCountTokensParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageTokensCount>> CountTokens(
        MessageCountTokensParams parameters,
        CancellationToken cancellationToken = default
    );
}
