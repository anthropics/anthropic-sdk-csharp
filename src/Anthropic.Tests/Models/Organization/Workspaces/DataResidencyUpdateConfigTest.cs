using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Models.Organization.Workspaces;

public class DataResidencyUpdateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataResidencyUpdateConfig
        {
            AllowedInferenceGeos = new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        DataResidencyUpdateConfigAllowedInferenceGeos expectedAllowedInferenceGeos =
            new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        ApiEnum<string, DataResidencyUpdateConfigDefaultInferenceGeo> expectedDefaultInferenceGeo =
            DataResidencyUpdateConfigDefaultInferenceGeo.Global;

        Assert.Equal(expectedAllowedInferenceGeos, model.AllowedInferenceGeos);
        Assert.Equal(expectedDefaultInferenceGeo, model.DefaultInferenceGeo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataResidencyUpdateConfig
        {
            AllowedInferenceGeos = new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataResidencyUpdateConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataResidencyUpdateConfig
        {
            AllowedInferenceGeos = new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataResidencyUpdateConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DataResidencyUpdateConfigAllowedInferenceGeos expectedAllowedInferenceGeos =
            new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        ApiEnum<string, DataResidencyUpdateConfigDefaultInferenceGeo> expectedDefaultInferenceGeo =
            DataResidencyUpdateConfigDefaultInferenceGeo.Global;

        Assert.Equal(expectedAllowedInferenceGeos, deserialized.AllowedInferenceGeos);
        Assert.Equal(expectedDefaultInferenceGeo, deserialized.DefaultInferenceGeo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataResidencyUpdateConfig
        {
            AllowedInferenceGeos = new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataResidencyUpdateConfig { };

        Assert.Null(model.AllowedInferenceGeos);
        Assert.False(model.RawData.ContainsKey("allowed_inference_geos"));
        Assert.Null(model.DefaultInferenceGeo);
        Assert.False(model.RawData.ContainsKey("default_inference_geo"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataResidencyUpdateConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataResidencyUpdateConfig
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
        var model = new DataResidencyUpdateConfig
        {
            AllowedInferenceGeos = null,
            DefaultInferenceGeo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataResidencyUpdateConfig
        {
            AllowedInferenceGeos = new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted(),
            DefaultInferenceGeo = DataResidencyUpdateConfigDefaultInferenceGeo.Global,
        };

        DataResidencyUpdateConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataResidencyUpdateConfigAllowedInferenceGeosTest : TestBase
{
    [Fact]
    public void GeosValidationWorks()
    {
        DataResidencyUpdateConfigAllowedInferenceGeos value = new([AllowedInferenceGeo.Global]);
        value.Validate();
    }

    [Fact]
    public void UnrestrictedValidationWorks()
    {
        DataResidencyUpdateConfigAllowedInferenceGeos value =
            new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        value.Validate();
    }

    [Fact]
    public void GeosSerializationRoundtripWorks()
    {
        DataResidencyUpdateConfigAllowedInferenceGeos value = new([AllowedInferenceGeo.Global]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyUpdateConfigAllowedInferenceGeos>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnrestrictedSerializationRoundtripWorks()
    {
        DataResidencyUpdateConfigAllowedInferenceGeos value =
            new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyUpdateConfigAllowedInferenceGeos>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class DataResidencyUpdateConfigAllowedInferenceGeosUnrestrictedTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant =
            JsonSerializer.Deserialize<DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
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
            JsonSerializer.Deserialize<DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );

        Assert.NotNull(constant);
        Assert.Throws<AnthropicInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("unrestricted"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant =
            JsonSerializer.Deserialize<DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                JsonSerializer.SerializeToElement("invalid value"),
                ModelBase.SerializerOptions
            );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DataResidencyUpdateConfigAllowedInferenceGeosUnrestricted>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(constant, deserialized);
    }
}

public class DataResidencyUpdateConfigDefaultInferenceGeoTest : TestBase
{
    [Theory]
    [InlineData(DataResidencyUpdateConfigDefaultInferenceGeo.Global)]
    [InlineData(DataResidencyUpdateConfigDefaultInferenceGeo.Us)]
    public void Validation_Works(DataResidencyUpdateConfigDefaultInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataResidencyUpdateConfigDefaultInferenceGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyUpdateConfigDefaultInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataResidencyUpdateConfigDefaultInferenceGeo.Global)]
    [InlineData(DataResidencyUpdateConfigDefaultInferenceGeo.Us)]
    public void SerializationRoundtrip_Works(DataResidencyUpdateConfigDefaultInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataResidencyUpdateConfigDefaultInferenceGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyUpdateConfigDefaultInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyUpdateConfigDefaultInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataResidencyUpdateConfigDefaultInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
