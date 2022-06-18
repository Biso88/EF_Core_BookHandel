using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_BookHandel.Models
{
    [Keyless]
    public partial class AuthorsBook
    {
        public int AuthorsId { get; set; }
        [Column("ISBN13")]
        public long Isbn13 { get; set; }

        [ForeignKey(nameof(AuthorsId))]
        public virtual Author Authors { get; set; } = null!;
        [ForeignKey(nameof(Isbn13))]
        public virtual Book Isbn13Navigation { get; set; } = null!;
    }
}
