using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserFormInputValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaBrowserFormInputValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        BetaBrowserFormInputValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        BetaBrowserFormInputValue value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        BetaBrowserFormInputValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserFormInputValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        BetaBrowserFormInputValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserFormInputValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        BetaBrowserFormInputValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserFormInputValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
