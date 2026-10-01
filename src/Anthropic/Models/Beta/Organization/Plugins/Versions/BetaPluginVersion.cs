using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Plugins.Versions;

[JsonConverter(typeof(JsonModelConverter<BetaPluginVersion, BetaPluginVersionFromRaw>))]
public sealed record class BetaPluginVersion : JsonModel
{
    /// <summary>
    /// The version's ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// What the version contains; null when not enumerated.
    /// </summary>
    public required IReadOnlyList<BetaPluginComponent>? Components
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaPluginComponent>>(
                "components"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaPluginComponent>?>(
                "components",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// This version's content scan; null when it has not been scanned.
    /// </summary>
    public required BetaPluginContentScan? ContentScan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaPluginContentScan>("content_scan");
        }
        init { this._rawData.Set("content_scan", value); }
    }

    /// <summary>
    /// RFC 3339.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Who uploaded this version; null when not recorded.
    /// </summary>
    public required CreatedBy? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedBy>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    /// <summary>
    /// The manifest's description; null when it declares none.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The manifest's display name; null when it declares none.
    /// </summary>
    public required string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// The version string the manifest declares; null when it declares none.
    /// </summary>
    public required string? ManifestVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("manifest_version");
        }
        init { this._rawData.Set("manifest_version", value); }
    }

    /// <summary>
    /// The Plugin's ID.
    /// </summary>
    public required string PluginID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plugin_id");
        }
        init { this._rawData.Set("plugin_id", value); }
    }

    /// <summary>
    /// How far the version reaches: `remote`, `privileged` or `contained`, as on
    /// the Plugin; null when not classifiable.
    /// </summary>
    public required ApiEnum<string, Reach>? Reach
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Reach>>("reach");
        }
        init { this._rawData.Set("reach", value); }
    }

    /// <summary>
    /// As supplied with the upload; null when none were supplied.
    /// </summary>
    public required string? ReleaseNotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("release_notes");
        }
        init { this._rawData.Set("release_notes", value); }
    }

    /// <summary>
    /// Always `plugin_version`.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Components ?? [])
        {
            item.Validate();
        }
        this.ContentScan?.Validate();
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.ManifestVersion;
        _ = this.PluginID;
        this.Reach?.Validate();
        _ = this.ReleaseNotes;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("plugin_version")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPluginVersion()
    {
        this.Type = JsonSerializer.SerializeToElement("plugin_version");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginVersion(BetaPluginVersion betaPluginVersion)
        : base(betaPluginVersion) { }
#pragma warning restore CS8618

    public BetaPluginVersion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("plugin_version");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginVersion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginVersionFromRaw.FromRawUnchecked"/>
    public static BetaPluginVersion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginVersionFromRaw : IFromRawJson<BetaPluginVersion>
{
    /// <inheritdoc/>
    public BetaPluginVersion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPluginVersion.FromRawUnchecked(rawData);
}

/// <summary>
/// Who uploaded this version; null when not recorded.
/// </summary>
[JsonConverter(typeof(CreatedByConverter))]
public record class CreatedBy : ModelBase
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
            return this.Value switch
            {
                BetaPluginUserActor x => x.Type,
                BetaPluginApiActor x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public CreatedBy(BetaPluginUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreatedBy(BetaPluginApiActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreatedBy(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginUserActor(out var value)) {
    ///     // `value` is of type `BetaPluginUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginUserActor([NotNullWhen(true)] out BetaPluginUserActor? value)
    {
        value = this.Value as BetaPluginUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginApiActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginApiActor(out var value)) {
    ///     // `value` is of type `BetaPluginApiActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginApiActor([NotNullWhen(true)] out BetaPluginApiActor? value)
    {
        value = this.Value as BetaPluginApiActor;
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
    ///     (BetaPluginUserActor value) =&gt; {...},
    ///     (BetaPluginApiActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaPluginUserActor> betaPluginUserActor,
        System::Action<BetaPluginApiActor> betaPluginApiActor
    )
    {
        switch (this.Value)
        {
            case BetaPluginUserActor value:
                betaPluginUserActor(value);
                break;
            case BetaPluginApiActor value:
                betaPluginApiActor(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of CreatedBy"
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
    ///     (BetaPluginUserActor value) =&gt; {...},
    ///     (BetaPluginApiActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaPluginUserActor, T> betaPluginUserActor,
        System::Func<BetaPluginApiActor, T> betaPluginApiActor
    )
    {
        return this.Value switch
        {
            BetaPluginUserActor value => betaPluginUserActor(value),
            BetaPluginApiActor value => betaPluginApiActor(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of CreatedBy"
            ),
        };
    }

    public static implicit operator CreatedBy(BetaPluginUserActor value) => new(value);

    public static implicit operator CreatedBy(BetaPluginApiActor value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of CreatedBy");
        }
        this.Switch(
            (betaPluginUserActor) => betaPluginUserActor.Validate(),
            (betaPluginApiActor) => betaPluginApiActor.Validate()
        );
    }

    public virtual bool Equals(CreatedBy? other) =>
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
            BetaPluginUserActor _ => 0,
            BetaPluginApiActor _ => 1,
            _ => -1,
        };
    }
}

sealed class CreatedByConverter : JsonConverter<CreatedBy?>
{
    public override CreatedBy? Read(
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
            case "user_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPluginUserActor>(
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
            case "api_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPluginApiActor>(
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
                return new CreatedBy(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreatedBy? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// How far the version reaches: `remote`, `privileged` or `contained`, as on the
/// Plugin; null when not classifiable.
/// </summary>
[JsonConverter(typeof(ReachConverter))]
public enum Reach
{
    Contained,
    Privileged,
    Remote,
}

sealed class ReachConverter : JsonConverter<Reach>
{
    public override Reach Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "contained" => Reach.Contained,
            "privileged" => Reach.Privileged,
            "remote" => Reach.Remote,
            _ => (Reach)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reach value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reach.Contained => "contained",
                Reach.Privileged => "privileged",
                Reach.Remote => "remote",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
