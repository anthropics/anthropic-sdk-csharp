using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChangeToolDefinitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolChangeToolDefinition
        {
            Definition = new BetaResponseTool()
            {
                InputSchema = new()
                {
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "location", JsonSerializer.SerializeToElement("bar") },
                        { "unit", JsonSerializer.SerializeToElement("bar") },
                    },
                    Required = ["location"],
                },
                Name = "name",
                AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
                DeferLoading = true,
                Description = "Get the current weather in a given location",
                EagerInputStreaming = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
                Type = BetaResponseToolType.Custom,
            },
        };

        BetaResponseToolUnion expectedDefinition = new BetaResponseTool()
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = BetaResponseToolType.Custom,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_definition");

        Assert.Equal(expectedDefinition, model.Definition);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolChangeToolDefinition
        {
            Definition = new BetaResponseTool()
            {
                InputSchema = new()
                {
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "location", JsonSerializer.SerializeToElement("bar") },
                        { "unit", JsonSerializer.SerializeToElement("bar") },
                    },
                    Required = ["location"],
                },
                Name = "name",
                AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
                DeferLoading = true,
                Description = "Get the current weather in a given location",
                EagerInputStreaming = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
                Type = BetaResponseToolType.Custom,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChangeToolDefinition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolChangeToolDefinition
        {
            Definition = new BetaResponseTool()
            {
                InputSchema = new()
                {
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "location", JsonSerializer.SerializeToElement("bar") },
                        { "unit", JsonSerializer.SerializeToElement("bar") },
                    },
                    Required = ["location"],
                },
                Name = "name",
                AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
                DeferLoading = true,
                Description = "Get the current weather in a given location",
                EagerInputStreaming = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
                Type = BetaResponseToolType.Custom,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChangeToolDefinition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaResponseToolUnion expectedDefinition = new BetaResponseTool()
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = BetaResponseToolType.Custom,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_definition");

        Assert.Equal(expectedDefinition, deserialized.Definition);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolChangeToolDefinition
        {
            Definition = new BetaResponseTool()
            {
                InputSchema = new()
                {
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "location", JsonSerializer.SerializeToElement("bar") },
                        { "unit", JsonSerializer.SerializeToElement("bar") },
                    },
                    Required = ["location"],
                },
                Name = "name",
                AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
                DeferLoading = true,
                Description = "Get the current weather in a given location",
                EagerInputStreaming = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
                Type = BetaResponseToolType.Custom,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaToolChangeToolDefinition
        {
            Definition = new BetaResponseTool()
            {
                InputSchema = new()
                {
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "location", JsonSerializer.SerializeToElement("bar") },
                        { "unit", JsonSerializer.SerializeToElement("bar") },
                    },
                    Required = ["location"],
                },
                Name = "name",
                AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
                DeferLoading = true,
                Description = "Get the current weather in a given location",
                EagerInputStreaming = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
                Type = BetaResponseToolType.Custom,
            },
        };

        BetaToolChangeToolDefinition copied = new(model);

        Assert.Equal(model, copied);
    }
}
