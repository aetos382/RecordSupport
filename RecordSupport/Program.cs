using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

using RecordSupport.Models;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddControllers()
    .AddOData(static options =>
    {
        options.EnableQueryFeatures();

        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntitySet<Order>("Orders");
        modelBuilder.EntitySet<Customer>("Customers");

        var model = modelBuilder.GetEdmModel();

        options.AddRouteComponents("api", model);
    });

var app = builder.Build();

app.UseODataRouteDebug();
app.UseRouting();
app.MapControllers();

app.Run();
