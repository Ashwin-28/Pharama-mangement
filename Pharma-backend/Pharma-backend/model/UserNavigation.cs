namespace Pharma_backend.model
{
    public class UserNavigation
    {
        
            public virtual ICollection<Order> Orders { get; set; }
                = new List<Order>();
        }
    }

