using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsFederatedActorGcpProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActorGcpProvider { ProjectNumber = "project_number" };

        string expectedProjectNumber = "project_number";
        JsonElement expectedType = JsonSerializer.SerializeToElement("gcp");

        Assert.Equal(expectedProjectNumber, model.ProjectNumber);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActorGcpProvider { ProjectNumber = "project_number" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorGcpProvider>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsFederatedActorGcpProvider { ProjectNumber = "project_number" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorGcpProvider>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProjectNumber = "project_number";
        JsonElement expectedType = JsonSerializer.SerializeToElement("gcp");

        Assert.Equal(expectedProjectNumber, deserialized.ProjectNumber);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsFederatedActorGcpProvider { ProjectNumber = "project_number" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsFederatedActorGcpProvider { ProjectNumber = "project_number" };

        BetaAnalyticsFederatedActorGcpProvider copied = new(model);

        Assert.Equal(model, copied);
    }
}
