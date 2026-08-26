using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaDataResidencyUpdateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDataResidencyUpdateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        BetaDataResidencyUpdateConfigAllowedInferenceGeos expectedAllowedInferenceGeos =
            new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        ApiEnum<
            string,
            BetaDataResidencyUpdateConfigDefaultInferenceGeo
        > expectedDefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global;

        Assert.Equal(expectedAllowedInferenceGeos, model.AllowedInferenceGeos);
        Assert.Equal(expectedDefaultInferenceGeo, model.DefaultInferenceGeo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDataResidencyUpdateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDataResidencyUpdateConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDataResidencyUpdateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDataResidencyUpdateConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaDataResidencyUpdateConfigAllowedInferenceGeos expectedAllowedInferenceGeos =
            new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        ApiEnum<
            string,
            BetaDataResidencyUpdateConfigDefaultInferenceGeo
        > expectedDefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global;

        Assert.Equal(expectedAllowedInferenceGeos, deserialized.AllowedInferenceGeos);
        Assert.Equal(expectedDefaultInferenceGeo, deserialized.DefaultInferenceGeo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDataResidencyUpdateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaDataResidencyUpdateConfig { };

        Assert.Null(model.AllowedInferenceGeos);
        Assert.False(model.RawData.ContainsKey("allowed_inference_geos"));
        Assert.Null(model.DefaultInferenceGeo);
        Assert.False(model.RawData.ContainsKey("default_inference_geo"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaDataResidencyUpdateConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaDataResidencyUpdateConfig
        {
            AllowedInferenceGeos = null,
            DefaultInferenceGeo = null,
        };

        Assert.Null(model.AllowedInferenceGeos);
        Assert.True(model.RawData.ContainsKey("allowed_inference_geos"));
        Assert.Null(model.DefaultInferenceGeo);
        Assert.True(model.RawData.ContainsKey("default_inference_geo"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaDataResidencyUpdateConfig
        {
            AllowedInferenceGeos = null,
            DefaultInferenceGeo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDataResidencyUpdateConfig
        {
            AllowedInferenceGeos =
                new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        BetaDataResidencyUpdateConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaDataResidencyUpdateConfigAllowedInferenceGeosTest : TestBase
{
    [Fact]
    public void GeosValidationWorks()
    {
        BetaDataResidencyUpdateConfigAllowedInferenceGeos value = new(
            [BetaAllowedInferenceGeo.Global]
        );
        value.Validate();
    }

    [Fact]
    public void UnrestrictedValidationWorks()
    {
        BetaDataResidencyUpdateConfigAllowedInferenceGeos value =
            new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        value.Validate();
    }

    [Fact]
    public void GeosSerializationRoundtripWorks()
    {
        BetaDataResidencyUpdateConfigAllowedInferenceGeos value = new(
            [BetaAllowedInferenceGeo.Global]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyUpdateConfigAllowedInferenceGeos>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnrestrictedSerializationRoundtripWorks()
    {
        BetaDataResidencyUpdateConfigAllowedInferenceGeos value =
            new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyUpdateConfigAllowedInferenceGeos>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestrictedTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant =
            JsonSerializer.Deserialize<BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("unrestricted"),
                ModelBase.SerializerOptions
            );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant =
            JsonSerializer.Deserialize<BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );

        Assert.NotNull(constant);
        Assert.Throws<AnthropicInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("unrestricted"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaDataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }
}

public class BetaDataResidencyUpdateConfigDefaultInferenceGeoTest : TestBase
{
    [Theory]
    [InlineData(BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global)]
    [InlineData(BetaDataResidencyUpdateConfigDefaultInferenceGeo.Us)]
    public void Validation_Works(BetaDataResidencyUpdateConfigDefaultInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDataResidencyUpdateConfigDefaultInferenceGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyUpdateConfigDefaultInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDataResidencyUpdateConfigDefaultInferenceGeo.Global)]
    [InlineData(BetaDataResidencyUpdateConfigDefaultInferenceGeo.Us)]
    public void SerializationRoundtrip_Works(
        BetaDataResidencyUpdateConfigDefaultInferenceGeo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDataResidencyUpdateConfigDefaultInferenceGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyUpdateConfigDefaultInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyUpdateConfigDefaultInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDataResidencyUpdateConfigDefaultInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
