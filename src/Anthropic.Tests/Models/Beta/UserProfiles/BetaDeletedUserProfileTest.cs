using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class BetaDeletedUserProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDeletedUserProfile { ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9" };

        string expectedID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_profile_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDeletedUserProfile { ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedUserProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDeletedUserProfile { ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedUserProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "uprof_011CZkZCu8hGbp5mYRQgUmz9";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_profile_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDeletedUserProfile { ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDeletedUserProfile { ID = "uprof_011CZkZCu8hGbp5mYRQgUmz9" };

        BetaDeletedUserProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
