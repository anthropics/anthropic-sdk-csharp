using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class BetaSpendLimitIncreaseRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSpendLimitIncreaseRequest
        {
            ID = "id",
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        string expectedID = "id";
        BetaSpendLimitIncreaseRequestActor expectedActor = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Daily;
        DateTimeOffset expectedResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaSpendLimitIncreaseRequestResolvedBy expectedResolvedBy = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        BetaSpendSummary expectedSpendSummary = new()
        {
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            Amount = "50000",
            Currency = "USD",
            Period = BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Source = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
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
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
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
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
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
        BetaSpendLimitIncreaseRequestActor expectedActor = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Daily;
        DateTimeOffset expectedResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaSpendLimitIncreaseRequestResolvedBy expectedResolvedBy = new BetaSpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        BetaSpendSummary expectedSpendSummary = new()
        {
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            Amount = "50000",
            Currency = "USD",
            Period = BetaSpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Source = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
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
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
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
            Actor = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = BetaSpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new BetaSpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendSummary = new()
            {
                Actor = new BetaSpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = BetaSpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new BetaSpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                SpendLimitID = "spend_limit_id",
            },
            Status = BetaSpendLimitIncreaseRequestStatus.Approved,
        };

        BetaSpendLimitIncreaseRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
