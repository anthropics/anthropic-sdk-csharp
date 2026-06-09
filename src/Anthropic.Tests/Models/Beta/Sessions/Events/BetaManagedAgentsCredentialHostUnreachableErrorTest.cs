using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsCredentialHostUnreachableErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCredentialHostUnreachableError
        {
            CredentialID = "credential_id",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type =
                BetaManagedAgentsCredentialHostUnreachableErrorType.CredentialHostUnreachableError,
            VaultID = "vault_id",
        };

        string expectedCredentialID = "credential_id";
        string expectedMessage = "message";
        BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        ApiEnum<string, BetaManagedAgentsCredentialHostUnreachableErrorType> expectedType =
            BetaManagedAgentsCredentialHostUnreachableErrorType.CredentialHostUnreachableError;
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedCredentialID, model.CredentialID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVaultID, model.VaultID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCredentialHostUnreachableError
        {
            CredentialID = "credential_id",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type =
                BetaManagedAgentsCredentialHostUnreachableErrorType.CredentialHostUnreachableError,
            VaultID = "vault_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsCredentialHostUnreachableError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCredentialHostUnreachableError
        {
            CredentialID = "credential_id",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type =
                BetaManagedAgentsCredentialHostUnreachableErrorType.CredentialHostUnreachableError,
            VaultID = "vault_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsCredentialHostUnreachableError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCredentialID = "credential_id";
        string expectedMessage = "message";
        BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        ApiEnum<string, BetaManagedAgentsCredentialHostUnreachableErrorType> expectedType =
            BetaManagedAgentsCredentialHostUnreachableErrorType.CredentialHostUnreachableError;
        string expectedVaultID = "vault_id";

        Assert.Equal(expectedCredentialID, deserialized.CredentialID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVaultID, deserialized.VaultID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCredentialHostUnreachableError
        {
            CredentialID = "credential_id",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type =
                BetaManagedAgentsCredentialHostUnreachableErrorType.CredentialHostUnreachableError,
            VaultID = "vault_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCredentialHostUnreachableError
        {
            CredentialID = "credential_id",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type =
                BetaManagedAgentsCredentialHostUnreachableErrorType.CredentialHostUnreachableError,
            VaultID = "vault_id",
        };

        BetaManagedAgentsCredentialHostUnreachableError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsCredentialHostUnreachableErrorRetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted(
                BetaManagedAgentsRetryStatusExhaustedType.Exhausted
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal(
                BetaManagedAgentsRetryStatusTerminalType.Terminal
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted(
                BetaManagedAgentsRetryStatusExhaustedType.Exhausted
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal(
                BetaManagedAgentsRetryStatusTerminalType.Terminal
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsCredentialHostUnreachableErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsCredentialHostUnreachableErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsCredentialHostUnreachableErrorType.CredentialHostUnreachableError)]
    public void Validation_Works(BetaManagedAgentsCredentialHostUnreachableErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCredentialHostUnreachableErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialHostUnreachableErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsCredentialHostUnreachableErrorType.CredentialHostUnreachableError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsCredentialHostUnreachableErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCredentialHostUnreachableErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialHostUnreachableErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialHostUnreachableErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialHostUnreachableErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
