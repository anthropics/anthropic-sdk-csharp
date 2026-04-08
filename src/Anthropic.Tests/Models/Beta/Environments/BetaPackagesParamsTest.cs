using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class BetaPackagesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPackagesParams
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = BetaPackagesParamsType.Packages,
        };

        List<string> expectedApt = ["string"];
        List<string> expectedCargo = ["string"];
        List<string> expectedGem = ["string"];
        List<string> expectedGo = ["string"];
        List<string> expectedNpm = ["string"];
        List<string> expectedPip = ["string"];
        ApiEnum<string, BetaPackagesParamsType> expectedType = BetaPackagesParamsType.Packages;

        Assert.NotNull(model.Apt);
        Assert.Equal(expectedApt.Count, model.Apt.Count);
        for (int i = 0; i < expectedApt.Count; i++)
        {
            Assert.Equal(expectedApt[i], model.Apt[i]);
        }
        Assert.NotNull(model.Cargo);
        Assert.Equal(expectedCargo.Count, model.Cargo.Count);
        for (int i = 0; i < expectedCargo.Count; i++)
        {
            Assert.Equal(expectedCargo[i], model.Cargo[i]);
        }
        Assert.NotNull(model.Gem);
        Assert.Equal(expectedGem.Count, model.Gem.Count);
        for (int i = 0; i < expectedGem.Count; i++)
        {
            Assert.Equal(expectedGem[i], model.Gem[i]);
        }
        Assert.NotNull(model.Go);
        Assert.Equal(expectedGo.Count, model.Go.Count);
        for (int i = 0; i < expectedGo.Count; i++)
        {
            Assert.Equal(expectedGo[i], model.Go[i]);
        }
        Assert.NotNull(model.Npm);
        Assert.Equal(expectedNpm.Count, model.Npm.Count);
        for (int i = 0; i < expectedNpm.Count; i++)
        {
            Assert.Equal(expectedNpm[i], model.Npm[i]);
        }
        Assert.NotNull(model.Pip);
        Assert.Equal(expectedPip.Count, model.Pip.Count);
        for (int i = 0; i < expectedPip.Count; i++)
        {
            Assert.Equal(expectedPip[i], model.Pip[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPackagesParams
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = BetaPackagesParamsType.Packages,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPackagesParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPackagesParams
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = BetaPackagesParamsType.Packages,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPackagesParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedApt = ["string"];
        List<string> expectedCargo = ["string"];
        List<string> expectedGem = ["string"];
        List<string> expectedGo = ["string"];
        List<string> expectedNpm = ["string"];
        List<string> expectedPip = ["string"];
        ApiEnum<string, BetaPackagesParamsType> expectedType = BetaPackagesParamsType.Packages;

        Assert.NotNull(deserialized.Apt);
        Assert.Equal(expectedApt.Count, deserialized.Apt.Count);
        for (int i = 0; i < expectedApt.Count; i++)
        {
            Assert.Equal(expectedApt[i], deserialized.Apt[i]);
        }
        Assert.NotNull(deserialized.Cargo);
        Assert.Equal(expectedCargo.Count, deserialized.Cargo.Count);
        for (int i = 0; i < expectedCargo.Count; i++)
        {
            Assert.Equal(expectedCargo[i], deserialized.Cargo[i]);
        }
        Assert.NotNull(deserialized.Gem);
        Assert.Equal(expectedGem.Count, deserialized.Gem.Count);
        for (int i = 0; i < expectedGem.Count; i++)
        {
            Assert.Equal(expectedGem[i], deserialized.Gem[i]);
        }
        Assert.NotNull(deserialized.Go);
        Assert.Equal(expectedGo.Count, deserialized.Go.Count);
        for (int i = 0; i < expectedGo.Count; i++)
        {
            Assert.Equal(expectedGo[i], deserialized.Go[i]);
        }
        Assert.NotNull(deserialized.Npm);
        Assert.Equal(expectedNpm.Count, deserialized.Npm.Count);
        for (int i = 0; i < expectedNpm.Count; i++)
        {
            Assert.Equal(expectedNpm[i], deserialized.Npm[i]);
        }
        Assert.NotNull(deserialized.Pip);
        Assert.Equal(expectedPip.Count, deserialized.Pip.Count);
        for (int i = 0; i < expectedPip.Count; i++)
        {
            Assert.Equal(expectedPip[i], deserialized.Pip[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPackagesParams
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = BetaPackagesParamsType.Packages,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaPackagesParams
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaPackagesParams
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaPackagesParams
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaPackagesParams
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaPackagesParams { Type = BetaPackagesParamsType.Packages };

        Assert.Null(model.Apt);
        Assert.False(model.RawData.ContainsKey("apt"));
        Assert.Null(model.Cargo);
        Assert.False(model.RawData.ContainsKey("cargo"));
        Assert.Null(model.Gem);
        Assert.False(model.RawData.ContainsKey("gem"));
        Assert.Null(model.Go);
        Assert.False(model.RawData.ContainsKey("go"));
        Assert.Null(model.Npm);
        Assert.False(model.RawData.ContainsKey("npm"));
        Assert.Null(model.Pip);
        Assert.False(model.RawData.ContainsKey("pip"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaPackagesParams { Type = BetaPackagesParamsType.Packages };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaPackagesParams
        {
            Type = BetaPackagesParamsType.Packages,

            Apt = null,
            Cargo = null,
            Gem = null,
            Go = null,
            Npm = null,
            Pip = null,
        };

        Assert.Null(model.Apt);
        Assert.True(model.RawData.ContainsKey("apt"));
        Assert.Null(model.Cargo);
        Assert.True(model.RawData.ContainsKey("cargo"));
        Assert.Null(model.Gem);
        Assert.True(model.RawData.ContainsKey("gem"));
        Assert.Null(model.Go);
        Assert.True(model.RawData.ContainsKey("go"));
        Assert.Null(model.Npm);
        Assert.True(model.RawData.ContainsKey("npm"));
        Assert.Null(model.Pip);
        Assert.True(model.RawData.ContainsKey("pip"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaPackagesParams
        {
            Type = BetaPackagesParamsType.Packages,

            Apt = null,
            Cargo = null,
            Gem = null,
            Go = null,
            Npm = null,
            Pip = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPackagesParams
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = BetaPackagesParamsType.Packages,
        };

        BetaPackagesParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaPackagesParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaPackagesParamsType.Packages)]
    public void Validation_Works(BetaPackagesParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaPackagesParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaPackagesParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaPackagesParamsType.Packages)]
    public void SerializationRoundtrip_Works(BetaPackagesParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaPackagesParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaPackagesParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaPackagesParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaPackagesParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
