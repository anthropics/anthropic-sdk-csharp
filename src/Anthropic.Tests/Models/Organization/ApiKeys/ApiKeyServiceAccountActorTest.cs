using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Organization.ApiKeys;

public class ApiKeyServiceAccountActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeyServiceAccountActor
        {
            ServiceAccountID = "svac_01Hk3R9TWxq7CfQak00OiVw4",
        };

        string expectedServiceAccountID = "svac_01Hk3R9TWxq7CfQak00OiVw4";
        JsonElement expectedType = JsonSerializer.SerializeToElement("service_account_actor");

        Assert.Equal(expectedServiceAccountID, model.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeyServiceAccountActor
        {
            ServiceAccountID = "svac_01Hk3R9TWxq7CfQak00OiVw4",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyServiceAccountActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeyServiceAccountActor
        {
            ServiceAccountID = "svac_01Hk3R9TWxq7CfQak00OiVw4",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyServiceAccountActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedServiceAccountID = "svac_01Hk3R9TWxq7CfQak00OiVw4";
        JsonElement expectedType = JsonSerializer.SerializeToElement("service_account_actor");

        Assert.Equal(expectedServiceAccountID, deserialized.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeyServiceAccountActor
        {
            ServiceAccountID = "svac_01Hk3R9TWxq7CfQak00OiVw4",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyServiceAccountActor
        {
            ServiceAccountID = "svac_01Hk3R9TWxq7CfQak00OiVw4",
        };

        ApiKeyServiceAccountActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
