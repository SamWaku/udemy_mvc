using Microsoft.AspNetCore.Mvc;

namespace DotNetUdemyCore.Modules.CRUD;

[ApiController, Route("crud")]
public class CrudController : ControllerBase
{
    public Task<IActionResult> SumOfTwoNumbers([FromBody] int number1, int number)
    {
        return Ok();
    }
}