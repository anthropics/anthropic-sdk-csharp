using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class PermissionErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PermissionError
        {
            Message = "message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"permission_error\""),
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"permission_error\"");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
