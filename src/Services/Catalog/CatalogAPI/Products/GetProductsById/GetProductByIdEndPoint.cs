﻿
using CatalogAPI.Products.GetProducts;

namespace CatalogAPI.Products.GetProductsById
{
    public record GetProductByIdResponse(Product Product);

    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);

            }).WithName("GetProductById")
               .Produces<GetProductsResponse>(StatusCodes.Status200OK)
               .ProducesProblem(StatusCodes.Status400BadRequest)
               .WithSummary("Get Product Ny Id")
               .WithDescription("Get Product By Id");
        }
    }
}
 
