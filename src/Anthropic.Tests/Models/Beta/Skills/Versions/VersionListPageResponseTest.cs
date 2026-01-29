using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Tests.Models.Beta.Skills.Versions;

public class VersionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skillver_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    Description = "A custom skill for doing something useful",
                    Directory = "my-skill",
                    Name = "my-skill",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                    Type = "type",
                    Version = "1759178010641129",
                },
            ],
            HasMore = true,
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<VersionListResponse> expectedData =
        [
            new()
            {
                ID = "skillver_01JAbcdefghijklmnopqrstuvw",
                CreatedAt = "2024-10-30T23:58:27.427722Z",
                Description = "A custom skill for doing something useful",
                Directory = "my-skill",
                Name = "my-skill",
                SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                Type = "type",
                Version = "1759178010641129",
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
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skillver_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    Description = "A custom skill for doing something useful",
                    Directory = "my-skill",
                    Name = "my-skill",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                    Type = "type",
                    Version = "1759178010641129",
                },
            ],
            HasMore = true,
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skillver_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    Description = "A custom skill for doing something useful",
                    Directory = "my-skill",
                    Name = "my-skill",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                    Type = "type",
                    Version = "1759178010641129",
                },
            ],
            HasMore = true,
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<VersionListResponse> expectedData =
        [
            new()
            {
                ID = "skillver_01JAbcdefghijklmnopqrstuvw",
                CreatedAt = "2024-10-30T23:58:27.427722Z",
                Description = "A custom skill for doing something useful",
                Directory = "my-skill",
                Name = "my-skill",
                SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                Type = "type",
                Version = "1759178010641129",
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
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skillver_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    Description = "A custom skill for doing something useful",
                    Directory = "my-skill",
                    Name = "my-skill",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                    Type = "type",
                    Version = "1759178010641129",
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
        var model = new VersionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "skillver_01JAbcdefghijklmnopqrstuvw",
                    CreatedAt = "2024-10-30T23:58:27.427722Z",
                    Description = "A custom skill for doing something useful",
                    Directory = "my-skill",
                    Name = "my-skill",
                    SkillID = "skill_01JAbcdefghijklmnopqrstuvw",
                    Type = "type",
                    Version = "1759178010641129",
                },
            ],
            HasMore = true,
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        VersionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
