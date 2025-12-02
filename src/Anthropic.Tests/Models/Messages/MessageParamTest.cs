using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageParam { Content = "string", Role = Role.User };

        MessageParamContent expectedContent = "string";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageParam { Content = "string", Role = Role.User };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageParam { Content = "string", Role = Role.User };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageParam>(json);
        Assert.NotNull(deserialized);

        MessageParamContent expectedContent = "string";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageParam { Content = "string", Role = Role.User };

        model.Validate();
    }
}
