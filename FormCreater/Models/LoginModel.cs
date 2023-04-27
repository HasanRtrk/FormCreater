using System.ComponentModel.DataAnnotations;

namespace FormCreater.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
