using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class GatewayTimeoutErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GatewayTimeoutError
        {
            Message = "message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"timeout_error\""),
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"timeout_error\"");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
