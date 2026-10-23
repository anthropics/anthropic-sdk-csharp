using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Cost;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Cost;

public class BetaAnalyticsCostMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostMetrics
        {
            Amount = "41280.000000",
            Currency = "USD",
            ListAmount = "51600.000000",
            Requests = 128,
        };

        string expectedAmount = "41280.000000";
        string expectedCurrency = "USD";
        string expectedListAmount = "51600.000000";
        long expectedRequests = 128;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedListAmount, model.ListAmount);
        Assert.Equal(expectedRequests, model.Requests);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostMetrics
        {
            Amount = "41280.000000",
            Currency = "USD",
            ListAmount = "51600.000000",
            Requests = 128,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsCostMetrics
        {
            Amount = "41280.000000",
            Currency = "USD",
            ListAmount = "51600.000000",
            Requests = 128,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "41280.000000";
        string expectedCurrency = "USD";
        string expectedListAmount = "51600.000000";
        long expectedRequests = 128;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedListAmount, deserialized.ListAmount);
        Assert.Equal(expectedRequests, deserialized.Requests);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsCostMetrics
        {
            Amount = "41280.000000",
            Currency = "USD",
            ListAmount = "51600.000000",
            Requests = 128,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsCostMetrics
        {
            Amount = "41280.000000",
            Currency = "USD",
            ListAmount = "51600.000000",
            Requests = 128,
        };

        BetaAnalyticsCostMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
