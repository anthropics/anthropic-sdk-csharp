using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileExternalUserDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfileExternalUserDetails
        {
            AccountStatus = UserProfileExternalUserAccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = UserProfileExternalUserEntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        ApiEnum<string, UserProfileExternalUserAccountStatus> expectedAccountStatus =
            UserProfileExternalUserAccountStatus.Active;
        string expectedCountry = "country";
        string expectedEmailHash = "email_hash";
        ApiEnum<string, UserProfileExternalUserEntityType> expectedEntityType =
            UserProfileExternalUserEntityType.Individual;
        string expectedNameHash = "name_hash";
        DateTimeOffset expectedOnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedAccountStatus, model.AccountStatus);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedEmailHash, model.EmailHash);
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedNameHash, model.NameHash);
        Assert.Equal(expectedOnboardedAt, model.OnboardedAt);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfileExternalUserDetails
        {
            AccountStatus = UserProfileExternalUserAccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = UserProfileExternalUserEntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileExternalUserDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfileExternalUserDetails
        {
            AccountStatus = UserProfileExternalUserAccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = UserProfileExternalUserEntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileExternalUserDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UserProfileExternalUserAccountStatus> expectedAccountStatus =
            UserProfileExternalUserAccountStatus.Active;
        string expectedCountry = "country";
        string expectedEmailHash = "email_hash";
        ApiEnum<string, UserProfileExternalUserEntityType> expectedEntityType =
            UserProfileExternalUserEntityType.Individual;
        string expectedNameHash = "name_hash";
        DateTimeOffset expectedOnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedAccountStatus, deserialized.AccountStatus);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedEmailHash, deserialized.EmailHash);
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedNameHash, deserialized.NameHash);
        Assert.Equal(expectedOnboardedAt, deserialized.OnboardedAt);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfileExternalUserDetails
        {
            AccountStatus = UserProfileExternalUserAccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = UserProfileExternalUserEntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfileExternalUserDetails
        {
            AccountStatus = UserProfileExternalUserAccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = UserProfileExternalUserEntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        UserProfileExternalUserDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
