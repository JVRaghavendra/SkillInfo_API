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
            //try
            //{
            //   await _context.Skills.AddRangeAsync(skills);
            //    var result = await _context.SaveChangesAsync();

            //    if (result > 0)
            //    {

            //        return true;


            //    }

            //    else
            //    {
            //        return false;
            //    }  
            //}

            //catch (Exception ex)
            //{
            //    return false;

            //}


            try
            {
                // Filter out invalid skills based on conditions

                var validSkills = skills.Where(skill =>
                    !string.IsNullOrEmpty(skill.SkillID) &&                // SkillID is not null or empty
                    skill.SkillID.StartsWith("800") &&                    // SkillID starts with "800"
                    skill.SkillID.All(char.IsDigit) &&                    // SkillID is numeric only
                    skill.SkillID != "80010101"                           // SkillID is not "80010101"
                ).ToList();

                // Check if there are any valid skills to add

                if (!validSkills.Any())
                {
                    return false; // No valid skills to add
                }

                //else
                //{
                //    return false;
                //}

                // Add valid skills to the database

                await _context.Skills.AddRangeAsync(validSkills);

                var result = await _context.SaveChangesAsync();

                return result > 0; // Return true if records were added successfully
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is implemented)
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }



        }
    }
}


// Ex: sample data inserted in database about skill project
//{ SkillID = "80012345", RefSourceId = "Ref1", SourceId = "Source1" }, // insert record successfully
//{ SkillID = "70012345", RefSourceId = "Ref2", SourceId = "Source2" }, // Invalid (doesn't start with "800")
//{ SkillID = "800ABC45", RefSourceId = "Ref3", SourceId = "Source3" }, // Invalid (contains alphanumeric)
//{ SkillID = "80010101", RefSourceId = "Ref4", SourceId = "Source4" }  // Invalid (equals "80010101")
// Only the first record ("80012345") will be added to the database. The others will be filtered out.

//Explanation of Changes
//1) Validation Conditions:

//!string.IsNullOrEmpty(skill.SkillID):
//Ensures SkillID is not null or empty.

//skill.SkillID.StartsWith("800"):
//Ensures SkillID starts with "800".

//skill.SkillID.All(char.IsDigit):
//Ensures SkillID contains only numeric characters (no alphanumeric values).

//skill.SkillID != "80010101":
//Ensures SkillID is not "80010101".

//2) Filtering Invalid Records:
//Used Where LINQ method to filter out skills that do not satisfy the conditions.
//Only valid skills are added to the database.

//3) Check for Valid Skills:
//Before adding skills to the database, the method checks if there are any valid skills using validSkills.Any().

//4) Error Handling:
//The try-catch block handles exceptions that may occur during the database operation.

//5) Return Value:
//Returns true if valid skills were successfully added to the database.
//Returns false if no valid skills exist or an exception occurred.