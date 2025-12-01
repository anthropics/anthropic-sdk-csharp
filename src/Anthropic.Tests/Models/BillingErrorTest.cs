using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class BillingErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingError
        {
            Message = "message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"billing_error\""),
        };

        string expectedMessage = "message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"billing_error\"");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
