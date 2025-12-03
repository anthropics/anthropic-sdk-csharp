using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContentBlockSource { Content = "string" };

        Content expectedContent = "string";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"content\"");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContentBlockSource { Content = "string" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContentBlockSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContentBlockSource { Content = "string" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ContentBlockSource>(json);
        Assert.NotNull(deserialized);

        Content expectedContent = "string";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"content\"");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContentBlockSource { Content = "string" };

        model.Validate();
    }
}
