using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace cs_Api.Models
{
    public partial class TblProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string CoffeeType { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CoffeePrice { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
