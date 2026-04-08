using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Parameters for providing the result of a custom tool execution.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserCustomToolResultEventParams,
        BetaManagedAgentsUserCustomToolResultEventParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserCustomToolResultEventParams : JsonModel
{
    /// <summary>
    /// The id of the `agent.custom_tool_use` event this result corresponds to, which
    /// can be found in the last `session.status_idle` [event's](https://platform.claude.com/docs/en/api/beta/sessions/events/list#beta_managed_agents_session_requires_action.event_ids)
    /// `stop_reason.event_ids` field.
    /// </summary>
    public required string CustomToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("custom_tool_use_id");
        }
        init { this._rawData.Set("custom_tool_use_id", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The result content returned by the tool.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsUserCustomToolResultEventParamsContent>? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<BetaManagedAgentsUserCustomToolResultEventParamsContent>
            >("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsUserCustomToolResultEventParamsContent>?>(
                "content",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the tool execution resulted in an error.
    /// </summary>
    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init { this._rawData.Set("is_error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomToolUseID;
        this.Type.Validate();
        foreach (var item in this.Content ?? [])
        {
            item.Validate();
        }
        _ = this.IsError;
    }

    public BetaManagedAgentsUserCustomToolResultEventParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserCustomToolResultEventParams(
        BetaManagedAgentsUserCustomToolResultEventParams betaManagedAgentsUserCustomToolResultEventParams
    )
        : base(betaManagedAgentsUserCustomToolResultEventParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserCustomToolResultEventParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserCustomToolResultEventParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserCustomToolResultEventParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserCustomToolResultEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserCustomToolResultEventParamsFromRaw
    : IFromRawJson<BetaManagedAgentsUserCustomToolResultEventParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserCustomToolResultEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserCustomToolResultEventParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUserCustomToolResultEventParamsTypeConverter))]
public enum BetaManagedAgentsUserCustomToolResultEventParamsType
{
    UserCustomToolResult,
}

sealed class BetaManagedAgentsUserCustomToolResultEventParamsTypeConverter
    : JsonConverter<BetaManagedAgentsUserCustomToolResultEventParamsType>
{
    public override BetaManagedAgentsUserCustomToolResultEventParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.custom_tool_result" =>
                BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
            _ => (BetaManagedAgentsUserCustomToolResultEventParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserCustomToolResultEventParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult =>
                    "user.custom_tool_result",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Content block in a tool result. Can be `text`, `image`, `document`, or `search_result`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsUserCustomToolResultEventParamsContentConverter))]
public record class BetaManagedAgentsUserCustomToolResultEventParamsContent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BetaManagedAgentsUserCustomToolResultEventParamsContent(
        BetaManagedAgentsTextBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserCustomToolResultEventParamsContent(
        BetaManagedAgentsImageBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserCustomToolResultEventParamsContent(
        BetaManagedAgentsDocumentBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsUserCustomToolResultEventParamsContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTextBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTextBlock(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTextBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTextBlock(
        [NotNullWhen(true)] out BetaManagedAgentsTextBlock? value
    )
    {
        value = this.Value as BetaManagedAgentsTextBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsImageBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsImageBlock(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsImageBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsImageBlock(
        [NotNullWhen(true)] out BetaManagedAgentsImageBlock? value
    )
    {
        value = this.Value as BetaManagedAgentsImageBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsDocumentBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsDocumentBlock(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsDocumentBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsDocumentBlock(
        [NotNullWhen(true)] out BetaManagedAgentsDocumentBlock? value
    )
    {
        value = this.Value as BetaManagedAgentsDocumentBlock;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (BetaManagedAgentsImageBlock value) =&gt; {...},
    ///     (BetaManagedAgentsDocumentBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsTextBlock> betaManagedAgentsTextBlock,
        System::Action<BetaManagedAgentsImageBlock> betaManagedAgentsImageBlock,
        System::Action<BetaManagedAgentsDocumentBlock> betaManagedAgentsDocumentBlock
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsTextBlock value:
                betaManagedAgentsTextBlock(value);
                break;
            case BetaManagedAgentsImageBlock value:
                betaManagedAgentsImageBlock(value);
                break;
            case BetaManagedAgentsDocumentBlock value:
                betaManagedAgentsDocumentBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsUserCustomToolResultEventParamsContent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (BetaManagedAgentsTextBlock value) =&gt; {...},
    ///     (BetaManagedAgentsImageBlock value) =&gt; {...},
    ///     (BetaManagedAgentsDocumentBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsTextBlock, T> betaManagedAgentsTextBlock,
        System::Func<BetaManagedAgentsImageBlock, T> betaManagedAgentsImageBlock,
        System::Func<BetaManagedAgentsDocumentBlock, T> betaManagedAgentsDocumentBlock
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsTextBlock value => betaManagedAgentsTextBlock(value),
            BetaManagedAgentsImageBlock value => betaManagedAgentsImageBlock(value),
            BetaManagedAgentsDocumentBlock value => betaManagedAgentsDocumentBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsUserCustomToolResultEventParamsContent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsUserCustomToolResultEventParamsContent(
        BetaManagedAgentsTextBlock value
    ) => new(value);

    public static implicit operator BetaManagedAgentsUserCustomToolResultEventParamsContent(
        BetaManagedAgentsImageBlock value
    ) => new(value);

    public static implicit operator BetaManagedAgentsUserCustomToolResultEventParamsContent(
        BetaManagedAgentsDocumentBlock value
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsUserCustomToolResultEventParamsContent"
            );
        }
        this.Switch(
            (betaManagedAgentsTextBlock) => betaManagedAgentsTextBlock.Validate(),
            (betaManagedAgentsImageBlock) => betaManagedAgentsImageBlock.Validate(),
            (betaManagedAgentsDocumentBlock) => betaManagedAgentsDocumentBlock.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsUserCustomToolResultEventParamsContent? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaManagedAgentsTextBlock _ => 0,
            BetaManagedAgentsImageBlock _ => 1,
            BetaManagedAgentsDocumentBlock _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsUserCustomToolResultEventParamsContentConverter
    : JsonConverter<BetaManagedAgentsUserCustomToolResultEventParamsContent>
{
    public override BetaManagedAgentsUserCustomToolResultEventParamsContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTextBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "image":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsImageBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "document":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDocumentBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaManagedAgentsUserCustomToolResultEventParamsContent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserCustomToolResultEventParamsContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
