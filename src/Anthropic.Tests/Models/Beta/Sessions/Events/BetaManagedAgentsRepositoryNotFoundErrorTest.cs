using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsRepositoryNotFoundErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRepositoryNotFoundError
        {
            Message = "The repository host reported the repository as not found.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string expectedMessage = "The repository host reported the repository as not found.";
        string expectedRepositoryUrl = "https://github.com/example-org/example-repo";
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement("repository_not_found_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRepositoryUrl, model.RepositoryUrl);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRepositoryNotFoundError
        {
            Message = "The repository host reported the repository as not found.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRepositoryNotFoundError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsRepositoryNotFoundError
        {
            Message = "The repository host reported the repository as not found.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRepositoryNotFoundError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "The repository host reported the repository as not found.";
        string expectedRepositoryUrl = "https://github.com/example-org/example-repo";
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement("repository_not_found_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRepositoryUrl, deserialized.RepositoryUrl);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsRepositoryNotFoundError
        {
            Message = "The repository host reported the repository as not found.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsRepositoryNotFoundError
        {
            Message = "The repository host reported the repository as not found.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        BetaManagedAgentsRepositoryNotFoundError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsRepositoryNotFoundErrorRetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryNotFoundErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryNotFoundErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryNotFoundErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingTypeWorks()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        Assert.Equal(
            BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Retrying,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedTypeWorks()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        Assert.Equal(
            BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Exhausted,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalTypeWorks()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        Assert.Equal(
            BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Terminal,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "retrying"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType> expectedType =
            BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Retrying;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsRepositoryNotFoundErrorRetryStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsRepositoryNotFoundErrorRetryStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Terminal)]
    public void Validation_Works(BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType.Terminal)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRepositoryNotFoundErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
