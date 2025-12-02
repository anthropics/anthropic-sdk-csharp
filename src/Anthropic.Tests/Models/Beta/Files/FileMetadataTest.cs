using System;
using System.Text.Json;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Tests.Models.Beta.Files;

public class FileMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileMetadata
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filename = "x",
            MimeType = "x",
            SizeBytes = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"file\""),
            Downloadable = true,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFilename = "x";
        string expectedMimeType = "x";
        long expectedSizeBytes = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"file\"");
        bool expectedDownloadable = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDownloadable, model.Downloadable);
    }
}
