using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserFileUploadInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserFileUploadInput
        {
            Target = new("ref"),
            DocumentIds = ["string"],
            Paths = ["string"],
            TabID = "tab_id",
        };

        BetaBrowserRefTarget expectedTarget = new("ref");
        List<string> expectedDocumentIds = ["string"];
        List<string> expectedPaths = ["string"];
        string expectedTabID = "tab_id";

        Assert.Equal(expectedTarget, model.Target);
        Assert.NotNull(model.DocumentIds);
        Assert.Equal(expectedDocumentIds.Count, model.DocumentIds.Count);
        for (int i = 0; i < expectedDocumentIds.Count; i++)
        {
            Assert.Equal(expectedDocumentIds[i], model.DocumentIds[i]);
        }
        Assert.NotNull(model.Paths);
        Assert.Equal(expectedPaths.Count, model.Paths.Count);
        for (int i = 0; i < expectedPaths.Count; i++)
        {
            Assert.Equal(expectedPaths[i], model.Paths[i]);
        }
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserFileUploadInput
        {
            Target = new("ref"),
            DocumentIds = ["string"],
            Paths = ["string"],
            TabID = "tab_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserFileUploadInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserFileUploadInput
        {
            Target = new("ref"),
            DocumentIds = ["string"],
            Paths = ["string"],
            TabID = "tab_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserFileUploadInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaBrowserRefTarget expectedTarget = new("ref");
        List<string> expectedDocumentIds = ["string"];
        List<string> expectedPaths = ["string"];
        string expectedTabID = "tab_id";

        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.NotNull(deserialized.DocumentIds);
        Assert.Equal(expectedDocumentIds.Count, deserialized.DocumentIds.Count);
        for (int i = 0; i < expectedDocumentIds.Count; i++)
        {
            Assert.Equal(expectedDocumentIds[i], deserialized.DocumentIds[i]);
        }
        Assert.NotNull(deserialized.Paths);
        Assert.Equal(expectedPaths.Count, deserialized.Paths.Count);
        for (int i = 0; i < expectedPaths.Count; i++)
        {
            Assert.Equal(expectedPaths[i], deserialized.Paths[i]);
        }
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserFileUploadInput
        {
            Target = new("ref"),
            DocumentIds = ["string"],
            Paths = ["string"],
            TabID = "tab_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserFileUploadInput { Target = new("ref") };

        Assert.Null(model.DocumentIds);
        Assert.False(model.RawData.ContainsKey("document_ids"));
        Assert.Null(model.Paths);
        Assert.False(model.RawData.ContainsKey("paths"));
        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserFileUploadInput { Target = new("ref") };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserFileUploadInput
        {
            Target = new("ref"),

            DocumentIds = null,
            Paths = null,
            TabID = null,
        };

        Assert.Null(model.DocumentIds);
        Assert.True(model.RawData.ContainsKey("document_ids"));
        Assert.Null(model.Paths);
        Assert.True(model.RawData.ContainsKey("paths"));
        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserFileUploadInput
        {
            Target = new("ref"),

            DocumentIds = null,
            Paths = null,
            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserFileUploadInput
        {
            Target = new("ref"),
            DocumentIds = ["string"],
            Paths = ["string"],
            TabID = "tab_id",
        };

        BetaBrowserFileUploadInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
