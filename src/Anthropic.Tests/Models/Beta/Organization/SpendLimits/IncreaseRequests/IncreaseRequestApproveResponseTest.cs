using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class IncreaseRequestApproveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IncreaseRequestApproveResponse
        {
            ID = "id",
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = BetaSpendLimitPeriod.Daily,
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        string expectedID = "id";
        IncreaseRequestApproveResponseActor expectedActor = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Daily;
        DateTimeOffset expectedResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        IncreaseRequestApproveResponseResolvedBy expectedResolvedBy = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        BetaSpendLimit expectedSpendLimit = new()
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = BetaSpendLimitPeriod.Daily,
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        BetaSpendSummary expectedSpendSummary = new()
        {
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            Amount = "50000",
            Currency = "USD",
            Period = BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
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
        Assert.Equal(expectedSpendLimit, model.SpendLimit);
        Assert.Equal(expectedSpendSummary, model.SpendSummary);
        Assert.Equal(expectedStatus, model.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IncreaseRequestApproveResponse
        {
            ID = "id",
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = BetaSpendLimitPeriod.Daily,
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncreaseRequestApproveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IncreaseRequestApproveResponse
        {
            ID = "id",
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = BetaSpendLimitPeriod.Daily,
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncreaseRequestApproveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        IncreaseRequestApproveResponseActor expectedActor = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Daily;
        DateTimeOffset expectedResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        IncreaseRequestApproveResponseResolvedBy expectedResolvedBy = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        BetaSpendLimit expectedSpendLimit = new()
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = BetaSpendLimitPeriod.Daily,
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        BetaSpendSummary expectedSpendSummary = new()
        {
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            Amount = "50000",
            Currency = "USD",
            Period = BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
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
        Assert.Equal(expectedSpendLimit, deserialized.SpendLimit);
        Assert.Equal(expectedSpendSummary, deserialized.SpendSummary);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IncreaseRequestApproveResponse
        {
            ID = "id",
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = BetaSpendLimitPeriod.Daily,
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IncreaseRequestApproveResponse
        {
            ID = "id",
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = BetaSpendLimitPeriod.Daily,
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Source = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        IncreaseRequestApproveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IncreaseRequestApproveResponseActorTest : TestBase
{
    [Fact]
    public void BetaSpendLimitUserValidationWorks()
    {
        IncreaseRequestApproveResponseActor value = new BetaSpendLimitUserActor()
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
        IncreaseRequestApproveResponseActor value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUserSerializationRoundtripWorks()
    {
        IncreaseRequestApproveResponseActor value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncreaseRequestApproveResponseActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitScopedApiKeySerializationRoundtripWorks()
    {
        IncreaseRequestApproveResponseActor value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncreaseRequestApproveResponseActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        IncreaseRequestApproveResponseActor value = new(
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

        IncreaseRequestApproveResponseActor emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class IncreaseRequestApproveResponseResolvedByTest : TestBase
{
    [Fact]
    public void BetaSpendLimitUserActorValidationWorks()
    {
        IncreaseRequestApproveResponseResolvedBy value = new BetaSpendLimitUserActor()
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
        IncreaseRequestApproveResponseResolvedBy value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        value.Validate();
    }

    [Fact]
    public void BetaSpendLimitUserActorSerializationRoundtripWorks()
    {
        IncreaseRequestApproveResponseResolvedBy value = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncreaseRequestApproveResponseResolvedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSpendLimitScopedApiKeyActorSerializationRoundtripWorks()
    {
        IncreaseRequestApproveResponseResolvedBy value = new BetaSpendLimitScopedApiKeyActor(
            "scoped_api_key_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncreaseRequestApproveResponseResolvedBy>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        IncreaseRequestApproveResponseResolvedBy value = new(
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

        IncreaseRequestApproveResponseResolvedBy emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
