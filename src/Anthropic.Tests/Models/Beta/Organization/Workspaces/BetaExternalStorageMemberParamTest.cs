using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaExternalStorageMemberParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaExternalStorageMemberParam
        {
            ExternalStorageID = "external_storage_id",
        };

        string expectedExternalStorageID = "external_storage_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("external");

        Assert.Equal(expectedExternalStorageID, model.ExternalStorageID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaExternalStorageMemberParam
        {
            ExternalStorageID = "external_storage_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalStorageMemberParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaExternalStorageMemberParam
        {
            ExternalStorageID = "external_storage_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalStorageMemberParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExternalStorageID = "external_storage_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("external");

        Assert.Equal(expectedExternalStorageID, deserialized.ExternalStorageID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaExternalStorageMemberParam
        {
            ExternalStorageID = "external_storage_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaExternalStorageMemberParam
        {
            ExternalStorageID = "external_storage_id",
        };

        BetaExternalStorageMemberParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
