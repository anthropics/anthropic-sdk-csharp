using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class RateLimitErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateLimitError
        {
            Message = "message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"rate_limit_error\""),
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"rate_limit_error\"");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
