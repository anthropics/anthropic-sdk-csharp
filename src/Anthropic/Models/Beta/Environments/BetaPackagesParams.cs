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
/// Specify packages (and optionally their versions) available in this environment.
///
/// <para>When versioning, use the version semantics relevant for the package manager,
/// e.g. for `pip` use `package==1.0.0`. You are responsible for validating the package
/// and version exist. Unversioned installs the latest.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaPackagesParams, BetaPackagesParamsFromRaw>))]
public sealed record class BetaPackagesParams : JsonModel
{
    /// <summary>
    /// Ubuntu/Debian packages to install
    /// </summary>
    public IReadOnlyList<string>? Apt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("apt");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "apt",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Rust packages to install
    /// </summary>
    public IReadOnlyList<string>? Cargo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("cargo");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "cargo",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Ruby packages to install
    /// </summary>
    public IReadOnlyList<string>? Gem
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("gem");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "gem",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Go packages to install
    /// </summary>
    public IReadOnlyList<string>? Go
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("go");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "go",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Node.js packages to install
    /// </summary>
    public IReadOnlyList<string>? Npm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("npm");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "npm",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Python packages to install
    /// </summary>
    public IReadOnlyList<string>? Pip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("pip");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "pip",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Package configuration type
    /// </summary>
    public ApiEnum<string, BetaPackagesParamsType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaPackagesParamsType>>("type");
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

    public BetaPackagesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPackagesParams(BetaPackagesParams betaPackagesParams)
        : base(betaPackagesParams) { }
#pragma warning restore CS8618

    public BetaPackagesParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPackagesParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPackagesParamsFromRaw.FromRawUnchecked"/>
    public static BetaPackagesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPackagesParamsFromRaw : IFromRawJson<BetaPackagesParams>
{
    /// <inheritdoc/>
    public BetaPackagesParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPackagesParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Package configuration type
/// </summary>
[JsonConverter(typeof(BetaPackagesParamsTypeConverter))]
public enum BetaPackagesParamsType
{
    Packages,
}

sealed class BetaPackagesParamsTypeConverter : JsonConverter<BetaPackagesParamsType>
{
    public override BetaPackagesParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "packages" => BetaPackagesParamsType.Packages,
            _ => (BetaPackagesParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaPackagesParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaPackagesParamsType.Packages => "packages",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
