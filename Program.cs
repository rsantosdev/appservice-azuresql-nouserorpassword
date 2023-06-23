using Dapper;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/categories", async (IConfiguration configuration) =>
{
    await using var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
    var categories = await sqlConnection.QueryAsync<ProductCategory>("select * from SalesLT.ProductCategory");
    return categories;
});

app.Run();

internal class ProductCategory
{
    public int ProductCategoryId { get; set; }
    public string Name { get; set; }
    public Guid RowGuid { get; set; }
    public DateTime ModifiedDate { get; set; }
}
