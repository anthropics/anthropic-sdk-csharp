using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class BetaUserProfileExternalUserDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUserProfileExternalUserDetails
        {
            AccountStatus = AccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = EntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        ApiEnum<string, AccountStatus> expectedAccountStatus = AccountStatus.Active;
        string expectedCountry = "country";
        string expectedEmailHash = "email_hash";
        ApiEnum<string, EntityType> expectedEntityType = EntityType.Individual;
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
        var model = new BetaUserProfileExternalUserDetails
        {
            AccountStatus = AccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = EntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileExternalUserDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUserProfileExternalUserDetails
        {
            AccountStatus = AccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = EntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileExternalUserDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccountStatus> expectedAccountStatus = AccountStatus.Active;
        string expectedCountry = "country";
        string expectedEmailHash = "email_hash";
        ApiEnum<string, EntityType> expectedEntityType = EntityType.Individual;
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
        var model = new BetaUserProfileExternalUserDetails
        {
            AccountStatus = AccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = EntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaUserProfileExternalUserDetails
        {
            AccountStatus = AccountStatus.Active,
            Country = "country",
            EmailHash = "email_hash",
            EntityType = EntityType.Individual,
            NameHash = "name_hash",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "reference_id",
        };

        BetaUserProfileExternalUserDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountStatus.Active)]
    [InlineData(AccountStatus.Suspended)]
    [InlineData(AccountStatus.Blocked)]
    public void Validation_Works(AccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountStatus.Active)]
    [InlineData(AccountStatus.Suspended)]
    [InlineData(AccountStatus.Blocked)]
    public void SerializationRoundtrip_Works(AccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntityTypeTest : TestBase
{
    [Theory]
    [InlineData(EntityType.Individual)]
    [InlineData(EntityType.Business)]
    [InlineData(EntityType.NonProfit)]
    [InlineData(EntityType.Government)]
    public void Validation_Works(EntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityType.Individual)]
    [InlineData(EntityType.Business)]
    [InlineData(EntityType.NonProfit)]
    [InlineData(EntityType.Government)]
    public void SerializationRoundtrip_Works(EntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
