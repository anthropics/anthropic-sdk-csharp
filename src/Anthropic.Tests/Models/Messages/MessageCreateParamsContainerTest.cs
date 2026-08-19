using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageCreateParamsContainerTest : TestBase
{
    [Fact]
    public void ContainerParamsValidationWorks()
    {
        MessageCreateParamsContainer value = new ContainerParams()
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = SkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        MessageCreateParamsContainer value = "string";
        value.Validate();
    }

    [Fact]
    public void ContainerParamsSerializationRoundtripWorks()
    {
        MessageCreateParamsContainer value = new ContainerParams()
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = SkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCreateParamsContainer>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MessageCreateParamsContainer value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCreateParamsContainer>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
