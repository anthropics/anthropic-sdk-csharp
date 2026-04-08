using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsDeletedCredentialTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            Type = BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted,
        };

        string expectedID = "vcrd_011CZkZEMt8gZan2iYOQfSkw";
        ApiEnum<string, BetaManagedAgentsDeletedCredentialType> expectedType =
            BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            Type = BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedCredential>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            Type = BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedCredential>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "vcrd_011CZkZEMt8gZan2iYOQfSkw";
        ApiEnum<string, BetaManagedAgentsDeletedCredentialType> expectedType =
            BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            Type = BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential
        {
            ID = "vcrd_011CZkZEMt8gZan2iYOQfSkw",
            Type = BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted,
        };

        BetaManagedAgentsDeletedCredential copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsDeletedCredentialTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted)]
    public void Validation_Works(BetaManagedAgentsDeletedCredentialType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeletedCredentialType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedCredentialType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsDeletedCredentialType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeletedCredentialType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedCredentialType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedCredentialType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedCredentialType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
