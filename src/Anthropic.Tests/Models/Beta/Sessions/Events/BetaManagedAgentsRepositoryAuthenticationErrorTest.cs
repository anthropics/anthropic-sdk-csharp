using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsRepositoryAuthenticationErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRepositoryAuthenticationError
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string expectedMessage =
            "The repository host rejected the credentials for the repository, or required credentials and received none.";
        string expectedRepositoryUrl = "https://github.com/example-org/example-repo";
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "repository_authentication_error"
        );

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRepositoryUrl, model.RepositoryUrl);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRepositoryAuthenticationError
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryAuthenticationError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsRepositoryAuthenticationError
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryAuthenticationError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMessage =
            "The repository host rejected the credentials for the repository, or required credentials and received none.";
        string expectedRepositoryUrl = "https://github.com/example-org/example-repo";
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "repository_authentication_error"
        );

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRepositoryUrl, deserialized.RepositoryUrl);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsRepositoryAuthenticationError
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsRepositoryAuthenticationError
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        BetaManagedAgentsRepositoryAuthenticationError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingTypeWorks()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        Assert.Equal(
            BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Retrying,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedTypeWorks()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        Assert.Equal(
            BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Exhausted,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalTypeWorks()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        Assert.Equal(
            BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Terminal,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "retrying"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<
            string,
            BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType
        > expectedType = BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Retrying;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Terminal)]
    public void Validation_Works(
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType.Terminal)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRepositoryAuthenticationErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
