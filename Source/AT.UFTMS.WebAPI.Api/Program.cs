using AT.UFTMS.WebAPI.Api.DependencyInjection;
using AT.UFTMS.WebAPI.Application.DependencyInjection;
using AT.UFTMS.WebAPI.Infrastructure.DependencyInjection;
// ==================================================================================================
// Builder
// ==================================================================================================
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Service Registration (Framework)

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.ParameterLocation.Header,
        Description = "Enter your JWT token"
    });
});

#endregion

#region Service Registration (Application Layers)

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddApi(builder.Configuration);

#endregion

#region Service Registration (Authentication - JWT)

AT.UFTMS.WebAPI.Api.Authentication.JwtOptions jwtOptions = builder.Configuration
                                                           .GetSection("JwtOptions")
                                                           .Get<AT.UFTMS.WebAPI.Api.Authentication.JwtOptions>()!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),

        NameClaimType = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub
    };
});

#endregion

// ==================================================================================================
// Build
// ==================================================================================================
WebApplication app = builder.Build();

#region Middleware (Development)

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#endregion

#region Middleware (HTTP Pipeline)

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

#endregion

// ==================================================================================================
// Run
// ==================================================================================================
app.Run();