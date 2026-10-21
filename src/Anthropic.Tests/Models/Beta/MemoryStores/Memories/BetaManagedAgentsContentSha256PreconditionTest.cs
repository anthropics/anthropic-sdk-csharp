using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsContentSha256PreconditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition
        {
            ContentSha256 = "content_sha256",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("content_sha256");
        string expectedContentSha256 = "content_sha256";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedContentSha256, model.ContentSha256);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition
        {
            ContentSha256 = "content_sha256",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsContentSha256Precondition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition
        {
            ContentSha256 = "content_sha256",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsContentSha256Precondition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("content_sha256");
        string expectedContentSha256 = "content_sha256";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedContentSha256, deserialized.ContentSha256);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition
        {
            ContentSha256 = "content_sha256",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition { };

        Assert.Null(model.ContentSha256);
        Assert.False(model.RawData.ContainsKey("content_sha256"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition
        {
            // Null should be interpreted as omitted for these properties
            ContentSha256 = null,
        };

        Assert.Null(model.ContentSha256);
        Assert.False(model.RawData.ContainsKey("content_sha256"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition
        {
            ContentSha256 = "content_sha256",
        } with
        {
            // Null should be interpreted as omitted for these properties
            ContentSha256 = null,
        };

        Assert.Null(model.ContentSha256);
        Assert.False(model.RawData.ContainsKey("content_sha256"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition
        {
            // Null should be interpreted as omitted for these properties
            ContentSha256 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsContentSha256Precondition
        {
            ContentSha256 = "content_sha256",
        };

        BetaManagedAgentsContentSha256Precondition copied = new(model);

        Assert.Equal(model, copied);
    }
}
