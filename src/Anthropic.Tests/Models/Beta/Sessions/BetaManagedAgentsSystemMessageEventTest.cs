using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSystemMessageEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<BetaManagedAgentsSystemContentBlock> expectedContent =
        [
            new("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("system.message");
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<BetaManagedAgentsSystemContentBlock> expectedContent =
        [
            new("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("system.message");
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
        };

        Assert.Null(model.ProcessedAt);
        Assert.False(model.RawData.ContainsKey("processed_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],

            ProcessedAt = null,
        };

        Assert.Null(model.ProcessedAt);
        Assert.True(model.RawData.ContainsKey("processed_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],

            ProcessedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaManagedAgentsSystemMessageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
