using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class IncreaseRequestListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IncreaseRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        List<BetaSpendLimitIncreaseRequest> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IncreaseRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncreaseRequestListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IncreaseRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IncreaseRequestListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaSpendLimitIncreaseRequest> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IncreaseRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IncreaseRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        IncreaseRequestListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
