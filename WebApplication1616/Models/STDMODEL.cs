
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1616.Models
{
    public class STDMODEL
    {
        public int REFID { get; set; }

        [Required(ErrorMessage = "Rollno is required*")]
        public string rollno { get; set; }

        [Required(ErrorMessage = "What's ur Name*")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string name { get; set; }

        [Required(ErrorMessage = "Email is required*")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Emailid { get; set; }


        [Required(ErrorMessage = "Please enter password*")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Select DOB*")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Select option*")]
        public string GENDER { get; set; }

        [Required(ErrorMessage = "Mobile is required*")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string MOBILE { get; set; }

        [Required(ErrorMessage = "Fee is required*")]
        [Range(typeof(int), "1000", "20000", ErrorMessage = "Fee can only be between 1000 and 20000")]
        public int FEE { get; set; }

        [Required(ErrorMessage = "Select role*")]
        public string Role { get; set; }



        [Required(ErrorMessage = "Select Branch*")]
        public string BRANCH { get; set; }
        public bool Status { get; set; }
    }
}

public class ForgetPasswordModel
{
  

    [Required(ErrorMessage = "Email is required*")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
    public string Emailid { get; set; }


    [Required(ErrorMessage = "Please enter password*")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
    public string Password { get; set; }

}
    public class STDMODELlogin
{
    [Required(ErrorMessage = "Email is required*")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
    public string emailid { get; set; }


    [Required(ErrorMessage = "Please enter password*")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
    public string password { get; set; }
}