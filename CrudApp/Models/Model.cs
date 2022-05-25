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

        [Required(ErrorMessage = "La description est obligatoire")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
