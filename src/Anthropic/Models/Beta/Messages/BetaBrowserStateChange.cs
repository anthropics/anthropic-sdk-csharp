using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A tab this call's execution opened that remains open at its end — the creation
/// delta of the `tabs` inventory, not an event log.
///
/// <para>Carries only the `tab_id`; the tab's `title` and `url` live on its `tabs`
/// entry, which must include the same `tab_id`. A tab opened during a failed call
/// gets no deferred `tab_opened`; it simply appears in the next result's `tabs` inventory.</para>
/// </summary>
[JsonConverter(typeof(BetaBrowserStateChangeConverter))]
public record class BetaBrowserStateChange : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return Match(
                tabOpened: (x) => x.Type,
                downloadStarted: (x) => x.Type,
                downloadCompleted: (x) => x.Type,
                downloadFailed: (x) => x.Type
            );
        }
    }

    public string? DownloadID
    {
        get
        {
            return Match<string?>(
                tabOpened: (_) => null,
                downloadStarted: (x) => x.DownloadID,
                downloadCompleted: (x) => x.DownloadID,
                downloadFailed: (x) => x.DownloadID
            );
        }
    }

    public string? Url
    {
        get
        {
            return Match<string?>(
                tabOpened: (_) => null,
                downloadStarted: (x) => x.Url,
                downloadCompleted: (x) => x.Url,
                downloadFailed: (x) => x.Url
            );
        }
    }

    public BetaBrowserStateChange(
        BetaBrowserStateChangeTabOpened value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserStateChange(
        BetaBrowserStateChangeDownloadStarted value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserStateChange(
        BetaBrowserStateChangeDownloadCompleted value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserStateChange(
        BetaBrowserStateChangeDownloadFailed value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserStateChange(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserStateChangeTabOpened"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTabOpened(out var value)) {
    ///     // `value` is of type `BetaBrowserStateChangeTabOpened`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTabOpened([NotNullWhen(true)] out BetaBrowserStateChangeTabOpened? value)
    {
        value = this.Value as BetaBrowserStateChangeTabOpened;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserStateChangeDownloadStarted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDownloadStarted(out var value)) {
    ///     // `value` is of type `BetaBrowserStateChangeDownloadStarted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDownloadStarted(
        [NotNullWhen(true)] out BetaBrowserStateChangeDownloadStarted? value
    )
    {
        value = this.Value as BetaBrowserStateChangeDownloadStarted;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserStateChangeDownloadCompleted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDownloadCompleted(out var value)) {
    ///     // `value` is of type `BetaBrowserStateChangeDownloadCompleted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDownloadCompleted(
        [NotNullWhen(true)] out BetaBrowserStateChangeDownloadCompleted? value
    )
    {
        value = this.Value as BetaBrowserStateChangeDownloadCompleted;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserStateChangeDownloadFailed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDownloadFailed(out var value)) {
    ///     // `value` is of type `BetaBrowserStateChangeDownloadFailed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDownloadFailed(
        [NotNullWhen(true)] out BetaBrowserStateChangeDownloadFailed? value
    )
    {
        value = this.Value as BetaBrowserStateChangeDownloadFailed;
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
    ///     (BetaBrowserStateChangeTabOpened value) =&gt; {...},
    ///     (BetaBrowserStateChangeDownloadStarted value) =&gt; {...},
    ///     (BetaBrowserStateChangeDownloadCompleted value) =&gt; {...},
    ///     (BetaBrowserStateChangeDownloadFailed value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaBrowserStateChangeTabOpened> tabOpened,
        System::Action<BetaBrowserStateChangeDownloadStarted> downloadStarted,
        System::Action<BetaBrowserStateChangeDownloadCompleted> downloadCompleted,
        System::Action<BetaBrowserStateChangeDownloadFailed> downloadFailed
    )
    {
        switch (this.Value)
        {
            case BetaBrowserStateChangeTabOpened value:
                tabOpened(value);
                break;
            case BetaBrowserStateChangeDownloadStarted value:
                downloadStarted(value);
                break;
            case BetaBrowserStateChangeDownloadCompleted value:
                downloadCompleted(value);
                break;
            case BetaBrowserStateChangeDownloadFailed value:
                downloadFailed(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaBrowserStateChange"
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
    ///     (BetaBrowserStateChangeTabOpened value) =&gt; {...},
    ///     (BetaBrowserStateChangeDownloadStarted value) =&gt; {...},
    ///     (BetaBrowserStateChangeDownloadCompleted value) =&gt; {...},
    ///     (BetaBrowserStateChangeDownloadFailed value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaBrowserStateChangeTabOpened, T> tabOpened,
        System::Func<BetaBrowserStateChangeDownloadStarted, T> downloadStarted,
        System::Func<BetaBrowserStateChangeDownloadCompleted, T> downloadCompleted,
        System::Func<BetaBrowserStateChangeDownloadFailed, T> downloadFailed
    )
    {
        return this.Value switch
        {
            BetaBrowserStateChangeTabOpened value => tabOpened(value),
            BetaBrowserStateChangeDownloadStarted value => downloadStarted(value),
            BetaBrowserStateChangeDownloadCompleted value => downloadCompleted(value),
            BetaBrowserStateChangeDownloadFailed value => downloadFailed(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaBrowserStateChange"
            ),
        };
    }

    public static implicit operator BetaBrowserStateChange(BetaBrowserStateChangeTabOpened value) =>
        new(value);

    public static implicit operator BetaBrowserStateChange(
        BetaBrowserStateChangeDownloadStarted value
    ) => new(value);

    public static implicit operator BetaBrowserStateChange(
        BetaBrowserStateChangeDownloadCompleted value
    ) => new(value);

    public static implicit operator BetaBrowserStateChange(
        BetaBrowserStateChangeDownloadFailed value
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
                "Data did not match any variant of BetaBrowserStateChange"
            );
        }
        this.Switch(
            (tabOpened) => tabOpened.Validate(),
            (downloadStarted) => downloadStarted.Validate(),
            (downloadCompleted) => downloadCompleted.Validate(),
            (downloadFailed) => downloadFailed.Validate()
        );
    }

    public virtual bool Equals(BetaBrowserStateChange? other) =>
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
            BetaBrowserStateChangeTabOpened _ => 0,
            BetaBrowserStateChangeDownloadStarted _ => 1,
            BetaBrowserStateChangeDownloadCompleted _ => 2,
            BetaBrowserStateChangeDownloadFailed _ => 3,
            _ => -1,
        };
    }
}

sealed class BetaBrowserStateChangeConverter : JsonConverter<BetaBrowserStateChange>
{
    public override BetaBrowserStateChange? Read(
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
            case "tab_opened":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserStateChangeTabOpened>(
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
            case "download_started":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBrowserStateChangeDownloadStarted>(
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
            case "download_completed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBrowserStateChangeDownloadCompleted>(
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
            case "download_failed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBrowserStateChangeDownloadFailed>(
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
                return new BetaBrowserStateChange(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaBrowserStateChange value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
