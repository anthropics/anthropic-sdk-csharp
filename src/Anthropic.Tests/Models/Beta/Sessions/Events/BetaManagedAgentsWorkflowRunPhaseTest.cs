using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsWorkflowRunPhaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhase
        {
            ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            Description = "Finds each vendor's pricing page.",
            Name = "Collect the sources",
        };

        string expectedID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd";
        string expectedDescription = "Finds each vendor's pricing page.";
        string expectedName = "Collect the sources";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhase
        {
            ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            Description = "Finds each vendor's pricing page.",
            Name = "Collect the sources",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunPhase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhase
        {
            ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            Description = "Finds each vendor's pricing page.",
            Name = "Collect the sources",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunPhase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd";
        string expectedDescription = "Finds each vendor's pricing page.";
        string expectedName = "Collect the sources";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhase
        {
            ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            Description = "Finds each vendor's pricing page.",
            Name = "Collect the sources",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhase
        {
            ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
            Description = "Finds each vendor's pricing page.",
            Name = "Collect the sources",
        };

        BetaManagedAgentsWorkflowRunPhase copied = new(model);

        Assert.Equal(model, copied);
    }
}
