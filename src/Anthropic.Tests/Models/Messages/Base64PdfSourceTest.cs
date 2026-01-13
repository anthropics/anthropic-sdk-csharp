using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class Base64PdfSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Base64PdfSource { Data = "U3RhaW5sZXNzIHJvY2tz" };

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        JsonElement expectedMediaType = JsonSerializer.SerializeToElement("application/pdf");
        JsonElement expectedType = JsonSerializer.SerializeToElement("base64");

        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, model.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Base64PdfSource { Data = "U3RhaW5sZXNzIHJvY2tz" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Base64PdfSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Base64PdfSource { Data = "U3RhaW5sZXNzIHJvY2tz" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Base64PdfSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        JsonElement expectedMediaType = JsonSerializer.SerializeToElement("application/pdf");
        JsonElement expectedType = JsonSerializer.SerializeToElement("base64");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, deserialized.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Base64PdfSource { Data = "U3RhaW5sZXNzIHJvY2tz" };

        model.Validate();
    }
}
