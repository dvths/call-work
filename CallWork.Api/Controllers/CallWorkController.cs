using CallWork.Contracts.CallWork;

using Microsoft.AspNetCore.Mvc;

namespace CallWork.Api.Controllers;

[ApiController]
public class CallWorkController: ControllerBase
{
    [HttpPost("/callwork")]
    public IActionResult CreateCall(CreateCallWorkRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/callwork/{id:guid}")]
    public IActionResult GetCall(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/callwork/{id:guid}")]
    public IActionResult UpsertCall(Guid id, UpsertCallWorkRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/callwork/{id:guid}")]
    public IActionResult DeleteCall(Guid id)
    {
        return Ok(id);
    }
}