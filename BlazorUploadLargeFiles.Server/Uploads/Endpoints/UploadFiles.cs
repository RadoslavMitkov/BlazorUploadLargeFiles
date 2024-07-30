using BlazorUploadLargeFiles.Server.Common.Api;
using BlazorUploadLargeFiles.Server.Common.Filters;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorUploadLargeFiles.Server.Uploads.Endpoints
{
    public class UploadFiles : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app
            .MapPost("/{id}", Handle)
            .AddEndpointFilter<RequestValidationFilter<Request>>();

        public record Request(int Id);

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(x => x.Id).GreaterThan(0);
            }
        }

        public record Response(
        );

        private static async Task<Results<Ok<Response>, NotFound>> Handle([AsParameters] Request request, /*AppDbContext database,*/ CancellationToken cancellationToken)
        {
            return TypedResults.Ok(new Response());
        }
    }
}
