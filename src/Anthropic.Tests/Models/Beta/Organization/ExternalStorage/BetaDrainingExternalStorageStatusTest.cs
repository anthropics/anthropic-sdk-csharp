using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaDrainingExternalStorageStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDrainingExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RemovalStarted = true,
        };

        bool expectedHealthy = true;
        DateTimeOffset expectedLastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        bool expectedRemovalStarted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("draining");

        Assert.Equal(expectedHealthy, model.Healthy);
        Assert.Equal(expectedLastCheckedAt, model.LastCheckedAt);
        Assert.Equal(expectedRemovalStarted, model.RemovalStarted);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDrainingExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RemovalStarted = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDrainingExternalStorageStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDrainingExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RemovalStarted = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDrainingExternalStorageStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHealthy = true;
        DateTimeOffset expectedLastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        bool expectedRemovalStarted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("draining");

        Assert.Equal(expectedHealthy, deserialized.Healthy);
        Assert.Equal(expectedLastCheckedAt, deserialized.LastCheckedAt);
        Assert.Equal(expectedRemovalStarted, deserialized.RemovalStarted);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDrainingExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RemovalStarted = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDrainingExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RemovalStarted = true,
        };

        BetaDrainingExternalStorageStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}
