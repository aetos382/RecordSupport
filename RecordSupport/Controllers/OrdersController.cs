using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

using RecordSupport.Models;

namespace RecordSupport.Controllers;

public class OrdersController :
    ODataController
{
    [EnableQuery]
    public ActionResult<IQueryable<Order>> Get()
    {
        var entities = new Order[]
        {
            new("1", "O")
        };

        return this.Ok(entities.AsQueryable());
    }

    [HttpPost]
    [EnableQuery]
    public IActionResult Post(
        [FromBody] Order order)
    {
        // This method is called, but `order` is always `null`.
        if (order is null)
        {
            return this.BadRequest();
        }

        return this.Ok();
    }
}