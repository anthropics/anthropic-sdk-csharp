using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Kind of identity a row's usage is attributed to.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsActorTypeConverter))]
public enum BetaAnalyticsActorType
{
    ApiActor,
    FederatedActor,
    ServiceAccountActor,
    UserActor,
}

sealed class BetaAnalyticsActorTypeConverter : JsonConverter<BetaAnalyticsActorType>
{
    public override BetaAnalyticsActorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api_actor" => BetaAnalyticsActorType.ApiActor,
            "federated_actor" => BetaAnalyticsActorType.FederatedActor,
            "service_account_actor" => BetaAnalyticsActorType.ServiceAccountActor,
            "user_actor" => BetaAnalyticsActorType.UserActor,
            _ => (BetaAnalyticsActorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsActorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsActorType.ApiActor => "api_actor",
                BetaAnalyticsActorType.FederatedActor => "federated_actor",
                BetaAnalyticsActorType.ServiceAccountActor => "service_account_actor",
                BetaAnalyticsActorType.UserActor => "user_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
