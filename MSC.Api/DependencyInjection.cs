using MSC.Api.Common.Mapping;
using MSC.Api.Controllers;

namespace MSC.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.ConfigureProblemDetails();
        services.AddMappings();

        return services;
    }

    public static IServiceCollection ConfigureProblemDetails(this IServiceCollection services)
    {
        services.Configure<ProblemDetailsOptions>(
            options => options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions
                    .Add("errorCodes", ApiController.GetErrors().Select(e => e.Code));
            }
        );

        return services;
    }
}