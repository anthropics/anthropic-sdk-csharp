using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using System = System;

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
        BetaManagedAgentsMultiagentSelfParams value,
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
    /// type <see cref="BetaManagedAgentsMultiagentSelfParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSelf(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMultiagentSelfParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSelf([NotNullWhen(true)] out BetaManagedAgentsMultiagentSelfParams? value)
    {
        value = this.Value as BetaManagedAgentsMultiagentSelfParams;
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
    ///     (BetaManagedAgentsMultiagentSelfParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<BetaManagedAgentsAgentParams> agent,
        System::Action<BetaManagedAgentsMultiagentSelfParams> self
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
            case BetaManagedAgentsMultiagentSelfParams value:
                self(value);
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
    ///     (BetaManagedAgentsMultiagentSelfParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<BetaManagedAgentsAgentParams, T> agent,
        System::Func<BetaManagedAgentsMultiagentSelfParams, T> self
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            BetaManagedAgentsAgentParams value => agent(value),
            BetaManagedAgentsMultiagentSelfParams value => self(value),
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
        BetaManagedAgentsMultiagentSelfParams value
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
        this.Switch((_) => { }, (agent) => agent.Validate(), (self) => self.Validate());
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
            BetaManagedAgentsMultiagentSelfParams _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsMultiagentRosterEntryParamsConverter
    : JsonConverter<BetaManagedAgentsMultiagentRosterEntryParams>
{
    public override BetaManagedAgentsMultiagentRosterEntryParams? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentSelfParams>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
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
