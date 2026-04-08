using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Skill to load in the session container.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSkillParamsConverter))]
public record class BetaManagedAgentsSkillParams : ModelBase
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

    public string SkillID
    {
        get { return Match(anthropic: (x) => x.SkillID, custom: (x) => x.SkillID); }
    }

    public string? Version
    {
        get { return Match<string?>(anthropic: (x) => x.Version, custom: (x) => x.Version); }
    }

    public BetaManagedAgentsSkillParams(
        BetaManagedAgentsAnthropicSkillParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSkillParams(
        BetaManagedAgentsCustomSkillParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSkillParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAnthropicSkillParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAnthropic(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAnthropicSkillParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAnthropic(
        [NotNullWhen(true)] out BetaManagedAgentsAnthropicSkillParams? value
    )
    {
        value = this.Value as BetaManagedAgentsAnthropicSkillParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsCustomSkillParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCustom(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsCustomSkillParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCustom([NotNullWhen(true)] out BetaManagedAgentsCustomSkillParams? value)
    {
        value = this.Value as BetaManagedAgentsCustomSkillParams;
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
    ///     (BetaManagedAgentsAnthropicSkillParams value) =&gt; {...},
    ///     (BetaManagedAgentsCustomSkillParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAnthropicSkillParams> anthropic,
        System::Action<BetaManagedAgentsCustomSkillParams> custom
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAnthropicSkillParams value:
                anthropic(value);
                break;
            case BetaManagedAgentsCustomSkillParams value:
                custom(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSkillParams"
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
    ///     (BetaManagedAgentsAnthropicSkillParams value) =&gt; {...},
    ///     (BetaManagedAgentsCustomSkillParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsAnthropicSkillParams, T> anthropic,
        System::Func<BetaManagedAgentsCustomSkillParams, T> custom
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAnthropicSkillParams value => anthropic(value),
            BetaManagedAgentsCustomSkillParams value => custom(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSkillParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSkillParams(
        BetaManagedAgentsAnthropicSkillParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSkillParams(
        BetaManagedAgentsCustomSkillParams value
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
                "Data did not match any variant of BetaManagedAgentsSkillParams"
            );
        }
        this.Switch((anthropic) => anthropic.Validate(), (custom) => custom.Validate());
    }

    public virtual bool Equals(BetaManagedAgentsSkillParams? other) =>
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
            BetaManagedAgentsAnthropicSkillParams _ => 0,
            BetaManagedAgentsCustomSkillParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSkillParamsConverter : JsonConverter<BetaManagedAgentsSkillParams>
{
    public override BetaManagedAgentsSkillParams? Read(
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
            case "anthropic":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAnthropicSkillParams>(
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
            case "custom":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsCustomSkillParams>(
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
                return new BetaManagedAgentsSkillParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSkillParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
