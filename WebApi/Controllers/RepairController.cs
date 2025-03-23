using Microsoft.AspNetCore.Mvc;
using Services;
using DAL.Dto;
using WebApi.ViewModels;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RepairController(IRepairsService repairServices) : ControllerBase
{
    [HttpGet]
    public IActionResult GetRepairDateWithCost([FromQuery] RepairRequest repairRequest)
    {
        List<RepairResponse> repairs = repairServices.GetRepairDateWithCost(repairRequest);
        List<MasterPercentageResponse> masterPercentageResponses = repairServices.GetMasterPercentage(repairRequest);

        RepairReplyModel repairReply = new (repairs, masterPercentageResponses);

        return Ok(repairReply);
    }
}
