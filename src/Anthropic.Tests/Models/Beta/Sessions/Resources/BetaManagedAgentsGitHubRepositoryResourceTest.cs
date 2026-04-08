using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Resources;
using Sessions = Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class BetaManagedAgentsGitHubRepositoryResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResource
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

        string expectedID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedMountPath = "/workspace/example-repo";
        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType> expectedType =
            BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedUrl = "https://github.com/example-org/example-repo";
        Checkout expectedCheckout = new Sessions::BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMountPath, model.MountPath);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedCheckout, model.Checkout);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResource
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResource
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedMountPath = "/workspace/example-repo";
        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType> expectedType =
            BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedUrl = "https://github.com/example-org/example-repo";
        Checkout expectedCheckout = new Sessions::BetaManagedAgentsBranchCheckout()
        {
            Name = "main",
            Type = Sessions::BetaManagedAgentsBranchCheckoutType.Branch,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMountPath, deserialized.MountPath);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedCheckout, deserialized.Checkout);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResource
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResource
        {
            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            MountPath = "/workspace/example-repo",
            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Url = "https://github.com/example-org/example-repo",
        };

        Assert.Null(model.Checkout);
        Assert.False(model.RawData.ContainsKey("checkout"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResource
        {
            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            MountPath = "/workspace/example-repo",
            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Url = "https://github.com/example-org/example-repo",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResource
        {
            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            MountPath = "/workspace/example-repo",
            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Url = "https://github.com/example-org/example-repo",

            Checkout = null,
        };

        Assert.Null(model.Checkout);
        Assert.True(model.RawData.ContainsKey("checkout"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResource
        {
            ID = "sesrsc_011CZkZCKr6eXyl0gWMOdQiu",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            MountPath = "/workspace/example-repo",
            Type = BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
            UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Url = "https://github.com/example-org/example-repo",

            Checkout = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResource
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

        BetaManagedAgentsGitHubRepositoryResource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsGitHubRepositoryResourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository)]
    public void Validation_Works(BetaManagedAgentsGitHubRepositoryResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsGitHubRepositoryResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType>
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
