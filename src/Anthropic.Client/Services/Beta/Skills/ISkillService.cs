using System;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Skills;
using Anthropic.Client.Services.Beta.Skills.Versions;

namespace Anthropic.Client.Services.Beta.Skills;

public interface ISkillService
{
    ISkillService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVersionService Versions { get; }

    /// <summary>
    /// Create Skill
    /// </summary>
    Task<SkillCreateResponse> Create(SkillCreateParams? parameters = null);

    /// <summary>
    /// Get Skill
    /// </summary>
    Task<SkillRetrieveResponse> Retrieve(SkillRetrieveParams parameters);

    /// <summary>
    /// List Skills
    /// </summary>
    Task<SkillListPageResponse> List(SkillListParams? parameters = null);

    /// <summary>
    /// Delete Skill
    /// </summary>
    Task<SkillDeleteResponse> Delete(SkillDeleteParams parameters);
}
