using System.ComponentModel.DataAnnotations;
namespace jayassignment3.Models;

public class ProductViewModel  
{
    [Key] 
    public int Id {get; set;}
    [Required]
    public String description {get; set;}
    public String? image {get; set;}
    [Required]
    public String price  {get; set;}
    [Required]
    public String quantity {get; set;}
}
