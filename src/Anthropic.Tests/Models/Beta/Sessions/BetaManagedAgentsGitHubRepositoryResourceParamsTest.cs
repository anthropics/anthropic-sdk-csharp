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
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
            MountPath = "x",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("github_repository");
        string expectedUrl = "https://github.com/example-org/example-repo";
        string expectedAuthorizationToken = "ghp_exampletoken";
        Checkout expectedCheckout = new BetaManagedAgentsBranchCheckout("main");
        string expectedMountPath = "x";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
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
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
            MountPath = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResourceParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("github_repository");
        string expectedUrl = "https://github.com/example-org/example-repo";
        string expectedAuthorizationToken = "ghp_exampletoken";
        Checkout expectedCheckout = new BetaManagedAgentsBranchCheckout("main");
        string expectedMountPath = "x";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
            MountPath = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
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
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
            MountPath = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
            MountPath = "x",

            // Null should be interpreted as omitted for these properties
            AuthorizationToken = null,
        };

        Assert.Null(model.AuthorizationToken);
        Assert.False(model.RawData.ContainsKey("authorization_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsGitHubRepositoryResourceParams
        {
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
            MountPath = "x",
        } with
        {
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
            Url = "https://github.com/example-org/example-repo",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
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
            Url = "https://github.com/example-org/example-repo",
            AuthorizationToken = "ghp_exampletoken",
            Checkout = new BetaManagedAgentsBranchCheckout("main"),
            MountPath = "x",
        };

        BetaManagedAgentsGitHubRepositoryResourceParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckoutTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsBranchValidationWorks()
    {
        Checkout value = new BetaManagedAgentsBranchCheckout("main");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCommitValidationWorks()
    {
        Checkout value = new BetaManagedAgentsCommitCheckout("xxxxxxx");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsBranchSerializationRoundtripWorks()
    {
        Checkout value = new BetaManagedAgentsBranchCheckout("main");
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
        Checkout value = new BetaManagedAgentsCommitCheckout("xxxxxxx");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkout>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsBranchTypeWorks()
    {
        Checkout value = new BetaManagedAgentsBranchCheckout("main");
        Assert.Equal(CheckoutType.Branch, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCommitTypeWorks()
    {
        Checkout value = new BetaManagedAgentsCommitCheckout("xxxxxxx");
        Assert.Equal(CheckoutType.Commit, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Checkout value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "branch"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, CheckoutType> expectedType = CheckoutType.Branch;

        Assert.Equal(expectedType, value.Type);

        Checkout emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class CheckoutTypeTest : TestBase
{
    [Theory]
    [InlineData(CheckoutType.Branch)]
    [InlineData(CheckoutType.Commit)]
    public void Validation_Works(CheckoutType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckoutType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckoutType.Branch)]
    [InlineData(CheckoutType.Commit)]
    public void SerializationRoundtrip_Works(CheckoutType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckoutType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckoutType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckoutType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckoutType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
