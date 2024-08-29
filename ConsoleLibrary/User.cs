using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace ConsoleLibrary;

public class User
{
    public string Name { get; set; }
    public int PhoneNumber { get; set; }
    [Key]
    public Guid UserID { get; set; }
}