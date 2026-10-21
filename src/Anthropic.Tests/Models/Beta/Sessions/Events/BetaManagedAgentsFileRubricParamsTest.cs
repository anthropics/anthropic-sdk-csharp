using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsFileRubricParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
        };

        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");

        Assert.Equal(expectedFileID, model.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileRubricParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileRubricParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file");

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
        };

        BetaManagedAgentsFileRubricParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
