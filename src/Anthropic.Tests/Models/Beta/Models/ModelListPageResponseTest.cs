using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
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
                    ID = "claude-opus-4-6",
                    CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
                    DisplayName = "Claude Opus 4.6",
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
                ID = "claude-opus-4-6",
                CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
                DisplayName = "Claude Opus 4.6",
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
                    ID = "claude-opus-4-6",
                    CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
                    DisplayName = "Claude Opus 4.6",
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

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
                    ID = "claude-opus-4-6",
                    CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
                    DisplayName = "Claude Opus 4.6",
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaModelInfo> expectedData =
        [
            new()
            {
                ID = "claude-opus-4-6",
                CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
                DisplayName = "Claude Opus 4.6",
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
                    ID = "claude-opus-4-6",
                    CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
                    DisplayName = "Claude Opus 4.6",
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "claude-opus-4-6",
                    CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
                    DisplayName = "Claude Opus 4.6",
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        ModelListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
