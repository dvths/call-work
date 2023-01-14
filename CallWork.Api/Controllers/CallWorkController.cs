using CallWork.Api.Models;
using CallWork.Api.Services.CallWork;
using CallWork.Contracts.CallWork;

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
        var callwork = new CallWorkModel(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Subjects,
            request.Technologies);

        // TODO salvar no banco de dados
        _callWorkService.CreateNewCallWork(callwork);

        var response = new CreateCallWorkResponse(
            callwork.Id,
            callwork.Title,
            callwork.Description,
            callwork.StartDateTime,
            callwork.EndDateTime,
            callwork.LastModifiedDateTime,
            callwork.Subjects,
            callwork.Technologies
        );

        return CreatedAtAction(
            actionName: nameof(GetCall),
            routeValues: new { id = callwork.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetCall(Guid id)
    {
        CallWorkModel callwork = _callWorkService.GetCallById(id);

        var response = new CreateCallWorkResponse(
            callwork.Id,
            callwork.Title,
            callwork.Description,
            callwork.StartDateTime,
            callwork.EndDateTime,
            callwork.LastModifiedDateTime,
            callwork.Subjects,
            callwork.Technologies
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertCall(Guid id, UpsertCallWorkRequest request)
    {
        var callwork = new CallWorkModel(
            id,
            request.Title,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Subjects,
            request.Technologies);

        _callWorkService.UpsertCallWork(callwork);

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