using System.ComponentModel.DataAnnotations;
namespace jayassignment3.Models;

public class UserViewModel  
{
    [Key]  
    public int Id {get; set;}
    [Required]
    public String email {get; set;}
    [Required]
    public String password {get; set;}

    public String username  {get; set;}

    public String? purchaseHistory {get; set;}
    
    public String? shippingAdd {get; set;}
}
