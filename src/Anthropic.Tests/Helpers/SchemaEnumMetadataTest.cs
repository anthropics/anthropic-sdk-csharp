using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Anthropic.Helpers;

namespace Anthropic.Tests.Helpers;

public enum MetadataState
{
    WaitingForReview,
    ReadyToRun,
}

public sealed class EnumMetadataModel : StructuredOutputModel
{
    [SchemaProperty(
        Default = MetadataState.ReadyToRun,
        Const = MetadataState.ReadyToRun,
        Enum = new object[] { MetadataState.WaitingForReview, MetadataState.ReadyToRun }
    )]
    public MetadataState State { get; set; }
}

public sealed class NestedEnumMetadataModel : StructuredOutputModel
{
    public EnumMetadataModel Item { get; set; } = new();
}

public sealed class PrimitiveMetadataModel : StructuredOutputModel
{
    [SchemaProperty(Default = 0, Const = 0, Enum = new object[] { 0, 1 })]
    public int Number { get; set; }

    [SchemaProperty(Default = false, Const = false, Enum = new object[] { false, true })]
    public bool Flag { get; set; }

    [SchemaProperty(Default = "", Const = "", Enum = new object[] { "", "ready" })]
    public string Text { get; set; } = "";
}

public sealed class SchemaEnumMetadataTest
{
    private static readonly string[] ExpectedStateNames = ["waiting_for_review", "ready_to_run"];

    [Fact]
    public void EnumAttributeValuesUseTheSchemaNamingPolicy()
    {
        var schema = StructuredOutput.ToJsonSchema<EnumMetadataModel>();
        var properties = Assert.IsType<JsonObject>(schema["properties"]);
        var state = Assert.IsType<JsonObject>(properties["state"]);
        Assert.Equal("ready_to_run", state["default"]?.GetValue<string>());
        Assert.Equal("ready_to_run", state["const"]?.GetValue<string>());
        var values = Assert.IsType<JsonArray>(state["enum"]);
        Assert.Equal(ExpectedStateNames, values.Select(v => v?.GetValue<string>()).ToArray());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void PublicFormatHelpersKeepSerializedEnumValues(bool beta)
    {
        IReadOnlyDictionary<string, JsonElement> schema = beta
            ? StructuredOutput.CreateBetaJsonFormat<EnumMetadataModel>().Schema
            : StructuredOutput.CreateJsonFormat<EnumMetadataModel>().Schema;
        var state = schema["properties"].GetProperty("state");
        Assert.Equal("ready_to_run", state.GetProperty("const").GetString());
        Assert.Equal("ready_to_run", state.GetProperty("default").GetString());
        var json = "{\"state\":" + state.GetProperty("const").GetRawText() + "}";
        Assert.Equal(
            MetadataState.ReadyToRun,
            StructuredOutput.Parse<EnumMetadataModel>(json).State
        );
    }

    [Fact]
    public void NestedEnumMetadataUsesTheSamePolicy()
    {
        var schema = StructuredOutput.ToJsonSchema<NestedEnumMetadataModel>();
        var properties = Assert.IsType<JsonObject>(schema["properties"]);
        var item = Assert.IsType<JsonObject>(properties["item"]);
        var nested = Assert.IsType<JsonObject>(item["properties"]);
        var state = Assert.IsType<JsonObject>(nested["state"]);
        Assert.Equal("ready_to_run", state["const"]?.GetValue<string>());
        Assert.Equal("ready_to_run", state["default"]?.GetValue<string>());
    }

    [Fact]
    public void PrimitiveAttributeValuesKeepTheirTypes()
    {
        var schema = StructuredOutput.CreateJsonFormat<PrimitiveMetadataModel>().Schema;
        var properties = schema["properties"];
        foreach (var keyword in new[] { "default", "const" })
        {
            Assert.Equal(0, properties.GetProperty("number").GetProperty(keyword).GetInt32());
            Assert.False(properties.GetProperty("flag").GetProperty(keyword).GetBoolean());
            Assert.Equal("", properties.GetProperty("text").GetProperty(keyword).GetString());
        }
        Assert.Equal("[0,1]", properties.GetProperty("number").GetProperty("enum").GetRawText());
        Assert.Equal(
            "[false,true]",
            properties.GetProperty("flag").GetProperty("enum").GetRawText()
        );
    }
}
