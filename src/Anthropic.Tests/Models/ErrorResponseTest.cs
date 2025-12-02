using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class ErrorResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ErrorResponse
        {
            Error = new InvalidRequestError("message"),
            RequestID = "request_id",
            Type = JsonSerializer.Deserialize<JsonElement>("\"error\""),
        };

        ErrorObject expectedError = new InvalidRequestError("message");
        string expectedRequestID = "request_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"error\"");

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
