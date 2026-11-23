using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Models.Organization.Workspaces;

public class StorageProfileMismatchErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StorageProfileMismatchErrorDetails { Field = "field" };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "storage_profile_mismatch"
        );
        string expectedField = "field";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StorageProfileMismatchErrorDetails { Field = "field" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StorageProfileMismatchErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StorageProfileMismatchErrorDetails { Field = "field" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StorageProfileMismatchErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "storage_profile_mismatch"
        );
        string expectedField = "field";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StorageProfileMismatchErrorDetails { Field = "field" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StorageProfileMismatchErrorDetails { Field = "field" };

        StorageProfileMismatchErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
