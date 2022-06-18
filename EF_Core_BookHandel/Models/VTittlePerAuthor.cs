using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_BookHandel.Models
{
    [Keyless]
    public partial class VTittlePerAuthor
    {
        [StringLength(101)]
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public int? Tittles { get; set; }
        [StringLength(43)]
        [Unicode(false)]
        public string StockValue { get; set; } = null!;
    }
}
