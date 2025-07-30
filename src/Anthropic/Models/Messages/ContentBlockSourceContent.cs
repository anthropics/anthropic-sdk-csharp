using System.Text.Json.Serialization;
using ContentBlockSourceContentVariants = Anthropic.Models.Messages.ContentBlockSourceContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(UnionConverter<ContentBlockSourceContent>))]
public abstract record class ContentBlockSourceContent
{
    internal ContentBlockSourceContent() { }

    public static implicit operator ContentBlockSourceContent(TextBlockParam value) =>
        new ContentBlockSourceContentVariants::TextBlockParamVariant(value);

    public static implicit operator ContentBlockSourceContent(ImageBlockParam value) =>
        new ContentBlockSourceContentVariants::ImageBlockParamVariant(value);

    public abstract void Validate();
}
