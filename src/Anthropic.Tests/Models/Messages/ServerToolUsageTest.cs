using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ServerToolUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServerToolUsage { WebSearchRequests = 0 };

        long expectedWebSearchRequests = 0;

        Assert.Equal(expectedWebSearchRequests, model.WebSearchRequests);
    }
}
