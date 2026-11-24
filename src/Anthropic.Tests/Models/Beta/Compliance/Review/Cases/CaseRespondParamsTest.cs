using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class CaseRespondParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CaseRespondParams
        {
            CaseID = "case_id",
            Determination = BetaComplianceReviewDetermination.NoViolation,
            PolicyCategories = [BetaComplianceReviewViolatedPolicyCategory.Cyber],
            Verdicts =
            [
                new()
                {
                    Determination = BetaComplianceReviewDetermination.Violation,
                    ItemID = "item_id",
                    PolicyCategory = BetaComplianceReviewViolatedPolicyCategory.Cyber,
                },
            ],
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedCaseID = "case_id";
        ApiEnum<string, BetaComplianceReviewDetermination> expectedDetermination =
            BetaComplianceReviewDetermination.NoViolation;
        List<
            ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>
        > expectedPolicyCategories = [BetaComplianceReviewViolatedPolicyCategory.Cyber];
        List<BetaComplianceReviewVerdictParam> expectedVerdicts =
        [
            new()
            {
                Determination = BetaComplianceReviewDetermination.Violation,
                ItemID = "item_id",
                PolicyCategory = BetaComplianceReviewViolatedPolicyCategory.Cyber,
            },
        ];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedCaseID, parameters.CaseID);
        Assert.Equal(expectedDetermination, parameters.Determination);
        Assert.NotNull(parameters.PolicyCategories);
        Assert.Equal(expectedPolicyCategories.Count, parameters.PolicyCategories.Count);
        for (int i = 0; i < expectedPolicyCategories.Count; i++)
        {
            Assert.Equal(expectedPolicyCategories[i], parameters.PolicyCategories[i]);
        }
        Assert.NotNull(parameters.Verdicts);
        Assert.Equal(expectedVerdicts.Count, parameters.Verdicts.Count);
        for (int i = 0; i < expectedVerdicts.Count; i++)
        {
            Assert.Equal(expectedVerdicts[i], parameters.Verdicts[i]);
        }
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
        var parameters = new CaseRespondParams
        {
            CaseID = "case_id",
            Determination = BetaComplianceReviewDetermination.NoViolation,
        };

        Assert.Null(parameters.PolicyCategories);
        Assert.False(parameters.RawBodyData.ContainsKey("policy_categories"));
        Assert.Null(parameters.Verdicts);
        Assert.False(parameters.RawBodyData.ContainsKey("verdicts"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CaseRespondParams
        {
            CaseID = "case_id",
            Determination = BetaComplianceReviewDetermination.NoViolation,

            // Null should be interpreted as omitted for these properties
            PolicyCategories = null,
            Verdicts = null,
            Betas = null,
        };

        Assert.Null(parameters.PolicyCategories);
        Assert.False(parameters.RawBodyData.ContainsKey("policy_categories"));
        Assert.Null(parameters.Verdicts);
        Assert.False(parameters.RawBodyData.ContainsKey("verdicts"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new CaseRespondParams
        {
            CaseID = "case_id",
            Determination = BetaComplianceReviewDetermination.NoViolation,
            PolicyCategories = [BetaComplianceReviewViolatedPolicyCategory.Cyber],
            Verdicts =
            [
                new()
                {
                    Determination = BetaComplianceReviewDetermination.Violation,
                    ItemID = "item_id",
                    PolicyCategory = BetaComplianceReviewViolatedPolicyCategory.Cyber,
                },
            ],
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            PolicyCategories = null,
            Verdicts = null,
            Betas = null,
        };

        Assert.Null(parameters.PolicyCategories);
        Assert.False(parameters.RawBodyData.ContainsKey("policy_categories"));
        Assert.Null(parameters.Verdicts);
        Assert.False(parameters.RawBodyData.ContainsKey("verdicts"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        CaseRespondParams parameters = new()
        {
            CaseID = "case_id",
            Determination = BetaComplianceReviewDetermination.NoViolation,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/compliance/review/cases/case_id/respond"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CaseRespondParams parameters = new()
        {
            CaseID = "case_id",
            Determination = BetaComplianceReviewDetermination.NoViolation,
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
        var parameters = new CaseRespondParams
        {
            CaseID = "case_id",
            Determination = BetaComplianceReviewDetermination.NoViolation,
            PolicyCategories = [BetaComplianceReviewViolatedPolicyCategory.Cyber],
            Verdicts =
            [
                new()
                {
                    Determination = BetaComplianceReviewDetermination.Violation,
                    ItemID = "item_id",
                    PolicyCategory = BetaComplianceReviewViolatedPolicyCategory.Cyber,
                },
            ],
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        CaseRespondParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
