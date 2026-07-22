using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Packages (and their versions) available in this environment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaPackages, BetaPackagesFromRaw>))]
public sealed record class BetaPackages : JsonModel
{
    /// <summary>
    /// Ubuntu/Debian packages to install
    /// </summary>
    public required IReadOnlyList<string> Apt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("apt");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "apt",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Rust packages to install
    /// </summary>
    public required IReadOnlyList<string> Cargo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("cargo");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "cargo",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Ruby packages to install
    /// </summary>
    public required IReadOnlyList<string> Gem
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("gem");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "gem",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Go packages to install
    /// </summary>
    public required IReadOnlyList<string> Go
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("go");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>("go", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Node.js packages to install
    /// </summary>
    public required IReadOnlyList<string> Npm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("npm");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "npm",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Python packages to install
    /// </summary>
    public required IReadOnlyList<string> Pip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("pip");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "pip",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Package configuration type
    /// </summary>
    public ApiEnum<string, BetaPackagesType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaPackagesType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Apt;
        _ = this.Cargo;
        _ = this.Gem;
        _ = this.Go;
        _ = this.Npm;
        _ = this.Pip;
        this.Type?.Validate();
    }

    public BetaPackages() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPackages(BetaPackages betaPackages)
        : base(betaPackages) { }
#pragma warning restore CS8618

    public BetaPackages(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPackages(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPackagesFromRaw.FromRawUnchecked"/>
    public static BetaPackages FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPackagesFromRaw : IFromRawJson<BetaPackages>
{
    /// <inheritdoc/>
    public BetaPackages FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPackages.FromRawUnchecked(rawData);
}

/// <summary>
/// Package configuration type
/// </summary>
[JsonConverter(typeof(BetaPackagesTypeConverter))]
public enum BetaPackagesType
{
    Packages,
}

sealed class BetaPackagesTypeConverter : JsonConverter<BetaPackagesType>
{
    public override BetaPackagesType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "packages" => BetaPackagesType.Packages,
            _ => (BetaPackagesType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaPackagesType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaPackagesType.Packages => "packages",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
