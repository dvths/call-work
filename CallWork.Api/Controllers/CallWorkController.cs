using CallWork.Api.Models;
using CallWork.Api.ServiceErrors;
using CallWork.Api.Services.CallWork;
using CallWork.Contracts.CallWork;

using ErrorOr;

using Microsoft.AspNetCore.Mvc;

namespace CallWork.Api.Controllers;
public class CallWorkController : ApiController
{
    private readonly ICallWorkService _callWorkService;

    public CallWorkController(ICallWorkService callWorkService)
    {
        _callWorkService = callWorkService;
    }

    [HttpPost]
    public IActionResult CreateCall(CreateCallWorkRequest request)
    {
        var requestToCallWorkResult = CallWorkModel.From(request);

        if (requestToCallWorkResult.IsError)
        {
            return Problem(requestToCallWorkResult.Errors);
        }

        var callWork = requestToCallWorkResult.Value;

        var createCallWorkResult = _callWorkService.CreateNewCallWork(callWork);
        return createCallWorkResult.Match(
            created => CreatedAtGetCallWork(callWork),
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetCall(Guid id)
    {
        ErrorOr<CallWorkModel> getCallWorkResult = _callWorkService.GetCallById(id);
        return getCallWorkResult.Match(
            callWork => Ok(MapCallWorkResponse(callWork)),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertCall(Guid id, UpsertCallWorkRequest request)
    {
        var requestCallWorkResult = CallWorkModel.From(id, request);

        if (requestCallWorkResult.IsError)
        {
            return Problem(requestCallWorkResult.Errors);
        }

        var callWork = requestCallWorkResult.Value;
        var upsertCallWorkResult = _callWorkService.UpsertCallWork(callWork);

        return upsertCallWorkResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetCallWork(callWork) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCall(Guid id)
    {
        var deleteCallWorkResult = _callWorkService.DeleteCall(id);

        return deleteCallWorkResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

    // Métodos Privados
    private static CreateCallWorkResponse MapCallWorkResponse(CallWorkModel callWork)
    {
        return new CreateCallWorkResponse(
            callWork.Id,
            callWork.Title,
            callWork.Description,
            callWork.StartDateTime,
            callWork.EndDateTime,
            callWork.LastModifiedDateTime,
            callWork.Subjects,
            callWork.Technologies
        );
    }

    private CreatedAtActionResult CreatedAtGetCallWork(CallWorkModel callWork)
    {
        return CreatedAtAction(
            actionName: nameof(GetCall),
            routeValues: new { id = callWork.Id },
            value: MapCallWorkResponse(callWork));
    }
}