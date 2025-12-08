using System.Text.Json;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchRequestCountsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBatchRequestCounts
        {
            Canceled = 10,
            Errored = 30,
            Expired = 10,
            Processing = 100,
            Succeeded = 50,
        };

        long expectedCanceled = 10;
        long expectedErrored = 30;
        long expectedExpired = 10;
        long expectedProcessing = 100;
        long expectedSucceeded = 50;

        Assert.Equal(expectedCanceled, model.Canceled);
        Assert.Equal(expectedErrored, model.Errored);
        Assert.Equal(expectedExpired, model.Expired);
        Assert.Equal(expectedProcessing, model.Processing);
        Assert.Equal(expectedSucceeded, model.Succeeded);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageBatchRequestCounts
        {
            Canceled = 10,
            Errored = 30,
            Expired = 10,
            Processing = 100,
            Succeeded = 50,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageBatchRequestCounts>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageBatchRequestCounts
        {
            Canceled = 10,
            Errored = 30,
            Expired = 10,
            Processing = 100,
            Succeeded = 50,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageBatchRequestCounts>(json);
        Assert.NotNull(deserialized);

        long expectedCanceled = 10;
        long expectedErrored = 30;
        long expectedExpired = 10;
        long expectedProcessing = 100;
        long expectedSucceeded = 50;

        Assert.Equal(expectedCanceled, deserialized.Canceled);
        Assert.Equal(expectedErrored, deserialized.Errored);
        Assert.Equal(expectedExpired, deserialized.Expired);
        Assert.Equal(expectedProcessing, deserialized.Processing);
        Assert.Equal(expectedSucceeded, deserialized.Succeeded);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageBatchRequestCounts
        {
            Canceled = 10,
            Errored = 30,
            Expired = 10,
            Processing = 100,
            Succeeded = 50,
        };

        model.Validate();
    }
}
