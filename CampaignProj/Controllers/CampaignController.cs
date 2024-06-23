using CampaignProj.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampaignProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly CampaignService _campaignService;

        public CampaignController(CampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpPost("schedule")]
        public IActionResult ScheduleCampaigns()
        {
            _campaignService.ScheduleCampaigns();
            return Ok("Campaigns scheduled");
        }
    }
}
