using Microsoft.AspNetCore.Mvc;

using RecordSupport.Models;

namespace RecordSupport.Controllers;

[ApiController]
[Route("api/Products")]
public class ProductsController :
    ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        var entities = new Product[]
        {
            new("1", "P")
        };

        return this.Ok(entities);
    }

    [HttpPost]
    public IActionResult Post(
        [FromBody] Product product)
    {
        // This method is called, and `product` is deserialized correctly.
        if (product is null)
        {
            return this.BadRequest();
        }

        return this.Ok();
    }

}