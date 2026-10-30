using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.SpendLimits;
using Anthropic.Models.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Organization.SpendLimits.IncreaseRequests;

public class IncreaseRequestApproveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IncreaseRequestApproveResponse
        {
            ID = "id",
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = SpendLimitPeriod.Daily,
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new SpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                SpendLimitID = "spend_limit_id",
            },
            Status = SpendLimitIncreaseRequestStatus.Approved,
        };

        string expectedID = "id";
        SpendLimitIncreaseRequestActor expectedActor = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SpendLimitPeriod> expectedPeriod = SpendLimitPeriod.Daily;
        DateTimeOffset expectedResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        SpendLimitIncreaseRequestResolvedBy expectedResolvedBy = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        SpendLimit expectedSpendLimit = new()
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = SpendLimitPeriod.Daily,
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        SpendSummary expectedSpendSummary = new()
        {
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            Amount = "50000",
            Currency = "USD",
            Period = SpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            SpendLimitID = "spend_limit_id",
        };
        ApiEnum<string, SpendLimitIncreaseRequestStatus> expectedStatus =
            SpendLimitIncreaseRequestStatus.Approved;
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
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = SpendLimitPeriod.Daily,
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new SpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                SpendLimitID = "spend_limit_id",
            },
            Status = SpendLimitIncreaseRequestStatus.Approved,
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
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = SpendLimitPeriod.Daily,
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new SpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                SpendLimitID = "spend_limit_id",
            },
            Status = SpendLimitIncreaseRequestStatus.Approved,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncreaseRequestApproveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        SpendLimitIncreaseRequestActor expectedActor = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SpendLimitPeriod> expectedPeriod = SpendLimitPeriod.Daily;
        DateTimeOffset expectedResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        SpendLimitIncreaseRequestResolvedBy expectedResolvedBy = new SpendLimitUserActor()
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };
        SpendLimit expectedSpendLimit = new()
        {
            ID = "id",
            Amount = "50000",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "USD",
            IsEnabled = true,
            Period = SpendLimitPeriod.Daily,
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        SpendSummary expectedSpendSummary = new()
        {
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            Amount = "50000",
            Currency = "USD",
            Period = SpendLimitPeriod.Daily,
            PeriodToDateSpend = "12050.5",
            Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            SpendLimitID = "spend_limit_id",
        };
        ApiEnum<string, SpendLimitIncreaseRequestStatus> expectedStatus =
            SpendLimitIncreaseRequestStatus.Approved;
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
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = SpendLimitPeriod.Daily,
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new SpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                SpendLimitID = "spend_limit_id",
            },
            Status = SpendLimitIncreaseRequestStatus.Approved,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IncreaseRequestApproveResponse
        {
            ID = "id",
            Actor = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Period = SpendLimitPeriod.Daily,
            ResolvedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResolvedBy = new SpendLimitUserActor()
            {
                Deleted = true,
                EmailAddress = "email_address",
                Name = "name",
                UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            },
            SpendLimit = new()
            {
                ID = "id",
                Amount = "50000",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "USD",
                IsEnabled = true,
                Period = SpendLimitPeriod.Daily,
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            SpendSummary = new()
            {
                Actor = new SpendLimitUserActor()
                {
                    Deleted = true,
                    EmailAddress = "email_address",
                    Name = "name",
                    UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
                },
                Amount = "50000",
                Currency = "USD",
                Period = SpendLimitPeriod.Daily,
                PeriodToDateSpend = "12050.5",
                Scope = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                Source = new SpendLimitUserScope("user_01WxYzAbCdEfGhJkMnPqRsTu"),
                SpendLimitID = "spend_limit_id",
            },
            Status = SpendLimitIncreaseRequestStatus.Approved,
        };

        IncreaseRequestApproveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
