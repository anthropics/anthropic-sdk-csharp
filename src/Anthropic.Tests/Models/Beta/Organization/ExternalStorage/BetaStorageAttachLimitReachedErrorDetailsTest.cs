using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaStorageAttachLimitReachedErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaStorageAttachLimitReachedErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "storage_attach_limit_reached"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaStorageAttachLimitReachedErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageAttachLimitReachedErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaStorageAttachLimitReachedErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaStorageAttachLimitReachedErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "storage_attach_limit_reached"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaStorageAttachLimitReachedErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaStorageAttachLimitReachedErrorDetails { };

        BetaStorageAttachLimitReachedErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
