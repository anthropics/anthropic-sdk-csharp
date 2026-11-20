using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ComplianceSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ComplianceSettings;

public class ComplianceSettingUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ComplianceSettingUpdateParams
        {
            State = new BetaComplianceSettingsStateEnabledParam(),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        BetaComplianceSettingsStateParam expectedState =
            new BetaComplianceSettingsStateEnabledParam();
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedState, parameters.State);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ComplianceSettingUpdateParams
        {
            State = new BetaComplianceSettingsStateEnabledParam(),
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ComplianceSettingUpdateParams
        {
            State = new BetaComplianceSettingsStateEnabledParam(),

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new ComplianceSettingUpdateParams
        {
            State = new BetaComplianceSettingsStateEnabledParam(),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        ComplianceSettingUpdateParams parameters = new()
        {
            State = new BetaComplianceSettingsStateEnabledParam(),
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/compliance_settings"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ComplianceSettingUpdateParams parameters = new()
        {
            State = new BetaComplianceSettingsStateEnabledParam(),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ComplianceSettingUpdateParams
        {
            State = new BetaComplianceSettingsStateEnabledParam(),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        ComplianceSettingUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
