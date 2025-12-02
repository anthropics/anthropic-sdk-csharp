using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class APIErrorObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new APIErrorObject
        {
            Message = "message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"api_error\""),
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"api_error\"");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
