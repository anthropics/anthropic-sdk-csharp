using System;
using System.Collections.Generic;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Tests.Models.Beta.Files;

public class FileListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filename = "x",
                    MimeType = "x",
                    SizeBytes = 0,
                    Downloadable = true,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        List<FileMetadata> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filename = "x",
                MimeType = "x",
                SizeBytes = 0,
                Downloadable = true,
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
