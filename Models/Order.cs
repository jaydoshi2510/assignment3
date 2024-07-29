using System.ComponentModel.DataAnnotations;
namespace jayassignment3.Models;

public class OrderViewModel 
{
    [Key] 
    public int Id {get; set;}

    [Required]
    public String productId {get; set;}

    [Required]
    public String userId  {get; set;}

    [Required]
    public String orderDate {get; set;}
    
    [Required]
    public String quantity {get; set;}
}
