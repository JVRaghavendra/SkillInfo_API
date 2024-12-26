﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillInfo_API.Interfaces;
using SkillInfo_API.Model;

namespace SkillInfo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillInfoController : ControllerBase
    {
        private readonly ISkillInfoService _skillInfoService;

        public SkillInfoController(ISkillInfoService skillInfoService)
        {
            _skillInfoService = skillInfoService;
            
        }

        [HttpPost]
        [Route("AddSkillAsync")]
        public IActionResult Post([FromBody] SkillModel skillModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                var skills = _skillInfoService.AddSkillAsync(new List<SkillModel> { skillModel });

                return StatusCode(StatusCodes.Status201Created, "skill Details Added Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}