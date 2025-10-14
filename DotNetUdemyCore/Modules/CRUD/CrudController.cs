using DotNetUdemyCore.Modules.CRUD.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DotNetUdemyCore.Modules.CRUD;

[ApiController, Route("crud")]
public class CrudController : ControllerBase
{
    public CrudResponse SumOfTwoNumbers(CrudRequest request)
    {
        return new CrudResponse
        {
            Message = $"Sum of two numbers is: {request.Number1 + request.Number2}"
        };
    }
}