using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace DataAccess.Model
{
    public class UserDetails
    {
        [Key]
        public int UserId{  get; set; }
        [NotNull]
        [StringLength(50)]
        //[Index(IsUnique =true)]
        public string User_First_Name {  get; set; }
        [StringLength(50)]
        public string User_Last_Name { get; set; }
        [StringLength(50)]
        public string User_EmailId { get; set; }
        [StringLength(50)]
        public string User_Password { get; set;}
    }
}
