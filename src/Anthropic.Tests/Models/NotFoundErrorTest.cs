using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class NotFoundErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotFoundError
        {
            Message = "message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"not_found_error\""),
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"not_found_error\"");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
