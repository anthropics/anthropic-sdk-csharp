using System.Text.Json;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaErrorResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaErrorResponse
        {
            Error = new BetaInvalidRequestError("message"),
            RequestID = "request_id",
            Type = JsonSerializer.Deserialize<JsonElement>("\"error\""),
        };

        BetaError expectedError = new BetaInvalidRequestError("message");
        string expectedRequestID = "request_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"error\"");

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
