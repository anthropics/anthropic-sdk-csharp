using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;
using Sessions = Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsGitHubRepositoryResourceConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceConfig
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

        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceConfigType> expectedType =
            BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository;
        string expectedUrl = "url";
        Checkout expectedCheckout = new Sessions::BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
        };
        string expectedMountPath = "mount_path";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedCheckout, model.Checkout);
        Assert.Equal(expectedMountPath, model.MountPath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceConfig
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResourceConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceConfig
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResourceConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceConfigType> expectedType =
            BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository;
        string expectedUrl = "url";
        Checkout expectedCheckout = new Sessions::BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
        };
        string expectedMountPath = "mount_path";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedCheckout, deserialized.Checkout);
        Assert.Equal(expectedMountPath, deserialized.MountPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceConfig
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceConfig
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
            Url = "url",
        };

        Assert.Null(model.Checkout);
        Assert.False(model.RawData.ContainsKey("checkout"));
        Assert.Null(model.MountPath);
        Assert.False(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceConfig
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceConfig
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
            Url = "url",

            Checkout = null,
            MountPath = null,
        };

        Assert.Null(model.Checkout);
        Assert.True(model.RawData.ContainsKey("checkout"));
        Assert.Null(model.MountPath);
        Assert.True(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceConfig
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository,
            Url = "url",

            Checkout = null,
            MountPath = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceConfig
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

        BetaManagedAgentsGitHubRepositoryResourceConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsGitHubRepositoryResourceConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository)]
    public void Validation_Works(BetaManagedAgentsGitHubRepositoryResourceConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsGitHubRepositoryResourceConfigType.GitHubRepository)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsGitHubRepositoryResourceConfigType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsBranchValidationWorks()
    {
        Checkout value = new Sessions::BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCommitValidationWorks()
    {
        Checkout value = new Sessions::BetaManagedAgentsCommitCheckout()
        {
            Sha = "xxxxxxx",
            Type = Sessions::BetaManagedAgentsCommitCheckoutType.Commit,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsBranchSerializationRoundtripWorks()
    {
        Checkout value = new Sessions::BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkout>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCommitSerializationRoundtripWorks()
    {
        Checkout value = new Sessions::BetaManagedAgentsCommitCheckout()
        {
            Sha = "xxxxxxx",
            Type = Sessions::BetaManagedAgentsCommitCheckoutType.Commit,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkout>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
