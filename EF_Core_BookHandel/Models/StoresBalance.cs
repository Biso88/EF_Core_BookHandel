using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_BookHandel.Models
{
    [Table("StoresBalance")]
    public partial class StoresBalance
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int StoreId { get; set; }
        [Column("ISBN13")]
        public long Isbn13 { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(Isbn13))]
        [InverseProperty(nameof(Book.StoresBalances))]
        public virtual Book Isbn13Navigation { get; set; } = null!;
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("StoresBalances")]
        public virtual Store Store { get; set; } = null!;
    }
}
