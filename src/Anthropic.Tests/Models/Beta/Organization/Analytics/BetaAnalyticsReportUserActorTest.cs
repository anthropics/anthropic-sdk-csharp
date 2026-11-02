using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsReportUserActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsReportUserActor
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        bool expectedDeleted = false;
        string expectedEmailAddress = "user@emaildomain.com";
        string expectedName = "Jane Doe";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WxYzAbCdEfGhJkMnPqRsTu";

        Assert.Equal(expectedDeleted, model.Deleted);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsReportUserActor
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsReportUserActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsReportUserActor
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsReportUserActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDeleted = false;
        string expectedEmailAddress = "user@emaildomain.com";
        string expectedName = "Jane Doe";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WxYzAbCdEfGhJkMnPqRsTu";

        Assert.Equal(expectedDeleted, deserialized.Deleted);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsReportUserActor
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsReportUserActor
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        BetaAnalyticsReportUserActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
