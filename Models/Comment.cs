using System.ComponentModel.DataAnnotations;
namespace jayassignment3.Models;

public class CommentViewModel 
{
    [Key] 
    public int Id {get; set;}
    [Required]
    public String productId {get; set;}
    [Required]
    public String comment {get; set;}
    [Required]
    public String userId {get; set;}
    public String? rating  {get; set;}
    public String? images {get; set;}   
}
