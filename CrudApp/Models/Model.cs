using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApp.Models
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Le Nom est obligatoire")]
        [Display(Name ="Nom")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        public bool IsEdited { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
