using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class ModelListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "claude-sonnet-4-20250514",
                    CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
                    DisplayName = "Claude Sonnet 4",
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        List<BetaModelInfo> expectedData =
        [
            new()
            {
                ID = "claude-sonnet-4-20250514",
                CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
                DisplayName = "Claude Sonnet 4",
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedFirstID, model.FirstID);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLastID, model.LastID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "claude-sonnet-4-20250514",
                    CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
                    DisplayName = "Claude Sonnet 4",
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ModelListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "claude-sonnet-4-20250514",
                    CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
                    DisplayName = "Claude Sonnet 4",
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ModelListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<BetaModelInfo> expectedData =
        [
            new()
            {
                ID = "claude-sonnet-4-20250514",
                CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
                DisplayName = "Claude Sonnet 4",
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedFirstID, deserialized.FirstID);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLastID, deserialized.LastID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "claude-sonnet-4-20250514",
                    CreatedAt = DateTimeOffset.Parse("2025-02-19T00:00:00Z"),
                    DisplayName = "Claude Sonnet 4",
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        model.Validate();
    }
}
