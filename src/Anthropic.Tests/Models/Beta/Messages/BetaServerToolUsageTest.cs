using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaServerToolUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServerToolUsage { WebFetchRequests = 2, WebSearchRequests = 0 };

        long expectedWebFetchRequests = 2;
        long expectedWebSearchRequests = 0;

        Assert.Equal(expectedWebFetchRequests, model.WebFetchRequests);
        Assert.Equal(expectedWebSearchRequests, model.WebSearchRequests);
    }
}
