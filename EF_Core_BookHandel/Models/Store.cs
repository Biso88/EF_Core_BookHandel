using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_BookHandel.Models
{
    public partial class Store
    {
        public Store()
        {
            StoresBalances = new HashSet<StoresBalance>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string StoresName { get; set; } = null!;
        [StringLength(100)]
        public string StoresWebsite { get; set; } = null!;
        public int? OrdersId { get; set; }

        [ForeignKey(nameof(OrdersId))]
        [InverseProperty(nameof(Order.Stores))]
        public virtual Order? Orders { get; set; }
        [InverseProperty(nameof(StoresBalance.Store))]
        public virtual ICollection<StoresBalance> StoresBalances { get; set; }
    }
}
