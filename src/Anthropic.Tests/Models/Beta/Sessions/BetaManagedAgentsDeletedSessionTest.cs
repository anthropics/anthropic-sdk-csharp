using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsDeletedSessionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedSession
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Type = BetaManagedAgentsDeletedSessionType.SessionDeleted,
        };

        string expectedID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        ApiEnum<string, BetaManagedAgentsDeletedSessionType> expectedType =
            BetaManagedAgentsDeletedSessionType.SessionDeleted;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedSession
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Type = BetaManagedAgentsDeletedSessionType.SessionDeleted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedSession>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeletedSession
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Type = BetaManagedAgentsDeletedSessionType.SessionDeleted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedSession>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        ApiEnum<string, BetaManagedAgentsDeletedSessionType> expectedType =
            BetaManagedAgentsDeletedSessionType.SessionDeleted;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeletedSession
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Type = BetaManagedAgentsDeletedSessionType.SessionDeleted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeletedSession
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Type = BetaManagedAgentsDeletedSessionType.SessionDeleted,
        };

        BetaManagedAgentsDeletedSession copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsDeletedSessionTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeletedSessionType.SessionDeleted)]
    public void Validation_Works(BetaManagedAgentsDeletedSessionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeletedSessionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedSessionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeletedSessionType.SessionDeleted)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsDeletedSessionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeletedSessionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedSessionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedSessionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeletedSessionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
