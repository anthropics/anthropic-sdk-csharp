using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamInputTest : TestBase
{
    [Fact]
    public void MemoryStoreValidationWorks()
    {
        BetaDreamInput value = new BetaDreamMemoryStoreInput()
        {
            MemoryStoreID = "x",
            Type = BetaDreamMemoryStoreInputType.MemoryStore,
        };
        value.Validate();
    }

    [Fact]
    public void SessionsValidationWorks()
    {
        BetaDreamInput value = new BetaDreamSessionsInput()
        {
            SessionIds = ["string"],
            Type = BetaDreamSessionsInputType.Sessions,
        };
        value.Validate();
    }

    [Fact]
    public void MemoryStoreSerializationRoundtripWorks()
    {
        BetaDreamInput value = new BetaDreamMemoryStoreInput()
        {
            MemoryStoreID = "x",
            Type = BetaDreamMemoryStoreInputType.MemoryStore,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionsSerializationRoundtripWorks()
    {
        BetaDreamInput value = new BetaDreamSessionsInput()
        {
            SessionIds = ["string"],
            Type = BetaDreamSessionsInputType.Sessions,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
