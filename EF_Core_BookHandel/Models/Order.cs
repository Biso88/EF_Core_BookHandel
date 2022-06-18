using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_BookHandel.Models
{
    public partial class Order
    {
        public Order()
        {
            Stores = new HashSet<Store>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int CustomersId { get; set; }
        [Column("ISBN13")]
        public long Isbn13 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Customer.Order))]
        public virtual Customer IdNavigation { get; set; } = null!;
        [ForeignKey(nameof(Isbn13))]
        [InverseProperty(nameof(Book.Orders))]
        public virtual Book Isbn13Navigation { get; set; } = null!;
        [InverseProperty(nameof(Store.Orders))]
        public virtual ICollection<Store> Stores { get; set; }
    }
}
