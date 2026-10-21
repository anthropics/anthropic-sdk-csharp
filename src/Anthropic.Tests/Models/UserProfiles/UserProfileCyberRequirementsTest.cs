using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileCyberRequirementsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfileCyberRequirements { DataRetention = true, HumanReview = true };

        bool expectedDataRetention = true;
        bool expectedHumanReview = true;

        Assert.Equal(expectedDataRetention, model.DataRetention);
        Assert.Equal(expectedHumanReview, model.HumanReview);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfileCyberRequirements { DataRetention = true, HumanReview = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileCyberRequirements>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfileCyberRequirements { DataRetention = true, HumanReview = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileCyberRequirements>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDataRetention = true;
        bool expectedHumanReview = true;

        Assert.Equal(expectedDataRetention, deserialized.DataRetention);
        Assert.Equal(expectedHumanReview, deserialized.HumanReview);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfileCyberRequirements { DataRetention = true, HumanReview = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfileCyberRequirements { DataRetention = true, HumanReview = true };

        UserProfileCyberRequirements copied = new(model);

        Assert.Equal(model, copied);
    }
}
