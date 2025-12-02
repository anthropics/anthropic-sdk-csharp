using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaSignatureDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSignatureDelta
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
