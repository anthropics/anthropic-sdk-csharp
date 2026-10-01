using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class SpendLimitListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpendLimitListPageResponse
        {
            Data =
            [
                new()
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
            ],
            NextPage = "next_page",
        };

        List<BetaSpendLimit> expectedData =
        [
            new()
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
        var model = new SpendLimitListPageResponse
        {
            Data =
            [
                new()
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
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SpendLimitListPageResponse
        {
            Data =
            [
                new()
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
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaSpendLimit> expectedData =
        [
            new()
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
        var model = new SpendLimitListPageResponse
        {
            Data =
            [
                new()
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
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SpendLimitListPageResponse
        {
            Data =
            [
                new()
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
            ],
            NextPage = "next_page",
        };

        SpendLimitListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
