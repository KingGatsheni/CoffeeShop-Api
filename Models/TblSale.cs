using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cs_Api.Models
{
    public partial class TblSale
    {
        public TblSale()
        {
            TblPays = new HashSet<TblPay>();
        }

        [Key]
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public DateTime SoldAt { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }

        [InverseProperty(nameof(TblPay.Sale))]
        public virtual ICollection<TblPay> TblPays { get; set; }
    }
}
