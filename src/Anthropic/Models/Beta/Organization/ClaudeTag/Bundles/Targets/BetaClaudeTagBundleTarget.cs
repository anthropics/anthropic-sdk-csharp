using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

/// <summary>
/// One Bundle attached to one Slack channel or one Slack workspace. More types of
/// target can be added.
/// </summary>
[JsonConverter(typeof(BetaClaudeTagBundleTargetConverter))]
public record class BetaClaudeTagBundleTarget : ModelBase
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

    public string ID
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeTagSlackChannelBundleTarget x => x.ID,
                BetaClaudeTagSlackWorkspaceBundleTarget x => x.ID,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "id"),
            };
        }
    }

    public DateTimeOffset CreatedAt
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeTagSlackChannelBundleTarget x => x.CreatedAt,
                BetaClaudeTagSlackWorkspaceBundleTarget x => x.CreatedAt,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<DateTimeOffset>(
                    this.Json,
                    "created_at"
                ),
            };
        }
    }

    public ApiEnum<string, BetaClaudeTagBundleTargetType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeTagSlackChannelBundleTarget _ =>
                    BetaClaudeTagBundleTargetType.SlackChannel,
                BetaClaudeTagSlackWorkspaceBundleTarget _ =>
                    BetaClaudeTagBundleTargetType.SlackWorkspace,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaClaudeTagBundleTargetType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaClaudeTagBundleTarget(
        BetaClaudeTagSlackChannelBundleTarget value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagBundleTarget(
        BetaClaudeTagSlackWorkspaceBundleTarget value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagBundleTarget(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagSlackChannelBundleTarget"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackChannel(out var value)) {
    ///     // `value` is of type `BetaClaudeTagSlackChannelBundleTarget`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackChannel(
        [NotNullWhen(true)] out BetaClaudeTagSlackChannelBundleTarget? value
    )
    {
        value = this.Value as BetaClaudeTagSlackChannelBundleTarget;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagSlackWorkspaceBundleTarget"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackWorkspace(out var value)) {
    ///     // `value` is of type `BetaClaudeTagSlackWorkspaceBundleTarget`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackWorkspace(
        [NotNullWhen(true)] out BetaClaudeTagSlackWorkspaceBundleTarget? value
    )
    {
        value = this.Value as BetaClaudeTagSlackWorkspaceBundleTarget;
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
    ///     (BetaClaudeTagSlackChannelBundleTarget value) =&gt; {...},
    ///     (BetaClaudeTagSlackWorkspaceBundleTarget value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaClaudeTagSlackChannelBundleTarget> slackChannel,
        Action<BetaClaudeTagSlackWorkspaceBundleTarget> slackWorkspace
    )
    {
        switch (this.Value)
        {
            case BetaClaudeTagSlackChannelBundleTarget value:
                slackChannel(value);
                break;
            case BetaClaudeTagSlackWorkspaceBundleTarget value:
                slackWorkspace(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaClaudeTagBundleTarget"
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
    ///     (BetaClaudeTagSlackChannelBundleTarget value) =&gt; {...},
    ///     (BetaClaudeTagSlackWorkspaceBundleTarget value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaClaudeTagSlackChannelBundleTarget, T> slackChannel,
        Func<BetaClaudeTagSlackWorkspaceBundleTarget, T> slackWorkspace
    )
    {
        return this.Value switch
        {
            BetaClaudeTagSlackChannelBundleTarget value => slackChannel(value),
            BetaClaudeTagSlackWorkspaceBundleTarget value => slackWorkspace(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaClaudeTagBundleTarget"
            ),
        };
    }

    public static implicit operator BetaClaudeTagBundleTarget(
        BetaClaudeTagSlackChannelBundleTarget value
    ) => new(value);

    public static implicit operator BetaClaudeTagBundleTarget(
        BetaClaudeTagSlackWorkspaceBundleTarget value
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
                "Data did not match any variant of BetaClaudeTagBundleTarget"
            );
        }
        this.Switch(
            (slackChannel) => slackChannel.Validate(),
            (slackWorkspace) => slackWorkspace.Validate()
        );
    }

    public virtual bool Equals(BetaClaudeTagBundleTarget? other) =>
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
            BetaClaudeTagSlackChannelBundleTarget _ => 0,
            BetaClaudeTagSlackWorkspaceBundleTarget _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaClaudeTagBundleTargetConverter : JsonConverter<BetaClaudeTagBundleTarget>
{
    public override BetaClaudeTagBundleTarget? Read(
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
                        JsonSerializer.Deserialize<BetaClaudeTagSlackChannelBundleTarget>(
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
                        JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspaceBundleTarget>(
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
                return new BetaClaudeTagBundleTarget(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagBundleTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaClaudeTagBundleTargetTypeConverter))]
public enum BetaClaudeTagBundleTargetType
{
    SlackChannel,
    SlackWorkspace,
}

sealed class BetaClaudeTagBundleTargetTypeConverter : JsonConverter<BetaClaudeTagBundleTargetType>
{
    public override BetaClaudeTagBundleTargetType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "slack_channel" => BetaClaudeTagBundleTargetType.SlackChannel,
            "slack_workspace" => BetaClaudeTagBundleTargetType.SlackWorkspace,
            _ => (BetaClaudeTagBundleTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagBundleTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaClaudeTagBundleTargetType.SlackChannel => "slack_channel",
                BetaClaudeTagBundleTargetType.SlackWorkspace => "slack_workspace",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
