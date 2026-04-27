using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    [NotMapped]
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
