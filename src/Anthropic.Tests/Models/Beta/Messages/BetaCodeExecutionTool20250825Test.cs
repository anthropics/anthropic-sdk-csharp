using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionTool20250825Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCodeExecutionTool20250825
        {
            Name = JsonSerializer.Deserialize<JsonElement>("\"code_execution\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_20250825\""),
            AllowedCallers = [AllowedCallerModel.Direct],
            CacheControl = new() { TTL = TTL.TTL5m },
            DeferLoading = true,
            Strict = true,
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"code_execution\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_20250825\""
        );
        List<ApiEnum<string, AllowedCallerModel>> expectedAllowedCallers =
        [
            AllowedCallerModel.Direct,
        ];
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedStrict, model.Strict);
    }
}
