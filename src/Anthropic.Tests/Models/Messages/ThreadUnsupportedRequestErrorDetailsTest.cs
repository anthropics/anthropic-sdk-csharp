using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThreadUnsupportedRequestErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThreadUnsupportedRequestErrorDetails
        {
            Unsupported = [ThreadUnsupportedFeatureName.CacheControl],
        };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "thread_unsupported_request"
        );
        List<ApiEnum<string, ThreadUnsupportedFeatureName>> expectedUnsupported =
        [
            ThreadUnsupportedFeatureName.CacheControl,
        ];

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.NotNull(model.Unsupported);
        Assert.Equal(expectedUnsupported.Count, model.Unsupported.Count);
        for (int i = 0; i < expectedUnsupported.Count; i++)
        {
            Assert.Equal(expectedUnsupported[i], model.Unsupported[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThreadUnsupportedRequestErrorDetails
        {
            Unsupported = [ThreadUnsupportedFeatureName.CacheControl],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThreadUnsupportedRequestErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThreadUnsupportedRequestErrorDetails
        {
            Unsupported = [ThreadUnsupportedFeatureName.CacheControl],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThreadUnsupportedRequestErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "thread_unsupported_request"
        );
        List<ApiEnum<string, ThreadUnsupportedFeatureName>> expectedUnsupported =
        [
            ThreadUnsupportedFeatureName.CacheControl,
        ];

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.NotNull(deserialized.Unsupported);
        Assert.Equal(expectedUnsupported.Count, deserialized.Unsupported.Count);
        for (int i = 0; i < expectedUnsupported.Count; i++)
        {
            Assert.Equal(expectedUnsupported[i], deserialized.Unsupported[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThreadUnsupportedRequestErrorDetails
        {
            Unsupported = [ThreadUnsupportedFeatureName.CacheControl],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThreadUnsupportedRequestErrorDetails { };

        Assert.Null(model.Unsupported);
        Assert.False(model.RawData.ContainsKey("unsupported"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThreadUnsupportedRequestErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ThreadUnsupportedRequestErrorDetails { Unsupported = null };

        Assert.Null(model.Unsupported);
        Assert.True(model.RawData.ContainsKey("unsupported"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThreadUnsupportedRequestErrorDetails { Unsupported = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThreadUnsupportedRequestErrorDetails
        {
            Unsupported = [ThreadUnsupportedFeatureName.CacheControl],
        };

        ThreadUnsupportedRequestErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
