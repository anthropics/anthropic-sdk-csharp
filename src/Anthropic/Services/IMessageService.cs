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
    /// <exception cref="AnthropicAvailableToolsLimitExceededException">
    /// The tools available after a message exceed a limit on their number or their
    /// size.
    /// </exception>
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException">
    /// The API key belongs to the Claude Code workspace, and the user who created it is
    /// no longer a member of the organization or of that workspace.
    /// </exception>
    /// <exception cref="AnthropicClaudeCodeVersionTooOldException">
    /// The request comes from a Claude Code version older than the minimum that the
    /// requested model or the organization requires. Update Claude Code, then retry.
    /// </exception>
    /// <exception cref="AnthropicCmekKeyDisabledException">
    /// The workspace's customer-managed encryption key is disabled or revoked.
    /// Re-enable the key, then retry.
    /// </exception>
    /// <exception cref="AnthropicCmekKeyNetworkBlockedException">
    /// The key management service's network access controls blocked the request to the
    /// workspace's customer-managed encryption key. The key itself may be healthy.
    /// </exception>
    /// <exception cref="AnthropicCompactionBlockAmbiguousException">
    /// `messages` holds more than one `compaction` block with content. Send only the
    /// block the conversation returned last.
    /// </exception>
    /// <exception cref="AnthropicCompactionBlockMisplacedException">
    /// The `compaction` block is not the first block of the conversation, or is in a
    /// `system` message.
    /// </exception>
    /// <exception cref="AnthropicCompactionContentMismatchException">
    /// The `compaction` block's `content` differs from the text its `signature`
    /// recorded.
    /// </exception>
    /// <exception cref="AnthropicCompactionIncompleteTurnException">
    /// The compaction request ends on an `assistant` turn that is not finished.
    /// </exception>
    /// <exception cref="AnthropicCompactionNothingToSummarizeException">
    /// `messages` holds no `user` or `assistant` content to summarize or adopt.
    /// </exception>
    /// <exception cref="AnthropicCompactionSignatureInvalidException">
    /// The `compaction` block's `signature` does not verify.
    /// </exception>
    /// <exception cref="AnthropicCompactionTooManyToolReferencesException">
    /// The conversation references more distinct tools than a `compaction` block can
    /// record.
    /// </exception>
    /// <exception cref="AnthropicCompactionToolChangesMismatchException">
    /// The `compaction` block's `tool_changes` differs from what was returned with the
    /// block.
    /// </exception>
    /// <exception cref="AnthropicOrganizationOnHoldException">
    /// Anthropic has disabled the organization for trust and safety reasons. An
    /// organization disabled for any other reason, such as billing, does not get this
    /// code. `appeal_url`, when present, is where the organization can appeal.
    /// </exception>
    /// <exception cref="AnthropicRequestBodyEncodingInvalidException">
    /// The request body is not valid for its `Content-Encoding`.
    /// </exception>
    /// <exception cref="AnthropicRequestBodyEncodingUnsupportedException">
    /// The request's `Content-Encoding` is not supported.
    /// </exception>
    /// <exception cref="AnthropicThreadAlreadyContinuedException">
    /// The response that `previous_message_id` names has already been continued, and
    /// each response can be continued only once. Continue from the Thread's most recent
    /// response `id`.
    /// </exception>
    /// <exception cref="AnthropicThreadContinueInFlightException">
    /// Another request is still continuing from the same `previous_message_id`. Wait
    /// for it to complete and continue from its response `id`, or replay the full
    /// conversation with `thread: {"type": "create"}`.
    /// </exception>
    /// <exception cref="AnthropicThreadFingerprintMismatchException">
    /// A field that must stay the same across a Thread's turns differs from the value
    /// stored with the Thread; the message names each such field. Send the stored
    /// values, or replay the full conversation with `thread: {"type": "create"}` to
    /// change them.
    /// </exception>
    /// <exception cref="AnthropicThreadUnsupportedRequestException">
    /// The request combines `thread` with a request field or an organization setting
    /// that Threads do not support; `unsupported`, when present, names it. Send the
    /// full conversation without `thread`, or change that field.
    /// </exception>
    /// <exception cref="AnthropicToolNameConflictException">
    /// A tool made available in `messages` takes a name that an available tool of
    /// another kind, or of another MCP server, already holds.
    /// </exception>
    /// <exception cref="AnthropicToolReferenceUnresolvedException">
    /// A tool change or MCP tool listing references a tool or MCP server that is not
    /// defined at that position in the conversation.
    /// </exception>
    /// <exception cref="AnthropicThreadNotFoundException">
    /// No usable Thread state was found for `previous_message_id`. Replay the full
    /// conversation with `thread: {"type": "create"}` to start a new Thread.
    /// </exception>
    /// <exception cref="AnthropicSkillReadBlockedUndecryptableException">
    /// A custom skill the request names is stored under an encryption key state the
    /// workspace cannot currently decrypt.
    /// </exception>
    /// <exception cref="AnthropicRequestBodyTooLargeAfterDecodingException">
    /// The compressed request body exceeds the request size limit once decoded.
    /// </exception>
    /// <exception cref="AnthropicEnforcedSpendLimitReachedException">
    /// The organization has crossed the monthly API usage threshold of its API tier.
    /// </exception>
    /// <exception cref="AnthropicCmekKeyUnreachableException">
    /// The workspace's customer-managed encryption key could not be reached. Retry the
    /// request; if this continues, check that the key is available in your key
    /// management service, or contact Anthropic support.
    /// </exception>
    /// <exception cref="AnthropicCompactionUnavailableException">
    /// The compaction could not be completed for a transient server reason. Retry the
    /// request.
    /// </exception>
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
    /// <exception cref="AnthropicAvailableToolsLimitExceededException">
    /// The tools available after a message exceed a limit on their number or their
    /// size.
    /// </exception>
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException">
    /// The API key belongs to the Claude Code workspace, and the user who created it is
    /// no longer a member of the organization or of that workspace.
    /// </exception>
    /// <exception cref="AnthropicClaudeCodeVersionTooOldException">
    /// The request comes from a Claude Code version older than the minimum that the
    /// requested model or the organization requires. Update Claude Code, then retry.
    /// </exception>
    /// <exception cref="AnthropicCmekKeyDisabledException">
    /// The workspace's customer-managed encryption key is disabled or revoked.
    /// Re-enable the key, then retry.
    /// </exception>
    /// <exception cref="AnthropicCmekKeyNetworkBlockedException">
    /// The key management service's network access controls blocked the request to the
    /// workspace's customer-managed encryption key. The key itself may be healthy.
    /// </exception>
    /// <exception cref="AnthropicCompactionBlockAmbiguousException">
    /// `messages` holds more than one `compaction` block with content. Send only the
    /// block the conversation returned last.
    /// </exception>
    /// <exception cref="AnthropicCompactionBlockMisplacedException">
    /// The `compaction` block is not the first block of the conversation, or is in a
    /// `system` message.
    /// </exception>
    /// <exception cref="AnthropicCompactionContentMismatchException">
    /// The `compaction` block's `content` differs from the text its `signature`
    /// recorded.
    /// </exception>
    /// <exception cref="AnthropicCompactionIncompleteTurnException">
    /// The compaction request ends on an `assistant` turn that is not finished.
    /// </exception>
    /// <exception cref="AnthropicCompactionNothingToSummarizeException">
    /// `messages` holds no `user` or `assistant` content to summarize or adopt.
    /// </exception>
    /// <exception cref="AnthropicCompactionSignatureInvalidException">
    /// The `compaction` block's `signature` does not verify.
    /// </exception>
    /// <exception cref="AnthropicCompactionTooManyToolReferencesException">
    /// The conversation references more distinct tools than a `compaction` block can
    /// record.
    /// </exception>
    /// <exception cref="AnthropicCompactionToolChangesMismatchException">
    /// The `compaction` block's `tool_changes` differs from what was returned with the
    /// block.
    /// </exception>
    /// <exception cref="AnthropicOrganizationOnHoldException">
    /// Anthropic has disabled the organization for trust and safety reasons. An
    /// organization disabled for any other reason, such as billing, does not get this
    /// code. `appeal_url`, when present, is where the organization can appeal.
    /// </exception>
    /// <exception cref="AnthropicRequestBodyEncodingInvalidException">
    /// The request body is not valid for its `Content-Encoding`.
    /// </exception>
    /// <exception cref="AnthropicRequestBodyEncodingUnsupportedException">
    /// The request's `Content-Encoding` is not supported.
    /// </exception>
    /// <exception cref="AnthropicThreadAlreadyContinuedException">
    /// The response that `previous_message_id` names has already been continued, and
    /// each response can be continued only once. Continue from the Thread's most recent
    /// response `id`.
    /// </exception>
    /// <exception cref="AnthropicThreadContinueInFlightException">
    /// Another request is still continuing from the same `previous_message_id`. Wait
    /// for it to complete and continue from its response `id`, or replay the full
    /// conversation with `thread: {"type": "create"}`.
    /// </exception>
    /// <exception cref="AnthropicThreadFingerprintMismatchException">
    /// A field that must stay the same across a Thread's turns differs from the value
    /// stored with the Thread; the message names each such field. Send the stored
    /// values, or replay the full conversation with `thread: {"type": "create"}` to
    /// change them.
    /// </exception>
    /// <exception cref="AnthropicThreadUnsupportedRequestException">
    /// The request combines `thread` with a request field or an organization setting
    /// that Threads do not support; `unsupported`, when present, names it. Send the
    /// full conversation without `thread`, or change that field.
    /// </exception>
    /// <exception cref="AnthropicToolNameConflictException">
    /// A tool made available in `messages` takes a name that an available tool of
    /// another kind, or of another MCP server, already holds.
    /// </exception>
    /// <exception cref="AnthropicToolReferenceUnresolvedException">
    /// A tool change or MCP tool listing references a tool or MCP server that is not
    /// defined at that position in the conversation.
    /// </exception>
    /// <exception cref="AnthropicThreadNotFoundException">
    /// No usable Thread state was found for `previous_message_id`. Replay the full
    /// conversation with `thread: {"type": "create"}` to start a new Thread.
    /// </exception>
    /// <exception cref="AnthropicSkillReadBlockedUndecryptableException">
    /// A custom skill the request names is stored under an encryption key state the
    /// workspace cannot currently decrypt.
    /// </exception>
    /// <exception cref="AnthropicRequestBodyTooLargeAfterDecodingException">
    /// The compressed request body exceeds the request size limit once decoded.
    /// </exception>
    /// <exception cref="AnthropicEnforcedSpendLimitReachedException">
    /// The organization has crossed the monthly API usage threshold of its API tier.
    /// </exception>
    /// <exception cref="AnthropicCmekKeyUnreachableException">
    /// The workspace's customer-managed encryption key could not be reached. Retry the
    /// request; if this continues, check that the key is available in your key
    /// management service, or contact Anthropic support.
    /// </exception>
    /// <exception cref="AnthropicCompactionUnavailableException">
    /// The compaction could not be completed for a transient server reason. Retry the
    /// request.
    /// </exception>
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
    /// <exception cref="AnthropicAvailableToolsLimitExceededException">
    /// The tools available after a message exceed a limit on their number or their
    /// size.
    /// </exception>
    /// <exception cref="AnthropicClaudeCodeKeyCreatorNotMemberException">
    /// The API key belongs to the Claude Code workspace, and the user who created it is
    /// no longer a member of the organization or of that workspace.
    /// </exception>
    /// <exception cref="AnthropicCompactionBlockAmbiguousException">
    /// `messages` holds more than one `compaction` block with content. Send only the
    /// block the conversation returned last.
    /// </exception>
    /// <exception cref="AnthropicCompactionBlockMisplacedException">
    /// The `compaction` block is not the first block of the conversation, or is in a
    /// `system` message.
    /// </exception>
    /// <exception cref="AnthropicCompactionContentMismatchException">
    /// The `compaction` block's `content` differs from the text its `signature`
    /// recorded.
    /// </exception>
    /// <exception cref="AnthropicCompactionNothingToSummarizeException">
    /// `messages` holds no `user` or `assistant` content to summarize or adopt.
    /// </exception>
    /// <exception cref="AnthropicCompactionSignatureInvalidException">
    /// The `compaction` block's `signature` does not verify.
    /// </exception>
    /// <exception cref="AnthropicCompactionToolChangesMismatchException">
    /// The `compaction` block's `tool_changes` differs from what was returned with the
    /// block.
    /// </exception>
    /// <exception cref="AnthropicOrganizationOnHoldException">
    /// Anthropic has disabled the organization for trust and safety reasons. An
    /// organization disabled for any other reason, such as billing, does not get this
    /// code. `appeal_url`, when present, is where the organization can appeal.
    /// </exception>
    /// <exception cref="AnthropicRequestBodyEncodingInvalidException">
    /// The request body is not valid for its `Content-Encoding`.
    /// </exception>
    /// <exception cref="AnthropicRequestBodyEncodingUnsupportedException">
    /// The request's `Content-Encoding` is not supported.
    /// </exception>
    /// <exception cref="AnthropicToolNameConflictException">
    /// A tool made available in `messages` takes a name that an available tool of
    /// another kind, or of another MCP server, already holds.
    /// </exception>
    /// <exception cref="AnthropicToolReferenceUnresolvedException">
    /// A tool change or MCP tool listing references a tool or MCP server that is not
    /// defined at that position in the conversation.
    /// </exception>
    /// <exception cref="AnthropicRequestBodyTooLargeAfterDecodingException">
    /// The compressed request body exceeds the request size limit once decoded.
    /// </exception>
    /// <exception cref="AnthropicEnforcedSpendLimitReachedException">
    /// The organization has crossed the monthly API usage threshold of its API tier.
    /// </exception>
    /// <exception cref="AnthropicCompactionUnavailableException">
    /// The compaction could not be completed for a transient server reason. Retry the
    /// request.
    /// </exception>
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
