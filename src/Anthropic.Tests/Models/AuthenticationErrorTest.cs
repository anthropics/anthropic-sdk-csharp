using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class AuthenticationErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuthenticationError
        {
            Message = "message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"authentication_error\""),
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"authentication_error\""
        );

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
