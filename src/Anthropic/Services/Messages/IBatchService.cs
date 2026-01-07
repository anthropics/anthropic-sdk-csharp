using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Services.Messages;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBatchService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Send a batch of Message creation requests.
    ///
    /// <para>The Message Batches API can be used to process multiple Messages API
    /// requests at once. Once a Message Batch is created, it begins processing immediately.
    /// Batches can take up to 24 hours to complete.</para>
    ///
    /// <para>Learn more about the Message Batches API in our [user guide](https://docs.claude.com/en/docs/build-with-claude/batch-processing)</para>
    /// </summary>
    Task<MessageBatch> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is idempotent and can be used to poll for Message Batch completion.
    /// To access the results of a Message Batch, make a request to the `results_url`
    /// field in the response.
    ///
    /// <para>Learn more about the Message Batches API in our [user guide](https://docs.claude.com/en/docs/build-with-claude/batch-processing)</para>
    /// </summary>
    Task<MessageBatch> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BatchRetrieveParams, CancellationToken)"/>
    Task<MessageBatch> Retrieve(
        string messageBatchID,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all Message Batches within a Workspace. Most recently created batches
    /// are returned first.
    ///
    /// <para>Learn more about the Message Batches API in our [user guide](https://docs.claude.com/en/docs/build-with-claude/batch-processing)</para>
    /// </summary>
    Task<BatchListPage> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Message Batch.
    ///
    /// <para>Message Batches can only be deleted once they've finished processing.
    /// If you'd like to delete an in-progress batch, you must first cancel it.</para>
    ///
    /// <para>Learn more about the Message Batches API in our [user guide](https://docs.claude.com/en/docs/build-with-claude/batch-processing)</para>
    /// </summary>
    Task<DeletedMessageBatch> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(BatchDeleteParams, CancellationToken)"/>
    Task<DeletedMessageBatch> Delete(
        string messageBatchID,
        BatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Batches may be canceled any time before processing ends. Once cancellation
    /// is initiated, the batch enters a `canceling` state, at which time the system
    /// may complete any in-progress, non-interruptible requests before finalizing cancellation.
    ///
    /// <para>The number of canceled requests is specified in `request_counts`. To
    /// determine which requests were canceled, check the individual results within
    /// the batch. Note that cancellation may not result in any canceled requests
    /// if they were non-interruptible.</para>
    ///
    /// <para>Learn more about the Message Batches API in our [user guide](https://docs.claude.com/en/docs/build-with-claude/batch-processing)</para>
    /// </summary>
    Task<MessageBatch> Cancel(
        BatchCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(BatchCancelParams, CancellationToken)"/>
    Task<MessageBatch> Cancel(
        string messageBatchID,
        BatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Streams the results of a Message Batch as a `.jsonl` file.
    ///
    /// <para>Each line in the file is a JSON object containing the result of a single
    /// request in the Message Batch. Results are not guaranteed to be in the same
    /// order as requests. Use the `custom_id` field to match results to requests.</para>
    ///
    /// <para>Learn more about the Message Batches API in our [user guide](https://docs.claude.com/en/docs/build-with-claude/batch-processing)</para>
    /// </summary>
    IAsyncEnumerable<MessageBatchIndividualResponse> ResultsStreaming(
        BatchResultsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ResultsStreaming(BatchResultsParams, CancellationToken)"/>
    IAsyncEnumerable<MessageBatchIndividualResponse> ResultsStreaming(
        string messageBatchID,
        BatchResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
