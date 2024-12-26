using SkillInfo_API.Entity;

namespace SkillInfo_API.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSkillByIdAsync(string refSourceId);
        Task AddSkillAsync(Skill skill);
        Task UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(string refSourceId);
    }
}
