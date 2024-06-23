namespace CampaignProj.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public double Deposit { get; set; }
        public bool IsNewCustomer { get; set; }
    }
}
