using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaOutputBehaviorTest : TestBase
{
    [Fact]
    public void CreateNewValidationWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorCreateNew(
            BetaOutputBehaviorCreateNewType.CreateNew
        );
        value.Validate();
    }

    [Fact]
    public void UpdateExistingValidationWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorUpdateExisting()
        {
            MemoryStoreID = "x",
            Type = BetaOutputBehaviorUpdateExistingType.UpdateExisting,
        };
        value.Validate();
    }

    [Fact]
    public void CreateNewSerializationRoundtripWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorCreateNew(
            BetaOutputBehaviorCreateNewType.CreateNew
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputBehavior>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UpdateExistingSerializationRoundtripWorks()
    {
        BetaOutputBehavior value = new BetaOutputBehaviorUpdateExisting()
        {
            MemoryStoreID = "x",
            Type = BetaOutputBehaviorUpdateExistingType.UpdateExisting,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputBehavior>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
