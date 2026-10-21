using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Resources;

/// <summary>
/// The updated session resource.
/// </summary>
[JsonConverter(typeof(ResourceUpdateResponseConverter))]
public record class ResourceUpdateResponse : ModelBase
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

    public string? ID
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsGitHubRepositoryResource x => x.ID,
                BetaManagedAgentsFileResource x => x.ID,
                BetaManagedAgentsMemoryStoreResource _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "id"),
            };
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsGitHubRepositoryResource x => x.CreatedAt,
                BetaManagedAgentsFileResource x => x.CreatedAt,
                BetaManagedAgentsMemoryStoreResource _ => null,
                _ => WrappedJsonSerializer.GetNullableStructProperty<DateTimeOffset>(
                    this.Json,
                    "created_at"
                ),
            };
        }
    }

    public string? MountPath
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsGitHubRepositoryResource x => x.MountPath,
                BetaManagedAgentsFileResource x => x.MountPath,
                BetaManagedAgentsMemoryStoreResource x => x.MountPath,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "mount_path"
                ),
            };
        }
    }

    public ApiEnum<string, ResourceUpdateResponseType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsGitHubRepositoryResource _ =>
                    ResourceUpdateResponseType.GitHubRepository,
                BetaManagedAgentsFileResource _ => ResourceUpdateResponseType.File,
                BetaManagedAgentsMemoryStoreResource _ => ResourceUpdateResponseType.MemoryStore,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, ResourceUpdateResponseType>
                >(this.Json, "type"),
            };
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsGitHubRepositoryResource x => x.UpdatedAt,
                BetaManagedAgentsFileResource x => x.UpdatedAt,
                BetaManagedAgentsMemoryStoreResource _ => null,
                _ => WrappedJsonSerializer.GetNullableStructProperty<DateTimeOffset>(
                    this.Json,
                    "updated_at"
                ),
            };
        }
    }

    public ResourceUpdateResponse(
        BetaManagedAgentsGitHubRepositoryResource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ResourceUpdateResponse(BetaManagedAgentsFileResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResourceUpdateResponse(
        BetaManagedAgentsMemoryStoreResource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ResourceUpdateResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsGitHubRepositoryResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsGitHubRepositoryResource(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsGitHubRepositoryResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsGitHubRepositoryResource(
        [NotNullWhen(true)] out BetaManagedAgentsGitHubRepositoryResource? value
    )
    {
        value = this.Value as BetaManagedAgentsGitHubRepositoryResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsFileResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsFileResource(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsFileResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsFileResource(
        [NotNullWhen(true)] out BetaManagedAgentsFileResource? value
    )
    {
        value = this.Value as BetaManagedAgentsFileResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMemoryStoreResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMemoryStoreResource(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMemoryStoreResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMemoryStoreResource(
        [NotNullWhen(true)] out BetaManagedAgentsMemoryStoreResource? value
    )
    {
        value = this.Value as BetaManagedAgentsMemoryStoreResource;
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
    ///     (BetaManagedAgentsGitHubRepositoryResource value) =&gt; {...},
    ///     (BetaManagedAgentsFileResource value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreResource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaManagedAgentsGitHubRepositoryResource> betaManagedAgentsGitHubRepositoryResource,
        Action<BetaManagedAgentsFileResource> betaManagedAgentsFileResource,
        Action<BetaManagedAgentsMemoryStoreResource> betaManagedAgentsMemoryStoreResource
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsGitHubRepositoryResource value:
                betaManagedAgentsGitHubRepositoryResource(value);
                break;
            case BetaManagedAgentsFileResource value:
                betaManagedAgentsFileResource(value);
                break;
            case BetaManagedAgentsMemoryStoreResource value:
                betaManagedAgentsMemoryStoreResource(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ResourceUpdateResponse"
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
    ///     (BetaManagedAgentsGitHubRepositoryResource value) =&gt; {...},
    ///     (BetaManagedAgentsFileResource value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryStoreResource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<
            BetaManagedAgentsGitHubRepositoryResource,
            T
        > betaManagedAgentsGitHubRepositoryResource,
        Func<BetaManagedAgentsFileResource, T> betaManagedAgentsFileResource,
        Func<BetaManagedAgentsMemoryStoreResource, T> betaManagedAgentsMemoryStoreResource
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsGitHubRepositoryResource value =>
                betaManagedAgentsGitHubRepositoryResource(value),
            BetaManagedAgentsFileResource value => betaManagedAgentsFileResource(value),
            BetaManagedAgentsMemoryStoreResource value => betaManagedAgentsMemoryStoreResource(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ResourceUpdateResponse"
            ),
        };
    }

    public static implicit operator ResourceUpdateResponse(
        BetaManagedAgentsGitHubRepositoryResource value
    ) => new(value);

    public static implicit operator ResourceUpdateResponse(BetaManagedAgentsFileResource value) =>
        new(value);

    public static implicit operator ResourceUpdateResponse(
        BetaManagedAgentsMemoryStoreResource value
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
                "Data did not match any variant of ResourceUpdateResponse"
            );
        }
        this.Switch(
            (betaManagedAgentsGitHubRepositoryResource) =>
                betaManagedAgentsGitHubRepositoryResource.Validate(),
            (betaManagedAgentsFileResource) => betaManagedAgentsFileResource.Validate(),
            (betaManagedAgentsMemoryStoreResource) =>
                betaManagedAgentsMemoryStoreResource.Validate()
        );
    }

    public virtual bool Equals(ResourceUpdateResponse? other) =>
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
            BetaManagedAgentsGitHubRepositoryResource _ => 0,
            BetaManagedAgentsFileResource _ => 1,
            BetaManagedAgentsMemoryStoreResource _ => 2,
            _ => -1,
        };
    }
}

sealed class ResourceUpdateResponseConverter : JsonConverter<ResourceUpdateResponse>
{
    public override ResourceUpdateResponse? Read(
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
            case "github_repository":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsGitHubRepositoryResource>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResource>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMemoryStoreResource>(
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
                return new ResourceUpdateResponse(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResourceUpdateResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ResourceUpdateResponseTypeConverter))]
public enum ResourceUpdateResponseType
{
    GitHubRepository,
    File,
    MemoryStore,
}

sealed class ResourceUpdateResponseTypeConverter : JsonConverter<ResourceUpdateResponseType>
{
    public override ResourceUpdateResponseType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "github_repository" => ResourceUpdateResponseType.GitHubRepository,
            "file" => ResourceUpdateResponseType.File,
            "memory_store" => ResourceUpdateResponseType.MemoryStore,
            _ => (ResourceUpdateResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResourceUpdateResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResourceUpdateResponseType.GitHubRepository => "github_repository",
                ResourceUpdateResponseType.File => "file",
                ResourceUpdateResponseType.MemoryStore => "memory_store",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
