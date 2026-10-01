using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsRepositoryCloneErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRepositoryCloneError
        {
            Message = "The repository could not be cloned.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
        };

        string expectedMessage = "The repository could not be cloned.";
        string expectedRepositoryUrl = "https://github.com/example-org/example-repo";
        BetaManagedAgentsRepositoryCloneErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("repository_clone_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRepositoryUrl, model.RepositoryUrl);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRepositoryCloneError
        {
            Message = "The repository could not be cloned.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCloneError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsRepositoryCloneError
        {
            Message = "The repository could not be cloned.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCloneError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "The repository could not be cloned.";
        string expectedRepositoryUrl = "https://github.com/example-org/example-repo";
        BetaManagedAgentsRepositoryCloneErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("repository_clone_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRepositoryUrl, deserialized.RepositoryUrl);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsRepositoryCloneError
        {
            Message = "The repository could not be cloned.",
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
        var model = new BetaManagedAgentsRepositoryCloneError
        {
            Message = "The repository could not be cloned.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
        };

        BetaManagedAgentsRepositoryCloneError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsRepositoryCloneErrorRetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        BetaManagedAgentsRepositoryCloneErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        BetaManagedAgentsRepositoryCloneErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted(
                BetaManagedAgentsRetryStatusExhaustedType.Exhausted
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        BetaManagedAgentsRepositoryCloneErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal(
                BetaManagedAgentsRetryStatusTerminalType.Terminal
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryCloneErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCloneErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryCloneErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted(
                BetaManagedAgentsRetryStatusExhaustedType.Exhausted
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCloneErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryCloneErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal(
                BetaManagedAgentsRetryStatusTerminalType.Terminal
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryCloneErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
