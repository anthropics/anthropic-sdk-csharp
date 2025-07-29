using Anthropic = Anthropic;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;
using SourceVariants = Anthropic.Models.Beta.Messages.BetaImageBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Beta.Messages.BetaImageBlockParamProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Source>))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Messages::BetaBase64ImageSource value) =>
        new SourceVariants::BetaBase64ImageSource(value);

    public static implicit operator Source(Messages::BetaURLImageSource value) =>
        new SourceVariants::BetaURLImageSource(value);

    public static implicit operator Source(Messages::BetaFileImageSource value) =>
        new SourceVariants::BetaFileImageSource(value);

    public abstract void Validate();
}
