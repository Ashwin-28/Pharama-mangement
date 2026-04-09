using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma_backend.model
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Dosage { get; set; }

        public string Packaging { get; set; }

        public int StockQuantity { get; set; }

        public bool RequiresPrescription { get; set; }
    }
}
