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
                    ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                    Scope = new("id"),
                },
            ],
            NextPage = "next_page",
        };

        List<BetaFileMetadata> expectedData =
        [
            new()
            {
                ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                Filename = "document.pdf",
                MimeType = "application/pdf",
                SizeBytes = 102400,
                Downloadable = false,
                ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                Scope = new("id"),
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
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
                    ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                    Scope = new("id"),
                },
            ],
            NextPage = "next_page",
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
                    ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                    Scope = new("id"),
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaFileMetadata> expectedData =
        [
            new()
            {
                ID = "file_011CNha8iCJcU1wXNR6q4V8w",
                CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
                Filename = "document.pdf",
                MimeType = "application/pdf",
                SizeBytes = 102400,
                Downloadable = false,
                ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                Scope = new("id"),
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
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
                    ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                    Scope = new("id"),
                },
            ],
            NextPage = "next_page",
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
                    ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                    Scope = new("id"),
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
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
                    ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                    Scope = new("id"),
                },
            ],
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
                    ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                    Scope = new("id"),
                },
            ],

            NextPage = null,
        };

        Assert.Null(model.NextPage);
        Assert.True(model.RawData.ContainsKey("next_page"));
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
                    ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                    Scope = new("id"),
                },
            ],

            NextPage = null,
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
                    ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
                    Scope = new("id"),
                },
            ],
            NextPage = "next_page",
        };

        FileListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
