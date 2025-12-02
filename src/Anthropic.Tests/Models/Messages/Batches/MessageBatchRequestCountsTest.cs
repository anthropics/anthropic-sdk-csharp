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
}
