using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CurateAI.Models
{
    public class UserDetails
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [NotNull]
        [StringLength(50)]
        // [Index(IsUnique =true)]
        [Required]
        [DisplayName("First Name")]
        public string User_First_Name { get; set; }
        [StringLength(50)]
        [Required]
        [DisplayName("Last Name")]
        public string User_Last_Name { get; set; }
        [StringLength(50)]
        [Required]
        [DisplayName("Email Id")]
        [DataType(DataType.EmailAddress)]
        public string User_EmailId { get; set; }
        [StringLength(50)]
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string User_Password { get; set; }
    }
}
