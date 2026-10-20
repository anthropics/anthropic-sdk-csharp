using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileEfsProgramTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfileEfsProgram
        {
            Features = new Dictionary<string, UserProfileEfsFeature>()
            {
                { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
            },
            Status = UserProfileProgramStatus.Active,
        };

        Dictionary<string, UserProfileEfsFeature> expectedFeatures = new()
        {
            { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
            { "cmek", new(UserProfileEfsFeatureStatus.Active) },
            { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
        };
        ApiEnum<string, UserProfileProgramStatus> expectedStatus = UserProfileProgramStatus.Active;

        Assert.Equal(expectedFeatures.Count, model.Features.Count);
        foreach (var item in expectedFeatures)
        {
            Assert.True(model.Features.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Features[item.Key]);
        }
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfileEfsProgram
        {
            Features = new Dictionary<string, UserProfileEfsFeature>()
            {
                { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
            },
            Status = UserProfileProgramStatus.Active,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEfsProgram>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfileEfsProgram
        {
            Features = new Dictionary<string, UserProfileEfsFeature>()
            {
                { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
            },
            Status = UserProfileProgramStatus.Active,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileEfsProgram>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, UserProfileEfsFeature> expectedFeatures = new()
        {
            { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
            { "cmek", new(UserProfileEfsFeatureStatus.Active) },
            { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
        };
        ApiEnum<string, UserProfileProgramStatus> expectedStatus = UserProfileProgramStatus.Active;

        Assert.Equal(expectedFeatures.Count, deserialized.Features.Count);
        foreach (var item in expectedFeatures)
        {
            Assert.True(deserialized.Features.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Features[item.Key]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfileEfsProgram
        {
            Features = new Dictionary<string, UserProfileEfsFeature>()
            {
                { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
            },
            Status = UserProfileProgramStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfileEfsProgram
        {
            Features = new Dictionary<string, UserProfileEfsFeature>()
            {
                { "data_retention_exemption", new(UserProfileEfsFeatureStatus.Inactive) },
                { "cmek", new(UserProfileEfsFeatureStatus.Active) },
                { "storage", new(UserProfileEfsFeatureStatus.Inactive) },
            },
            Status = UserProfileProgramStatus.Active,
        };

        UserProfileEfsProgram copied = new(model);

        Assert.Equal(model, copied);
    }
}
