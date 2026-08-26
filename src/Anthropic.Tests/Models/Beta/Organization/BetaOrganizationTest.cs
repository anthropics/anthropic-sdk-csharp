using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;

namespace Anthropic.Tests.Models.Beta.Organization;

public class BetaOrganizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOrganization
        {
            ID = "12345678-1234-5678-1234-567812345678",
            Name = "Organization Name",
        };

        string expectedID = "12345678-1234-5678-1234-567812345678";
        string expectedName = "Organization Name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOrganization
        {
            ID = "12345678-1234-5678-1234-567812345678",
            Name = "Organization Name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOrganization
        {
            ID = "12345678-1234-5678-1234-567812345678",
            Name = "Organization Name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "12345678-1234-5678-1234-567812345678";
        string expectedName = "Organization Name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOrganization
        {
            ID = "12345678-1234-5678-1234-567812345678",
            Name = "Organization Name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOrganization
        {
            ID = "12345678-1234-5678-1234-567812345678",
            Name = "Organization Name",
        };

        BetaOrganization copied = new(model);

        Assert.Equal(model, copied);
    }
}
