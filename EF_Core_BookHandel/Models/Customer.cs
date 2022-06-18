using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_BookHandel.Models
{
    public partial class Customer
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CustomerFN")]
        [StringLength(50)]
        public string CustomerFn { get; set; } = null!;
        [Column("CustomerLN")]
        [StringLength(50)]
        public string CustomerLn { get; set; } = null!;
        public int? CustomerPhone { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual Order Order { get; set; } = null!;
    }
}
