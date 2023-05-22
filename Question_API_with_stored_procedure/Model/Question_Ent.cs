using System.ComponentModel.DataAnnotations;

namespace Question_API_with_stored_procedure.Model
{
    public class Question_Ent
    {
        [Key]
        public int Id { get; set; } = 0; 
        [StringLength(300)]
        public string Question { get; set; } = "";
        [StringLength(255)]
        public string Option1 { get; set; } = "";
        [StringLength(255)]
        public string Option2 { get; set; } = "";
        [StringLength(255)]
        public string Option3 { get; set; } = "";
        [StringLength(255)]
        public string Option4 { get; set; } = "";
        [StringLength(255)]
        public string Answer { get; set; } = "";
        [StringLength(255)]
        public string Action { get; set; } = "";
    }
}
