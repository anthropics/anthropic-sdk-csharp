using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Organization.ExternalKeys;

public class GcpExternalKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GcpExternalKeyConfig
        {
            KeyName = "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key",
        };

        string expectedKeyName = "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key";
        JsonElement expectedType = JsonSerializer.SerializeToElement("gcp");

        Assert.Equal(expectedKeyName, model.KeyName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GcpExternalKeyConfig
        {
            KeyName = "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GcpExternalKeyConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GcpExternalKeyConfig
        {
            KeyName = "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GcpExternalKeyConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKeyName = "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key";
        JsonElement expectedType = JsonSerializer.SerializeToElement("gcp");

        Assert.Equal(expectedKeyName, deserialized.KeyName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GcpExternalKeyConfig
        {
            KeyName = "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GcpExternalKeyConfig
        {
            KeyName = "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key",
        };

        GcpExternalKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
