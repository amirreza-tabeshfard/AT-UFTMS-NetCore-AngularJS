namespace AT.UFTMS.WebAPI.Api.DependencyInjection;
public static class ApiServiceRegistration
{
    public static IServiceCollection AddApi(this IServiceCollection services,
                                            IConfiguration configuration)
    {
        // ---------- Infrastructure for Api ----------
        services.AddHttpContextAccessor();
        services.AddHostedService<BackgroundServices.OutboxBackgroundService>();

        // ---------- Application ----------
        services.AddScoped<Application.Abstractions.Services.ICurrentUserService, Authentication.CurrentUserService>();
        services.AddScoped<Application.Abstractions.Authorization.IAuthorizationService, Authorization.ApiAuthorizationService>();
        services.AddScoped<Application.Abstractions.Services.IAuthService, Authentication.JwtAuthService>();

        services.AddControllers(options =>
        {
            options.Filters.Add<Filters.GlobalExceptionFilter>();
        });

        // ---------- JWT Options ----------
        Authentication.JwtOptions jwtOptions = configuration
                                               .GetSection("JwtOptions")
                                               .Get<Authentication.JwtOptions>()!;

        services.AddSingleton(jwtOptions);

        return services;
    }
}