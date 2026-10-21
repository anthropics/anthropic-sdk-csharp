using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaSystemMessageParam, BetaSystemMessageParamFromRaw>))]
public sealed record class BetaSystemMessageParam : JsonModel
{
    public JsonElement Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// How long this system message's text stays in front of the model. `"never"`
    /// (the default) renders it on every request that includes it. `"next_user_message"`
    /// renders it only for the user turn it follows: once a later `role: "user"`
    /// message exists in `messages` the message stays in the array (send it unchanged)
    /// but is no longer shown to the model. Only permitted on `role: "system"` messages.
    /// </summary>
    public ApiEnum<string, ClearAt>? ClearAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ClearAt>>("clear_at");
        }
        init { this._rawData.Set("clear_at", value); }
    }

    public BetaSystemMessageParamContent? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaSystemMessageParamContent>("content");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("content");
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    /// <summary>
    /// Per-message output configuration on a role:"system" input message.
    ///
    /// <para>Fields here apply per-turn; ``format`` remains top-level only. An empty
    /// ``{}`` is accepted on a message that carries content; a message with neither
    /// content nor output_config fields is rejected.</para>
    /// </summary>
    public BetaSystemMessageOutputConfig? OutputConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaSystemMessageOutputConfig>("output_config");
        }
        init { this._rawData.Set("output_config", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Role, JsonSerializer.SerializeToElement("system")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.ClearAt?.Validate();
        this.Content?.Validate();
        this.OutputConfig?.Validate();
    }

    public BetaSystemMessageParam()
    {
        this.Role = JsonSerializer.SerializeToElement("system");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSystemMessageParam(BetaSystemMessageParam betaSystemMessageParam)
        : base(betaSystemMessageParam) { }
#pragma warning restore CS8618

    public BetaSystemMessageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Role = JsonSerializer.SerializeToElement("system");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSystemMessageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSystemMessageParamFromRaw.FromRawUnchecked"/>
    public static BetaSystemMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSystemMessageParam(BetaSystemMessageParamContent? content)
        : this()
    {
        this.Content = content;
    }
}

class BetaSystemMessageParamFromRaw : IFromRawJson<BetaSystemMessageParam>
{
    /// <inheritdoc/>
    public BetaSystemMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSystemMessageParam.FromRawUnchecked(rawData);
}

/// <summary>
/// How long this system message's text stays in front of the model. `"never"` (the
/// default) renders it on every request that includes it. `"next_user_message"`
/// renders it only for the user turn it follows: once a later `role: "user"` message
/// exists in `messages` the message stays in the array (send it unchanged) but is
/// no longer shown to the model. Only permitted on `role: "system"` messages.
/// </summary>
[JsonConverter(typeof(ClearAtConverter))]
public enum ClearAt
{
    NextUserMessage,
    Never,
}

sealed class ClearAtConverter : JsonConverter<ClearAt>
{
    public override ClearAt Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "next_user_message" => ClearAt.NextUserMessage,
            "never" => ClearAt.Never,
            _ => (ClearAt)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, ClearAt value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClearAt.NextUserMessage => "next_user_message",
                ClearAt.Never => "never",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BetaSystemMessageParamContentConverter))]
public record class BetaSystemMessageParamContent : ModelBase
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

    public BetaSystemMessageParamContent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSystemMessageParamContent(
        IReadOnlyList<SystemMessageContentBlock> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public BetaSystemMessageParamContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>SystemMessageContentBlock</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBlocks(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;SystemMessageContentBlock&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBlocks(
        [NotNullWhen(true)] out IReadOnlyList<SystemMessageContentBlock>? value
    )
    {
        value = this.Value as IReadOnlyList<SystemMessageContentBlock>;
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
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;SystemMessageContentBlock&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<SystemMessageContentBlock>> blocks
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<SystemMessageContentBlock> value:
                blocks(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaSystemMessageParamContent"
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
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;SystemMessageContentBlock&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<SystemMessageContentBlock>, T> blocks
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<SystemMessageContentBlock> value => blocks(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaSystemMessageParamContent"
            ),
        };
    }

    public static implicit operator BetaSystemMessageParamContent(string value) => new(value);

    public static implicit operator BetaSystemMessageParamContent(
        List<SystemMessageContentBlock> value
    ) => new((IReadOnlyList<SystemMessageContentBlock>)value);

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
                "Data did not match any variant of BetaSystemMessageParamContent"
            );
        }
        this.Switch(
            (_) => { },
            (blocks) =>
            {
                foreach (var item in blocks)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(BetaSystemMessageParamContent? other) =>
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
            string _ => 0,
            IReadOnlyList<SystemMessageContentBlock> _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaSystemMessageParamContentConverter : JsonConverter<BetaSystemMessageParamContent>
{
    public override BetaSystemMessageParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<SystemMessageContentBlock>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSystemMessageParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(SystemMessageContentBlockConverter))]
public record class SystemMessageContentBlock : ModelBase
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

    public ApiEnum<string, SystemMessageContentBlockType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaTextBlockParam _ => SystemMessageContentBlockType.Text,
                BetaRequestToolAdditionBlock _ => SystemMessageContentBlockType.ToolAddition,
                BetaRequestToolRemovalBlock _ => SystemMessageContentBlockType.ToolRemoval,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, SystemMessageContentBlockType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return this.Value switch
            {
                BetaTextBlockParam x => x.CacheControl,
                BetaRequestToolAdditionBlock x => x.CacheControl,
                BetaRequestToolRemovalBlock x => x.CacheControl,
                _ => WrappedJsonSerializer.GetNullableClassProperty<BetaCacheControlEphemeral>(
                    this.Json,
                    "cache_control"
                ),
            };
        }
    }

    public SystemMessageContentBlock(BetaTextBlockParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SystemMessageContentBlock(
        BetaRequestToolAdditionBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SystemMessageContentBlock(BetaRequestToolRemovalBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SystemMessageContentBlock(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextBlockParam(out var value)) {
    ///     // `value` is of type `BetaTextBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextBlockParam([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = this.Value as BetaTextBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRequestToolAdditionBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRequestToolAddition(out var value)) {
    ///     // `value` is of type `BetaRequestToolAdditionBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRequestToolAddition(
        [NotNullWhen(true)] out BetaRequestToolAdditionBlock? value
    )
    {
        value = this.Value as BetaRequestToolAdditionBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRequestToolRemovalBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRequestToolRemoval(out var value)) {
    ///     // `value` is of type `BetaRequestToolRemovalBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRequestToolRemoval(
        [NotNullWhen(true)] out BetaRequestToolRemovalBlock? value
    )
    {
        value = this.Value as BetaRequestToolRemovalBlock;
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
    ///     (BetaTextBlockParam value) =&gt; {...},
    ///     (BetaRequestToolAdditionBlock value) =&gt; {...},
    ///     (BetaRequestToolRemovalBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaTextBlockParam> betaTextBlockParam,
        System::Action<BetaRequestToolAdditionBlock> betaRequestToolAddition,
        System::Action<BetaRequestToolRemovalBlock> betaRequestToolRemoval
    )
    {
        switch (this.Value)
        {
            case BetaTextBlockParam value:
                betaTextBlockParam(value);
                break;
            case BetaRequestToolAdditionBlock value:
                betaRequestToolAddition(value);
                break;
            case BetaRequestToolRemovalBlock value:
                betaRequestToolRemoval(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of SystemMessageContentBlock"
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
    ///     (BetaTextBlockParam value) =&gt; {...},
    ///     (BetaRequestToolAdditionBlock value) =&gt; {...},
    ///     (BetaRequestToolRemovalBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaTextBlockParam, T> betaTextBlockParam,
        System::Func<BetaRequestToolAdditionBlock, T> betaRequestToolAddition,
        System::Func<BetaRequestToolRemovalBlock, T> betaRequestToolRemoval
    )
    {
        return this.Value switch
        {
            BetaTextBlockParam value => betaTextBlockParam(value),
            BetaRequestToolAdditionBlock value => betaRequestToolAddition(value),
            BetaRequestToolRemovalBlock value => betaRequestToolRemoval(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of SystemMessageContentBlock"
            ),
        };
    }

    public static implicit operator SystemMessageContentBlock(BetaTextBlockParam value) =>
        new(value);

    public static implicit operator SystemMessageContentBlock(BetaRequestToolAdditionBlock value) =>
        new(value);

    public static implicit operator SystemMessageContentBlock(BetaRequestToolRemovalBlock value) =>
        new(value);

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
                "Data did not match any variant of SystemMessageContentBlock"
            );
        }
        this.Switch(
            (betaTextBlockParam) => betaTextBlockParam.Validate(),
            (betaRequestToolAddition) => betaRequestToolAddition.Validate(),
            (betaRequestToolRemoval) => betaRequestToolRemoval.Validate()
        );
    }

    public virtual bool Equals(SystemMessageContentBlock? other) =>
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
            BetaTextBlockParam _ => 0,
            BetaRequestToolAdditionBlock _ => 1,
            BetaRequestToolRemovalBlock _ => 2,
            _ => -1,
        };
    }
}

sealed class SystemMessageContentBlockConverter : JsonConverter<SystemMessageContentBlock>
{
    public override SystemMessageContentBlock? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
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
            case "tool_addition":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlock>(
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
            case "tool_removal":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlock>(
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
                return new SystemMessageContentBlock(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SystemMessageContentBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(SystemMessageContentBlockTypeConverter))]
public enum SystemMessageContentBlockType
{
    Text,
    ToolAddition,
    ToolRemoval,
}

sealed class SystemMessageContentBlockTypeConverter : JsonConverter<SystemMessageContentBlockType>
{
    public override SystemMessageContentBlockType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => SystemMessageContentBlockType.Text,
            "tool_addition" => SystemMessageContentBlockType.ToolAddition,
            "tool_removal" => SystemMessageContentBlockType.ToolRemoval,
            _ => (SystemMessageContentBlockType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SystemMessageContentBlockType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SystemMessageContentBlockType.Text => "text",
                SystemMessageContentBlockType.ToolAddition => "tool_addition",
                SystemMessageContentBlockType.ToolRemoval => "tool_removal",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
