using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBatch
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
        MessageBatchRequestCounts expectedRequestCounts = new()
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageBatch
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageBatch>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageBatch
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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageBatch>(element);
        Assert.NotNull(deserialized);

        string expectedID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z");
        DateTimeOffset expectedCancelInitiatedAt = DateTimeOffset.Parse(
            "2024-08-20T18:37:24.100435Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z");
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-08-20T18:37:24.100435Z");
        ApiEnum<string, ProcessingStatus> expectedProcessingStatus = ProcessingStatus.InProgress;
        MessageBatchRequestCounts expectedRequestCounts = new()
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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedCancelInitiatedAt, deserialized.CancelInitiatedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEndedAt, deserialized.EndedAt);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedProcessingStatus, deserialized.ProcessingStatus);
        Assert.Equal(expectedRequestCounts, deserialized.RequestCounts);
        Assert.Equal(expectedResultsURL, deserialized.ResultsURL);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageBatch
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
        };

        model.Validate();
    }
}

public class ProcessingStatusTest : TestBase
{
    [Theory]
    [InlineData(ProcessingStatus.InProgress)]
    [InlineData(ProcessingStatus.Canceling)]
    [InlineData(ProcessingStatus.Ended)]
    public void Validation_Works(ProcessingStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProcessingStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProcessingStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProcessingStatus.InProgress)]
    [InlineData(ProcessingStatus.Canceling)]
    [InlineData(ProcessingStatus.Ended)]
    public void SerializationRoundtrip_Works(ProcessingStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProcessingStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProcessingStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProcessingStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProcessingStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
