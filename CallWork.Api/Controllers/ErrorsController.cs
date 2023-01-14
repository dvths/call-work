using Microsoft.AspNetCore.Mvc;

namespace CallWork.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}