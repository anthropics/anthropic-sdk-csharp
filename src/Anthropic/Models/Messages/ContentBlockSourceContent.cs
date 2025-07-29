using Anthropic = Anthropic;
using ContentBlockSourceContentVariants = Anthropic.Models.Messages.ContentBlockSourceContentVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ContentBlockSourceContent>))]
public abstract record class ContentBlockSourceContent
{
    internal ContentBlockSourceContent() { }

    public static implicit operator ContentBlockSourceContent(TextBlockParam value) =>
        new ContentBlockSourceContentVariants::TextBlockParam(value);

    public static implicit operator ContentBlockSourceContent(ImageBlockParam value) =>
        new ContentBlockSourceContentVariants::ImageBlockParam(value);

    public abstract void Validate();
}
