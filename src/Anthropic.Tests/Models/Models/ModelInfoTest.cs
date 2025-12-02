using System;
using System.Text.Json;
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
            Type = JsonSerializer.Deserialize<JsonElement>("\"model\""),
        };

        string expectedID = "claude-sonnet-4-20250514";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z");
        string expectedDisplayName = "Claude Sonnet 4";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"model\"");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
