using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Curate.AI.Models
{
    public class Site
    {
        [Required]
        [DisplayName("Upload Image")]
        public IFormFile Image{ get; set; }
    }
}
