using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;

using RecordSupport.Models;

namespace RecordSupport.Controllers;

[ApiController]
[Route("api/Customers")]
[ODataAttributeRouting]
public class CustomersController :
    ControllerBase
{
    [HttpGet]
    [EnableQuery]
    public ActionResult<IQueryable<Customer>> Get()
    {
        var entities = new Customer[]
        {
            new("1", "C")
        };

        return this.Ok(entities.AsQueryable());
    }

    [HttpPost]
    [EnableQuery]
    public IActionResult Post(
        [FromBody] Customer customer)
    {
        // This method is never called.
        if (customer is null)
        {
            return this.BadRequest();
        }

        return this.Ok();
    }
}