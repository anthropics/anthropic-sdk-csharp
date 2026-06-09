using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Deployments;
using Sessions = Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsSessionResourceConfigTest : TestBase
{
    [Fact]
    public void GitHubRepositoryValidationWorks()
    {
        BetaManagedAgentsSessionResourceConfig value =
            new BetaManagedAgentsGitHubRepositoryResourceConfig()
            {
                Type = BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                Url = "url",
                Checkout = new Sessions::BetaManagedAgentsBranchCheckout()
                {
                    Name = "main",
                    Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
                },
                MountPath = "mount_path",
            };
        value.Validate();
    }

    [Fact]
    public void FileValidationWorks()
    {
        BetaManagedAgentsSessionResourceConfig value = new BetaManagedAgentsFileResourceConfig()
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,
            MountPath = "mount_path",
        };
        value.Validate();
    }

    [Fact]
    public void MemoryStoreValidationWorks()
    {
        BetaManagedAgentsSessionResourceConfig value =
            new BetaManagedAgentsMemoryStoreResourceConfig()
            {
                MemoryStoreID = "memory_store_id",
                Type = BetaManagedAgentsMemoryStoreResourceConfigType.MemoryStore,
                Access = Access.ReadWrite,
                Instructions = "instructions",
            };
        value.Validate();
    }

    [Fact]
    public void GitHubRepositorySerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionResourceConfig value =
            new BetaManagedAgentsGitHubRepositoryResourceConfig()
            {
                Type = BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
                Url = "url",
                Checkout = new Sessions::BetaManagedAgentsBranchCheckout()
                {
                    Name = "main",
                    Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
                },
                MountPath = "mount_path",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionResourceConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionResourceConfig value = new BetaManagedAgentsFileResourceConfig()
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileResourceConfigType.File,
            MountPath = "mount_path",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionResourceConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryStoreSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionResourceConfig value =
            new BetaManagedAgentsMemoryStoreResourceConfig()
            {
                MemoryStoreID = "memory_store_id",
                Type = BetaManagedAgentsMemoryStoreResourceConfigType.MemoryStore,
                Access = Access.ReadWrite,
                Instructions = "instructions",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionResourceConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
