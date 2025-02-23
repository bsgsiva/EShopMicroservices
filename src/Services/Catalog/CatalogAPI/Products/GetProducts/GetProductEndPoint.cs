﻿
namespace CatalogAPI.Products.GetProducts
{
    public record GetProductsRequest();

    public record GetProductsResponse(IEnumerable<Product> products);
    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            }) .WithName("GetProduct")
               .Produces<GetProductsResponse>(StatusCodes.Status200OK)
               .ProducesProblem(StatusCodes.Status400BadRequest)
               .WithSummary("Get Products")
               .WithDescription("Get Product");
        }       
                
    }
}
