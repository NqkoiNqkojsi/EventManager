using System.ComponentModel.DataAnnotations;
namespace EventManager.Models
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; }
        public int EventID { get; set; }
        public string UserID { get; set; }
    }
}
