using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserFormInputValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BrowserFormInputValue value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        BrowserFormInputValue value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        BrowserFormInputValue value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        BrowserFormInputValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserFormInputValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        BrowserFormInputValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserFormInputValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        BrowserFormInputValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserFormInputValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
