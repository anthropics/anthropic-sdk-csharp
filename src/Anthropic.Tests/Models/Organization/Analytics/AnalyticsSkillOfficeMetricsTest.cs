using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsSkillOfficeMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsSkillOfficeMetrics
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };

        AnalyticsSkillOfficeProductMetrics expectedExcel = new(0);
        AnalyticsSkillOfficeProductMetrics expectedOutlook = new(0);
        AnalyticsSkillOfficeProductMetrics expectedPowerpoint = new(0);
        AnalyticsSkillOfficeProductMetrics expectedWord = new(0);

        Assert.Equal(expectedExcel, model.Excel);
        Assert.Equal(expectedOutlook, model.Outlook);
        Assert.Equal(expectedPowerpoint, model.Powerpoint);
        Assert.Equal(expectedWord, model.Word);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AnalyticsSkillOfficeMetrics
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsSkillOfficeMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsSkillOfficeMetrics
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsSkillOfficeMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AnalyticsSkillOfficeProductMetrics expectedExcel = new(0);
        AnalyticsSkillOfficeProductMetrics expectedOutlook = new(0);
        AnalyticsSkillOfficeProductMetrics expectedPowerpoint = new(0);
        AnalyticsSkillOfficeProductMetrics expectedWord = new(0);

        Assert.Equal(expectedExcel, deserialized.Excel);
        Assert.Equal(expectedOutlook, deserialized.Outlook);
        Assert.Equal(expectedPowerpoint, deserialized.Powerpoint);
        Assert.Equal(expectedWord, deserialized.Word);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AnalyticsSkillOfficeMetrics
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsSkillOfficeMetrics
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };

        AnalyticsSkillOfficeMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
