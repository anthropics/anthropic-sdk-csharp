using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Tests.Core;

public class JsonDictionaryTest : TestBase
{
    [Fact]
    public void DefaultConstructor_CreatesEmptyDictionary()
    {
        var dict = new JsonDictionary();

        Assert.Empty(dict.Freeze());
    }

    [Fact]
    public void DictionaryConstructor_CopiesData()
    {
        var source = new Dictionary<string, JsonElement>
        {
            ["foo"] = JsonSerializer.SerializeToElement("bar"),
            ["bar"] = JsonSerializer.SerializeToElement(42),
        };

        var dict = new JsonDictionary(source);

        var frozen = dict.Freeze();
        Assert.Equal(2, frozen.Count);
        Assert.Equal("bar", frozen["foo"].GetString());
        Assert.Equal(42, frozen["bar"].GetInt32());
    }

    [Fact]
    public void FrozenDictionaryConstructor_UsesProvidedDictionary()
    {
        var source = FrozenDictionary.ToFrozenDictionary(
            new Dictionary<string, JsonElement>
            {
                ["foo"] = JsonSerializer.SerializeToElement("bar"),
            }
        );

        var dict = new JsonDictionary(source);

        var frozen = dict.Freeze();
        Assert.Same(source, frozen);
    }

    [Fact]
    public void Set_AddsValueWhenUnfrozen()
    {
        var dict = new JsonDictionary();

        dict.Set("name", "Alice");
        dict.Set("age", 30);

        var frozen = dict.Freeze();
        Assert.Equal("Alice", frozen["name"].GetString());
        Assert.Equal(30, frozen["age"].GetInt32());
    }

    [Fact]
    public void Set_OverwritesExistingValue()
    {
        var dict = new JsonDictionary();

        dict.Set("foo", "bar");
        dict.Set("foo", "baz");

        var frozen = dict.Freeze();
        Assert.Equal("baz", frozen["foo"].GetString());
    }

    [Fact]
    public void Set_ThrowsAfterFreezing()
    {
        var dict = new JsonDictionary();
        dict.Freeze();

        Assert.Throws<InvalidOperationException>(() => dict.Set("foo", "bar"));
    }

    [Fact]
    public void Freeze_ReturnsFrozenDictionary()
    {
        var dict = new JsonDictionary();
        dict.Set("foo", "bar");

        var frozen1 = dict.Freeze();
        var frozen2 = dict.Freeze();

        Assert.Same(frozen1, frozen2);
    }

    [Fact]
    public void GetNotNullClass_ReturnsValue()
    {
        var dict = new JsonDictionary();
        dict.Set("name", "Alice");

        Assert.Equal("Alice", dict.GetNotNullClass<string>("name"));
    }

    [Fact]
    public void GetNotNullClass_CachesDeserializedValue()
    {
        var dict = new JsonDictionary();
        dict.Set("name", "Alice");

        var first = dict.GetNotNullClass<string>("name");
        var second = dict.GetNotNullClass<string>("name");

        Assert.Same(first, second);
    }

    [Fact]
    public void GetNotNullClass_ThrowsWhenKeyAbsent()
    {
        var dict = new JsonDictionary();

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullClass<string>("missing")
        );
        Assert.Contains("'missing' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullClass_ThrowsWhenValueIsNull()
    {
        var dict = new JsonDictionary(
            new Dictionary<string, JsonElement>
            {
                ["nullable"] = JsonSerializer.SerializeToElement<string?>(null),
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
        var dict = new JsonDictionary();
        dict.Set("number", 42);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullClass<string>("number")
        );
        Assert.Contains("'number' must be of type", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_ReturnsValue()
    {
        var dict = new JsonDictionary();
        dict.Set("age", 30);

        var age = dict.GetNotNullStruct<int>("age");

        Assert.Equal(30, age);
    }

    [Fact]
    public void GetNotNullStruct_ThrowsWhenKeyAbsent()
    {
        var dict = new JsonDictionary();

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullStruct<int>("missing")
        );
        Assert.Contains("'missing' cannot be absent", exception.Message);
    }

    [Fact]
    public void GetNotNullStruct_ThrowsWhenValueIsNull()
    {
        var dict = new JsonDictionary(
            new Dictionary<string, JsonElement>
            {
                ["nullable"] = JsonSerializer.SerializeToElement<int?>(null),
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
        var dict = new JsonDictionary();
        dict.Set("text", "not a number");

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNotNullStruct<int>("text")
        );
        Assert.Contains("'text' must be of type", exception.Message);
    }

    [Fact]
    public void GetNullableClass_ReturnsValueWhenPresent()
    {
        var dict = new JsonDictionary();
        dict.Set("name", "Alice");

        var name = dict.GetNullableClass<string>("name");

        Assert.Equal("Alice", name);
    }

    [Fact]
    public void GetNullableClass_ReturnsNullWhenKeyAbsent()
    {
        var dict = new JsonDictionary();

        var missing = dict.GetNullableClass<string>("missing");

        Assert.Null(missing);
    }

    [Fact]
    public void GetNullableClass_ReturnsNullWhenValueIsNull()
    {
        var dict = new JsonDictionary(
            new Dictionary<string, JsonElement>
            {
                ["nullable"] = JsonSerializer.SerializeToElement<string?>(null),
            }
        );

        var nullable = dict.GetNullableClass<string>("nullable");

        Assert.Null(nullable);
    }

    [Fact]
    public void GetNullableClass_CachesDeserializedValue()
    {
        var dict = new JsonDictionary();
        dict.Set("name", "Alice");

        var first = dict.GetNullableClass<string>("name");
        var second = dict.GetNullableClass<string>("name");

        Assert.Same(first, second);
    }

    [Fact]
    public void GetNullableClass_ThrowsWhenTypeInvalid()
    {
        var dict = new JsonDictionary();
        dict.Set("number", 42);

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNullableClass<string>("number")
        );
        Assert.Contains("'number' must be of type", exception.Message);
    }

    [Fact]
    public void GetNullableStruct_ReturnsValueWhenPresent()
    {
        var dict = new JsonDictionary();
        dict.Set("age", 30);

        var age = dict.GetNullableStruct<int>("age");

        Assert.Equal(30, age);
    }

    [Fact]
    public void GetNullableStruct_ReturnsNullWhenKeyAbsent()
    {
        var dict = new JsonDictionary();

        var missing = dict.GetNullableStruct<int>("missing");

        Assert.Null(missing);
    }

    [Fact]
    public void GetNullableStruct_ReturnsNullWhenValueIsNull()
    {
        var dict = new JsonDictionary(
            new Dictionary<string, JsonElement>
            {
                ["nullable"] = JsonSerializer.SerializeToElement<int?>(null),
            }
        );

        var nullable = dict.GetNullableStruct<int>("nullable");

        Assert.Null(nullable);
    }

    [Fact]
    public void GetNullableStruct_ThrowsWhenTypeInvalid()
    {
        var dict = new JsonDictionary();
        dict.Set("text", "not a number");

        var exception = Assert.Throws<AnthropicInvalidDataException>(() =>
            dict.GetNullableStruct<int>("text")
        );
        Assert.Contains("'text' must be of type", exception.Message);
    }

    [Fact]
    public void ComplexWorkflow_SetFreezeAndGet()
    {
        var dict = new JsonDictionary();
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

    [Fact]
    public void ToString_ContainsJsonValues()
    {
        var dict = new JsonDictionary();
        dict.Set("name", "Alice");
        dict.Set("age", 30);

        var json = dict.ToString();

        Assert.Contains("\"name\"", json);
        Assert.Contains("\"Alice\"", json);
        Assert.Contains("\"age\"", json);
        Assert.Contains("30", json);
    }

    [Fact]
    public void Equals_ReturnsTrueForSameContent()
    {
        var dict1 = new JsonDictionary();
        dict1.Set("name", "Alice");
        dict1.Set("age", 30);

        var dict2 = new JsonDictionary();
        dict2.Set("name", "Alice");
        dict2.Set("age", 30);

        Assert.True(dict1.Equals(dict2));
    }

    [Fact]
    public void Equals_ReturnsFalseForDifferentContent()
    {
        var dict1 = new JsonDictionary();
        dict1.Set("name", "Alice");

        var dict2 = new JsonDictionary();
        dict2.Set("name", "Bob");

        Assert.False(dict1.Equals(dict2));
    }

    [Fact]
    public void Equals_ReturnsFalseForDifferentCounts()
    {
        var dict1 = new JsonDictionary();
        dict1.Set("name", "Alice");
        dict1.Set("age", 30);

        var dict2 = new JsonDictionary();
        dict2.Set("name", "Alice");

        Assert.False(dict1.Equals(dict2));
    }

    [Fact]
    public void Equals_ReturnsFalseForNull()
    {
        var dict = new JsonDictionary();
        dict.Set("name", "Alice");

        Assert.False(dict.Equals(null));
    }

    [Fact]
    public void Equals_ReturnsFalseForDifferentType()
    {
        var dict = new JsonDictionary();
        dict.Set("name", "Alice");

        Assert.False(dict.Equals("not a dictionary"));
    }
}
