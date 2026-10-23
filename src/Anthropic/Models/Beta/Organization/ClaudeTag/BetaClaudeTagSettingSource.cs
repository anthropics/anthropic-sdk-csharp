using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The settings level a value comes from. More types can be added.
/// </summary>
[JsonConverter(typeof(BetaClaudeTagSettingSourceConverter))]
public record class BetaClaudeTagSettingSource : ModelBase
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

    public string? SlackChannelID
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeTagSlackChannelSettingSource x => x.SlackChannelID,
                BetaClaudeTagSlackWorkspaceSettingSource _ => null,
                BetaClaudeTagSlackParentChannelSettingSource x => x.SlackChannelID,
                BetaClaudeTagSlackDefaultSettingSource _ => null,
                BetaClaudeTagDefaultSettingSource _ => null,
                BetaClaudeTagSlackGridChannelSettingSource _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "slack_channel_id"
                ),
            };
        }
    }

    public ApiEnum<string, BetaClaudeTagSettingSourceType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeTagSlackChannelSettingSource _ =>
                    BetaClaudeTagSettingSourceType.SlackChannel,
                BetaClaudeTagSlackWorkspaceSettingSource _ =>
                    BetaClaudeTagSettingSourceType.SlackWorkspace,
                BetaClaudeTagSlackParentChannelSettingSource _ =>
                    BetaClaudeTagSettingSourceType.SlackParentChannel,
                BetaClaudeTagSlackDefaultSettingSource _ =>
                    BetaClaudeTagSettingSourceType.SlackDefault,
                BetaClaudeTagDefaultSettingSource _ => BetaClaudeTagSettingSourceType.Default,
                BetaClaudeTagSlackGridChannelSettingSource _ =>
                    BetaClaudeTagSettingSourceType.SlackGridChannel,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaClaudeTagSettingSourceType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaClaudeTagSettingSource(
        BetaClaudeTagSlackChannelSettingSource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagSettingSource(
        BetaClaudeTagSlackWorkspaceSettingSource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagSettingSource(
        BetaClaudeTagSlackParentChannelSettingSource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagSettingSource(
        BetaClaudeTagSlackDefaultSettingSource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagSettingSource(
        BetaClaudeTagDefaultSettingSource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagSettingSource(
        BetaClaudeTagSlackGridChannelSettingSource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagSettingSource(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagSlackChannelSettingSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackChannel(out var value)) {
    ///     // `value` is of type `BetaClaudeTagSlackChannelSettingSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackChannel(
        [NotNullWhen(true)] out BetaClaudeTagSlackChannelSettingSource? value
    )
    {
        value = this.Value as BetaClaudeTagSlackChannelSettingSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagSlackWorkspaceSettingSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackWorkspace(out var value)) {
    ///     // `value` is of type `BetaClaudeTagSlackWorkspaceSettingSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackWorkspace(
        [NotNullWhen(true)] out BetaClaudeTagSlackWorkspaceSettingSource? value
    )
    {
        value = this.Value as BetaClaudeTagSlackWorkspaceSettingSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagSlackParentChannelSettingSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackParentChannel(out var value)) {
    ///     // `value` is of type `BetaClaudeTagSlackParentChannelSettingSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackParentChannel(
        [NotNullWhen(true)] out BetaClaudeTagSlackParentChannelSettingSource? value
    )
    {
        value = this.Value as BetaClaudeTagSlackParentChannelSettingSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagSlackDefaultSettingSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackDefault(out var value)) {
    ///     // `value` is of type `BetaClaudeTagSlackDefaultSettingSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackDefault(
        [NotNullWhen(true)] out BetaClaudeTagSlackDefaultSettingSource? value
    )
    {
        value = this.Value as BetaClaudeTagSlackDefaultSettingSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagDefaultSettingSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDefault(out var value)) {
    ///     // `value` is of type `BetaClaudeTagDefaultSettingSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDefault([NotNullWhen(true)] out BetaClaudeTagDefaultSettingSource? value)
    {
        value = this.Value as BetaClaudeTagDefaultSettingSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagSlackGridChannelSettingSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackGridChannel(out var value)) {
    ///     // `value` is of type `BetaClaudeTagSlackGridChannelSettingSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackGridChannel(
        [NotNullWhen(true)] out BetaClaudeTagSlackGridChannelSettingSource? value
    )
    {
        value = this.Value as BetaClaudeTagSlackGridChannelSettingSource;
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
    ///     (BetaClaudeTagSlackChannelSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagSlackWorkspaceSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagSlackParentChannelSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagSlackDefaultSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagDefaultSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagSlackGridChannelSettingSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaClaudeTagSlackChannelSettingSource> slackChannel,
        Action<BetaClaudeTagSlackWorkspaceSettingSource> slackWorkspace,
        Action<BetaClaudeTagSlackParentChannelSettingSource> slackParentChannel,
        Action<BetaClaudeTagSlackDefaultSettingSource> slackDefault,
        Action<BetaClaudeTagDefaultSettingSource> default_,
        Action<BetaClaudeTagSlackGridChannelSettingSource> slackGridChannel
    )
    {
        switch (this.Value)
        {
            case BetaClaudeTagSlackChannelSettingSource value:
                slackChannel(value);
                break;
            case BetaClaudeTagSlackWorkspaceSettingSource value:
                slackWorkspace(value);
                break;
            case BetaClaudeTagSlackParentChannelSettingSource value:
                slackParentChannel(value);
                break;
            case BetaClaudeTagSlackDefaultSettingSource value:
                slackDefault(value);
                break;
            case BetaClaudeTagDefaultSettingSource value:
                default_(value);
                break;
            case BetaClaudeTagSlackGridChannelSettingSource value:
                slackGridChannel(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaClaudeTagSettingSource"
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
    ///     (BetaClaudeTagSlackChannelSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagSlackWorkspaceSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagSlackParentChannelSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagSlackDefaultSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagDefaultSettingSource value) =&gt; {...},
    ///     (BetaClaudeTagSlackGridChannelSettingSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaClaudeTagSlackChannelSettingSource, T> slackChannel,
        Func<BetaClaudeTagSlackWorkspaceSettingSource, T> slackWorkspace,
        Func<BetaClaudeTagSlackParentChannelSettingSource, T> slackParentChannel,
        Func<BetaClaudeTagSlackDefaultSettingSource, T> slackDefault,
        Func<BetaClaudeTagDefaultSettingSource, T> default_,
        Func<BetaClaudeTagSlackGridChannelSettingSource, T> slackGridChannel
    )
    {
        return this.Value switch
        {
            BetaClaudeTagSlackChannelSettingSource value => slackChannel(value),
            BetaClaudeTagSlackWorkspaceSettingSource value => slackWorkspace(value),
            BetaClaudeTagSlackParentChannelSettingSource value => slackParentChannel(value),
            BetaClaudeTagSlackDefaultSettingSource value => slackDefault(value),
            BetaClaudeTagDefaultSettingSource value => default_(value),
            BetaClaudeTagSlackGridChannelSettingSource value => slackGridChannel(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaClaudeTagSettingSource"
            ),
        };
    }

    public static implicit operator BetaClaudeTagSettingSource(
        BetaClaudeTagSlackChannelSettingSource value
    ) => new(value);

    public static implicit operator BetaClaudeTagSettingSource(
        BetaClaudeTagSlackWorkspaceSettingSource value
    ) => new(value);

    public static implicit operator BetaClaudeTagSettingSource(
        BetaClaudeTagSlackParentChannelSettingSource value
    ) => new(value);

    public static implicit operator BetaClaudeTagSettingSource(
        BetaClaudeTagSlackDefaultSettingSource value
    ) => new(value);

    public static implicit operator BetaClaudeTagSettingSource(
        BetaClaudeTagDefaultSettingSource value
    ) => new(value);

    public static implicit operator BetaClaudeTagSettingSource(
        BetaClaudeTagSlackGridChannelSettingSource value
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
                "Data did not match any variant of BetaClaudeTagSettingSource"
            );
        }
        this.Switch(
            (slackChannel) => slackChannel.Validate(),
            (slackWorkspace) => slackWorkspace.Validate(),
            (slackParentChannel) => slackParentChannel.Validate(),
            (slackDefault) => slackDefault.Validate(),
            (default_) => default_.Validate(),
            (slackGridChannel) => slackGridChannel.Validate()
        );
    }

    public virtual bool Equals(BetaClaudeTagSettingSource? other) =>
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
            BetaClaudeTagSlackChannelSettingSource _ => 0,
            BetaClaudeTagSlackWorkspaceSettingSource _ => 1,
            BetaClaudeTagSlackParentChannelSettingSource _ => 2,
            BetaClaudeTagSlackDefaultSettingSource _ => 3,
            BetaClaudeTagDefaultSettingSource _ => 4,
            BetaClaudeTagSlackGridChannelSettingSource _ => 5,
            _ => -1,
        };
    }
}

sealed class BetaClaudeTagSettingSourceConverter : JsonConverter<BetaClaudeTagSettingSource>
{
    public override BetaClaudeTagSettingSource? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "slack_channel":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagSlackChannelSettingSource>(
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
            case "slack_workspace":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspaceSettingSource>(
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
            case "slack_parent_channel":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagSlackParentChannelSettingSource>(
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
            case "slack_default":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagSlackDefaultSettingSource>(
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
            case "default":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagDefaultSettingSource>(
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
            case "slack_grid_channel":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagSlackGridChannelSettingSource>(
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
                return new BetaClaudeTagSettingSource(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagSettingSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaClaudeTagSettingSourceTypeConverter))]
public enum BetaClaudeTagSettingSourceType
{
    SlackChannel,
    SlackWorkspace,
    SlackParentChannel,
    SlackDefault,
    Default,
    SlackGridChannel,
}

sealed class BetaClaudeTagSettingSourceTypeConverter : JsonConverter<BetaClaudeTagSettingSourceType>
{
    public override BetaClaudeTagSettingSourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "slack_channel" => BetaClaudeTagSettingSourceType.SlackChannel,
            "slack_workspace" => BetaClaudeTagSettingSourceType.SlackWorkspace,
            "slack_parent_channel" => BetaClaudeTagSettingSourceType.SlackParentChannel,
            "slack_default" => BetaClaudeTagSettingSourceType.SlackDefault,
            "default" => BetaClaudeTagSettingSourceType.Default,
            "slack_grid_channel" => BetaClaudeTagSettingSourceType.SlackGridChannel,
            _ => (BetaClaudeTagSettingSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagSettingSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaClaudeTagSettingSourceType.SlackChannel => "slack_channel",
                BetaClaudeTagSettingSourceType.SlackWorkspace => "slack_workspace",
                BetaClaudeTagSettingSourceType.SlackParentChannel => "slack_parent_channel",
                BetaClaudeTagSettingSourceType.SlackDefault => "slack_default",
                BetaClaudeTagSettingSourceType.Default => "default",
                BetaClaudeTagSettingSourceType.SlackGridChannel => "slack_grid_channel",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
