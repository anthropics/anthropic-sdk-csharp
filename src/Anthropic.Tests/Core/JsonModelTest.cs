using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Tests.Core;

public class JsonModelTest
{
    [Fact]
    public void GetNotNullClass_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set(dictionary, "key", "value");

        var value = JsonModel.GetNotNullClass<string>(dictionary, "key");

        Assert.Equal("value", value);
    }

    [Fact]
    public void GetNotNullClass_WhenAbsent_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            JsonModel.GetNotNullClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullClass_WhenNull_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set<string?>(dictionary, "key", null);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            JsonModel.GetNotNullClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be null", exception.Message);
    }

    [Fact]
    public void GetNotNullClass_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set(dictionary, "key", 42);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            JsonModel.GetNotNullClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.String", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set(dictionary, "key", 42);

        var value = JsonModel.GetNotNullStruct<int>(dictionary, "key");

        Assert.Equal(42, value);
    }

    [Fact]
    public void GetNotNullStruct_WhenAbsent_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            JsonModel.GetNotNullStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_WhenNull_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set<int?>(dictionary, "key", null);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            JsonModel.GetNotNullStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' cannot be null", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set(dictionary, "key", "value");

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            JsonModel.GetNotNullStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.Int32", exception.Message);
    }

    [Fact]
    public void GetNullableClass_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set(dictionary, "key", "value");

        var value = JsonModel.GetNullableClass<string>(dictionary, "key");

        Assert.Equal("value", value);
    }

    [Fact]
    public void GetNullableClass_WhenAbsent_ReturnsNull()
    {
        var dictionary = new Dictionary<string, JsonElement>();

        var value = JsonModel.GetNullableClass<string>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableClass_WhenNull_ReturnsNull()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set<string?>(dictionary, "key", null);

        var value = JsonModel.GetNullableClass<string>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableClass_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set(dictionary, "key", 42);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            JsonModel.GetNullableClass<string>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.String", exception.Message);
    }

    [Fact]
    public void GetNullableStruct_WhenPresent_Works()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set(dictionary, "key", 42);

        var value = JsonModel.GetNullableStruct<int>(dictionary, "key");

        Assert.Equal(42, value);
    }

    [Fact]
    public void GetNullableStruct_WhenAbsent_ReturnsNull()
    {
        var dictionary = new Dictionary<string, JsonElement>();

        var value = JsonModel.GetNullableStruct<int>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableStruct_WhenNull_ReturnsNull()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set<int?>(dictionary, "key", null);

        var value = JsonModel.GetNullableStruct<int>(dictionary, "key");

        Assert.Null(value);
    }

    [Fact]
    public void GetNullableStruct_WhenMismatchedType_Throws()
    {
        var dictionary = new Dictionary<string, JsonElement>();
        JsonModel.Set(dictionary, "key", "value");

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            JsonModel.GetNullableStruct<int>(dictionary, "key")
        );

        Assert.Equal("'key' must be of type System.Int32", exception.Message);
    }
}
