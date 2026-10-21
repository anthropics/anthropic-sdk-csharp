using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebFetchUrlSourceUserInputTest : TestBase
{
    [Fact]
    public void AllValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceNone();
        value.Validate();
    }

    [Fact]
    public void AllSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceUserInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceUserInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("all");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaManagedAgentsWebFetchUrlSourceUserInput emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
