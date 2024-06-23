namespace CampaignProj.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Template { get; set; }
        public string Condition { get; set; }
        public DateTime Time { get; set; }
        public int Priority { get; set; }
    }
}
