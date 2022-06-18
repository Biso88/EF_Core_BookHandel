using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_BookHandel.Models
{
    public partial class Book
    {
        public Book()
        {
            Orders = new HashSet<Order>();
            StoresBalances = new HashSet<StoresBalance>();
        }

        [Key]
        [Column("ISBN13")]
        public long Isbn13 { get; set; }
        public int AuthorsId { get; set; }
        [StringLength(50)]
        public string Tittle { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PublicationDate { get; set; }

        [InverseProperty(nameof(Order.Isbn13Navigation))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(StoresBalance.Isbn13Navigation))]
        public virtual ICollection<StoresBalance> StoresBalances { get; set; }
    }
}
