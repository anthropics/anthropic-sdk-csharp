using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaFileImageSource>))]
public sealed record class BetaFileImageSource : ModelBase, IFromRaw<BetaFileImageSource>
{
    public required string FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("file_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'file_id' cannot be null",
                    new System::ArgumentOutOfRangeException("file_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'file_id' cannot be null",
                    new System::ArgumentNullException("file_id")
                );
        }
        set
        {
            this.Properties["file_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FileID;
        _ = this.Type;
    }

    public BetaFileImageSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"file\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFileImageSource(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaFileImageSource FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaFileImageSource(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}
