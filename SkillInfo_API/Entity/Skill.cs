using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkillInfo_API.Entity
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        [MaxLength(int.MaxValue)]
        public string RefSourceId { get; set; }

        [MaxLength(int.MaxValue)]
        public string SourceId { get; set; }

        [MaxLength(int.MaxValue)]
        public string SkillID { get; set; }
    }
}
