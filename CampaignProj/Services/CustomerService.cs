using CampaignProj.Models;

namespace CampaignProj.Services
{
    public class CustomerService
    {
        private readonly CampaignDbContext _context;

        public CustomerService(CampaignDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomers(Func<Customer, bool> condition)
        {
            return _context.Customers.Where(condition).ToList();
        }
    }
}
