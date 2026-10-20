using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileCyberProgramTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfileCyberProgram
        {
            Requirements = new() { DataRetention = true, HumanReview = true },
            Status = UserProfileProgramStatus.Active,
            Tiers = new Dictionary<string, UserProfileCyberTier>()
            {
                { "a", new(Status.Inactive) },
                { "b", new(Status.Active) },
                { "c", new(Status.Inactive) },
            },
        };

        UserProfileCyberRequirements expectedRequirements = new()
        {
            DataRetention = true,
            HumanReview = true,
        };
        ApiEnum<string, UserProfileProgramStatus> expectedStatus = UserProfileProgramStatus.Active;
        Dictionary<string, UserProfileCyberTier> expectedTiers = new()
        {
            { "a", new(Status.Inactive) },
            { "b", new(Status.Active) },
            { "c", new(Status.Inactive) },
        };

        Assert.Equal(expectedRequirements, model.Requirements);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        foreach (var item in expectedTiers)
        {
            Assert.True(model.Tiers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Tiers[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfileCyberProgram
        {
            Requirements = new() { DataRetention = true, HumanReview = true },
            Status = UserProfileProgramStatus.Active,
            Tiers = new Dictionary<string, UserProfileCyberTier>()
            {
                { "a", new(Status.Inactive) },
                { "b", new(Status.Active) },
                { "c", new(Status.Inactive) },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileCyberProgram>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfileCyberProgram
        {
            Requirements = new() { DataRetention = true, HumanReview = true },
            Status = UserProfileProgramStatus.Active,
            Tiers = new Dictionary<string, UserProfileCyberTier>()
            {
                { "a", new(Status.Inactive) },
                { "b", new(Status.Active) },
                { "c", new(Status.Inactive) },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileCyberProgram>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        UserProfileCyberRequirements expectedRequirements = new()
        {
            DataRetention = true,
            HumanReview = true,
        };
        ApiEnum<string, UserProfileProgramStatus> expectedStatus = UserProfileProgramStatus.Active;
        Dictionary<string, UserProfileCyberTier> expectedTiers = new()
        {
            { "a", new(Status.Inactive) },
            { "b", new(Status.Active) },
            { "c", new(Status.Inactive) },
        };

        Assert.Equal(expectedRequirements, deserialized.Requirements);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        foreach (var item in expectedTiers)
        {
            Assert.True(deserialized.Tiers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Tiers[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfileCyberProgram
        {
            Requirements = new() { DataRetention = true, HumanReview = true },
            Status = UserProfileProgramStatus.Active,
            Tiers = new Dictionary<string, UserProfileCyberTier>()
            {
                { "a", new(Status.Inactive) },
                { "b", new(Status.Active) },
                { "c", new(Status.Inactive) },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfileCyberProgram
        {
            Requirements = new() { DataRetention = true, HumanReview = true },
            Status = UserProfileProgramStatus.Active,
            Tiers = new Dictionary<string, UserProfileCyberTier>()
            {
                { "a", new(Status.Inactive) },
                { "b", new(Status.Active) },
                { "c", new(Status.Inactive) },
            },
        };

        UserProfileCyberProgram copied = new(model);

        Assert.Equal(model, copied);
    }
}
