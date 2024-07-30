using BlazorUploadLargeFiles.Server.Common.Api;
using BlazorUploadLargeFiles.Server.Common.Filters;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorUploadLargeFiles.Server.Uploads.Endpoints;

public class UploadFiles : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapPost("/", Handle);
        //.AddEndpointFilter<RequestValidationFilter<Request>>();

    public record Request();

    //public class RequestValidator : AbstractValidator<Request>
    //{
    //    public RequestValidator()
    //    {
    //        RuleFor(x => x.Id).GreaterThan(0);
    //    }
    //}

    public record Response(
    );

    private static async Task<Ok> Handle([FromForm] IEnumerable<IFormFile> files, /*AppDbContext database,*/ CancellationToken cancellationToken)
    {
        foreach (var formFile in files)
        {
            if (formFile.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using var stream = File.Create(filePath);
                await formFile.CopyToAsync(stream, cancellationToken);
            }
        }

        return TypedResults.Ok();
    }
}
