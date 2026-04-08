using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Resources;

/// <summary>
/// The requested session resource.
/// </summary>
[JsonConverter(typeof(ResourceRetrieveResponseConverter))]
public record class ResourceRetrieveResponse : ModelBase
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

    public string ID
    {
        get
        {
            return Match(
                betaManagedAgentsGitHubRepositoryResource: (x) => x.ID,
                betaManagedAgentsFileResource: (x) => x.ID
            );
        }
    }

    public System::DateTimeOffset CreatedAt
    {
        get
        {
            return Match(
                betaManagedAgentsGitHubRepositoryResource: (x) => x.CreatedAt,
                betaManagedAgentsFileResource: (x) => x.CreatedAt
            );
        }
    }

    public string MountPath
    {
        get
        {
            return Match(
                betaManagedAgentsGitHubRepositoryResource: (x) => x.MountPath,
                betaManagedAgentsFileResource: (x) => x.MountPath
            );
        }
    }

    public System::DateTimeOffset UpdatedAt
    {
        get
        {
            return Match(
                betaManagedAgentsGitHubRepositoryResource: (x) => x.UpdatedAt,
                betaManagedAgentsFileResource: (x) => x.UpdatedAt
            );
        }
    }

    public ResourceRetrieveResponse(
        BetaManagedAgentsGitHubRepositoryResource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ResourceRetrieveResponse(
        BetaManagedAgentsFileResource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ResourceRetrieveResponse(JsonElement element)
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
    ///     (BetaManagedAgentsFileResource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsGitHubRepositoryResource> betaManagedAgentsGitHubRepositoryResource,
        System::Action<BetaManagedAgentsFileResource> betaManagedAgentsFileResource
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
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ResourceRetrieveResponse"
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
    ///     (BetaManagedAgentsFileResource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsGitHubRepositoryResource,
            T
        > betaManagedAgentsGitHubRepositoryResource,
        System::Func<BetaManagedAgentsFileResource, T> betaManagedAgentsFileResource
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsGitHubRepositoryResource value =>
                betaManagedAgentsGitHubRepositoryResource(value),
            BetaManagedAgentsFileResource value => betaManagedAgentsFileResource(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ResourceRetrieveResponse"
            ),
        };
    }

    public static implicit operator ResourceRetrieveResponse(
        BetaManagedAgentsGitHubRepositoryResource value
    ) => new(value);

    public static implicit operator ResourceRetrieveResponse(BetaManagedAgentsFileResource value) =>
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
                "Data did not match any variant of ResourceRetrieveResponse"
            );
        }
        this.Switch(
            (betaManagedAgentsGitHubRepositoryResource) =>
                betaManagedAgentsGitHubRepositoryResource.Validate(),
            (betaManagedAgentsFileResource) => betaManagedAgentsFileResource.Validate()
        );
    }

    public virtual bool Equals(ResourceRetrieveResponse? other) =>
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
            _ => -1,
        };
    }
}

sealed class ResourceRetrieveResponseConverter : JsonConverter<ResourceRetrieveResponse>
{
    public override ResourceRetrieveResponse? Read(
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
            default:
            {
                return new ResourceRetrieveResponse(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResourceRetrieveResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
