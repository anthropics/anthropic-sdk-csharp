using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileProgramsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfilePrograms
        {
            Cyber = new()
            {
                Requirements = new() { DataRetention = true, HumanReview = true },
                Status = UserProfileProgramStatus.Active,
                Tiers = new Dictionary<string, UserProfileCyberTier>()
                {
                    { "a", new(Status.Inactive) },
                    { "b", new(Status.Active) },
                    { "c", new(Status.Inactive) },
                },
            },
            Efs = new()
            {
                Features = new Dictionary<string, UserProfileEfsFeature>()
                {
                    { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                    { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                    { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                },
                Status = UserProfileProgramStatus.Active,
            },
        };

        UserProfileCyberProgram expectedCyber = new()
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
        UserProfileEfsProgram expectedEfs = new()
        {
            Features = new Dictionary<string, UserProfileEfsFeature>()
            {
                { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
            },
            Status = UserProfileProgramStatus.Active,
        };

        Assert.Equal(expectedCyber, model.Cyber);
        Assert.Equal(expectedEfs, model.Efs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfilePrograms
        {
            Cyber = new()
            {
                Requirements = new() { DataRetention = true, HumanReview = true },
                Status = UserProfileProgramStatus.Active,
                Tiers = new Dictionary<string, UserProfileCyberTier>()
                {
                    { "a", new(Status.Inactive) },
                    { "b", new(Status.Active) },
                    { "c", new(Status.Inactive) },
                },
            },
            Efs = new()
            {
                Features = new Dictionary<string, UserProfileEfsFeature>()
                {
                    { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                    { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                    { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                },
                Status = UserProfileProgramStatus.Active,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfilePrograms>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfilePrograms
        {
            Cyber = new()
            {
                Requirements = new() { DataRetention = true, HumanReview = true },
                Status = UserProfileProgramStatus.Active,
                Tiers = new Dictionary<string, UserProfileCyberTier>()
                {
                    { "a", new(Status.Inactive) },
                    { "b", new(Status.Active) },
                    { "c", new(Status.Inactive) },
                },
            },
            Efs = new()
            {
                Features = new Dictionary<string, UserProfileEfsFeature>()
                {
                    { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                    { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                    { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                },
                Status = UserProfileProgramStatus.Active,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfilePrograms>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        UserProfileCyberProgram expectedCyber = new()
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
        UserProfileEfsProgram expectedEfs = new()
        {
            Features = new Dictionary<string, UserProfileEfsFeature>()
            {
                { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
            },
            Status = UserProfileProgramStatus.Active,
        };

        Assert.Equal(expectedCyber, deserialized.Cyber);
        Assert.Equal(expectedEfs, deserialized.Efs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfilePrograms
        {
            Cyber = new()
            {
                Requirements = new() { DataRetention = true, HumanReview = true },
                Status = UserProfileProgramStatus.Active,
                Tiers = new Dictionary<string, UserProfileCyberTier>()
                {
                    { "a", new(Status.Inactive) },
                    { "b", new(Status.Active) },
                    { "c", new(Status.Inactive) },
                },
            },
            Efs = new()
            {
                Features = new Dictionary<string, UserProfileEfsFeature>()
                {
                    { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                    { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                    { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                },
                Status = UserProfileProgramStatus.Active,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfilePrograms
        {
            Cyber = new()
            {
                Requirements = new() { DataRetention = true, HumanReview = true },
                Status = UserProfileProgramStatus.Active,
                Tiers = new Dictionary<string, UserProfileCyberTier>()
                {
                    { "a", new(Status.Inactive) },
                    { "b", new(Status.Active) },
                    { "c", new(Status.Inactive) },
                },
            },
            Efs = new()
            {
                Features = new Dictionary<string, UserProfileEfsFeature>()
                {
                    { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                    { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                    { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
                },
                Status = UserProfileProgramStatus.Active,
            },
        };

        UserProfilePrograms copied = new(model);

        Assert.Equal(model, copied);
    }
}
