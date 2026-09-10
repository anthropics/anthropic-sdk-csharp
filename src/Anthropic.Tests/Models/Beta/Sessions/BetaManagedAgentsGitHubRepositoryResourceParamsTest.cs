using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsGitHubRepositoryResourceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",
        };

        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceParamsType> expectedType =
            BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository;
        string expectedUrl = "https://github.com/example-org/example-repo";
        string expectedAuthorizationToken = "ghp_exampletoken";
        Checkout expectedCheckout = new BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = BetaManagedAgentsBranchCheckoutType.Branch,
        };
        string expectedMountPath = "x";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedAuthorizationToken, model.AuthorizationToken);
        Assert.Equal(expectedCheckout, model.Checkout);
        Assert.Equal(expectedMountPath, model.MountPath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResourceParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResourceParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceParamsType> expectedType =
            BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository;
        string expectedUrl = "https://github.com/example-org/example-repo";
        string expectedAuthorizationToken = "ghp_exampletoken";
        Checkout expectedCheckout = new BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = BetaManagedAgentsBranchCheckoutType.Branch,
        };
        string expectedMountPath = "x";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedAuthorizationToken, deserialized.AuthorizationToken);
        Assert.Equal(expectedCheckout, deserialized.Checkout);
        Assert.Equal(expectedMountPath, deserialized.MountPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",
        };

        Assert.Null(model.AuthorizationToken);
        Assert.False(model.RawData.ContainsKey("authorization_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",

            // Null should be interpreted as omitted for these properties
            AuthorizationToken = null,
        };

        Assert.Null(model.AuthorizationToken);
        Assert.False(model.RawData.ContainsKey("authorization_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",

            // Null should be interpreted as omitted for these properties
            AuthorizationToken = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
        };

        Assert.Null(model.Checkout);
        Assert.False(model.RawData.ContainsKey("checkout"));
        Assert.Null(model.MountPath);
        Assert.False(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",

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
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",

            Checkout = null,
            MountPath = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Type = BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository,
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout()
            {
                Name = "main",
                Type = BetaManagedAgentsBranchCheckoutType.Branch,
            },
            MountPath = "x",
        };

        BetaManagedAgentsGitHubRepositoryResourceParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsGitHubRepositoryResourceParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository)]
    public void Validation_Works(BetaManagedAgentsGitHubRepositoryResourceParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsGitHubRepositoryResourceParamsType.GitHubRepository)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsGitHubRepositoryResourceParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsBranchValidationWorks()
    {
        Checkout value = new BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = BetaManagedAgentsBranchCheckoutType.Branch,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCommitValidationWorks()
    {
        Checkout value = new BetaManagedAgentsCommitCheckout()
        {
            Sha = "xxxxxxx",
            Type = BetaManagedAgentsCommitCheckoutType.Commit,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsBranchSerializationRoundtripWorks()
    {
        Checkout value = new BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = BetaManagedAgentsBranchCheckoutType.Branch,
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
        Checkout value = new BetaManagedAgentsCommitCheckout()
        {
            Sha = "xxxxxxx",
            Type = BetaManagedAgentsCommitCheckoutType.Commit,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkout>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
