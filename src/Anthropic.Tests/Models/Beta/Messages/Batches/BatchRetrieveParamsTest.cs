using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BatchRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BatchRetrieveParams
        {
            MessageBatchID = "message_batch_id",
            Betas = ["string"],
        };

        string expectedMessageBatchID = "message_batch_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = ["string"];

        Assert.Equal(expectedMessageBatchID, parameters.MessageBatchID);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BatchRetrieveParams { MessageBatchID = "message_batch_id" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BatchRetrieveParams
        {
            MessageBatchID = "message_batch_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
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
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BatchRetrieveParams parameters = new()
        {
            MessageBatchID = "message_batch_id",
            Betas = ["string"],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24", "string"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BatchRetrieveParams
        {
            MessageBatchID = "message_batch_id",
            Betas = ["string"],
        };

        BatchRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
