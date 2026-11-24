using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Organization.ApiKeys;

public class ApiKeyWorkspaceScopeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeyWorkspaceScope { WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace");
        string expectedWorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeyWorkspaceScope { WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyWorkspaceScope>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeyWorkspaceScope { WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyWorkspaceScope>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace");
        string expectedWorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeyWorkspaceScope { WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyWorkspaceScope { WorkspaceID = "wrkspc_01AbCdEfGhJkLmNpQrStUvWx" };

        ApiKeyWorkspaceScope copied = new(model);

        Assert.Equal(model, copied);
    }
}
