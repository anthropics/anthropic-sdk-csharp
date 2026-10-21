using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// An entry in a multiagent roster: an agent ID string, a versioned agent reference,
/// or `self`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMultiagentRosterEntryParamsConverter))]
public record class BetaManagedAgentsMultiagentRosterEntryParams : ModelBase
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

    public JsonElement? Type
    {
        get
        {
            return this.Value switch
            {
                string _ => null,
                BetaManagedAgentsAgentParams x => x.Type,
                Agents::BetaManagedAgentsMultiagentSelfParams x => x.Type,
                BetaManagedAgentsAdvisorParams x => x.Type,
                _ => WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public BetaManagedAgentsMultiagentRosterEntryParams(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentRosterEntryParams(
        BetaManagedAgentsAgentParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentRosterEntryParams(
        Agents::BetaManagedAgentsMultiagentSelfParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentRosterEntryParams(
        BetaManagedAgentsAdvisorParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMultiagentRosterEntryParams(JsonElement element)
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
    /// type <see cref="BetaManagedAgentsAgentParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgent([NotNullWhen(true)] out BetaManagedAgentsAgentParams? value)
    {
        value = this.Value as BetaManagedAgentsAgentParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsMultiagentSelfParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSelf(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsMultiagentSelfParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSelf(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsMultiagentSelfParams? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsMultiagentSelfParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAdvisorParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAdvisor(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAdvisorParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAdvisor([NotNullWhen(true)] out BetaManagedAgentsAdvisorParams? value)
    {
        value = this.Value as BetaManagedAgentsAdvisorParams;
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
    ///     (BetaManagedAgentsAgentParams value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMultiagentSelfParams value) =&gt; {...},
    ///     (BetaManagedAgentsAdvisorParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<BetaManagedAgentsAgentParams> agent,
        Action<Agents::BetaManagedAgentsMultiagentSelfParams> self,
        Action<BetaManagedAgentsAdvisorParams> advisor
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case BetaManagedAgentsAgentParams value:
                agent(value);
                break;
            case Agents::BetaManagedAgentsMultiagentSelfParams value:
                self(value);
                break;
            case BetaManagedAgentsAdvisorParams value:
                advisor(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsMultiagentRosterEntryParams"
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
    ///     (BetaManagedAgentsAgentParams value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMultiagentSelfParams value) =&gt; {...},
    ///     (BetaManagedAgentsAdvisorParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<BetaManagedAgentsAgentParams, T> agent,
        Func<Agents::BetaManagedAgentsMultiagentSelfParams, T> self,
        Func<BetaManagedAgentsAdvisorParams, T> advisor
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            BetaManagedAgentsAgentParams value => agent(value),
            Agents::BetaManagedAgentsMultiagentSelfParams value => self(value),
            BetaManagedAgentsAdvisorParams value => advisor(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsMultiagentRosterEntryParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsMultiagentRosterEntryParams(string value) =>
        new(value);

    public static implicit operator BetaManagedAgentsMultiagentRosterEntryParams(
        BetaManagedAgentsAgentParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMultiagentRosterEntryParams(
        Agents::BetaManagedAgentsMultiagentSelfParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMultiagentRosterEntryParams(
        BetaManagedAgentsAdvisorParams value
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
                "Data did not match any variant of BetaManagedAgentsMultiagentRosterEntryParams"
            );
        }
        this.Switch(
            (_) => { },
            (agent) => agent.Validate(),
            (self) => self.Validate(),
            (advisor) => advisor.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsMultiagentRosterEntryParams? other) =>
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
            BetaManagedAgentsAgentParams _ => 1,
            Agents::BetaManagedAgentsMultiagentSelfParams _ => 2,
            BetaManagedAgentsAdvisorParams _ => 3,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsMultiagentRosterEntryParamsConverter
    : JsonConverter<BetaManagedAgentsMultiagentRosterEntryParams>
{
    public override BetaManagedAgentsMultiagentRosterEntryParams? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentParams>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<Agents::BetaManagedAgentsMultiagentSelfParams>(
                    element,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAdvisorParams>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentRosterEntryParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
