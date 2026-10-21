using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class BetaEnvironmentDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaEnvironmentDeleteResponse { ID = "env_011CZkZ9X2dpNyB7HsEFoRfW" };

        string expectedID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        JsonElement expectedType = JsonSerializer.SerializeToElement("environment_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaEnvironmentDeleteResponse { ID = "env_011CZkZ9X2dpNyB7HsEFoRfW" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaEnvironmentDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaEnvironmentDeleteResponse { ID = "env_011CZkZ9X2dpNyB7HsEFoRfW" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaEnvironmentDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        JsonElement expectedType = JsonSerializer.SerializeToElement("environment_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaEnvironmentDeleteResponse { ID = "env_011CZkZ9X2dpNyB7HsEFoRfW" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaEnvironmentDeleteResponse { ID = "env_011CZkZ9X2dpNyB7HsEFoRfW" };

        BetaEnvironmentDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
