using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Persons", Schema = "dbo")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "UserPassword")]
        public string UserPassword { get; set; }
        [Required]
        [Display(Name = "UserEmail")]
        public string UserEmail { get; set; }
        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
