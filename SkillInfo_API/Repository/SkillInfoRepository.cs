using SkillInfo_API.DBConnection;
using SkillInfo_API.Entity;
using SkillInfo_API.Interfaces;

namespace SkillInfo_API.Repository
{
    public class SkillInfoRepository : ISkillInfoRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillInfoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddSkillAsync(List<Skill> skills)
        {
            try
            {
                _context.Skills.AddRangeAsync(skills);
                _context.SaveChanges();
                return true;

            }

            catch (Exception ex)
            {
                return false;
            
            }




        }
    }
}
