using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageParam { Content = "string", Role = Role.User };

        MessageParamContent expectedContent = "string";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
    }
}
