using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillInfo_API.Entity;
using SkillInfo_API.Interfaces;

namespace SkillInfo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetAllSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [HttpGet("{refSourceId}")]
        public async Task<ActionResult<Skill>> GetSkill(string refSourceId)
        {
            var skill = await _skillService.GetSkillByIdAsync(refSourceId);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        [HttpPost]
        public async Task<ActionResult> AddSkill(Skill skill)
        {
            await _skillService.AddSkillAsync(skill);
            return CreatedAtAction(nameof(GetSkill), new { refSourceId = skill.RefSourceId }, skill);
        }

        [HttpPut("{refSourceId}")]
        public async Task<ActionResult> UpdateSkill(string refSourceId, Skill skill)
        {
            if (refSourceId != skill.RefSourceId)
            {
                return BadRequest();
            }

            await _skillService.UpdateSkillAsync(skill);
            return NoContent();
        }

        [HttpDelete("{refSourceId}")]
        public async Task<ActionResult> DeleteSkill(string refSourceId)
        {
            await _skillService.DeleteSkillAsync(refSourceId);
            return NoContent();
        }
    }
}
