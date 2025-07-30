using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaToolChoiceVariants;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
[JsonConverter(typeof(VariantConverter<BetaToolChoiceAutoVariant, BetaToolChoiceAuto>))]
public sealed record class BetaToolChoiceAutoVariant(BetaToolChoiceAuto Value)
    : BetaToolChoice,
        IVariant<BetaToolChoiceAutoVariant, BetaToolChoiceAuto>
{
    public static BetaToolChoiceAutoVariant From(BetaToolChoiceAuto value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// The model will use any available tools.
/// </summary>
[JsonConverter(typeof(VariantConverter<BetaToolChoiceAnyVariant, BetaToolChoiceAny>))]
public sealed record class BetaToolChoiceAnyVariant(BetaToolChoiceAny Value)
    : BetaToolChoice,
        IVariant<BetaToolChoiceAnyVariant, BetaToolChoiceAny>
{
    public static BetaToolChoiceAnyVariant From(BetaToolChoiceAny value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// The model will use the specified tool with `tool_choice.name`.
/// </summary>
[JsonConverter(typeof(VariantConverter<BetaToolChoiceToolVariant, BetaToolChoiceTool>))]
public sealed record class BetaToolChoiceToolVariant(BetaToolChoiceTool Value)
    : BetaToolChoice,
        IVariant<BetaToolChoiceToolVariant, BetaToolChoiceTool>
{
    public static BetaToolChoiceToolVariant From(BetaToolChoiceTool value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// The model will not be allowed to use tools.
/// </summary>
[JsonConverter(typeof(VariantConverter<BetaToolChoiceNoneVariant, BetaToolChoiceNone>))]
public sealed record class BetaToolChoiceNoneVariant(BetaToolChoiceNone Value)
    : BetaToolChoice,
        IVariant<BetaToolChoiceNoneVariant, BetaToolChoiceNone>
{
    public static BetaToolChoiceNoneVariant From(BetaToolChoiceNone value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
