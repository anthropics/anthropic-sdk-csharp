using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebFetchUrlSourceUserInputParamsTest : TestBase
{
    [Fact]
    public void ShorthandValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInputParams value =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsWebFetchUrlSourceUserInputValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInputParams value =
            new BetaManagedAgentsWebFetchUrlSourceUserInput(
                new BetaManagedAgentsWebFetchUrlSourceAll()
            );
        value.Validate();
    }

    [Fact]
    public void ShorthandSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInputParams value =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceUserInputParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsWebFetchUrlSourceUserInputSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInputParams value =
            new BetaManagedAgentsWebFetchUrlSourceUserInput(
                new BetaManagedAgentsWebFetchUrlSourceAll()
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceUserInputParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
