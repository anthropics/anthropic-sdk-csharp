using System;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class BatchCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BatchCancelParams { MessageBatchID = "message_batch_id" };

        string expectedMessageBatchID = "message_batch_id";

        Assert.Equal(expectedMessageBatchID, parameters.MessageBatchID);
    }

    [Fact]
    public void Url_Works()
    {
        BatchCancelParams parameters = new() { MessageBatchID = "message_batch_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri("https://api.anthropic.com/v1/messages/batches/message_batch_id/cancel"),
            url
        );
    }
}
