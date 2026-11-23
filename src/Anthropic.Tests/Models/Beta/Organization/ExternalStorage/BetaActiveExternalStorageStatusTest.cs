using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaActiveExternalStorageStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaActiveExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        bool expectedHealthy = true;
        DateTimeOffset expectedLastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("active");

        Assert.Equal(expectedHealthy, model.Healthy);
        Assert.Equal(expectedLastCheckedAt, model.LastCheckedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaActiveExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaActiveExternalStorageStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaActiveExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaActiveExternalStorageStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHealthy = true;
        DateTimeOffset expectedLastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("active");

        Assert.Equal(expectedHealthy, deserialized.Healthy);
        Assert.Equal(expectedLastCheckedAt, deserialized.LastCheckedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaActiveExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaActiveExternalStorageStatus
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        BetaActiveExternalStorageStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}
