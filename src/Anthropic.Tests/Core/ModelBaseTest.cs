using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Tests.Core;

public class ModelBaseTest
{
    [Fact]
    public void GetNotNullClass_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set(dictionary, "key", "value");

        var value = ModelBase.GetNotNullClass<string>(dictionary, "key");

        Assert.Equal("value", value);
    }

    [Fact]
    public void GetNotNullClass_WhenAbsent_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            ModelBase.GetNotNullClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullClass_WhenNull_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set<string?>(dictionary, "key", null);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            ModelBase.GetNotNullClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be null", exception.Message);
    }

    [Fact]
    public void GetNotNullClass_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set(dictionary, "key", 42);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            ModelBase.GetNotNullClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.String", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set(dictionary, "key", 42);

        var value = ModelBase.GetNotNullStruct<int>(dictionary, "key");

        Assert.Equal(42, value);
    }

    [Fact]
    public void GetNotNullStruct_WhenAbsent_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            ModelBase.GetNotNullStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_WhenNull_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set<int?>(dictionary, "key", null);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            ModelBase.GetNotNullStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be null", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set(dictionary, "key", "value");

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            ModelBase.GetNotNullStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.Int32", exception.Message);
    }

    [Fact]
    public void GetNullableClass_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set(dictionary, "key", "value");

        var value = ModelBase.GetNullableClass<string>(dictionary, "key");

        Assert.Equal("value", value);
    }

    [Fact]
    public void GetNullableClass_WhenAbsent_ReturnsNull()
    {
        var dictionary = new Dictionary<string, JsonElement>();

        var value = ModelBase.GetNullableClass<string>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableClass_WhenNull_ReturnsNull()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set<string?>(dictionary, "key", null);

        var value = ModelBase.GetNullableClass<string>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableClass_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set(dictionary, "key", 42);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            ModelBase.GetNullableClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.String", exception.Message);
    }

    [Fact]
    public void GetNullableStruct_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set(dictionary, "key", 42);

        var value = ModelBase.GetNullableStruct<int>(dictionary, "key");

        Assert.Equal(42, value);
    }

    [Fact]
    public void GetNullableStruct_WhenAbsent_ReturnsNull()
    {
        var dictionary = new Dictionary<string, JsonElement>();

        var value = ModelBase.GetNullableStruct<int>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableStruct_WhenNull_ReturnsNull()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set<int?>(dictionary, "key", null);

        var value = ModelBase.GetNullableStruct<int>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableStruct_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        ModelBase.Set(dictionary, "key", "value");

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            ModelBase.GetNullableStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.Int32", exception.Message);
    }
}
