using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsOfficeMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsOfficeMetrics
        {
            Excel = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Outlook = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Powerpoint = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Word = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
        };

        BetaAnalyticsOfficeProductMetrics expectedExcel = new()
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };
        BetaAnalyticsOfficeProductMetrics expectedOutlook = new()
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };
        BetaAnalyticsOfficeProductMetrics expectedPowerpoint = new()
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };
        BetaAnalyticsOfficeProductMetrics expectedWord = new()
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        Assert.Equal(expectedExcel, model.Excel);
        Assert.Equal(expectedOutlook, model.Outlook);
        Assert.Equal(expectedPowerpoint, model.Powerpoint);
        Assert.Equal(expectedWord, model.Word);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsOfficeMetrics
        {
            Excel = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Outlook = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Powerpoint = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Word = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsOfficeMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsOfficeMetrics
        {
            Excel = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Outlook = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Powerpoint = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Word = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsOfficeMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsOfficeProductMetrics expectedExcel = new()
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };
        BetaAnalyticsOfficeProductMetrics expectedOutlook = new()
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };
        BetaAnalyticsOfficeProductMetrics expectedPowerpoint = new()
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };
        BetaAnalyticsOfficeProductMetrics expectedWord = new()
        {
            ConnectorsUsedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        Assert.Equal(expectedExcel, deserialized.Excel);
        Assert.Equal(expectedOutlook, deserialized.Outlook);
        Assert.Equal(expectedPowerpoint, deserialized.Powerpoint);
        Assert.Equal(expectedWord, deserialized.Word);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsOfficeMetrics
        {
            Excel = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Outlook = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Powerpoint = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Word = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsOfficeMetrics
        {
            Excel = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Outlook = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Powerpoint = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Word = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
        };

        BetaAnalyticsOfficeMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
