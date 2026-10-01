using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsRepositoryCheckoutErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRepositoryCheckoutError
        {
            Message = "The requested branch or commit does not exist in the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
        };

        string expectedMessage = "The requested branch or commit does not exist in the repository.";
        string expectedRepositoryUrl = "https://github.com/example-org/example-repo";
        BetaManagedAgentsRepositoryCheckoutErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("repository_checkout_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRepositoryUrl, model.RepositoryUrl);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRepositoryCheckoutError
        {
            Message = "The requested branch or commit does not exist in the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCheckoutError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsRepositoryCheckoutError
        {
            Message = "The requested branch or commit does not exist in the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCheckoutError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "The requested branch or commit does not exist in the repository.";
        string expectedRepositoryUrl = "https://github.com/example-org/example-repo";
        BetaManagedAgentsRepositoryCheckoutErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("repository_checkout_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRepositoryUrl, deserialized.RepositoryUrl);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsRepositoryCheckoutError
        {
            Message = "The requested branch or commit does not exist in the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsRepositoryCheckoutError
        {
            Message = "The requested branch or commit does not exist in the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
        };

        BetaManagedAgentsRepositoryCheckoutError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsRepositoryCheckoutErrorRetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        BetaManagedAgentsRepositoryCheckoutErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        BetaManagedAgentsRepositoryCheckoutErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted(
                BetaManagedAgentsRetryStatusExhaustedType.Exhausted
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        BetaManagedAgentsRepositoryCheckoutErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal(
                BetaManagedAgentsRetryStatusTerminalType.Terminal
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryCheckoutErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCheckoutErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryCheckoutErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted(
                BetaManagedAgentsRetryStatusExhaustedType.Exhausted
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCheckoutErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryCheckoutErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal(
                BetaManagedAgentsRetryStatusTerminalType.Terminal
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCheckoutErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
