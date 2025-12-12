using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    DisplayTitle = "My Custom Skill",
                    LatestVersion = "1759178010641129",
                    Source = "custom",
                    Type = "type",
                    UpdatedAt = "2024-10-30T23:58:27.427722Z",
                },
            ],
            HasMore = true,
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<Data> expectedData =
        [
            new()
            {
                ID = "skill_01JAbcdefghijklmnopqrstuvw",
                CreatedAt = "2024-10-30T23:58:27.427722Z",
                DisplayTitle = "My Custom Skill",
                LatestVersion = "1759178010641129",
                Source = "custom",
                Type = "type",
                UpdatedAt = "2024-10-30T23:58:27.427722Z",
            },
        ];
        bool expectedHasMore = true;
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    DisplayTitle = "My Custom Skill",
                    LatestVersion = "1759178010641129",
                    Source = "custom",
                    Type = "type",
                    UpdatedAt = "2024-10-30T23:58:27.427722Z",
                },
            ],
            HasMore = true,
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SkillListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    DisplayTitle = "My Custom Skill",
                    LatestVersion = "1759178010641129",
                    Source = "custom",
                    Type = "type",
                    UpdatedAt = "2024-10-30T23:58:27.427722Z",
                },
            ],
            HasMore = true,
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SkillListPageResponse>(json);
        Assert.NotNull(deserialized);

        List<Data> expectedData =
        [
            new()
            {
                ID = "skill_01JAbcdefghijklmnopqrstuvw",
                CreatedAt = "2024-10-30T23:58:27.427722Z",
                DisplayTitle = "My Custom Skill",
                LatestVersion = "1759178010641129",
                Source = "custom",
                Type = "type",
                UpdatedAt = "2024-10-30T23:58:27.427722Z",
            },
        ];
        bool expectedHasMore = true;
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skill_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    DisplayTitle = "My Custom Skill",
                    LatestVersion = "1759178010641129",
                    Source = "custom",
                    Type = "type",
                    UpdatedAt = "2024-10-30T23:58:27.427722Z",
                },
            ],
            HasMore = true,
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedCreatedAt = "2024-10-30T23:58:27.427722Z";
        string expectedDisplayTitle = "My Custom Skill";
        string expectedLatestVersion = "1759178010641129";
        string expectedSource = "custom";
        string expectedType = "type";
        string expectedUpdatedAt = "2024-10-30T23:58:27.427722Z";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayTitle, model.DisplayTitle);
        Assert.Equal(expectedLatestVersion, model.LatestVersion);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);
        Assert.NotNull(deserialized);

        string expectedID = "skill_01JAbcdefghijklmnopqrstuvw";
        string expectedCreatedAt = "2024-10-30T23:58:27.427722Z";
        string expectedDisplayTitle = "My Custom Skill";
        string expectedLatestVersion = "1759178010641129";
        string expectedSource = "custom";
        string expectedType = "type";
        string expectedUpdatedAt = "2024-10-30T23:58:27.427722Z";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayTitle, deserialized.DisplayTitle);
        Assert.Equal(expectedLatestVersion, deserialized.LatestVersion);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "skill_01JAbcdefghijklmnopqrstuvw",
            CreatedAt = "2024-10-30T23:58:27.427722Z",
            DisplayTitle = "My Custom Skill",
            LatestVersion = "1759178010641129",
            Source = "custom",
            Type = "type",
            UpdatedAt = "2024-10-30T23:58:27.427722Z",
        };

        model.Validate();
    }
}
