using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestMcpServerURLDefinitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestMcpServerURLDefinition
        {
            Name = "name",
            Url = "url",
            AuthorizationToken = "authorization_token",
            ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
        };

        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedUrl = "url";
        string expectedAuthorizationToken = "authorization_token";
        BetaRequestMcpServerToolConfiguration expectedToolConfiguration = new()
        {
            AllowedTools = ["string"],
            Enabled = true,
        };

        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedAuthorizationToken, model.AuthorizationToken);
        Assert.Equal(expectedToolConfiguration, model.ToolConfiguration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRequestMcpServerURLDefinition
        {
            Name = "name",
            Url = "url",
            AuthorizationToken = "authorization_token",
            ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMcpServerURLDefinition>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestMcpServerURLDefinition
        {
            Name = "name",
            Url = "url",
            AuthorizationToken = "authorization_token",
            ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMcpServerURLDefinition>(element);
        Assert.NotNull(deserialized);

        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedUrl = "url";
        string expectedAuthorizationToken = "authorization_token";
        BetaRequestMcpServerToolConfiguration expectedToolConfiguration = new()
        {
            AllowedTools = ["string"],
            Enabled = true,
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedAuthorizationToken, deserialized.AuthorizationToken);
        Assert.Equal(expectedToolConfiguration, deserialized.ToolConfiguration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRequestMcpServerURLDefinition
        {
            Name = "name",
            Url = "url",
            AuthorizationToken = "authorization_token",
            ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaRequestMcpServerURLDefinition { Name = "name", Url = "url" };

        Assert.Null(model.AuthorizationToken);
        Assert.False(model.RawData.ContainsKey("authorization_token"));
        Assert.Null(model.ToolConfiguration);
        Assert.False(model.RawData.ContainsKey("tool_configuration"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaRequestMcpServerURLDefinition { Name = "name", Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaRequestMcpServerURLDefinition
        {
            Name = "name",
            Url = "url",

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
        var model = new BetaRequestMcpServerURLDefinition
        {
            Name = "name",
            Url = "url",

            AuthorizationToken = null,
            ToolConfiguration = null,
        };

        model.Validate();
    }
}
