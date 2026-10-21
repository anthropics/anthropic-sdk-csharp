using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;
using SpendLimits = Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class BetaSpendLimitIncreaseRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSpendLimitIncreaseRequest
        {
            ID = "id",
            Actor = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimits::BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendSummary = new()
            {
                Actor = new SpendLimits::BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimits::BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        string expectedID = "id";
        Actor expectedActor = new SpendLimits::BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SpendLimits::BetaSpendLimitPeriod> expectedPeriod =
            SpendLimits::BetaSpendLimitPeriod.Daily;
        DateTimeOffset expectedResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ResolvedBy expectedResolvedBy = new SpendLimits::BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        SpendLimits::BetaSpendSummary expectedSpendSummary = new()
        {
            Actor = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            Amount = "50000",
            Currency = "USD",
            Period = SpendLimits::BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Source = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            SpendLimitID = "spend_limit_id",
        };
        ApiEnum<string, BetaSpendLimitIncreaseRequestStatus> expectedStatus =
            BetaSpendLimitIncreaseRequestStatus.Approved;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "spend_limit_increase_request"
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedResolvedAt, model.ResolvedAt);
        Assert.Equal(expectedResolvedBy, model.ResolvedBy);
        Assert.Equal(expectedSpendSummary, model.SpendSummary);
        Assert.Equal(expectedStatus, model.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSpendLimitIncreaseRequest
        {
            ID = "id",
            Actor = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimits::BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendSummary = new()
            {
                Actor = new SpendLimits::BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimits::BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitIncreaseRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSpendLimitIncreaseRequest
        {
            ID = "id",
            Actor = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimits::BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendSummary = new()
            {
                Actor = new SpendLimits::BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimits::BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitIncreaseRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Actor expectedActor = new SpendLimits::BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SpendLimits::BetaSpendLimitPeriod> expectedPeriod =
            SpendLimits::BetaSpendLimitPeriod.Daily;
        DateTimeOffset expectedResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ResolvedBy expectedResolvedBy = new SpendLimits::BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        SpendLimits::BetaSpendSummary expectedSpendSummary = new()
        {
            Actor = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            Amount = "50000",
            Currency = "USD",
            Period = SpendLimits::BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Source = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            SpendLimitID = "spend_limit_id",
        };
        ApiEnum<string, BetaSpendLimitIncreaseRequestStatus> expectedStatus =
            BetaSpendLimitIncreaseRequestStatus.Approved;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "spend_limit_increase_request"
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPeriod, deserialized.Period);
        Assert.Equal(expectedResolvedAt, deserialized.ResolvedAt);
        Assert.Equal(expectedResolvedBy, deserialized.ResolvedBy);
        Assert.Equal(expectedSpendSummary, deserialized.SpendSummary);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSpendLimitIncreaseRequest
        {
            ID = "id",
            Actor = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimits::BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendSummary = new()
            {
                Actor = new SpendLimits::BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimits::BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSpendLimitIncreaseRequest
        {
            ID = "id",
            Actor = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimits::BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimits::BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendSummary = new()
            {
                Actor = new SpendLimits::BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimits::BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new SpendLimits::BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        BetaSpendLimitIncreaseRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActorTest : TestBase
{
    [Fact]
    public void BetaSpendLimitUserValidationWorks()
    {
        Actor value = new SpendLimits::BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitScopedApiKeyValidationWorks()
    {
        Actor value = new SpendLimits::BetaSpendLimitScopedApiKeyActor("scoped_api_key_id");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUserSerializationRoundtripWorks()
    {
        Actor value = new SpendLimits::BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Actor>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitScopedApiKeySerializationRoundtripWorks()
    {
        Actor value = new SpendLimits::BetaSpendLimitScopedApiKeyActor("scoped_api_key_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Actor>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Actor value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        Actor emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ResolvedByTest : TestBase
{
    [Fact]
    public void BetaSpendLimitUserActorValidationWorks()
    {
        ResolvedBy value = new SpendLimits::BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitScopedApiKeyActorValidationWorks()
    {
        ResolvedBy value = new SpendLimits::BetaSpendLimitScopedApiKeyActor("scoped_api_key_id");
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUserActorSerializationRoundtripWorks()
    {
        ResolvedBy value = new SpendLimits::BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResolvedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitScopedApiKeyActorSerializationRoundtripWorks()
    {
        ResolvedBy value = new SpendLimits::BetaSpendLimitScopedApiKeyActor("scoped_api_key_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResolvedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ResolvedBy value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        ResolvedBy emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
