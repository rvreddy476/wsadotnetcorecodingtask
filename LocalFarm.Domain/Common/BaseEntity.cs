using System.ComponentModel.DataAnnotations;

namespace LocalFarm.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }        
    }
}
