using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMetadata { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" };

        string expectedUserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b";

        Assert.Equal(expectedUserID, model.UserID);
    }
}
