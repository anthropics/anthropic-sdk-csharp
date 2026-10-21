using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.ActionUrls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.ActionUrls;

public class BetaUserProfileEnrollEndUserActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUserProfileEnrollEndUserAction { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("enroll_end_user");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaUserProfileEnrollEndUserAction { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileEnrollEndUserAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUserProfileEnrollEndUserAction { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileEnrollEndUserAction>(
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
        var model = new BetaUserProfileEnrollEndUserAction { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaUserProfileEnrollEndUserAction { };

        BetaUserProfileEnrollEndUserAction copied = new(model);

        Assert.Equal(model, copied);
    }
}
