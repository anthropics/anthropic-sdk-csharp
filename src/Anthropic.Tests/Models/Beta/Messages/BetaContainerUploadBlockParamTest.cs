using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContainerUploadBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContainerUploadBlockParam
        {
            FileID = "file_id",
            Type = JsonSerializer.Deserialize<JsonElement>("\"container_upload\""),
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string expectedFileID = "file_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"container_upload\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedFileID, model.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }
}
