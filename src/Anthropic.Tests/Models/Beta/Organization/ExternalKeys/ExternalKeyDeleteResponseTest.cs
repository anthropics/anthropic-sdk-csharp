using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalKeys;

public class ExternalKeyDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalKeyDeleteResponse { ID = "ekey_01AbCdEfGhIjKlMnOpQrStUv" };

        string expectedID = "ekey_01AbCdEfGhIjKlMnOpQrStUv";
        JsonElement expectedType = JsonSerializer.SerializeToElement("external_key_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalKeyDeleteResponse { ID = "ekey_01AbCdEfGhIjKlMnOpQrStUv" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalKeyDeleteResponse { ID = "ekey_01AbCdEfGhIjKlMnOpQrStUv" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ekey_01AbCdEfGhIjKlMnOpQrStUv";
        JsonElement expectedType = JsonSerializer.SerializeToElement("external_key_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalKeyDeleteResponse { ID = "ekey_01AbCdEfGhIjKlMnOpQrStUv" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExternalKeyDeleteResponse { ID = "ekey_01AbCdEfGhIjKlMnOpQrStUv" };

        ExternalKeyDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
