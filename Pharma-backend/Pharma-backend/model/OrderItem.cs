using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma_backend.model
{
    public class OrderItem
    {
       
            [Key]
            public int OrderItemId { get; set; }

            public int OrderId { get; set; }

            public int MedicineId { get; set; }

            public int Quantity { get; set; }

            public decimal Price { get; set; }

            [ForeignKey("OrderId")]
            public virtual Order Order { get; set; }

            [ForeignKey("MedicineId")]
            public virtual Medicine Medicine { get; set; }
        }
    }

