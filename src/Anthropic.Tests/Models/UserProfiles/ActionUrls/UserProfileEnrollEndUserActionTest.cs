using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles.ActionUrls;

namespace Anthropic.Tests.Models.UserProfiles.ActionUrls;

public class UserProfileEnrollEndUserActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfileEnrollEndUserAction { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("enroll_end_user");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfileEnrollEndUserAction { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEnrollEndUserAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfileEnrollEndUserAction { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEnrollEndUserAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("enroll_end_user");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfileEnrollEndUserAction { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfileEnrollEndUserAction { };

        UserProfileEnrollEndUserAction copied = new(model);

        Assert.Equal(model, copied);
    }
}
