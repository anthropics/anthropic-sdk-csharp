using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

[JsonConverter(typeof(BetaClaudeTagBundleTargetCreateConverter))]
public record class BetaClaudeTagBundleTargetCreate : ModelBase
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

    public ApiEnum<string, BetaClaudeTagBundleTargetCreateType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeTagSlackChannelBundleTargetCreate _ =>
                    BetaClaudeTagBundleTargetCreateType.SlackChannel,
                BetaClaudeTagSlackWorkspaceBundleTargetCreate _ =>
                    BetaClaudeTagBundleTargetCreateType.SlackWorkspace,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaClaudeTagBundleTargetCreateType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaClaudeTagBundleTargetCreate(
        BetaClaudeTagSlackChannelBundleTargetCreate value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagBundleTargetCreate(
        BetaClaudeTagSlackWorkspaceBundleTargetCreate value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagBundleTargetCreate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagSlackChannelBundleTargetCreate"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackChannel(out var value)) {
    ///     // `value` is of type `BetaClaudeTagSlackChannelBundleTargetCreate`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackChannel(
        [NotNullWhen(true)] out BetaClaudeTagSlackChannelBundleTargetCreate? value
    )
    {
        value = this.Value as BetaClaudeTagSlackChannelBundleTargetCreate;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagSlackWorkspaceBundleTargetCreate"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackWorkspace(out var value)) {
    ///     // `value` is of type `BetaClaudeTagSlackWorkspaceBundleTargetCreate`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackWorkspace(
        [NotNullWhen(true)] out BetaClaudeTagSlackWorkspaceBundleTargetCreate? value
    )
    {
        value = this.Value as BetaClaudeTagSlackWorkspaceBundleTargetCreate;
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
    ///     (BetaClaudeTagSlackChannelBundleTargetCreate value) =&gt; {...},
    ///     (BetaClaudeTagSlackWorkspaceBundleTargetCreate value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaClaudeTagSlackChannelBundleTargetCreate> slackChannel,
        Action<BetaClaudeTagSlackWorkspaceBundleTargetCreate> slackWorkspace
    )
    {
        switch (this.Value)
        {
            case BetaClaudeTagSlackChannelBundleTargetCreate value:
                slackChannel(value);
                break;
            case BetaClaudeTagSlackWorkspaceBundleTargetCreate value:
                slackWorkspace(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaClaudeTagBundleTargetCreate"
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
    ///     (BetaClaudeTagSlackChannelBundleTargetCreate value) =&gt; {...},
    ///     (BetaClaudeTagSlackWorkspaceBundleTargetCreate value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaClaudeTagSlackChannelBundleTargetCreate, T> slackChannel,
        Func<BetaClaudeTagSlackWorkspaceBundleTargetCreate, T> slackWorkspace
    )
    {
        return this.Value switch
        {
            BetaClaudeTagSlackChannelBundleTargetCreate value => slackChannel(value),
            BetaClaudeTagSlackWorkspaceBundleTargetCreate value => slackWorkspace(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaClaudeTagBundleTargetCreate"
            ),
        };
    }

    public static implicit operator BetaClaudeTagBundleTargetCreate(
        BetaClaudeTagSlackChannelBundleTargetCreate value
    ) => new(value);

    public static implicit operator BetaClaudeTagBundleTargetCreate(
        BetaClaudeTagSlackWorkspaceBundleTargetCreate value
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
                "Data did not match any variant of BetaClaudeTagBundleTargetCreate"
            );
        }
        this.Switch(
            (slackChannel) => slackChannel.Validate(),
            (slackWorkspace) => slackWorkspace.Validate()
        );
    }

    public virtual bool Equals(BetaClaudeTagBundleTargetCreate? other) =>
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
            BetaClaudeTagSlackChannelBundleTargetCreate _ => 0,
            BetaClaudeTagSlackWorkspaceBundleTargetCreate _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaClaudeTagBundleTargetCreateConverter
    : JsonConverter<BetaClaudeTagBundleTargetCreate>
{
    public override BetaClaudeTagBundleTargetCreate? Read(
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
                        JsonSerializer.Deserialize<BetaClaudeTagSlackChannelBundleTargetCreate>(
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
                        JsonSerializer.Deserialize<BetaClaudeTagSlackWorkspaceBundleTargetCreate>(
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
                return new BetaClaudeTagBundleTargetCreate(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagBundleTargetCreate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaClaudeTagBundleTargetCreateTypeConverter))]
public enum BetaClaudeTagBundleTargetCreateType
{
    SlackChannel,
    SlackWorkspace,
}

sealed class BetaClaudeTagBundleTargetCreateTypeConverter
    : JsonConverter<BetaClaudeTagBundleTargetCreateType>
{
    public override BetaClaudeTagBundleTargetCreateType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "slack_channel" => BetaClaudeTagBundleTargetCreateType.SlackChannel,
            "slack_workspace" => BetaClaudeTagBundleTargetCreateType.SlackWorkspace,
            _ => (BetaClaudeTagBundleTargetCreateType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagBundleTargetCreateType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaClaudeTagBundleTargetCreateType.SlackChannel => "slack_channel",
                BetaClaudeTagBundleTargetCreateType.SlackWorkspace => "slack_workspace",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
