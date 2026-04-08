using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class BetaManagedAgentsSessionResourceTest : TestBase
{
    [Fact]
    public void GitHubRepositoryValidationWorks()
    {
        BetaManagedAgentsSessionResource value = new BetaManagedAgentsGitHubRepositoryResource()
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
        };
        value.Validate();
    }

    [Fact]
    public void FileValidationWorks()
    {
        BetaManagedAgentsSessionResource value = new BetaManagedAgentsFileResource()
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
    public void GitHubRepositorySerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionResource value = new BetaManagedAgentsGitHubRepositoryResource()
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionResource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionResource value = new BetaManagedAgentsFileResource()
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            MountPath = "/uploads/receipt.pdf",
            Type = BetaManagedAgentsFileResourceType.File,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionResource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
