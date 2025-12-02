using System.Text.Json;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaInvalidRequestErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaInvalidRequestError
        {
            Message = "message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"invalid_request_error\""),
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"invalid_request_error\""
        );

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
