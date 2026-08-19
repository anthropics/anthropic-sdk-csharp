using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Files;

namespace Anthropic.Tests.Models.Files;

public class FileMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            Downloadable = false,
            ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
        };

        string expectedID = "file_011CNha8iCJcU1wXNR6q4V8w";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z");
        string expectedFilename = "document.pdf";
        string expectedMimeType = "application/pdf";
        long expectedSizeBytes = 102400;
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");
        bool expectedDownloadable = false;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDownloadable, model.Downloadable);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            Downloadable = false,
            ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            Downloadable = false,
            ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "file_011CNha8iCJcU1wXNR6q4V8w";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z");
        string expectedFilename = "document.pdf";
        string expectedMimeType = "application/pdf";
        long expectedSizeBytes = 102400;
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");
        bool expectedDownloadable = false;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDownloadable, deserialized.Downloadable);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            Downloadable = false,
            ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
        };

        Assert.Null(model.Downloadable);
        Assert.False(model.RawData.ContainsKey("downloadable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),

            // Null should be interpreted as omitted for these properties
            Downloadable = null,
        };

        Assert.Null(model.Downloadable);
        Assert.False(model.RawData.ContainsKey("downloadable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),

            // Null should be interpreted as omitted for these properties
            Downloadable = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            Downloadable = false,
        };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            Downloadable = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            Downloadable = false,

            ExpiresAt = null,
        };

        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            Downloadable = false,

            ExpiresAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileMetadata
        {
            ID = "file_011CNha8iCJcU1wXNR6q4V8w",
            CreatedAt = DateTimeOffset.Parse("2025-04-15T18:37:24.100435Z"),
            Filename = "document.pdf",
            MimeType = "application/pdf",
            SizeBytes = 102400,
            Downloadable = false,
            ExpiresAt = DateTimeOffset.Parse("2025-05-15T18:37:24.100435Z"),
        };

        FileMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
