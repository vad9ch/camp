using CampaignProj.Models;

namespace CampaignProj.Services
{
    public class CampaignService
    {
        private readonly CampaignDbContext _context;
        private readonly CustomerService _customerService;
        private Dictionary<int, List<DateTime>> _customerSendLog;

        public CampaignService(CampaignDbContext context, CustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
            _customerSendLog = new Dictionary<int, List<DateTime>>();
        }

        public void ScheduleCampaigns()
        {
            var campaigns = _context.Campaigns.OrderBy(c => c.Time).ToList();
            foreach (var campaign in campaigns)
            {
                var delay = campaign.Time - DateTime.Now;
                if (delay.TotalMilliseconds > 0)
                {
                    Task.Delay(delay).ContinueWith(_ => SendCampaign(campaign));
                }
            }
        }

        public void SendCampaign(Campaign campaign)
        {
            Func<Customer, bool> condition = GetConditionFunc(campaign.Condition);
            var customers = _customerService.GetCustomers(condition);
            foreach (var customer in customers)
            {
                if (!_customerSendLog.ContainsKey(customer.Id))
                {
                    _customerSendLog[customer.Id] = new List<DateTime>();
                }

                if (!_customerSendLog[customer.Id].Any(date => date.Date == DateTime.Today))
                {
                    _customerSendLog[customer.Id].Add(DateTime.Now);
                    // Simulate sending the campaign by writing to a file
                    System.IO.File.AppendAllText($"sends_{DateTime.Today:yyyyMMdd}.txt", $"Sent {campaign.Template} to {customer.Id} at {DateTime.Now}\n");
                }
            }
        }

        private Func<Customer, bool> GetConditionFunc(string condition)
        {
            return condition switch
            {
                "Male" => c => c.Gender == "Male",
                "Age > 45" => c => c.Age > 45,
                "Location = 'New York'" => c => c.Location == "New York",
                "Deposit > 100" => c => c.Deposit > 100,
                "IsNewCustomer" => c => c.IsNewCustomer,
                _ => throw new ArgumentException("Invalid condition")
            };
        }
    }
}
