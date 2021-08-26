using System.ComponentModel.DataAnnotations;

namespace Pokemon.Data.Interfaces
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
