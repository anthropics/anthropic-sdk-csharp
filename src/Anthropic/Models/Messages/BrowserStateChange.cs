using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// A tab this call's execution opened that remains open at its end — the creation
/// delta of the `tabs` inventory, not an event log.
///
/// <para>Carries only the `tab_id`; the tab's `title` and `url` live on its `tabs`
/// entry, which must include the same `tab_id`. A tab opened during a failed call
/// gets no deferred `tab_opened`; it simply appears in the next result's `tabs` inventory.</para>
/// </summary>
[JsonConverter(typeof(BrowserStateChangeConverter))]
public record class BrowserStateChange : ModelBase
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

    public BrowserStateChange(BrowserStateChangeTabOpened value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserStateChange(BrowserStateChangeDownloadStarted value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserStateChange(
        BrowserStateChangeDownloadCompleted value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserStateChange(BrowserStateChangeDownloadFailed value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserStateChange(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserStateChangeTabOpened"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTabOpened(out var value)) {
    ///     // `value` is of type `BrowserStateChangeTabOpened`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTabOpened([NotNullWhen(true)] out BrowserStateChangeTabOpened? value)
    {
        value = this.Value as BrowserStateChangeTabOpened;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserStateChangeDownloadStarted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDownloadStarted(out var value)) {
    ///     // `value` is of type `BrowserStateChangeDownloadStarted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDownloadStarted(
        [NotNullWhen(true)] out BrowserStateChangeDownloadStarted? value
    )
    {
        value = this.Value as BrowserStateChangeDownloadStarted;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserStateChangeDownloadCompleted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDownloadCompleted(out var value)) {
    ///     // `value` is of type `BrowserStateChangeDownloadCompleted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDownloadCompleted(
        [NotNullWhen(true)] out BrowserStateChangeDownloadCompleted? value
    )
    {
        value = this.Value as BrowserStateChangeDownloadCompleted;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserStateChangeDownloadFailed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDownloadFailed(out var value)) {
    ///     // `value` is of type `BrowserStateChangeDownloadFailed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDownloadFailed(
        [NotNullWhen(true)] out BrowserStateChangeDownloadFailed? value
    )
    {
        value = this.Value as BrowserStateChangeDownloadFailed;
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
    ///     (BrowserStateChangeTabOpened value) =&gt; {...},
    ///     (BrowserStateChangeDownloadStarted value) =&gt; {...},
    ///     (BrowserStateChangeDownloadCompleted value) =&gt; {...},
    ///     (BrowserStateChangeDownloadFailed value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BrowserStateChangeTabOpened> tabOpened,
        System::Action<BrowserStateChangeDownloadStarted> downloadStarted,
        System::Action<BrowserStateChangeDownloadCompleted> downloadCompleted,
        System::Action<BrowserStateChangeDownloadFailed> downloadFailed
    )
    {
        switch (this.Value)
        {
            case BrowserStateChangeTabOpened value:
                tabOpened(value);
                break;
            case BrowserStateChangeDownloadStarted value:
                downloadStarted(value);
                break;
            case BrowserStateChangeDownloadCompleted value:
                downloadCompleted(value);
                break;
            case BrowserStateChangeDownloadFailed value:
                downloadFailed(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BrowserStateChange"
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
    ///     (BrowserStateChangeTabOpened value) =&gt; {...},
    ///     (BrowserStateChangeDownloadStarted value) =&gt; {...},
    ///     (BrowserStateChangeDownloadCompleted value) =&gt; {...},
    ///     (BrowserStateChangeDownloadFailed value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BrowserStateChangeTabOpened, T> tabOpened,
        System::Func<BrowserStateChangeDownloadStarted, T> downloadStarted,
        System::Func<BrowserStateChangeDownloadCompleted, T> downloadCompleted,
        System::Func<BrowserStateChangeDownloadFailed, T> downloadFailed
    )
    {
        return this.Value switch
        {
            BrowserStateChangeTabOpened value => tabOpened(value),
            BrowserStateChangeDownloadStarted value => downloadStarted(value),
            BrowserStateChangeDownloadCompleted value => downloadCompleted(value),
            BrowserStateChangeDownloadFailed value => downloadFailed(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BrowserStateChange"
            ),
        };
    }

    public static implicit operator BrowserStateChange(BrowserStateChangeTabOpened value) =>
        new(value);

    public static implicit operator BrowserStateChange(BrowserStateChangeDownloadStarted value) =>
        new(value);

    public static implicit operator BrowserStateChange(BrowserStateChangeDownloadCompleted value) =>
        new(value);

    public static implicit operator BrowserStateChange(BrowserStateChangeDownloadFailed value) =>
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
                "Data did not match any variant of BrowserStateChange"
            );
        }
        this.Switch(
            (tabOpened) => tabOpened.Validate(),
            (downloadStarted) => downloadStarted.Validate(),
            (downloadCompleted) => downloadCompleted.Validate(),
            (downloadFailed) => downloadFailed.Validate()
        );
    }

    public virtual bool Equals(BrowserStateChange? other) =>
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
            BrowserStateChangeTabOpened _ => 0,
            BrowserStateChangeDownloadStarted _ => 1,
            BrowserStateChangeDownloadCompleted _ => 2,
            BrowserStateChangeDownloadFailed _ => 3,
            _ => -1,
        };
    }
}

sealed class BrowserStateChangeConverter : JsonConverter<BrowserStateChange>
{
    public override BrowserStateChange? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserStateChangeTabOpened>(
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
                        JsonSerializer.Deserialize<BrowserStateChangeDownloadStarted>(
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
                        JsonSerializer.Deserialize<BrowserStateChangeDownloadCompleted>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserStateChangeDownloadFailed>(
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
                return new BrowserStateChange(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrowserStateChange value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
