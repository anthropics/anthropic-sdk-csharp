using System;
using System.Collections.Generic;
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
}
