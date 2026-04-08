using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class BetaManagedAgentsDeleteSessionResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            Type = BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted,
        };

        string expectedID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht";
        ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType> expectedType =
            BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            Type = BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeleteSessionResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            Type = BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeleteSessionResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht";
        ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType> expectedType =
            BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            Type = BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            Type = BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted,
        };

        BetaManagedAgentsDeleteSessionResource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsDeleteSessionResourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted)]
    public void Validation_Works(BetaManagedAgentsDeleteSessionResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeleteSessionResourceType.SessionResourceDeleted)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsDeleteSessionResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeleteSessionResourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
