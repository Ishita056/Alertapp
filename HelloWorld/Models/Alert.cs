using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class Alert
    {
        [Key]public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ExpDate { get; set; }
        public string? Link { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
