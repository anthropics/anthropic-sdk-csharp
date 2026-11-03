using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class CmekKeyUnreachableErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CmekKeyUnreachableErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("cmek_key_unreachable");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CmekKeyUnreachableErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CmekKeyUnreachableErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CmekKeyUnreachableErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CmekKeyUnreachableErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("cmek_key_unreachable");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CmekKeyUnreachableErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CmekKeyUnreachableErrorDetails { };

        CmekKeyUnreachableErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
