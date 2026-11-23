using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaStorageChangedConcurrentlyErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaStorageChangedConcurrentlyErrorDetails
        {
            Field = "inference_data_privacy.safeguards_storage",
        };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "storage_changed_concurrently"
        );
        string expectedField = "inference_data_privacy.safeguards_storage";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaStorageChangedConcurrentlyErrorDetails
        {
            Field = "inference_data_privacy.safeguards_storage",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageChangedConcurrentlyErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaStorageChangedConcurrentlyErrorDetails
        {
            Field = "inference_data_privacy.safeguards_storage",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageChangedConcurrentlyErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "storage_changed_concurrently"
        );
        string expectedField = "inference_data_privacy.safeguards_storage";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaStorageChangedConcurrentlyErrorDetails
        {
            Field = "inference_data_privacy.safeguards_storage",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaStorageChangedConcurrentlyErrorDetails
        {
            Field = "inference_data_privacy.safeguards_storage",
        };

        BetaStorageChangedConcurrentlyErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
