using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaDeletedExternalStorageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDeletedExternalStorage { ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK" };

        string expectedID = "estrg_01SDCCSbTxrXDpWc1phhtcfK";
        JsonElement expectedType = JsonSerializer.SerializeToElement("external_storage_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDeletedExternalStorage { ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedExternalStorage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDeletedExternalStorage { ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedExternalStorage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "estrg_01SDCCSbTxrXDpWc1phhtcfK";
        JsonElement expectedType = JsonSerializer.SerializeToElement("external_storage_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDeletedExternalStorage { ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDeletedExternalStorage { ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK" };

        BetaDeletedExternalStorage copied = new(model);

        Assert.Equal(model, copied);
    }
}
