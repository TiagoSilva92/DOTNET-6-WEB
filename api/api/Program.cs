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

app.MapGet("/", () => "Hello World!");
app.MapPost("/", () => new {Name = "Tiago Melo", Age = 31});
app.MapGet("/AddHeader", (HttpResponse response) => { 
    response.Headers.Add("Teste", "Tiago Melo");
    return new { Name = "Tiago Melo", Age = 31};
});


app.MapPost("/saveproduct", (Product product) => {
    return product.Code + " - " + product.Name;
});

app.MapGet("/", () => "Hello World!");

app.Run();


public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}