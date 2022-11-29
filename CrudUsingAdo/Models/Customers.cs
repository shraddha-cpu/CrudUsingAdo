using System.ComponentModel.DataAnnotations;

namespace CrudUsingAdo.Models
{
    public class Customers  //model/entity / BO(business object
    {
        [Key]
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public String? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public String? Email { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        public string? Contact { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
