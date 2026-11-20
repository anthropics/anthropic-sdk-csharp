using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaTranscriptsStorageRequiredErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTranscriptsStorageRequiredErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "transcripts_storage_required"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTranscriptsStorageRequiredErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTranscriptsStorageRequiredErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTranscriptsStorageRequiredErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTranscriptsStorageRequiredErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "transcripts_storage_required"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTranscriptsStorageRequiredErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTranscriptsStorageRequiredErrorDetails { };

        BetaTranscriptsStorageRequiredErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
