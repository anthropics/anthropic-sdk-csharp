using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Default configuration for all tools in a toolset.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolsetDefaultConfigParams,
        BetaManagedAgentsAgentToolsetDefaultConfigParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolsetDefaultConfigParams : JsonModel
{
    /// <summary>
    /// Whether tools are enabled and available to Claude by default. Defaults to
    /// true if not specified.
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <summary>
    /// Permission policy for tool execution.
    /// </summary>
    public BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy? PermissionPolicy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy>(
                "permission_policy"
            );
        }
        init { this._rawData.Set("permission_policy", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        this.PermissionPolicy?.Validate();
    }

    public BetaManagedAgentsAgentToolsetDefaultConfigParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolsetDefaultConfigParams(
        BetaManagedAgentsAgentToolsetDefaultConfigParams betaManagedAgentsAgentToolsetDefaultConfigParams
    )
        : base(betaManagedAgentsAgentToolsetDefaultConfigParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolsetDefaultConfigParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolsetDefaultConfigParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolsetDefaultConfigParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolsetDefaultConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentToolsetDefaultConfigParamsFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolsetDefaultConfigParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolsetDefaultConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolsetDefaultConfigParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Permission policy for tool execution.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicyConverter))]
public record class BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy : ModelBase
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

    public BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy(
        BetaManagedAgentsAlwaysAllowPolicy value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy(
        BetaManagedAgentsAlwaysAskPolicy value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAlwaysAllowPolicy"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAlwaysAllow(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAlwaysAllowPolicy`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAlwaysAllow(
        [NotNullWhen(true)] out BetaManagedAgentsAlwaysAllowPolicy? value
    )
    {
        value = this.Value as BetaManagedAgentsAlwaysAllowPolicy;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAlwaysAskPolicy"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAlwaysAsk(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAlwaysAskPolicy`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAlwaysAsk(
        [NotNullWhen(true)] out BetaManagedAgentsAlwaysAskPolicy? value
    )
    {
        value = this.Value as BetaManagedAgentsAlwaysAskPolicy;
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
    ///     (BetaManagedAgentsAlwaysAllowPolicy value) =&gt; {...},
    ///     (BetaManagedAgentsAlwaysAskPolicy value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAlwaysAllowPolicy> betaManagedAgentsAlwaysAllow,
        System::Action<BetaManagedAgentsAlwaysAskPolicy> betaManagedAgentsAlwaysAsk
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAlwaysAllowPolicy value:
                betaManagedAgentsAlwaysAllow(value);
                break;
            case BetaManagedAgentsAlwaysAskPolicy value:
                betaManagedAgentsAlwaysAsk(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy"
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
    ///     (BetaManagedAgentsAlwaysAllowPolicy value) =&gt; {...},
    ///     (BetaManagedAgentsAlwaysAskPolicy value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsAlwaysAllowPolicy, T> betaManagedAgentsAlwaysAllow,
        System::Func<BetaManagedAgentsAlwaysAskPolicy, T> betaManagedAgentsAlwaysAsk
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAlwaysAllowPolicy value => betaManagedAgentsAlwaysAllow(value),
            BetaManagedAgentsAlwaysAskPolicy value => betaManagedAgentsAlwaysAsk(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy(
        BetaManagedAgentsAlwaysAllowPolicy value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy(
        BetaManagedAgentsAlwaysAskPolicy value
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
                "Data did not match any variant of BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy"
            );
        }
        this.Switch(
            (betaManagedAgentsAlwaysAllow) => betaManagedAgentsAlwaysAllow.Validate(),
            (betaManagedAgentsAlwaysAsk) => betaManagedAgentsAlwaysAsk.Validate()
        );
    }

    public virtual bool Equals(
        BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy? other
    ) =>
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
            BetaManagedAgentsAlwaysAllowPolicy _ => 0,
            BetaManagedAgentsAlwaysAskPolicy _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicyConverter
    : JsonConverter<BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy?>
{
    public override BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy? Read(
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
            case "always_allow":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAlwaysAllowPolicy>(
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
            case "always_ask":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAlwaysAskPolicy>(
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
                return new BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentToolsetDefaultConfigParamsPermissionPolicy? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
