using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// 5-field POSIX cron schedule. Literal wall-clock matching in the configured timezone.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsCronScheduleParams,
        BetaManagedAgentsCronScheduleParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsCronScheduleParams : JsonModel
{
    /// <summary>
    /// 5-field POSIX cron expression: minute hour day-of-month month day-of-week
    /// (e.g., "0 9 * * 1-5" for weekdays at 9am). Day-of-week is 0-7 where 0 and
    /// 7 both mean Sunday. Extended cron syntax - seconds or year fields, and the
    /// special characters L, W, #, and ? - is not supported, nor are predefined shortcuts (@daily).
    /// </summary>
    public required string Expression
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expression");
        }
        init { this._rawData.Set("expression", value); }
    }

    /// <summary>
    /// Required. IANA timezone identifier (e.g., "America/Los_Angeles", "UTC"). Validated
    /// against the IANA timezone database.
    /// </summary>
    public required string Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("timezone");
        }
        init { this._rawData.Set("timezone", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsCronScheduleParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsCronScheduleParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Expression;
        _ = this.Timezone;
        this.Type.Validate();
    }

    public BetaManagedAgentsCronScheduleParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCronScheduleParams(
        BetaManagedAgentsCronScheduleParams betaManagedAgentsCronScheduleParams
    )
        : base(betaManagedAgentsCronScheduleParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCronScheduleParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCronScheduleParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCronScheduleParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCronScheduleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCronScheduleParamsFromRaw : IFromRawJson<BetaManagedAgentsCronScheduleParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCronScheduleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCronScheduleParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsCronScheduleParamsTypeConverter))]
public enum BetaManagedAgentsCronScheduleParamsType
{
    Cron,
}

sealed class BetaManagedAgentsCronScheduleParamsTypeConverter
    : JsonConverter<BetaManagedAgentsCronScheduleParamsType>
{
    public override BetaManagedAgentsCronScheduleParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cron" => BetaManagedAgentsCronScheduleParamsType.Cron,
            _ => (BetaManagedAgentsCronScheduleParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsCronScheduleParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsCronScheduleParamsType.Cron => "cron",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
