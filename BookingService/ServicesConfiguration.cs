using BookingService.API.Auth;
using BookingService.API.Ride.Requests;
using BookingService.API.User.Requests;
using BookingService.API.Validators;
using BookingService.Application.Services.Interfaces;
using BookingService.Application.Services;
using BookingService.Domain.Repositories;
using BookingService.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using BookingService.API.Profiles;
using BookingService.Application.Profiles;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace BookingService.API
{
    public static class ServicesConfiguration
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Database services
            services.AddDbContext<BookingServiceContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRideService, RideService>();
            services.AddScoped<IRouteApiService, RouteApiService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddHttpClient<IRouteApiService, RouteApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["RouteApiServiceBaseUrl"]);
            });

            // Add mapping services 
            services.AddAutoMapper(typeof(BookRideRequestToRideDto), typeof(RideDtoToRoute));

            // Add FluentValidation services
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
            services.AddScoped<IValidator<UpdateUserRequest>, UpdateUserRequestValidator>();
            services.AddScoped<IValidator<GetAvailableRoutesRequest>, GetAvailableRoutesRequestValidator>();
            services.AddScoped<IValidator<BookRideRequest>, BookRideRequestValidator>();
            services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BookingService",
                    Description = "BookingService Web Api"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationScheme = JwtBearerDefaults.AuthenticationScheme;

            // Check if authentication scheme is already added
            if (services.Any(x => x.ImplementationType?.FullName == typeof(JwtBearerHandler).FullName))
            {
                return;
            }

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = authenticationScheme;
                opt.DefaultChallengeScheme = authenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidAudience = configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
        }
    }
}