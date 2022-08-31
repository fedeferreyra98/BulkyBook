using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]  //Data Annotation to set SQL attributes
        public int Id { get; set; }
        [Required] //This means the name cannot be null
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now; // This will assign that value after any new instance of Category.



    }
}
