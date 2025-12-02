using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class OverloadedErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OverloadedError
        {
            Message = "message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"overloaded_error\""),
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"overloaded_error\"");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
