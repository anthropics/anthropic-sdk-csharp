using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Beta.Client.Models.Beta.Messages.BetaMessageParamProperties;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMessageParam>))]
public sealed record class BetaMessageParam : ModelBase, IFromRaw<BetaMessageParam>
{
    public required Content Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new ArgumentOutOfRangeException("content", "Missing required argument");

            return JsonSerializer.Deserialize<Content>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("content");
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Role> Role
    {
        get
        {
            if (!this.Properties.TryGetValue("role", out JsonElement element))
                throw new ArgumentOutOfRangeException("role", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, Role>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["role"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Content.Validate();
        this.Role.Validate();
    }

    public BetaMessageParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageParam FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
