using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.MapPost("/saveproduct", (Product product) => {
    ProductRepository.Add(product);
});

app.MapGet("/getproduct/{code}", ([FromRoute] string code) =>
{
    var product = ProductRepository.GetBy(code);
    return product;
});

app.MapPut("/editproduct", (Product product) =>
{
    var productSaved = ProductRepository.GetBy(product.Code);
    productSaved.Name = product.Name;   
});

app.Run();

public static class ProductRepository
{
    public static List<Product> Products { get; set; }

    public static void Add(Product product)
    {
        if(Products == null)
            Products = new List<Product>();

        Products.Add(product);
    }

    public static Product GetBy(string code)
    {
        return Products.FirstOrDefault(p => p.Code == code);
    }
}

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}