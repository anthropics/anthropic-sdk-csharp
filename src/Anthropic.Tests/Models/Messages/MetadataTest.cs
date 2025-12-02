using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metadata { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" };

        string expectedUserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b";

        Assert.Equal(expectedUserID, model.UserID);
    }
}
