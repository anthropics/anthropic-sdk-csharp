using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class ResourceListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResourceListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsFileResource()
                {
                    ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                    Type = BetaManagedAgentsFileResourceType.File,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsGitHubRepositoryResource()
                {
                    ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MountPath = "/workspace/example-repo",
                    Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Url = "https://github.com/example-org/example-repo",
                    Checkout = new BetaManagedAgentsBranchCheckout()
                    {
                        Name = "main",
                        Type = BetaManagedAgentsBranchCheckoutType.Branch,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<BetaManagedAgentsSessionResource> expectedData =
        [
            new BetaManagedAgentsFileResource()
            {
                ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                MountPath = "/uploads/receipt.pdf",
                Type = BetaManagedAgentsFileResourceType.File,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            },
            new BetaManagedAgentsGitHubRepositoryResource()
            {
                ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                MountPath = "/workspace/example-repo",
                Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Url = "https://github.com/example-org/example-repo",
                Checkout = new BetaManagedAgentsBranchCheckout()
                {
                    Name = "main",
                    Type = BetaManagedAgentsBranchCheckoutType.Branch,
                },
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

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
        var model = new ResourceListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsFileResource()
                {
                    ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                    Type = BetaManagedAgentsFileResourceType.File,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsGitHubRepositoryResource()
                {
                    ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MountPath = "/workspace/example-repo",
                    Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Url = "https://github.com/example-org/example-repo",
                    Checkout = new BetaManagedAgentsBranchCheckout()
                    {
                        Name = "main",
                        Type = BetaManagedAgentsBranchCheckoutType.Branch,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResourceListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsFileResource()
                {
                    ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                    Type = BetaManagedAgentsFileResourceType.File,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsGitHubRepositoryResource()
                {
                    ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MountPath = "/workspace/example-repo",
                    Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Url = "https://github.com/example-org/example-repo",
                    Checkout = new BetaManagedAgentsBranchCheckout()
                    {
                        Name = "main",
                        Type = BetaManagedAgentsBranchCheckoutType.Branch,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsSessionResource> expectedData =
        [
            new BetaManagedAgentsFileResource()
            {
                ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                MountPath = "/uploads/receipt.pdf",
                Type = BetaManagedAgentsFileResourceType.File,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            },
            new BetaManagedAgentsGitHubRepositoryResource()
            {
                ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                MountPath = "/workspace/example-repo",
                Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Url = "https://github.com/example-org/example-repo",
                Checkout = new BetaManagedAgentsBranchCheckout()
                {
                    Name = "main",
                    Type = BetaManagedAgentsBranchCheckoutType.Branch,
                },
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

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
        var model = new ResourceListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsFileResource()
                {
                    ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                    Type = BetaManagedAgentsFileResourceType.File,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsGitHubRepositoryResource()
                {
                    ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MountPath = "/workspace/example-repo",
                    Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Url = "https://github.com/example-org/example-repo",
                    Checkout = new BetaManagedAgentsBranchCheckout()
                    {
                        Name = "main",
                        Type = BetaManagedAgentsBranchCheckoutType.Branch,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ResourceListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsFileResource()
                {
                    ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                    Type = BetaManagedAgentsFileResourceType.File,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsGitHubRepositoryResource()
                {
                    ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MountPath = "/workspace/example-repo",
                    Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Url = "https://github.com/example-org/example-repo",
                    Checkout = new BetaManagedAgentsBranchCheckout()
                    {
                        Name = "main",
                        Type = BetaManagedAgentsBranchCheckoutType.Branch,
                    },
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ResourceListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsFileResource()
                {
                    ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                    Type = BetaManagedAgentsFileResourceType.File,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsGitHubRepositoryResource()
                {
                    ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MountPath = "/workspace/example-repo",
                    Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Url = "https://github.com/example-org/example-repo",
                    Checkout = new BetaManagedAgentsBranchCheckout()
                    {
                        Name = "main",
                        Type = BetaManagedAgentsBranchCheckoutType.Branch,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ResourceListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsFileResource()
                {
                    ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                    Type = BetaManagedAgentsFileResourceType.File,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsGitHubRepositoryResource()
                {
                    ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MountPath = "/workspace/example-repo",
                    Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Url = "https://github.com/example-org/example-repo",
                    Checkout = new BetaManagedAgentsBranchCheckout()
                    {
                        Name = "main",
                        Type = BetaManagedAgentsBranchCheckoutType.Branch,
                    },
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
        var model = new ResourceListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsFileResource()
                {
                    ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                    Type = BetaManagedAgentsFileResourceType.File,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsGitHubRepositoryResource()
                {
                    ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MountPath = "/workspace/example-repo",
                    Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Url = "https://github.com/example-org/example-repo",
                    Checkout = new BetaManagedAgentsBranchCheckout()
                    {
                        Name = "main",
                        Type = BetaManagedAgentsBranchCheckoutType.Branch,
                    },
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResourceListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsFileResource()
                {
                    ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    MountPath = "/uploads/receipt.pdf",
                    Type = BetaManagedAgentsFileResourceType.File,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsGitHubRepositoryResource()
                {
                    ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    MountPath = "/workspace/example-repo",
                    Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Url = "https://github.com/example-org/example-repo",
                    Checkout = new BetaManagedAgentsBranchCheckout()
                    {
                        Name = "main",
                        Type = BetaManagedAgentsBranchCheckoutType.Branch,
                    },
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        ResourceListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
