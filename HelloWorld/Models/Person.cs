using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required] public string? Email { get; set; }

        [Required] public string? Name { get; set; }

        [Required] public string? Password { get; set; }

        public int Age { get; set; } = 0;
    }  
}
