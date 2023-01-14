using CallWork.Api.Models;
using CallWork.Api.ServiceErrors;
using CallWork.Api.Services.CallWork;
using CallWork.Contracts.CallWork;

using ErrorOr;

using Microsoft.AspNetCore.Mvc;

namespace CallWork.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CallWorkController : ControllerBase
{
    private readonly ICallWorkService _callWorkService;

    public CallWorkController(ICallWorkService callWorkService)
    {
        _callWorkService = callWorkService;
    }

    [HttpPost]
    public IActionResult CreateCall(CreateCallWorkRequest request)
    {
        var callWork = new CallWorkModel(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Subjects,
            request.Technologies);

        _callWorkService.CreateNewCallWork(callWork);

        var response = new CreateCallWorkResponse(
            callWork.Id,
            callWork.Title,
            callWork.Description,
            callWork.StartDateTime,
            callWork.EndDateTime,
            callWork.LastModifiedDateTime,
            callWork.Subjects,
            callWork.Technologies
        );

        return CreatedAtAction(
            actionName: nameof(GetCall),
            routeValues: new { id = callWork.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetCall(Guid id)
    {
        ErrorOr<CallWorkModel> getCallWorkResult = _callWorkService.GetCallById(id);

        if (getCallWorkResult.IsError &&
            getCallWorkResult.FirstError == Errors.CallWork.NotFound)
        {
            return NotFound();
        }

        var callWork = getCallWorkResult.Value;

        var response = new CreateCallWorkResponse(
            callWork.Id,
            callWork.Title,
            callWork.Description,
            callWork.StartDateTime,
            callWork.EndDateTime,
            callWork.LastModifiedDateTime,
            callWork.Subjects,
            callWork.Technologies
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertCall(Guid id, UpsertCallWorkRequest request)
    {
        var callWork = new CallWorkModel(
            id,
            request.Title,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Subjects,
            request.Technologies);

        _callWorkService.UpsertCallWork(callWork);

        // TODO retorna 201 se nenhuma callwork tiver sido criada
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCall(Guid id)
    {
        _callWorkService.DeleteCall(id);
        return NoContent();
    }
}