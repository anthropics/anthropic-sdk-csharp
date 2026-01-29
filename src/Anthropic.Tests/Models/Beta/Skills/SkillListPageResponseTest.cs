using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
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

        List<SkillListResponse> expectedData =
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SkillListResponse> expectedData =
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

    [Fact]
    public void CopyConstructor_Works()
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

        SkillListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
