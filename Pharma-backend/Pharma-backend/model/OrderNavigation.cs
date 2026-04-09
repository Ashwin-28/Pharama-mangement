namespace Pharma_backend.model
{
    public class OrderNavigation
    {
        
            public virtual ICollection<OrderItem> OrderItems { get; set; }
                = new List<OrderItem>();
        }
    }

