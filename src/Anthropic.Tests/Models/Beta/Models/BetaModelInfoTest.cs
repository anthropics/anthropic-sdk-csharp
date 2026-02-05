using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaModelInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-4-6",
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
        };

        string expectedID = "claude-opus-4-6";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z");
        string expectedDisplayName = "Claude Opus 4.6";
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-4-6",
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaModelInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-4-6",
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaModelInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "claude-opus-4-6";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z");
        string expectedDisplayName = "Claude Opus 4.6";
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-4-6",
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-4-6",
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
        };

        BetaModelInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
