using DotNetUdemyCore.Modules.CRUD.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DotNetUdemyCore.Modules.CRUD;

[ApiController, Route("crud")]
public class CrudController : ControllerBase
{
    public Task<int> SumOfTwoNumbers(CrudRequest request)
    {
        return new request.Number1 + request.Number2;
    }
}