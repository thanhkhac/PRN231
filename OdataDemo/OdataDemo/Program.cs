using OdataDemo.Data.Entities;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
var products = modelBuilder.EntitySet<Product>("Products");
var categories = modelBuilder.EntitySet<Category>("Categories");
products.EntityType.HasRequired(p => p.Category);
categories.EntityType.HasMany(c => c.Products);
var edmModel = modelBuilder.GetEdmModel();
builder.Services.AddControllers(options =>
    {
        options.RespectBrowserAcceptHeader = true; 
        options.ReturnHttpNotAcceptable = true; 
    })
    .AddOData(option => option
        .Select()
        .Filter()
        .Count()
        .OrderBy()
        .Expand()
        .SetMaxTop(100)
        .AddRouteComponents("odata", edmModel).EnableQueryFeatures())
    .AddXmlDataContractSerializerFormatters(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseODataRouteDebug();

app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.MapControllers();

app.Run();