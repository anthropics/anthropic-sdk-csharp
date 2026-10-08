using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebFetchUrlSourceToolFilterTest : TestBase
{
    [Fact]
    public void AllValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilter value =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilter value =
            new BetaManagedAgentsWebFetchUrlSourceNone();
        value.Validate();
    }

    [Fact]
    public void OnlyValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilter value =
            new BetaManagedAgentsWebFetchUrlSourceOnly([new("x")]);
        value.Validate();
    }

    [Fact]
    public void ExceptValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilter value =
            new BetaManagedAgentsWebFetchUrlSourceExcept([new("x")]);
        value.Validate();
    }

    [Fact]
    public void AllSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilter value =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceToolFilter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilter value =
            new BetaManagedAgentsWebFetchUrlSourceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceToolFilter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OnlySerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilter value =
            new BetaManagedAgentsWebFetchUrlSourceOnly([new("x")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceToolFilter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExceptSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilter value =
            new BetaManagedAgentsWebFetchUrlSourceExcept([new("x")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceToolFilter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilter value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all",
                  "tools": [
                    {
                      "name": "x",
                      "type": "tool_reference"
                    }
                  ]
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("all");
        List<BetaManagedAgentsWebFetchUrlSourceToolReference> expectedTools = [new("x")];

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.NotNull(value.Tools);
        Assert.Equal(expectedTools.Count, value.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], value.Tools[i]);
        }

        BetaManagedAgentsWebFetchUrlSourceToolFilter emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Tools);
    }
}
