using System.ComponentModel.DataAnnotations;

namespace MedicalClinic.DataBase.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required] 
    public string FirstName { get; set; }
    
    [Required] 
    public string LastName { get; set; }
        
    [Required] 
    public string PESEL { get; set; }
    
    public string Gender { get; set; }
        
    [Required] 
    public string Email { get; set; }
        
    [Required] 
    public string City { get; set; }
        
    [Required] 
    public string Street { get; set; }
        
    [Required] 
    public string ZipCode { get; set; }
    

    

}