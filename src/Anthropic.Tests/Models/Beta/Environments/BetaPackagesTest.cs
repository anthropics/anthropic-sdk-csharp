using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class BetaPackagesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPackages
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = Type.Packages,
        };

        List<string> expectedApt = ["string"];
        List<string> expectedCargo = ["string"];
        List<string> expectedGem = ["string"];
        List<string> expectedGo = ["string"];
        List<string> expectedNpm = ["string"];
        List<string> expectedPip = ["string"];
        ApiEnum<string, Type> expectedType = Type.Packages;

        Assert.Equal(expectedApt.Count, model.Apt.Count);
        for (int i = 0; i < expectedApt.Count; i++)
        {
            Assert.Equal(expectedApt[i], model.Apt[i]);
        }
        Assert.Equal(expectedCargo.Count, model.Cargo.Count);
        for (int i = 0; i < expectedCargo.Count; i++)
        {
            Assert.Equal(expectedCargo[i], model.Cargo[i]);
        }
        Assert.Equal(expectedGem.Count, model.Gem.Count);
        for (int i = 0; i < expectedGem.Count; i++)
        {
            Assert.Equal(expectedGem[i], model.Gem[i]);
        }
        Assert.Equal(expectedGo.Count, model.Go.Count);
        for (int i = 0; i < expectedGo.Count; i++)
        {
            Assert.Equal(expectedGo[i], model.Go[i]);
        }
        Assert.Equal(expectedNpm.Count, model.Npm.Count);
        for (int i = 0; i < expectedNpm.Count; i++)
        {
            Assert.Equal(expectedNpm[i], model.Npm[i]);
        }
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
        var model = new BetaPackages
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = Type.Packages,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPackages>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPackages
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = Type.Packages,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPackages>(
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
        ApiEnum<string, Type> expectedType = Type.Packages;

        Assert.Equal(expectedApt.Count, deserialized.Apt.Count);
        for (int i = 0; i < expectedApt.Count; i++)
        {
            Assert.Equal(expectedApt[i], deserialized.Apt[i]);
        }
        Assert.Equal(expectedCargo.Count, deserialized.Cargo.Count);
        for (int i = 0; i < expectedCargo.Count; i++)
        {
            Assert.Equal(expectedCargo[i], deserialized.Cargo[i]);
        }
        Assert.Equal(expectedGem.Count, deserialized.Gem.Count);
        for (int i = 0; i < expectedGem.Count; i++)
        {
            Assert.Equal(expectedGem[i], deserialized.Gem[i]);
        }
        Assert.Equal(expectedGo.Count, deserialized.Go.Count);
        for (int i = 0; i < expectedGo.Count; i++)
        {
            Assert.Equal(expectedGo[i], deserialized.Go[i]);
        }
        Assert.Equal(expectedNpm.Count, deserialized.Npm.Count);
        for (int i = 0; i < expectedNpm.Count; i++)
        {
            Assert.Equal(expectedNpm[i], deserialized.Npm[i]);
        }
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
        var model = new BetaPackages
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = Type.Packages,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaPackages
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
        var model = new BetaPackages
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
        var model = new BetaPackages
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
        var model = new BetaPackages
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
    public void CopyConstructor_Works()
    {
        var model = new BetaPackages
        {
            Apt = ["string"],
            Cargo = ["string"],
            Gem = ["string"],
            Go = ["string"],
            Npm = ["string"],
            Pip = ["string"],
            Type = Type.Packages,
        };

        BetaPackages copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Packages)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Packages)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
