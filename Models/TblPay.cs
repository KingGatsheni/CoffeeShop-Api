using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cs_Api.Models
{
    [Index(nameof(SaleId), Name = "IX_TblPays_SaleId")]
    public partial class TblPay
    {
        [Key]
        public int PayId { get; set; }
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalesTotal { get; set; }

        [ForeignKey(nameof(SaleId))]
        [InverseProperty(nameof(TblSale.TblPays))]
        public virtual TblSale Sale { get; set; }
    }
}
