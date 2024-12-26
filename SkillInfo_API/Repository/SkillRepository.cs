using Microsoft.EntityFrameworkCore;
using SkillInfo_API.DBConnection;
using SkillInfo_API.Entity;
using SkillInfo_API.Interfaces;

namespace SkillInfo_API.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(string refSourceId)
        {
            return await _context.Skills.FindAsync(refSourceId);
        }

        public async Task AddSkillAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSkillAsync(Skill skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSkillAsync(string refSourceId)
        {
            var skill = await GetSkillByIdAsync(refSourceId);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
            }
        }
    }
}
