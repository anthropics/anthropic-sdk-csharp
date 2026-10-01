using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsUserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUser { ID = "id", EmailAddress = "email_address" };

        string expectedID = "id";
        string expectedEmailAddress = "email_address";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUser { ID = "id", EmailAddress = "email_address" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUser>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUser { ID = "id", EmailAddress = "email_address" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUser>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedEmailAddress = "email_address";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUser { ID = "id", EmailAddress = "email_address" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUser { ID = "id", EmailAddress = "email_address" };

        BetaAnalyticsUser copied = new(model);

        Assert.Equal(model, copied);
    }
}
