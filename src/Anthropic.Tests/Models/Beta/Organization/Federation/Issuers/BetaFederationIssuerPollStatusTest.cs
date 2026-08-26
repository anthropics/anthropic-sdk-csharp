using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Issuers;

public class BetaFederationIssuerPollStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFederationIssuerPollStatus
        {
            ConsecutiveFailures = 0,
            LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        long expectedConsecutiveFailures = 0;
        DateTimeOffset expectedLastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedNextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedConsecutiveFailures, model.ConsecutiveFailures);
        Assert.Equal(expectedLastFetchedAt, model.LastFetchedAt);
        Assert.Equal(expectedNextPollAt, model.NextPollAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFederationIssuerPollStatus
        {
            ConsecutiveFailures = 0,
            LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationIssuerPollStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFederationIssuerPollStatus
        {
            ConsecutiveFailures = 0,
            LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationIssuerPollStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedConsecutiveFailures = 0;
        DateTimeOffset expectedLastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedNextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedConsecutiveFailures, deserialized.ConsecutiveFailures);
        Assert.Equal(expectedLastFetchedAt, deserialized.LastFetchedAt);
        Assert.Equal(expectedNextPollAt, deserialized.NextPollAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFederationIssuerPollStatus
        {
            ConsecutiveFailures = 0,
            LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFederationIssuerPollStatus
        {
            ConsecutiveFailures = 0,
            LastFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextPollAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaFederationIssuerPollStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}
