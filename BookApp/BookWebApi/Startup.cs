using ApiBase.Models;
using ApiBusiness;
using ApiBusiness.Business;
using ApiBusiness.Business.Master;
using ApiBusiness.Context;
using BookWebApi.ActionFilter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace BookWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //get config json
            IConfiguration jwtSettingConf = this.Configuration.GetSection("JwtSetting");
            services.Configure<JwtSettingModel>(jwtSettingConf);
            JwtSettingModel jwtSetting = jwtSettingConf.Get<JwtSettingModel>();
            byte[] jwtKey = Encoding.ASCII.GetBytes(jwtSetting.Secret);

            //Token Claimer validation
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                //Security key for signature
                IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
                ValidateIssuerSigningKey = true,
                //validaete time token validate exp at time set
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true,
                //validate recipient token is aithorize to receive
                ValidateAudience = false,
                //validate server that generate token
                ValidateIssuer = false
            };
            //chelenging schema auth
            services.AddAuthentication
                (
                    x =>
                    {
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    }
                )
            .AddJwtBearer(x =>
            {
                //save to properties
                x.SaveToken = true;
                //token validation accept
                x.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET Core 3.1 Web API",
                    Description = "Authentication and Authorization in ASP.NET Core 3.1 with JWT and Swagger"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            new string[] {}

                    }
                });
            });
            services.AddCors();

            services.AddApiVersioning(s =>
            {
                s.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
                s.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddDbContext<BookDbContext>
                (
                    options=> options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"))
                );

            //Depedency Injection
            services.AddSingleton(tokenValidationParameters);
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            services.AddScoped<AuthenticationManager>();
            services.AddScoped<BusinessUser>();
            services.AddScoped<BusinessItemCategory>();
            services.AddControllers(opt =>
            {
                opt.Filters.Add<ContextActionFilterAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseForwardedHeaders();
            app.UseHttpsRedirection();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            //Route tree should be
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
