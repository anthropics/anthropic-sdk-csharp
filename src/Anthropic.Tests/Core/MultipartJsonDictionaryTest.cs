using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Tests.Core;

public class MultipartJsonDictionaryTest : TestBase
{
    [Fact]
    public void DefaultConstructor_CreatesEmptyDictionary()
    {
        var dict = new MultipartJsonDictionary();

        Assert.Empty(dict.Freeze());
    }

    [Fact]
    public void DictionaryConstructor_CopiesData()
    {
        var source = new Dictionary<string, MultipartJsonElement>
        {
            ["foo"] = MultipartJsonSerializer.SerializeToElement("bar"),
            ["bar"] = MultipartJsonSerializer.SerializeToElement(42),
        };

        var dict = new MultipartJsonDictionary(source);

        var frozen = dict.Freeze();
        Assert.Equal(2, frozen.Count);
        Assert.Equal("bar", frozen["foo"].Json.GetString());
        Assert.Equal(42, frozen["bar"].Json.GetInt32());
    }

    [Fact]
    public void FrozenDictionaryConstructor_UsesProvidedDictionary()
    {
        var source = FrozenDictionary.ToFrozenDictionary(
            new Dictionary<string, MultipartJsonElement>
            {
                ["foo"] = MultipartJsonSerializer.SerializeToElement("bar"),
            }
        );

        var dict = new MultipartJsonDictionary(source);

        var frozen = dict.Freeze();
        Assert.Same(source, frozen);
    }

    [Fact]
    public void Set_AddsValueWhenUnfrozen()
    {
        var dict = new MultipartJsonDictionary();

        dict.Set("name", "Alice");
        dict.Set("age", 30);

        var frozen = dict.Freeze();
        Assert.Equal("Alice", frozen["name"].Json.GetString());
        Assert.Equal(30, frozen["age"].Json.GetInt32());
    }

    [Fact]
    public void Set_OverwritesExistingValue()
    {
        var dict = new MultipartJsonDictionary();

        dict.Set("foo", "bar");
        dict.Set("foo", "baz");

        var frozen = dict.Freeze();
        Assert.Equal("baz", frozen["foo"].Json.GetString());
    }

    [Fact]
    public void Set_ThrowsAfterFreezing()
    {
        var dict = new MultipartJsonDictionary();
        dict.Freeze();

        Assert.Throws<InvalidOperationException>(() => dict.Set("foo", "bar"));
    }

    [Fact]
    public void Freeze_ReturnsFrozenDictionary()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("foo", "bar");

        var frozen1 = dict.Freeze();
        var frozen2 = dict.Freeze();

        Assert.Same(frozen1, frozen2);
    }

    [Fact]
    public void GetNotNullClass_ReturnsValue()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("name", "Alice");

        Assert.Equal("Alice", dict.GetNotNullClass<string>("name"));
    }

    [Fact]
    public void GetNotNullClass_CachesDeserializedValue()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("name", "Alice");

        var first = dict.GetNotNullClass<string>("name");
        var second = dict.GetNotNullClass<string>("name");

        Assert.Same(first, second);
    }

    [Fact]
    public void GetNotNullClass_ThrowsWhenKeyAbsent()
    {
        var dict = new MultipartJsonDictionary();

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullClass<string>("missing")
        );
        Assert.Contains("'missing' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullClass_ThrowsWhenValueIsNull()
    {
        var dict = new MultipartJsonDictionary(
            new Dictionary<string, MultipartJsonElement>
            {
                ["nullable"] = MultipartJsonSerializer.SerializeToElement<string?>(null),
            }
        );

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullClass<string>("nullable")
        );
        Assert.Contains("'nullable' cannot be null", exception.Message);
    }

    [Fact]
    public void GetNotNullClass_ThrowsWhenTypeInvalid()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("number", 42);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullClass<string>("number")
        );
        Assert.Contains("'number' must be of type", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_ReturnsValue()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("age", 30);

        var age = dict.GetNotNullStruct<int>("age");

        Assert.Equal(30, age);
    }

    [Fact]
    public void GetNotNullStruct_ThrowsWhenKeyAbsent()
    {
        var dict = new MultipartJsonDictionary();

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullStruct<int>("missing")
        );
        Assert.Contains("'missing' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_ThrowsWhenValueIsNull()
    {
        var dict = new MultipartJsonDictionary(
            new Dictionary<string, MultipartJsonElement>
            {
                ["nullable"] = MultipartJsonSerializer.SerializeToElement<int?>(null),
            }
        );

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullStruct<int>("nullable")
        );
        Assert.Contains("'nullable' cannot be null", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_ThrowsWhenTypeInvalid()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("text", "not a number");

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullStruct<int>("text")
        );
        Assert.Contains("'text' must be of type", exception.Message);
    }

    [Fact]
    public void GetNullableClass_ReturnsValueWhenPresent()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("name", "Alice");

        var name = dict.GetNullableClass<string>("name");

        Assert.Equal("Alice", name);
    }

    [Fact]
    public void GetNullableClass_ReturnsNullWhenKeyAbsent()
    {
        var dict = new MultipartJsonDictionary();

        var missing = dict.GetNullableClass<string>("missing");

        Assert.Null(missing);
    }

    [Fact]
    public void GetNullableClass_ReturnsNullWhenValueIsNull()
    {
        var dict = new MultipartJsonDictionary(
            new Dictionary<string, MultipartJsonElement>
            {
                ["nullable"] = MultipartJsonSerializer.SerializeToElement<string?>(null),
            }
        );

        var nullable = dict.GetNullableClass<string>("nullable");

        Assert.Null(nullable);
    }

    [Fact]
    public void GetNullableClass_CachesDeserializedValue()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("name", "Alice");

        var first = dict.GetNullableClass<string>("name");
        var second = dict.GetNullableClass<string>("name");

        Assert.Same(first, second);
    }

    [Fact]
    public void GetNullableClass_ThrowsWhenTypeInvalid()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("number", 42);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNullableClass<string>("number")
        );
        Assert.Contains("'number' must be of type", exception.Message);
    }

    [Fact]
    public void GetNullableStruct_ReturnsValueWhenPresent()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("age", 30);

        var age = dict.GetNullableStruct<int>("age");

        Assert.Equal(30, age);
    }

    [Fact]
    public void GetNullableStruct_ReturnsNullWhenKeyAbsent()
    {
        var dict = new MultipartJsonDictionary();

        var missing = dict.GetNullableStruct<int>("missing");

        Assert.Null(missing);
    }

    [Fact]
    public void GetNullableStruct_ReturnsNullWhenValueIsNull()
    {
        var dict = new MultipartJsonDictionary(
            new Dictionary<string, MultipartJsonElement>
            {
                ["nullable"] = MultipartJsonSerializer.SerializeToElement<int?>(null),
            }
        );

        var nullable = dict.GetNullableStruct<int>("nullable");

        Assert.Null(nullable);
    }

    [Fact]
    public void GetNullableStruct_ThrowsWhenTypeInvalid()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("text", "not a number");

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNullableStruct<int>("text")
        );
        Assert.Contains("'text' must be of type", exception.Message);
    }

    [Fact]
    public void ComplexWorkflow_SetFreezeAndGet()
    {
        var dict = new MultipartJsonDictionary();
        dict.Set("name", "Alice");
        dict.Set("age", 30);
        dict.Set("active", true);

        var frozen = dict.Freeze();

        Assert.Equal("Alice", dict.GetNotNullClass<string>("name"));
        Assert.Equal(30, dict.GetNotNullStruct<int>("age"));
        Assert.True(dict.GetNotNullStruct<bool>("active"));
        Assert.Null(dict.GetNullableClass<string>("missing"));

        Assert.Throws<InvalidOperationException>(() => dict.Set("new", "value"));
    }
}
