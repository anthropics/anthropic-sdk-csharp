using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DeletedFileProperties = Anthropic.Beta.Client.Models.Beta.Files.DeletedFileProperties;

namespace Anthropic.Beta.Client.Models.Beta.Files;

[JsonConverter(typeof(ModelConverter<DeletedFile>))]
public sealed record class DeletedFile : ModelBase, IFromRaw<DeletedFile>
{
    /// <summary>
    /// ID of the deleted file.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Deleted object type.
    ///
    /// For file deletion, this is always `"file_deleted"`.
    /// </summary>
    public ApiEnum<string, DeletedFileProperties::Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, DeletedFileProperties::Type>?>(
                element,
                ModelBase.SerializerOptions
            );
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
        _ = this.ID;
        this.Type?.Validate();
    }

    public DeletedFile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedFile(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DeletedFile FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public DeletedFile(string id)
        : this()
    {
        this.ID = id;
    }
}
