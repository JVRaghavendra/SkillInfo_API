using SkillInfo_API.Entity;
using SkillInfo_API.Interfaces;

namespace SkillInfo_API.Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return _skillRepository.GetAllSkillsAsync();
        }

        public Task<Skill> GetSkillByIdAsync(string refSourceId)
        {
            return _skillRepository.GetSkillByIdAsync(refSourceId);
        }

        public Task AddSkillAsync(Skill skill)
        {
            return _skillRepository.AddSkillAsync(skill);
        }

        public Task UpdateSkillAsync(Skill skill)
        {
            return _skillRepository.UpdateSkillAsync(skill);
        }

        public Task DeleteSkillAsync(string refSourceId)
        {
            return _skillRepository.DeleteSkillAsync(refSourceId);
        }
    }
}
