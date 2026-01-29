using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class ModelInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-sonnet-4-20250514",
            CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
            DisplayName = "Claude Sonnet 4",
        };

        string expectedID = "claude-sonnet-4-20250514";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z");
        string expectedDisplayName = "Claude Sonnet 4";
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-sonnet-4-20250514",
            CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
            DisplayName = "Claude Sonnet 4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelInfo>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-sonnet-4-20250514",
            CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
            DisplayName = "Claude Sonnet 4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "claude-sonnet-4-20250514";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z");
        string expectedDisplayName = "Claude Sonnet 4";
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-sonnet-4-20250514",
            CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
            DisplayName = "Claude Sonnet 4",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-sonnet-4-20250514",
            CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
            DisplayName = "Claude Sonnet 4",
        };

        ModelInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
