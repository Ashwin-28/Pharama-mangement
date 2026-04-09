namespace Pharma_backend.model
{
    public class MedicineNavigation
    {
        
            public virtual ICollection<OrderItem> OrderItems { get; set; }
                = new List<OrderItem>();
        }
    }
