using System;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class BatchRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BatchRetrieveParams { MessageBatchID = "message_batch_id" };

        string expectedMessageBatchID = "message_batch_id";

        Assert.Equal(expectedMessageBatchID, parameters.MessageBatchID);
    }

    [Fact]
    public void Url_Works()
    {
        BatchRetrieveParams parameters = new() { MessageBatchID = "message_batch_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri("https://api.anthropic.com/v1/messages/batches/message_batch_id"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BatchRetrieveParams { MessageBatchID = "message_batch_id" };

        BatchRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
