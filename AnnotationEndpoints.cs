using HtmxDotnet.Pages;

namespace HtmxDotnet;

public static class AnnotationEndpoints
{
    public static void MapAnnotationEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/annotations", async (HttpContext context, Database database) =>
        {
            var annotation = await context.Request.ReadFromJsonAsync<DocumentComment>();
            annotation.Id = Guid.NewGuid();
            Database.Annotations.Add(annotation);
        });

        endpoints.MapDelete("/api/annotations/{id}", async (HttpContext context, Database database) =>
        {
            var id = context.Request.RouteValues["id"]?.ToString();
            var annotation = Database.Annotations.FirstOrDefault(a => a.Id.ToString() == id);
            if (annotation != null)
            {
                Database.Annotations.Remove(annotation);
            }
        });

        endpoints.MapPut("/api/annotations/{id}", async (HttpContext context, Database database) =>
        {
            var id = context.Request.RouteValues["id"]?.ToString();
            var newAnnotation = await context.Request.ReadFromJsonAsync<DocumentComment>();
            var existingAnnotation = Database.Annotations.FindIndex(r => r.AdobeId == id);
            // update existing
            Database.Annotations[existingAnnotation] = newAnnotation;
        });
    }
}