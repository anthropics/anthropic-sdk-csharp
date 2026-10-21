using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class BetaManagedAgentsFileResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string expectedID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        string expectedMountPath = "/uploads/receipt.pdf";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedMountPath, model.MountPath);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsFileResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        string expectedMountPath = "/uploads/receipt.pdf";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedMountPath, deserialized.MountPath);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsFileResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsFileResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        BetaManagedAgentsFileResource copied = new(model);

        Assert.Equal(model, copied);
    }
}
