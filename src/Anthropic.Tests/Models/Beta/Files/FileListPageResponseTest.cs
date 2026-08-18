using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            FirstID = "file_011CNha8iCJcU1wXNR6q4V8w",
            HasMore = true,
            LastID = "file_013Zva2CMHLNnXjNJJKqJ2EF",
        };

        List<FileMetadata> expectedData =
        [
            new()
            {
                ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                Filename = "document.pdf",
                MimeType = "application/pdf",
                SizeBytes = 102400,
                Downloadable = false,
                Scope = new("id"),
            },
        ];
        string expectedFirstID = "file_011CNha8iCJcU1wXNR6q4V8w";
        bool expectedHasMore = true;
        string expectedLastID = "file_013Zva2CMHLNnXjNJJKqJ2EF";

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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            FirstID = "file_011CNha8iCJcU1wXNR6q4V8w",
            HasMore = true,
            LastID = "file_013Zva2CMHLNnXjNJJKqJ2EF",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            FirstID = "file_011CNha8iCJcU1wXNR6q4V8w",
            HasMore = true,
            LastID = "file_013Zva2CMHLNnXjNJJKqJ2EF",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FileMetadata> expectedData =
        [
            new()
            {
                ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                Filename = "document.pdf",
                MimeType = "application/pdf",
                SizeBytes = 102400,
                Downloadable = false,
                Scope = new("id"),
            },
        ];
        string expectedFirstID = "file_011CNha8iCJcU1wXNR6q4V8w";
        bool expectedHasMore = true;
        string expectedLastID = "file_013Zva2CMHLNnXjNJJKqJ2EF";

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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            FirstID = "file_011CNha8iCJcU1wXNR6q4V8w",
            HasMore = true,
            LastID = "file_013Zva2CMHLNnXjNJJKqJ2EF",
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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            FirstID = "file_011CNha8iCJcU1wXNR6q4V8w",
            LastID = "file_013Zva2CMHLNnXjNJJKqJ2EF",
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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            FirstID = "file_011CNha8iCJcU1wXNR6q4V8w",
            LastID = "file_013Zva2CMHLNnXjNJJKqJ2EF",
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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            FirstID = "file_011CNha8iCJcU1wXNR6q4V8w",
            LastID = "file_013Zva2CMHLNnXjNJJKqJ2EF",

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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            FirstID = "file_011CNha8iCJcU1wXNR6q4V8w",
            LastID = "file_013Zva2CMHLNnXjNJJKqJ2EF",

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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
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
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            HasMore = true,

            FirstID = null,
            LastID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                    Filename = "document.pdf",
                    MimeType = "application/pdf",
                    SizeBytes = 102400,
                    Downloadable = false,
                    Scope = new("id"),
                },
            ],
            FirstID = "file_011CNha8iCJcU1wXNR6q4V8w",
            HasMore = true,
            LastID = "file_013Zva2CMHLNnXjNJJKqJ2EF",
        };

        FileListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
