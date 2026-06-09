using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A configured session resource. Echoes the input minus write-only credentials.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionResourceConfigConverter))]
public record class BetaManagedAgentsSessionResourceConfig : ModelBase
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

    public string? MountPath
    {
        get
        {
            return Match<string?>(
                githubRepository: (x) => x.MountPath,
                file: (x) => x.MountPath,
                memoryStore: (_) => null
            );
        }
    }

    public BetaManagedAgentsSessionResourceConfig(
        BetaManagedAgentsGitHubRepositoryResourceConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionResourceConfig(
        BetaManagedAgentsFileResourceConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionResourceConfig(
        BetaManagedAgentsMemoryStoreResourceConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionResourceConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsGitHubRepositoryResourceConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGitHubRepository(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsGitHubRepositoryResourceConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGitHubRepository(
        [NotNullWhen(true)] out BetaManagedAgentsGitHubRepositoryResourceConfig? value
    )
    {
        value = this.Value as BetaManagedAgentsGitHubRepositoryResourceConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsFileResourceConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFile(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsFileResourceConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFile([NotNullWhen(true)] out BetaManagedAgentsFileResourceConfig? value)
    {
        value = this.Value as BetaManagedAgentsFileResourceConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMemoryStoreResourceConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMemoryStore(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMemoryStoreResourceConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMemoryStore(
        [NotNullWhen(true)] out BetaManagedAgentsMemoryStoreResourceConfig? value
    )
    {
        value = this.Value as BetaManagedAgentsMemoryStoreResourceConfig;
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
    ///     (BetaManagedAgentsGitHubRepositoryResourceConfig value) =&gt; {...},
    ///     (BetaManagedAgentsFileResourceConfig value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreResourceConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsGitHubRepositoryResourceConfig> githubRepository,
        System::Action<BetaManagedAgentsFileResourceConfig> file,
        System::Action<BetaManagedAgentsMemoryStoreResourceConfig> memoryStore
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsGitHubRepositoryResourceConfig value:
                githubRepository(value);
                break;
            case BetaManagedAgentsFileResourceConfig value:
                file(value);
                break;
            case BetaManagedAgentsMemoryStoreResourceConfig value:
                memoryStore(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSessionResourceConfig"
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
    ///     (BetaManagedAgentsGitHubRepositoryResourceConfig value) =&gt; {...},
    ///     (BetaManagedAgentsFileResourceConfig value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreResourceConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsGitHubRepositoryResourceConfig, T> githubRepository,
        System::Func<BetaManagedAgentsFileResourceConfig, T> file,
        System::Func<BetaManagedAgentsMemoryStoreResourceConfig, T> memoryStore
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsGitHubRepositoryResourceConfig value => githubRepository(value),
            BetaManagedAgentsFileResourceConfig value => file(value),
            BetaManagedAgentsMemoryStoreResourceConfig value => memoryStore(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionResourceConfig"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSessionResourceConfig(
        BetaManagedAgentsGitHubRepositoryResourceConfig value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionResourceConfig(
        BetaManagedAgentsFileResourceConfig value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionResourceConfig(
        BetaManagedAgentsMemoryStoreResourceConfig value
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
                "Data did not match any variant of BetaManagedAgentsSessionResourceConfig"
            );
        }
        this.Switch(
            (githubRepository) => githubRepository.Validate(),
            (file) => file.Validate(),
            (memoryStore) => memoryStore.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsSessionResourceConfig? other) =>
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
            BetaManagedAgentsGitHubRepositoryResourceConfig _ => 0,
            BetaManagedAgentsFileResourceConfig _ => 1,
            BetaManagedAgentsMemoryStoreResourceConfig _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSessionResourceConfigConverter
    : JsonConverter<BetaManagedAgentsSessionResourceConfig>
{
    public override BetaManagedAgentsSessionResourceConfig? Read(
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
            case "github_repository":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResourceConfig>(
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
            case "file":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsFileResourceConfig>(
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
            case "memory_store":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreResourceConfig>(
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
                return new BetaManagedAgentsSessionResourceConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionResourceConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
