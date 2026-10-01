using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsUserActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActor
        {
            Deleted = true,
            EmailAddress = "jane@example.com",
            Name = "Jane Smith",
            UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
        };

        bool expectedDeleted = true;
        string expectedEmailAddress = "jane@example.com";
        string expectedName = "Jane Smith";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01AbCdEfGhIjKlMnOpQrSt";

        Assert.Equal(expectedDeleted, model.Deleted);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActor
        {
            Deleted = true,
            EmailAddress = "jane@example.com",
            Name = "Jane Smith",
            UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUserActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUserActor
        {
            Deleted = true,
            EmailAddress = "jane@example.com",
            Name = "Jane Smith",
            UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUserActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDeleted = true;
        string expectedEmailAddress = "jane@example.com";
        string expectedName = "Jane Smith";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01AbCdEfGhIjKlMnOpQrSt";

        Assert.Equal(expectedDeleted, deserialized.Deleted);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUserActor
        {
            Deleted = true,
            EmailAddress = "jane@example.com",
            Name = "Jane Smith",
            UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUserActor
        {
            Deleted = true,
            EmailAddress = "jane@example.com",
            Name = "Jane Smith",
            UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
        };

        BetaAnalyticsUserActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
