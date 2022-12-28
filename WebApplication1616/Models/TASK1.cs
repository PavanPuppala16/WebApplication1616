using System.ComponentModel.DataAnnotations;

namespace WebApplication1616.Models
{
    public class TASK1
    {

        public int RefId { get; set; }
        [Required(ErrorMessage = "what's Ur name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }
        [Required(ErrorMessage = "what's Ur name")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Emailid { get; set; }
        [Required(ErrorMessage = "what's Ur name")]
        [RegularExpression(@"^((?=.[a-z])(?=.[A-Z])(?=.*\d)).+$", ErrorMessage = "incorrect password Format")]
        public string password { get; set; }
        [Required(ErrorMessage = "Choose your gender")]

        public string Gender { get; set; }
        [Required(ErrorMessage = "Choose your department")]
        public string Department { get; set; }

        public string collegename { get; set; }
        [Required(ErrorMessage = "Choose your University")]
        public string University { get; set; }
        [Required(ErrorMessage = "Choose location")]
        public string location { get; set; }
    }

}