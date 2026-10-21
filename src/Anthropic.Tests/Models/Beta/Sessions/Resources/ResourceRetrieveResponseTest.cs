using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Resources;
using Sessions = Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class ResourceRetrieveResponseTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceValidationWorks()
    {
        ResourceRetrieveResponse value = new BetaManagedAgentsGitHubRepositoryResource()
        {
            ID = "sesrsc_011CZkZCKr6eXym1gWMPdQiu",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            MountPath = "/workspace/example-repo",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Url = "https://github.com/example-org/example-repo",
            Checkout = new Sessions::BetaManagedAgentsBranchCheckout("main"),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileResourceValidationWorks()
    {
        ResourceRetrieveResponse value = new BetaManagedAgentsFileResource()
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceValidationWorks()
    {
        ResourceRetrieveResponse value = new BetaManagedAgentsMemoryStoreResource()
        {
            MemoryStoreID = "memory_store_id",
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
        ResourceRetrieveResponse value = new BetaManagedAgentsGitHubRepositoryResource()
        {
            ID = "sesrsc_011CZkZCKr6eXym1gWMPdQiu",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            MountPath = "/workspace/example-repo",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Url = "https://github.com/example-org/example-repo",
            Checkout = new Sessions::BetaManagedAgentsBranchCheckout("main"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileResourceSerializationRoundtripWorks()
    {
        ResourceRetrieveResponse value = new BetaManagedAgentsFileResource()
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceSerializationRoundtripWorks()
    {
        ResourceRetrieveResponse value = new BetaManagedAgentsMemoryStoreResource()
        {
            MemoryStoreID = "memory_store_id",
            Access = Access.ReadWrite,
            Description = "description",
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsGitHubRepositoryResourceTypeWorks()
    {
        ResourceRetrieveResponse value = new BetaManagedAgentsGitHubRepositoryResource()
        {
            ID = "sesrsc_011CZkZCKr6eXym1gWMPdQiu",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            MountPath = "/workspace/example-repo",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Url = "https://github.com/example-org/example-repo",
            Checkout = new Sessions::BetaManagedAgentsBranchCheckout("main"),
        };
        Assert.Equal(ResourceRetrieveResponseType.GitHubRepository, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsFileResourceTypeWorks()
    {
        ResourceRetrieveResponse value = new BetaManagedAgentsFileResource()
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        Assert.Equal(ResourceRetrieveResponseType.File, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreResourceTypeWorks()
    {
        ResourceRetrieveResponse value = new BetaManagedAgentsMemoryStoreResource()
        {
            MemoryStoreID = "memory_store_id",
            Access = Access.ReadWrite,
            Description = "description",
            Instructions = "instructions",
            MountPath = "mount_path",
            Name = "name",
        };
        Assert.Equal(ResourceRetrieveResponseType.MemoryStore, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ResourceRetrieveResponse value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "sesrsc_011CZkZCKr6eXym1gWMPdQiu",
                  "created_at": "2026-03-15T10:00:00Z",
                  "mount_path": "/workspace/example-repo",
                  "type": "github_repository",
                  "updated_at": "2026-03-15T10:00:00Z"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "sesrsc_011CZkZCKr6eXym1gWMPdQiu";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedMountPath = "/workspace/example-repo";
        ApiEnum<string, ResourceRetrieveResponseType> expectedType =
            ResourceRetrieveResponseType.GitHubRepository;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedCreatedAt, value.CreatedAt);
        Assert.Equal(expectedMountPath, value.MountPath);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedUpdatedAt, value.UpdatedAt);

        ResourceRetrieveResponse emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.ID);
        Assert.Null(emptyValue.CreatedAt);
        Assert.Null(emptyValue.MountPath);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.UpdatedAt);

        ResourceRetrieveResponse mismatchedValue = new(
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

public class ResourceRetrieveResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(ResourceRetrieveResponseType.GitHubRepository)]
    [InlineData(ResourceRetrieveResponseType.File)]
    [InlineData(ResourceRetrieveResponseType.MemoryStore)]
    public void Validation_Works(ResourceRetrieveResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResourceRetrieveResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResourceRetrieveResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResourceRetrieveResponseType.GitHubRepository)]
    [InlineData(ResourceRetrieveResponseType.File)]
    [InlineData(ResourceRetrieveResponseType.MemoryStore)]
    public void SerializationRoundtrip_Works(ResourceRetrieveResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResourceRetrieveResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ResourceRetrieveResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResourceRetrieveResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ResourceRetrieveResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
