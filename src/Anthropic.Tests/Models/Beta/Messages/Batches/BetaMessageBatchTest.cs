using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaMessageBatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageBatch
        {
            ID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF",
            ArchivedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z"),
            CancelInitiatedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z"),
            CreatedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z"),
            EndedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z"),
            ExpiresAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z"),
            ProcessingStatus = ProcessingStatus.InProgress,
            RequestCounts = new()
            {
                Canceled = 10,
                Errored = 30,
                Expired = 10,
                Processing = 100,
                Succeeded = 50,
            },
            ResultsURL =
                "https://api.anthropic.com/v1/messages/batches/msgbatch_013Zva2CMHLNnXjNJJKqJ2EF/results",
            Type = JsonSerializer.Deserialize<JsonElement>("\"message_batch\""),
        };

        string expectedID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z");
        DateTimeOffset expectedCancelInitiatedAt = DateTimeOffset.Parse(
            "2024-08-20T18:37:24.100435Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z");
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z");
        ApiEnum<string, ProcessingStatus> expectedProcessingStatus = ProcessingStatus.InProgress;
        BetaMessageBatchRequestCounts expectedRequestCounts = new()
        {
            Canceled = 10,
            Errored = 30,
            Expired = 10,
            Processing = 100,
            Succeeded = 50,
        };
        string expectedResultsURL =
            "https://api.anthropic.com/v1/messages/batches/msgbatch_013Zva2CMHLNnXjNJJKqJ2EF/results";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"message_batch\"");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedCancelInitiatedAt, model.CancelInitiatedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEndedAt, model.EndedAt);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedProcessingStatus, model.ProcessingStatus);
        Assert.Equal(expectedRequestCounts, model.RequestCounts);
        Assert.Equal(expectedResultsURL, model.ResultsURL);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
