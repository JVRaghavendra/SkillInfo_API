using SkillInfo_API.Entity;
using SkillInfo_API.Model;

namespace SkillInfo_API.Interfaces
{
    public interface ISkillInfoService
    {
        Task<bool> AddSkillAsync(List<SkillModel> skillModels);
    }
}
