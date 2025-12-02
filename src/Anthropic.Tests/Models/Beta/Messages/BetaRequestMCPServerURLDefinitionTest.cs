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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRequestMCPServerURLDefinition
        {
            Name = "name",
            URL = "url",
            AuthorizationToken = "authorization_token",
            ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMCPServerURLDefinition>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestMCPServerURLDefinition
        {
            Name = "name",
            URL = "url",
            AuthorizationToken = "authorization_token",
            ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMCPServerURLDefinition>(json);
        Assert.NotNull(deserialized);

        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedURL = "url";
        string expectedAuthorizationToken = "authorization_token";
        BetaRequestMCPServerToolConfiguration expectedToolConfiguration = new()
        {
            AllowedTools = ["string"],
            Enabled = true,
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedURL, deserialized.URL);
        Assert.Equal(expectedAuthorizationToken, deserialized.AuthorizationToken);
        Assert.Equal(expectedToolConfiguration, deserialized.ToolConfiguration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRequestMCPServerURLDefinition
        {
            Name = "name",
            URL = "url",
            AuthorizationToken = "authorization_token",
            ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaRequestMCPServerURLDefinition { Name = "name", URL = "url" };

        Assert.Null(model.AuthorizationToken);
        Assert.False(model.RawData.ContainsKey("authorization_token"));
        Assert.Null(model.ToolConfiguration);
        Assert.False(model.RawData.ContainsKey("tool_configuration"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaRequestMCPServerURLDefinition { Name = "name", URL = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaRequestMCPServerURLDefinition
        {
            Name = "name",
            URL = "url",

            AuthorizationToken = null,
            ToolConfiguration = null,
        };

        Assert.Null(model.AuthorizationToken);
        Assert.True(model.RawData.ContainsKey("authorization_token"));
        Assert.Null(model.ToolConfiguration);
        Assert.True(model.RawData.ContainsKey("tool_configuration"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaRequestMCPServerURLDefinition
        {
            Name = "name",
            URL = "url",

            AuthorizationToken = null,
            ToolConfiguration = null,
        };

        model.Validate();
    }
}
