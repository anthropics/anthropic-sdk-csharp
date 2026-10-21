using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsCronScheduleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
        };

        string expectedExpression = "0 9 * * 1-5";
        string expectedTimezone = "America/Los_Angeles";
        JsonElement expectedType = JsonSerializer.SerializeToElement("cron");

        Assert.Equal(expectedExpression, model.Expression);
        Assert.Equal(expectedTimezone, model.Timezone);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCronScheduleParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCronScheduleParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExpression = "0 9 * * 1-5";
        string expectedTimezone = "America/Los_Angeles";
        JsonElement expectedType = JsonSerializer.SerializeToElement("cron");

        Assert.Equal(expectedExpression, deserialized.Expression);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCronScheduleParams
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
        };

        BetaManagedAgentsCronScheduleParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
