using SkillInfo_API.Entity;
using SkillInfo_API.Interfaces;
using SkillInfo_API.Model;

namespace SkillInfo_API.Service
{
    public class SkillInfoService : ISkillInfoService
    {
        private readonly ISkillInfoRepository _skillInfoRepository;

        public SkillInfoService(ISkillInfoRepository skillInfoRepository)
        {
            _skillInfoRepository = skillInfoRepository;
        }

        public async Task<bool> AddSkillAsync(List<SkillModel> skillModels)
        {
            //try
            //{
                var models = new List<Skill>();
                var result = false;

                foreach (var model in skillModels)
                {
                    var entity = new Skill();

                    {
                        entity.RefSourceId = model.RefSourceId;
                        entity.SourceId = model.SourceId;
                        entity.SkillID = model.SkillID;

                        models.Add(entity);

                    }

                    // After the loop, call AddSkillInfo once

                    result = await _skillInfoRepository.AddSkillAsync(models);


                }

                return result; // Return the result after adding all models
            //}

            //catch (Exception ex)
            //{
            //    return false; 
            //}

        }
     }
}
