using SkillInfo_API.Entity;

namespace SkillInfo_API.Interfaces
{
    public interface ISkillInfoRepository
    {
        Task<bool> AddSkillAsync(List<Skill> skills);
    }
}
