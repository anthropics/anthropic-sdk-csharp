using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class SignatureDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SignatureDelta
        {
            Signature = "signature",
            Type = JsonSerializer.Deserialize<JsonElement>("\"signature_delta\""),
        };

        string expectedSignature = "signature";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"signature_delta\"");

        Assert.Equal(expectedSignature, model.Signature);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
