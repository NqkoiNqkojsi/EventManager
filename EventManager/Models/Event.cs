using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventManager.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public DateTime PremiereDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
