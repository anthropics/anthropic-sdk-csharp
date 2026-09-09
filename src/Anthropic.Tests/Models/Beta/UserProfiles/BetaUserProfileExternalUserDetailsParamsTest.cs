using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Tests.Models.Beta.UserProfiles;

public class BetaUserProfileExternalUserDetailsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            AccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            Country = "country",
            EmailHash = "x",
            EntityType = BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            NameHash = "x",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "x",
        };

        ApiEnum<
            string,
            BetaUserProfileExternalUserDetailsParamsAccountStatus
        > expectedAccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active;
        string expectedCountry = "country";
        string expectedEmailHash = "x";
        ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType> expectedEntityType =
            BetaUserProfileExternalUserDetailsParamsEntityType.Individual;
        string expectedNameHash = "x";
        DateTimeOffset expectedOnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedReferenceID = "x";

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
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            AccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            Country = "country",
            EmailHash = "x",
            EntityType = BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            NameHash = "x",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileExternalUserDetailsParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            AccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            Country = "country",
            EmailHash = "x",
            EntityType = BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            NameHash = "x",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileExternalUserDetailsParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            BetaUserProfileExternalUserDetailsParamsAccountStatus
        > expectedAccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active;
        string expectedCountry = "country";
        string expectedEmailHash = "x";
        ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType> expectedEntityType =
            BetaUserProfileExternalUserDetailsParamsEntityType.Individual;
        string expectedNameHash = "x";
        DateTimeOffset expectedOnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedReferenceID = "x";

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
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            AccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            Country = "country",
            EmailHash = "x",
            EntityType = BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            NameHash = "x",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            AccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            Country = "country",
            EmailHash = "x",
            EntityType = BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            NameHash = "x",
            ReferenceID = "x",
        };

        Assert.Null(model.OnboardedAt);
        Assert.False(model.RawData.ContainsKey("onboarded_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            AccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            Country = "country",
            EmailHash = "x",
            EntityType = BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            NameHash = "x",
            ReferenceID = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            AccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            Country = "country",
            EmailHash = "x",
            EntityType = BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            NameHash = "x",
            ReferenceID = "x",

            // Null should be interpreted as omitted for these properties
            OnboardedAt = null,
        };

        Assert.Null(model.OnboardedAt);
        Assert.False(model.RawData.ContainsKey("onboarded_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            AccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            Country = "country",
            EmailHash = "x",
            EntityType = BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            NameHash = "x",
            ReferenceID = "x",

            // Null should be interpreted as omitted for these properties
            OnboardedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.AccountStatus);
        Assert.False(model.RawData.ContainsKey("account_status"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.EmailHash);
        Assert.False(model.RawData.ContainsKey("email_hash"));
        Assert.Null(model.EntityType);
        Assert.False(model.RawData.ContainsKey("entity_type"));
        Assert.Null(model.NameHash);
        Assert.False(model.RawData.ContainsKey("name_hash"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AccountStatus = null,
            Country = null,
            EmailHash = null,
            EntityType = null,
            NameHash = null,
            ReferenceID = null,
        };

        Assert.Null(model.AccountStatus);
        Assert.True(model.RawData.ContainsKey("account_status"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.EmailHash);
        Assert.True(model.RawData.ContainsKey("email_hash"));
        Assert.Null(model.EntityType);
        Assert.True(model.RawData.ContainsKey("entity_type"));
        Assert.Null(model.NameHash);
        Assert.True(model.RawData.ContainsKey("name_hash"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AccountStatus = null,
            Country = null,
            EmailHash = null,
            EntityType = null,
            NameHash = null,
            ReferenceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaUserProfileExternalUserDetailsParams
        {
            AccountStatus = BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            Country = "country",
            EmailHash = "x",
            EntityType = BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            NameHash = "x",
            OnboardedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReferenceID = "x",
        };

        BetaUserProfileExternalUserDetailsParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaUserProfileExternalUserDetailsParamsAccountStatusTest : TestBase
{
    [Theory]
    [InlineData(BetaUserProfileExternalUserDetailsParamsAccountStatus.Active)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsAccountStatus.Suspended)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsAccountStatus.Blocked)]
    public void Validation_Works(BetaUserProfileExternalUserDetailsParamsAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileExternalUserDetailsParamsAccountStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileExternalUserDetailsParamsAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaUserProfileExternalUserDetailsParamsAccountStatus.Active)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsAccountStatus.Suspended)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsAccountStatus.Blocked)]
    public void SerializationRoundtrip_Works(
        BetaUserProfileExternalUserDetailsParamsAccountStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileExternalUserDetailsParamsAccountStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileExternalUserDetailsParamsAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileExternalUserDetailsParamsAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileExternalUserDetailsParamsAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaUserProfileExternalUserDetailsParamsEntityTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaUserProfileExternalUserDetailsParamsEntityType.Individual)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsEntityType.Business)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsEntityType.NonProfit)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsEntityType.Government)]
    public void Validation_Works(BetaUserProfileExternalUserDetailsParamsEntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaUserProfileExternalUserDetailsParamsEntityType.Individual)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsEntityType.Business)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsEntityType.NonProfit)]
    [InlineData(BetaUserProfileExternalUserDetailsParamsEntityType.Government)]
    public void SerializationRoundtrip_Works(
        BetaUserProfileExternalUserDetailsParamsEntityType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
