using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Resources;
using Sessions = Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class ResourceUpdateResponseTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceValidationWorks()
    {
        ResourceUpdateResponse value = new BetaManagedAgentsGitHubRepositoryResource()
        {
            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            MountPath = "/workspace/example-repo",
            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Url = "https://github.com/example-org/example-repo",
            Checkout = new Sessions::BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileResourceValidationWorks()
    {
        ResourceUpdateResponse value = new BetaManagedAgentsFileResource()
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            Type = BetaManagedAgentsFileResourceType.File,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceValidationWorks()
    {
        ResourceUpdateResponse value = new BetaManagedAgentsMemoryStoreResource()
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Description = "description",
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceSerializationRoundtripWorks()
    {
        ResourceUpdateResponse value = new BetaManagedAgentsGitHubRepositoryResource()
        {
            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            MountPath = "/workspace/example-repo",
            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Url = "https://github.com/example-org/example-repo",
            Checkout = new Sessions::BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileResourceSerializationRoundtripWorks()
    {
        ResourceUpdateResponse value = new BetaManagedAgentsFileResource()
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            Type = BetaManagedAgentsFileResourceType.File,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceSerializationRoundtripWorks()
    {
        ResourceUpdateResponse value = new BetaManagedAgentsMemoryStoreResource()
        {
            MemoryStoreID = "memory_store_id",
            Type = BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            Access = Access.ReadWrite,
            Description = "description",
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ResourceUpdateResponse value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                  "created_at": "2026-03-15T10:00:00Z",
                  "mount_path": "/workspace/example-repo",
                  "updated_at": "2026-03-15T10:00:00Z"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedMountPath = "/workspace/example-repo";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedCreatedAt, value.CreatedAt);
        Assert.Equal(expectedMountPath, value.MountPath);
        Assert.Equal(expectedUpdatedAt, value.UpdatedAt);

        ResourceUpdateResponse emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.ID);
        Assert.Null(emptyValue.CreatedAt);
        Assert.Null(emptyValue.MountPath);
        Assert.Null(emptyValue.UpdatedAt);

        ResourceUpdateResponse mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ],
                  "created_at": [
                    "invalid"
                  ],
                  "mount_path": [
                    "invalid"
                  ],
                  "updated_at": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ID);
        Assert.Null(mismatchedValue.CreatedAt);
        Assert.Null(mismatchedValue.MountPath);
        Assert.Null(mismatchedValue.UpdatedAt);
    }
}
