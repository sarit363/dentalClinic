using dental_clinic.Middleware;
using Microsoft.AspNetCore.Builder;

namespace dental_clinic
{
    public static class Extensions
    {
        public static IApplicationBuilder UseLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TrackMiddleware>();
        }
    }
}
