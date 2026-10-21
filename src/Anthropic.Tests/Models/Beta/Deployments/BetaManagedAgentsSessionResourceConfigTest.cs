using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
                Url = "url",
                Checkout = new Sessions::BetaManagedAgentsBranchCheckout("main"),
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
                Url = "url",
                Checkout = new Sessions::BetaManagedAgentsBranchCheckout("main"),
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

    [Fact]
    public void GitHubRepositoryTypeWorks()
    {
        BetaManagedAgentsSessionResourceConfig value =
            new BetaManagedAgentsGitHubRepositoryResourceConfig()
            {
                Url = "url",
                Checkout = new Sessions::BetaManagedAgentsBranchCheckout("main"),
                MountPath = "mount_path",
            };
        Assert.Equal(
            BetaManagedAgentsSessionResourceConfigType.GitHubRepository,
            value.Type.Value()
        );
    }

    [Fact]
    public void FileTypeWorks()
    {
        BetaManagedAgentsSessionResourceConfig value = new BetaManagedAgentsFileResourceConfig()
        {
            FileID = "file_id",
            MountPath = "mount_path",
        };
        Assert.Equal(BetaManagedAgentsSessionResourceConfigType.File, value.Type.Value());
    }

    [Fact]
    public void MemoryStoreTypeWorks()
    {
        BetaManagedAgentsSessionResourceConfig value =
            new BetaManagedAgentsMemoryStoreResourceConfig()
            {
                MemoryStoreID = "memory_store_id",
                Access = Access.ReadWrite,
                Instructions = "instructions",
            };
        Assert.Equal(BetaManagedAgentsSessionResourceConfigType.MemoryStore, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSessionResourceConfig value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "github_repository",
                  "mount_path": "mount_path"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsSessionResourceConfigType> expectedType =
            BetaManagedAgentsSessionResourceConfigType.GitHubRepository;
        string expectedMountPath = "mount_path";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedMountPath, value.MountPath);

        BetaManagedAgentsSessionResourceConfig emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.MountPath);

        BetaManagedAgentsSessionResourceConfig mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "mount_path": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.MountPath);
    }
}

public class BetaManagedAgentsSessionResourceConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionResourceConfigType.GitHubRepository)]
    [InlineData(BetaManagedAgentsSessionResourceConfigType.File)]
    [InlineData(BetaManagedAgentsSessionResourceConfigType.MemoryStore)]
    public void Validation_Works(BetaManagedAgentsSessionResourceConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionResourceConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionResourceConfigType.GitHubRepository)]
    [InlineData(BetaManagedAgentsSessionResourceConfigType.File)]
    [InlineData(BetaManagedAgentsSessionResourceConfigType.MemoryStore)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionResourceConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionResourceConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
