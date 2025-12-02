using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestMCPServerURLDefinitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestMCPServerURLDefinition
        {
            Name = "name",
            Type = JsonSerializer.Deserialize<JsonElement>("\"url\""),
            URL = "url",
            AuthorizationToken = "authorization_token",
            ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
        };

        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedURL = "url";
        string expectedAuthorizationToken = "authorization_token";
        BetaRequestMCPServerToolConfiguration expectedToolConfiguration = new()
        {
            AllowedTools = ["string"],
            Enabled = true,
        };

        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedAuthorizationToken, model.AuthorizationToken);
        Assert.Equal(expectedToolConfiguration, model.ToolConfiguration);
    }
}
