using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
 
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name ="Form Adı")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter içermelidir.")]
        public string FormName { get; set; }
        [Display(Name = "Açıklama")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter içermelidir.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [MaxLength(25, ErrorMessage = "Maksimum 25 karakter içermelidir.")]
        public string FirstColumn { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [MaxLength(25, ErrorMessage = "Maksimum 25 karakter içermelidir.")]
        public string SecondColumn { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [MaxLength(25, ErrorMessage = "Maksimum 25 karakter içermelidir.")]
        public string ThirdColumn { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UserId { get; set; }
    }
    }
