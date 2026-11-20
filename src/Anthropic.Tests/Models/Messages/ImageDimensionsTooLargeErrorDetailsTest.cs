using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ImageDimensionsTooLargeErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageDimensionsTooLargeErrorDetails
        {
            MaxSideLengthPixels = 0,
            Paths = ["string"],
        };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "image_dimensions_too_large"
        );
        long expectedMaxSideLengthPixels = 0;
        List<string> expectedPaths = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedMaxSideLengthPixels, model.MaxSideLengthPixels);
        Assert.Equal(expectedPaths.Count, model.Paths.Count);
        for (int i = 0; i < expectedPaths.Count; i++)
        {
            Assert.Equal(expectedPaths[i], model.Paths[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageDimensionsTooLargeErrorDetails
        {
            MaxSideLengthPixels = 0,
            Paths = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageDimensionsTooLargeErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageDimensionsTooLargeErrorDetails
        {
            MaxSideLengthPixels = 0,
            Paths = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageDimensionsTooLargeErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "image_dimensions_too_large"
        );
        long expectedMaxSideLengthPixels = 0;
        List<string> expectedPaths = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedMaxSideLengthPixels, deserialized.MaxSideLengthPixels);
        Assert.Equal(expectedPaths.Count, deserialized.Paths.Count);
        for (int i = 0; i < expectedPaths.Count; i++)
        {
            Assert.Equal(expectedPaths[i], deserialized.Paths[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageDimensionsTooLargeErrorDetails
        {
            MaxSideLengthPixels = 0,
            Paths = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageDimensionsTooLargeErrorDetails
        {
            MaxSideLengthPixels = 0,
            Paths = ["string"],
        };

        ImageDimensionsTooLargeErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
