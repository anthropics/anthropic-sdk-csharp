using System;
using System.Collections.Generic;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FileListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FileListPageResponse>(element);
        Assert.NotNull(deserialized);

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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
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
            LastID = "last_id",
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
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
            LastID = "last_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
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
            LastID = "last_id",

            // Null should be interpreted as omitted for these properties
            HasMore = null,
        };

        Assert.Null(model.HasMore);
        Assert.False(model.RawData.ContainsKey("has_more"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
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
            LastID = "last_id",

            // Null should be interpreted as omitted for these properties
            HasMore = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
            HasMore = true,
        };

        Assert.Null(model.FirstID);
        Assert.False(model.RawData.ContainsKey("first_id"));
        Assert.Null(model.LastID);
        Assert.False(model.RawData.ContainsKey("last_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
            HasMore = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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
            HasMore = true,

            FirstID = null,
            LastID = null,
        };

        Assert.Null(model.FirstID);
        Assert.True(model.RawData.ContainsKey("first_id"));
        Assert.Null(model.LastID);
        Assert.True(model.RawData.ContainsKey("last_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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
            HasMore = true,

            FirstID = null,
            LastID = null,
        };

        model.Validate();
    }
}
