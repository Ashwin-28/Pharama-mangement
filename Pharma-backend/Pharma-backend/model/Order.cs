using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma_backend.model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }
            = DateTime.Now;

        public string Status { get; set; }
        // Pending / Confirmed / Completed

        public string PrescriptionFilePath { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
