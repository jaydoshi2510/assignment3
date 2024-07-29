using System.ComponentModel.DataAnnotations;
namespace jayassignment3.Models;

public class CartViewModel 
{
    [Key] 
    public int Id {get; set;}
    [Required]
    public String productId {get; set;}
    [Required]
    public String userId  {get; set;}

    public String? quantity {get; set;}
}
