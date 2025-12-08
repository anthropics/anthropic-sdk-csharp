using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class BatchListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        List<MessageBatch> expectedData =
        [
            new()
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
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedFirstID, model.FirstID);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLastID, model.LastID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BatchListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BatchListPageResponse>(json);
        Assert.NotNull(deserialized);

        List<MessageBatch> expectedData =
        [
            new()
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
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedFirstID, deserialized.FirstID);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLastID, deserialized.LastID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        model.Validate();
    }
}
