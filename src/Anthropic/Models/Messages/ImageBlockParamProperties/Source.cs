using Anthropic = Anthropic;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;
using SourceVariants = Anthropic.Models.Messages.ImageBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Messages.ImageBlockParamProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Source>))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Messages::Base64ImageSource value) =>
        new SourceVariants::Base64ImageSource(value);

    public static implicit operator Source(Messages::URLImageSource value) =>
        new SourceVariants::URLImageSource(value);

    public abstract void Validate();
}
