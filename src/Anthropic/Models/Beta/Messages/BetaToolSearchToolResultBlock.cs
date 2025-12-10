using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<BetaToolSearchToolResultBlock, BetaToolSearchToolResultBlockFromRaw>)
)]
public sealed record class BetaToolSearchToolResultBlock : ModelBase
{
    public required BetaToolSearchToolResultBlockContent Content
    {
        get
        {
            return ModelBase.GetNotNullClass<BetaToolSearchToolResultBlockContent>(
                this.RawData,
                "content"
            );
        }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public required string ToolUseID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tool_use_id"); }
        init { ModelBase.Set(this._rawData, "tool_use_id", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolSearchToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\"");
    }

    public BetaToolSearchToolResultBlock(
        BetaToolSearchToolResultBlock betaToolSearchToolResultBlock
    )
        : base(betaToolSearchToolResultBlock) { }

    public BetaToolSearchToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolSearchToolResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaToolSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolSearchToolResultBlockFromRaw : IFromRaw<BetaToolSearchToolResultBlock>
{
    /// <inheritdoc/>
    public BetaToolSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolSearchToolResultBlockContentConverter))]
public record class BetaToolSearchToolResultBlockContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaToolSearchToolResultError: (x) => x.Type,
                betaToolSearchToolSearchResultBlock: (x) => x.Type
            );
        }
    }

    public BetaToolSearchToolResultBlockContent(
        BetaToolSearchToolResultError value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolSearchToolResultBlockContent(
        BetaToolSearchToolSearchResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolSearchToolResultBlockContent(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolSearchToolResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolSearchToolResultError(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolSearchToolResultError(
        [NotNullWhen(true)] out BetaToolSearchToolResultError? value
    )
    {
        value = this.Value as BetaToolSearchToolResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolSearchToolSearchResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolSearchToolSearchResultBlock(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolSearchResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolSearchToolSearchResultBlock(
        [NotNullWhen(true)] out BetaToolSearchToolSearchResultBlock? value
    )
    {
        value = this.Value as BetaToolSearchToolSearchResultBlock;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaToolSearchToolResultError value) => {...},
    ///     (BetaToolSearchToolSearchResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaToolSearchToolResultError> betaToolSearchToolResultError,
        System::Action<BetaToolSearchToolSearchResultBlock> betaToolSearchToolSearchResultBlock
    )
    {
        switch (this.Value)
        {
            case BetaToolSearchToolResultError value:
                betaToolSearchToolResultError(value);
                break;
            case BetaToolSearchToolSearchResultBlock value:
                betaToolSearchToolSearchResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolSearchToolResultBlockContent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaToolSearchToolResultError value) => {...},
    ///     (BetaToolSearchToolSearchResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaToolSearchToolResultError, T> betaToolSearchToolResultError,
        System::Func<BetaToolSearchToolSearchResultBlock, T> betaToolSearchToolSearchResultBlock
    )
    {
        return this.Value switch
        {
            BetaToolSearchToolResultError value => betaToolSearchToolResultError(value),
            BetaToolSearchToolSearchResultBlock value => betaToolSearchToolSearchResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolSearchToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaToolSearchToolResultBlockContent(
        BetaToolSearchToolResultError value
    ) => new(value);

    public static implicit operator BetaToolSearchToolResultBlockContent(
        BetaToolSearchToolSearchResultBlock value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolSearchToolResultBlockContent"
            );
        }
        this.Switch(
            (betaToolSearchToolResultError) => betaToolSearchToolResultError.Validate(),
            (betaToolSearchToolSearchResultBlock) => betaToolSearchToolSearchResultBlock.Validate()
        );
    }

    public virtual bool Equals(BetaToolSearchToolResultBlockContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaToolSearchToolResultBlockContentConverter
    : JsonConverter<BetaToolSearchToolResultBlockContent>
{
    public override BetaToolSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultError>(
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolSearchResultBlock>(
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
