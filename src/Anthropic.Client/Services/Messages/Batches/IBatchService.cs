using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Messages.Batches;

namespace Anthropic.Client.Services.Messages.Batches;

public interface IBatchService
{
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Send a batch of Message creation requests.
    ///
    /// The Message Batches API can be used to process multiple Messages API requests
    /// at once. Once a Message Batch is created, it begins processing immediately.
    /// Batches can take up to 24 hours to complete.
    ///
    /// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
    /// </summary>
    Task<MessageBatch> Create(BatchCreateParams parameters);

    /// <summary>
    /// This endpoint is idempotent and can be used to poll for Message Batch completion.
    /// To access the results of a Message Batch, make a request to the `results_url`
    /// field in the response.
    ///
    /// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
    /// </summary>
    Task<MessageBatch> Retrieve(BatchRetrieveParams parameters);

    /// <summary>
    /// List all Message Batches within a Workspace. Most recently created batches
    /// are returned first.
    ///
    /// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
    /// </summary>
    Task<BatchListPageResponse> List(BatchListParams? parameters = null);

    /// <summary>
    /// Delete a Message Batch.
    ///
    /// Message Batches can only be deleted once they've finished processing. If
    /// you'd like to delete an in-progress batch, you must first cancel it.
    ///
    /// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
    /// </summary>
    Task<DeletedMessageBatch> Delete(BatchDeleteParams parameters);

    /// <summary>
    /// Batches may be canceled any time before processing ends. Once cancellation
    /// is initiated, the batch enters a `canceling` state, at which time the system
    /// may complete any in-progress, non-interruptible requests before finalizing cancellation.
    ///
    /// The number of canceled requests is specified in `request_counts`. To determine
    /// which requests were canceled, check the individual results within the batch.
    /// Note that cancellation may not result in any canceled requests if they were non-interruptible.
    ///
    /// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
    /// </summary>
    Task<MessageBatch> Cancel(BatchCancelParams parameters);

    /// <summary>
    /// Streams the results of a Message Batch as a `.jsonl` file.
    ///
    /// Each line in the file is a JSON object containing the result of a single
    /// request in the Message Batch. Results are not guaranteed to be in the same
    /// order as requests. Use the `custom_id` field to match results to requests.
    ///
    /// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
    /// </summary>
    IAsyncEnumerable<MessageBatchIndividualResponse> ResultsStreaming(
        BatchResultsParams parameters
    );
}
