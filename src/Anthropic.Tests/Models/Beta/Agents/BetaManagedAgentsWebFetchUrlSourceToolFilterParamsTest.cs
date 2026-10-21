using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebFetchUrlSourceToolFilterParamsTest : TestBase
{
    [Fact]
    public void ShorthandValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilterParams value =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsWebFetchUrlSourceToolFilterValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilterParams value =
            new BetaManagedAgentsWebFetchUrlSourceToolFilter(
                new BetaManagedAgentsWebFetchUrlSourceAll()
            );
        value.Validate();
    }

    [Fact]
    public void ShorthandSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilterParams value =
            BetaManagedAgentsWebFetchUrlSourceShorthand.All;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceToolFilterParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsWebFetchUrlSourceToolFilterSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceToolFilterParams value =
            new BetaManagedAgentsWebFetchUrlSourceToolFilter(
                new BetaManagedAgentsWebFetchUrlSourceAll()
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceToolFilterParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
