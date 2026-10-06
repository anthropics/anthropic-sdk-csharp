using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebFetchUrlSourcesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSourcesParams
        {
            ClientToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            ServerToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            UserInput = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
        };

        BetaManagedAgentsWebFetchUrlSourceToolFilterParams expectedClientToolResults =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;
        BetaManagedAgentsWebFetchUrlSourceToolFilterParams expectedServerToolResults =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;
        BetaManagedAgentsWebFetchUrlSourceUserInputParams expectedUserInput =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;

        Assert.Equal(expectedClientToolResults, model.ClientToolResults);
        Assert.Equal(expectedServerToolResults, model.ServerToolResults);
        Assert.Equal(expectedUserInput, model.UserInput);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSourcesParams
        {
            ClientToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            ServerToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            UserInput = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourcesParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSourcesParams
        {
            ClientToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            ServerToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            UserInput = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourcesParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsWebFetchUrlSourceToolFilterParams expectedClientToolResults =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;
        BetaManagedAgentsWebFetchUrlSourceToolFilterParams expectedServerToolResults =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;
        BetaManagedAgentsWebFetchUrlSourceUserInputParams expectedUserInput =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;

        Assert.Equal(expectedClientToolResults, deserialized.ClientToolResults);
        Assert.Equal(expectedServerToolResults, deserialized.ServerToolResults);
        Assert.Equal(expectedUserInput, deserialized.UserInput);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSourcesParams
        {
            ClientToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            ServerToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            UserInput = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSourcesParams { };

        Assert.Null(model.ClientToolResults);
        Assert.False(model.RawData.ContainsKey("client_tool_results"));
        Assert.Null(model.ServerToolResults);
        Assert.False(model.RawData.ContainsKey("server_tool_results"));
        Assert.Null(model.UserInput);
        Assert.False(model.RawData.ContainsKey("user_input"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSourcesParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSourcesParams
        {
            ClientToolResults = null,
            ServerToolResults = null,
            UserInput = null,
        };

        Assert.Null(model.ClientToolResults);
        Assert.True(model.RawData.ContainsKey("client_tool_results"));
        Assert.Null(model.ServerToolResults);
        Assert.True(model.RawData.ContainsKey("server_tool_results"));
        Assert.Null(model.UserInput);
        Assert.True(model.RawData.ContainsKey("user_input"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSourcesParams
        {
            ClientToolResults = null,
            ServerToolResults = null,
            UserInput = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSourcesParams
        {
            ClientToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            ServerToolResults = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            UserInput = BetaManagedAgentsWebFetchUrlSourceShorthand.All,
        };

        BetaManagedAgentsWebFetchUrlSourcesParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
