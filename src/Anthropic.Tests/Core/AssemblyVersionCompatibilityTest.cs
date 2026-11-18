using System;
using System.Reflection;
using Anthropic.Core;

namespace Anthropic.Tests.Core;

public class AssemblyVersionCompatibilityTest
{
    static readonly AssemblyName Tests =
        typeof(AssemblyVersionCompatibilityTest).Assembly.GetName();
    static readonly AssemblyName Sdk = typeof(AssemblyVersionCompatibility).Assembly.GetName();

    static AssemblyName SdkWithVersion(int major, int minor) =>
        new(Sdk.Name!) { Version = new Version(major, minor, 0, 0) };

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ReferenceToSameMajorVersionIsCompatible(int minorDifference)
    {
        var running = SdkWithVersion(Sdk.Version!.Major, Sdk.Version.Minor + minorDifference);

        var incompatible = AssemblyVersionCompatibility.FindIncompatibleReferences(Tests, running);

        Assert.Empty(incompatible);
    }

    [Fact]
    public void ReferenceToDifferentMajorVersionIsIncompatible()
    {
        var running = SdkWithVersion(Sdk.Version!.Major + 1, 0);

        var incompatible = AssemblyVersionCompatibility.FindIncompatibleReferences(Tests, running);

        Assert.Contains(
            incompatible,
            found => found.Assembly.Name == Tests.Name && found.Reference.Version == Sdk.Version
        );
    }

    [Fact]
    public void ReferenceOfReferencedAssemblyIsChecked()
    {
        var running = new AssemblyName("System.Text.Json") { Version = new Version(0, 0, 0, 0) };

        var incompatible = AssemblyVersionCompatibility.FindIncompatibleReferences(Tests, running);

        Assert.Contains(incompatible, found => found.Assembly.Name == Sdk.Name);
    }
}
