using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Resources;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsGitHubRepositoryResource,
        BetaManagedAgentsGitHubRepositoryResourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsGitHubRepositoryResource : JsonModel
{
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
    /// A timestamp in RFC 3339 format
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

    public required string MountPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mount_path");
        }
        init { this._rawData.Set("mount_path", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsGitHubRepositoryResourceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public Checkout? Checkout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Checkout>("checkout");
        }
        init { this._rawData.Set("checkout", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.MountPath;
        this.Type.Validate();
        _ = this.UpdatedAt;
        _ = this.Url;
        this.Checkout?.Validate();
    }

    public BetaManagedAgentsGitHubRepositoryResource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsGitHubRepositoryResource(
        BetaManagedAgentsGitHubRepositoryResource betaManagedAgentsGitHubRepositoryResource
    )
        : base(betaManagedAgentsGitHubRepositoryResource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsGitHubRepositoryResource(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsGitHubRepositoryResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsGitHubRepositoryResourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsGitHubRepositoryResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsGitHubRepositoryResourceFromRaw
    : IFromRawJson<BetaManagedAgentsGitHubRepositoryResource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsGitHubRepositoryResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsGitHubRepositoryResource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsGitHubRepositoryResourceTypeConverter))]
public enum BetaManagedAgentsGitHubRepositoryResourceType
{
    GitHubRepository,
}

sealed class BetaManagedAgentsGitHubRepositoryResourceTypeConverter
    : JsonConverter<BetaManagedAgentsGitHubRepositoryResourceType>
{
    public override BetaManagedAgentsGitHubRepositoryResourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "github_repository" => BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository,
            _ => (BetaManagedAgentsGitHubRepositoryResourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsGitHubRepositoryResourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsGitHubRepositoryResourceType.GitHubRepository =>
                    "github_repository",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CheckoutConverter))]
public record class Checkout : ModelBase
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

    public Checkout(BetaManagedAgentsBranchCheckout value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Checkout(BetaManagedAgentsCommitCheckout value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Checkout(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsBranchCheckout"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsBranch(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsBranchCheckout`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsBranch(
        [NotNullWhen(true)] out BetaManagedAgentsBranchCheckout? value
    )
    {
        value = this.Value as BetaManagedAgentsBranchCheckout;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsCommitCheckout"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsCommit(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsCommitCheckout`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsCommit(
        [NotNullWhen(true)] out BetaManagedAgentsCommitCheckout? value
    )
    {
        value = this.Value as BetaManagedAgentsCommitCheckout;
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
    ///     (BetaManagedAgentsBranchCheckout value) =&gt; {...},
    ///     (BetaManagedAgentsCommitCheckout value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsBranchCheckout> betaManagedAgentsBranch,
        System::Action<BetaManagedAgentsCommitCheckout> betaManagedAgentsCommit
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsBranchCheckout value:
                betaManagedAgentsBranch(value);
                break;
            case BetaManagedAgentsCommitCheckout value:
                betaManagedAgentsCommit(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Checkout"
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
    ///     (BetaManagedAgentsBranchCheckout value) =&gt; {...},
    ///     (BetaManagedAgentsCommitCheckout value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsBranchCheckout, T> betaManagedAgentsBranch,
        System::Func<BetaManagedAgentsCommitCheckout, T> betaManagedAgentsCommit
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsBranchCheckout value => betaManagedAgentsBranch(value),
            BetaManagedAgentsCommitCheckout value => betaManagedAgentsCommit(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Checkout"
            ),
        };
    }

    public static implicit operator Checkout(BetaManagedAgentsBranchCheckout value) => new(value);

    public static implicit operator Checkout(BetaManagedAgentsCommitCheckout value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Checkout");
        }
        this.Switch(
            (betaManagedAgentsBranch) => betaManagedAgentsBranch.Validate(),
            (betaManagedAgentsCommit) => betaManagedAgentsCommit.Validate()
        );
    }

    public virtual bool Equals(Checkout? other) =>
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
            BetaManagedAgentsBranchCheckout _ => 0,
            BetaManagedAgentsCommitCheckout _ => 1,
            _ => -1,
        };
    }
}

sealed class CheckoutConverter : JsonConverter<Checkout?>
{
    public override Checkout? Read(
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
            case "branch":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBranchCheckout>(
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
            case "commit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCommitCheckout>(
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
                return new Checkout(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Checkout? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
