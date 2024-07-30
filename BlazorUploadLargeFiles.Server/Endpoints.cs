using BlazorUploadLargeFiles.Server.Common.Api;
using BlazorUploadLargeFiles.Server.Uploads.Endpoints;

namespace BlazorUploadLargeFiles.Server
{
    public static class Endpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/upload")
                .MapEndpoint<UploadFiles>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);

            return app;
        }
    }
}
